using AutoMapper;
using CleanArchitecture.Application.UseCases.GetAllUser;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Test.UseCases.GetAllUser
{
    public class GetAllUserUnitTests
    {
        [Fact]
        public async Task GetAllUserHandler_WithNoUserInDatabase_ShouldReturnEmptyArray()
        {
            // Arrange
            var dbContext = await Helpers.Helpers.GetUserRepository();
            var mapper = Helpers.Helpers.GetMapper();

            var handler = new GetAllUserHandler(dbContext, mapper);

            var request = new GetAllUserRequest { };

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            result!.Count.Should().Be(0);
            result.Should().BeEmpty();
            result.Should().NotBeNull();
            result.Should().BeOfType<List<GetAllUserResponse>>();
        }

        [Fact]
        public async Task GetAllUserHandler_WithNoUser_ShouldReturnArrayWithUser()
        {
            // Arrange
            var dbContext = Helpers.Helpers.GetDatabaseContext();
            var userRepository = await Helpers.Helpers.GetUserRepository();
            var mapper = Helpers.Helpers.GetMapper();

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

            var handler = new GetAllUserHandler(userRepository, mapper);

            var request = new GetAllUserRequest { };

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            result!.Count.Should().Be(1);
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(new List<GetAllUserResponse>
            {
                new GetAllUserResponse
                {
                    Id = userCreated.Id,
                    Name = userCreated.Name,
                    Email = userCreated.Email,
                }
            });
            result.Should().BeOfType<List<GetAllUserResponse>>();
        }
    }
}
