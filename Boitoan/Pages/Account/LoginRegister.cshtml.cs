using Boitoan.BLL;
using Boitoan.BLL.Abstraction;
using Boitoan.DAL.Entities;
using Boitoan.DAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPTS_Writer.Services;
using System.Security.Claims;

namespace Boitoan.Pages.Account
{
    public class LoginRegisterModel : PageModel
    {
        private readonly Authen _authenService; 
		private readonly UserService _userService;
		public LoginRegisterModel(Authen authenService, UserService userService)
        {
            _authenService = authenService;
			_userService = userService;
		}
		[BindProperty]
		public LoginRequest LoginData { get; set; }

		[BindProperty]
		public RegisterRequest RegisterData { get; set; }

		public string SuccessMessage { get; set; }
		public string ErrorMessage { get; set; }
		public void OnGet()
        {
        }
		public async Task<IActionResult> OnPostLoginAsync()
		{
			ModelState.Clear(); // Xoá tất cả lỗi cũ (nếu có)
			TryValidateModel(LoginData, nameof(LoginData));
			if (!ModelState.IsValid)
			{
				ErrorMessage = "Thông tin đăng nhập không hợp lệ.";
				return Page();
			}

			try
			{
				var user = await _authenService.Login(LoginData);
				var claims = new List<Claim>
		{
			new(ClaimTypes.Sid, user.Id.ToString()),
			new(ClaimTypes.Name, user.Name ?? ""),
			new(ClaimTypes.Email, user.Email),
			new(ClaimTypes.Role, user.Role.ToString())
		};

				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				await HttpContext.SignInAsync(
					CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(identity));

				return RedirectToPage("/Index");
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return Page();
			}
		}


		public async Task<IActionResult> OnPostRegisterAsync()
		{
			ModelState.Clear();
			TryValidateModel(RegisterData, nameof(RegisterData));

			if (!ModelState.IsValid)
			{
				ErrorMessage = "Dữ liệu không hợp lệ.";
				return Page();
			}

			try
			{
				var user = await _authenService.Register(RegisterData);
				SuccessMessage = "Đăng ký thành công. Vui lòng đăng nhập.";
				RegisterData = new RegisterRequest(); // reset form nếu muốn
				return Page(); // giữ lại trang hiện tại, không redirect
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return Page();
			}
		}

		public IActionResult OnGetLoginGoogle()
		{
			var redirectUrl = Url.Page("LoginRegister", "GoogleResponse");
			var props = new AuthenticationProperties { RedirectUri = redirectUrl };
			return Challenge(props, GoogleDefaults.AuthenticationScheme);
		}

		public async Task<IActionResult> OnGetGoogleResponseAsync()
		{
			var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			if (!result.Succeeded || result.Principal == null)
				return RedirectToPage("/Index");

			var claims = result.Principal.Claims;
			var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
			var name = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

			if (string.IsNullOrEmpty(email))
				return RedirectToPage("/Index");

			var account = await _authenService.GetOrCreateGoogleAccountAsync(email, name);

			await SignInAsync(account);
			return RedirectToPage("/Index");
		}

		public async Task<IActionResult> OnGetLogoutAsync()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToPage("/Index");
		}

		private async Task SignInAsync(User user)
		{
			var claims = new List<Claim>
	{
		new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
		new Claim(ClaimTypes.Email, user.Email),
		new Claim(ClaimTypes.Name, user.Name ?? "")
		// Nếu có thêm vai trò:
		// new Claim(ClaimTypes.Role, "User")
	};

			var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			var authProperties = new AuthenticationProperties
			{
				IsPersistent = true, // lưu đăng nhập sau khi đóng trình duyệt
				ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
			};

			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity),
				authProperties);
		}

	}
}
