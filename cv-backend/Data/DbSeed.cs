namespace cv_backend.Data;

using cv_backend.Models;
public class DbSeed
{
    private readonly DataContext _dbContext;

    public DbSeed(DataContext userDbContext)
    {
        _dbContext = userDbContext;
    }

    public void Seed()
    {
        if (!_dbContext.User.Any())
        {
            var users = new List<User>()
            {
                new User()
                {
                    Name = "Alma Cederblad",
                    Email = "almacederblad@mac.com",
                    PhoneNumber = "073-2626945",
                    Address = "Mariehällsvägen 12, Bromma",
                    City = "Stockholm",
                },
                new User()
                {
                    Name = "Alojz Milicevic",
                    Email = "alomi136@gmail.com",
                    PhoneNumber = "072-4415751",
                    Address = "Mariehällsvägen 12, Bromma",
                    City = "Stockholm",
                }
            };

            _dbContext.User.AddRange(users);
            _dbContext.SaveChanges();
        }
    }
}

