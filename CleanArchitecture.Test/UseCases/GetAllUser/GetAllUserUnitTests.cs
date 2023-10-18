using CleanArchitecture.Application.UseCases.GetAllUser;
using CleanArchitecture.Test.Helpers;
using FluentAssertions;

namespace CleanArchitecture.Test.UseCases.GetAllUser
{
    public class GetAllUserUnitTests
    {
        [Fact]
        public async Task GetAllUserHandler_WithNoUserInDatabase_ShouldReturnEmptyArray()
        {
            // Arrange
            var dbContext = await Factory.GetUserRepository();
            var mapper = Factory.GetMapper(new GetAllUserMapper());

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
            var userRepository = await Factory.GetUserRepository();
            var mapper = Factory.GetMapper(new GetAllUserMapper());
            var userCreated = await UserHelper.CreateUser();

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
