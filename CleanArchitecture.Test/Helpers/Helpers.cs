using AutoMapper;
using CleanArchitecture.Application.UseCases.GetAllUser;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Test.Helpers
{
    public class Helpers
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
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "CleanArchitectureTest")
                .Options;

            var databaseContext = new AppDbContext(options);
            databaseContext.Database.EnsureCreated();

            return Task.FromResult(new UserRepository(databaseContext));
        }

        public static IMapper GetMapper()
        {
            var myProfile = new GetAllUserMapper();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);

            return mapper;
        }
    }
}
