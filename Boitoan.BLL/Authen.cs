using BCrypt.Net;
using Boitoan.BLL;
using Boitoan.BLL.Abstraction;
using Boitoan.DAL.Entities;
using Boitoan.DAL.Models;
using Boitoan.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using System.Net.Http;
using System.Security.Claims;

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
                throw new Exception("Email hoặc Mật khẩu không đúng");
            }
            new Claim(ClaimTypes.Sid, user.Id ?? string.Empty);
            return user;
        }

        public async Task<User> Register(RegisterRequest registerRequest)
        {
            // Check if user already exists
            var user = await _userRepository.GetByEmailAsync(registerRequest.Email);
            if (user != null)
            {
                throw new Exception("Email này đã tồn tại");
            }

            // Hash the password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);

            // Create new user
            user = new User
            {
                Name = registerRequest.Name,
                Email = registerRequest.Email,
                PhoneNumber = registerRequest.PhoneNumber,
                Password = hashedPassword,
                Role = "Admin"
			};

            await _userRepository.AddAsync(user);

            return user;
        }

		public async Task<User> GetOrCreateGoogleAccountAsync(string email, string name)
		{
			var account = await _userRepository.GetByEmailAsync(email);

			if (account != null)
			{
				return account; // Trả về nếu đã có
			}

			account = new User
			{
				Email = email,
				Name = name,
				Role = "USER",
				PhoneNumber = string.Empty,
				Password = string.Empty
			};

			await _userRepository.AddAsync(account);

			return account;
		}
	}
}
