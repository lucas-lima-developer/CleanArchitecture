using AutoMapper;
using CleanArchitecture.Application.UseCases.GetAllUser;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Test.Helpers;
using FluentAssertions;

namespace CleanArchitecture.Test.UseCases.GetAllUser
{
    public class GetAllUserUnitTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserUnitTests()
        {
            _userRepository = Factory.GetUserRepository();
            _mapper = Factory.GetMapper(new GetAllUserMapper());
        }

        [Fact]
        public async Task GetAllUserHandler_WithNoUserInDatabase_ShouldReturnEmptyArray()
        {
            // Arrange
            var handler = new GetAllUserHandler(_userRepository, _mapper);

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
            var userCreated = await UserHelper.CreateUser();

            var handler = new GetAllUserHandler(_userRepository, _mapper);

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
