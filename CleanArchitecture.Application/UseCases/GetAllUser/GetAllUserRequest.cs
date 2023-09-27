using MediatR;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    public sealed record class GetAllUserRequest : IRequest<List<GetAllUserResponse>>
    {
    }
}
