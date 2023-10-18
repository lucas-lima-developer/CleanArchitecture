using AutoMapper;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Test.Helpers
{
    public class Factory
    {
        public static AppDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "CleanArchitectureTest")
                .Options;

            var databaseContext = new AppDbContext(options);
            databaseContext.Database.EnsureCreated();

            return databaseContext;
        }
        public static Task<UserRepository> GetUserRepository()
        {
            var databaseContext = GetDatabaseContext();
            databaseContext.Database.EnsureCreated();

            return Task.FromResult(new UserRepository(databaseContext));
        }

        public static IMapper GetMapper(Profile profile)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);

            return mapper;
        }
    }
}
