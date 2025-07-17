using SPTS_Writer.Services.Abstraction;
using SPTS_Writer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDependencyInjection(builder.Configuration);

builder.Services.AddScoped<ITestService, TestService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapGet("/", context =>
{
    context.Response.Redirect("/Home");
    return Task.CompletedTask;
});

app.MapRazorPages();

app.Run();
