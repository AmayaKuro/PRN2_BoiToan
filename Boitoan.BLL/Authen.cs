using MongoDB.Driver;
using Boitoan.DAL.Entities;
using Boitoan.DAL.Models;
using BCrypt.Net;
using Boitoan.DAL.Repositories;

namespace SPTS_Writer.Services
{
    public class Authen
    {
        private readonly UserRepository _userRepository;

        public Authen(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Login(LoginRequest loginRequest)
        {
            var user = await _userRepository.GetByEmailAsync(loginRequest.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            {
                throw new Exception("User not exists or password incorrect");
            }
            return user;
        }

        public async Task<User> Register(RegisterRequest registerRequest)
        {
            // Check if user already exists
            var user = await _userRepository.GetByEmailAsync(registerRequest.Email);
            if (user != null)
            {
                throw new Exception("Email already exists");
            }

            // Hash the password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);

            // Create new user
            user = new User
            {
                Name = registerRequest.Name,
                Email = registerRequest.Email,
                PhoneNumber = registerRequest.PhoneNumber,
                Password = hashedPassword
            };

            await _userRepository.AddAsync(user);

            return user;
        }
    }
}
