using AutoMapper;
using CleanArchitecture.Application.UseCases.CreateUser;
using CleanArchitecture.Application.UseCases.GetAllUser;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Test.Helpers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Test.UseCases.CreateUser
{
    public class CreateUserUnitTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserUnitTest()
        {
            _userRepository = Factory.GetUserRepository();
            _mapper = Factory.GetMapper(new CreateUserMapper());
            _unitOfWork = Factory.GetUnitOfWork();
        }

        [Fact]
        public async Task CreateUserHandler_WithCorrectData_ShouldReturnCreatedUserResponse()
        {
            // Arrange
            var context = Factory.GetDatabaseContext();
            var handler = new CreateUserHandler(_unitOfWork, _userRepository, _mapper);

            var request = new CreateUserRequest("newuser@email.com", "newuser");
            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            result.Name.Should().Be("newuser");
            result.Email.Should().Be("newuser@email.com");
            result.Id.Should().NotBeEmpty();
            result.Should().BeOfType<CreateUserResponse>();
        }
    }
}
