﻿namespace Boitoan.DAL.Models;

public class RegisterRequest
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
	public string? Role { get; set; }
}
