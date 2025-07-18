using Boitoan.BLL;
using Boitoan.DAL.Abstraction;
using Boitoan.DAL.Entities;
using Boitoan.DAL.Models.Config;
using Boitoan.DAL.Repositories;
using Microsoft.Extensions.Options;
using SPTS_Writer.Services;
using SPTS_Writer.Services.Abstraction;

public static class DependencyInjection
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        // Bind MongoDbConfig from appsettings
        services.RegisterMongoDbContext(configuration);
        services.RegisterRepositories();
        services.RegisterService();
    }

    private static void RegisterMongoDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbConfig>(configuration.GetSection("MongoDbConfig"));
        services.AddScoped<MongoDbContext>(sp =>
        {
            var config = sp.GetRequiredService<IOptions<MongoDbConfig>>().Value;
            return new MongoDbContext(config.ConnectionString, config.DatabaseName);
        });

        // Run once per startup
        var serviceProvider = services.BuildServiceProvider();
        var mongoContext = serviceProvider.GetRequiredService<MongoDbContext>();
        mongoContext.SeedData();
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<User>, Repository<User>>();
        services.AddScoped<UserRepository>();
        services.AddScoped<IRepository<Test>, Repository<Test>>();
        services.AddScoped<IRepository<History>, Repository<History>>();
    }

    private static void RegisterService(this IServiceCollection services)
    {
        services.AddScoped<TestService>();
        services.AddScoped<ITestService, TestService>();
        services.AddScoped<Authen>();
        services.AddScoped<UserService>();
        services.AddScoped<HistoryService>();
        services.AddScoped<TestHistoryService>();

    }
}
