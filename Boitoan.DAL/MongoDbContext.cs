using Boitoan.DAL.Entities;
using MongoDB.Driver;
using static System.Net.Mime.MediaTypeNames;


public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
    public IMongoCollection<Test> Tests => _database.GetCollection<Test>("Tests");
    public IMongoCollection<History> Histories => _database.GetCollection<History>("Histories");
    //public IMongoCollection<School> Schools => _database.GetCollection<School>("Schools");




    public IMongoCollection<T> GetCollection<T>()
    {
        if (typeof(T) == typeof(User))
            return (IMongoCollection<T>)Users;
        if (typeof(T) == typeof(Test))
            return (IMongoCollection<T>)Tests;

        if (typeof(T) == typeof(History))
            return (IMongoCollection<T>)Histories;
        //if (typeof(T) == typeof(School))
        //    return (IMongoCollection<T>)Schools;


        throw new ArgumentException("Collection not found for the given type");
    }

    public void SeedData()
    {
        // Seed Emp data
        if (!Users.Find(_ => true).Any())
        {
            Users.InsertMany(new[]
            {
                new User
                {
                    Name = "John Doe",
                    Email = "john@example.com",
                    PhoneNumber = "123-456-7890",
                    Password = "hashed_password_1" // In production, ensure passwords are properly hashed
                },
                new User
                {
                    Name = "Jane Smith",
                    Email = "jane@example.com",
                    PhoneNumber = "123-456-7891",
                    Password = "hashed_password_2"
                },
                new User
                {
                    Name = "Bob Wilson",
                    Email = "bob@example.com",
                    PhoneNumber = "123-456-7892",
                    Password = "hashed_password_3"
                }
            });
        }

        // Seed Test data
        List<Question> questions = SPTS_Writer.Utils.DataGenerator.GenerateSampleQuestions();

        if (!Tests.Find(_ => true).Any())
        {
            Tests.InsertMany(SPTS_Writer.Utils.DataGenerator.GenerateSampleTests(questions));
        }
    }
}
