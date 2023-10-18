using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
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

        public static IUnitOfWork GetUnitOfWork()
        {
            var databaseContext = GetDatabaseContext();
            databaseContext.Database.EnsureCreated();

            return new UnitOfWork(databaseContext);
        }

        public static IUserRepository GetUserRepository()
        {
            var databaseContext = GetDatabaseContext();
            databaseContext.Database.EnsureCreated();

            return new UserRepository(databaseContext);
        }

        public static IMapper GetMapper(Profile profile)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(configuration);

            return mapper;
        }
    }
}
