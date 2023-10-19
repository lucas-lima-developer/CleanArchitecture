using AutoMapper;
using CleanArchitecture.Application.UseCases.DeleteUser;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Test.Helpers;
using FluentAssertions;

namespace CleanArchitecture.Test.UseCases.DeleteUser
{
    public class DeleteUserUnitTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteUserUnitTest()
        {
            _userRepository = Factory.GetUserRepository();
            _mapper = Factory.GetMapper(new DeleteUserMapper());
            _unitOfWork = Factory.GetUnitOfWork();
        }

        [Fact]
        public async Task DeleteUserHandler_WithUserInDatabase_ShouldReturnDeletedUser()
        {
            // Arrange
            var handler = new DeleteUserHandler(_unitOfWork, _userRepository, _mapper);
            var userCreated = await UserHelper.CreateUser();
            var request = new DeleteUserRequest(userCreated.Id);

            // Act
            var result = await handler.Handle(request, new CancellationToken());

            // Assert
            result.Should().BeEquivalentTo(new DeleteUserResponse
            {
                Email = userCreated.Email,
                Name = userCreated.Name,
                Id = userCreated.Id
            });
            result.Should().BeOfType<DeleteUserResponse>();
        }
    }
}
