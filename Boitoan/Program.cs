using Boitoan;
using Boitoan.BLL;
using Boitoan.Hubs;
using Microsoft.AspNetCore.Authentication.Google;
using SPTS_Writer.Services;
using SPTS_Writer.Services.Abstraction;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<GeminiService>();

builder.Services.AddDependencyInjection(builder.Configuration);

builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<HistoryRepository>();

builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = "Cookies";
	options.DefaultChallengeScheme = "Google";
})
.AddCookie("Cookies")
.AddGoogle(options =>
{
	options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
	options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
	options.CallbackPath = "/signin-google";
});

// ✅ Nếu muốn xử lý cookie + redirect sau login:
builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Account/LoginRegister"; // Trang login
	options.AccessDeniedPath = "/AccessDenied";   // Nếu có
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapHub<SignalRHub>("/signalrhub");

app.UseAuthorization();

app.MapGet("/", context =>
{
    context.Response.Redirect("/Home");
    return Task.CompletedTask;
});

app.MapRazorPages();

app.Run();
