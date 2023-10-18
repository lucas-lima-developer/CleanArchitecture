using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Test.Helpers
{
    public class UserHelper
    {
        public async static Task<User> CreateUser()
        {
            var dbContext = Factory.GetDatabaseContext();

            var userCreated = new User
            {
                Id = Guid.NewGuid(),
                Name = "Lucas",
                Email = "lucas@email.com",
                DateCreated = DateTime.Now,
                DateUpdate = DateTime.Now,
                DateDeleted = DateTime.Now,
            };

            dbContext.Users.Add(userCreated);
            await dbContext.SaveChangesAsync();

            return userCreated;
        }
    }
}
