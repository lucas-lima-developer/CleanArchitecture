using FluentValidation;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    public class GetAllUserValidator : AbstractValidator<GetAllUserResponse>
    {
        public GetAllUserValidator()
        {
            // sem validação
        }
    }
}
