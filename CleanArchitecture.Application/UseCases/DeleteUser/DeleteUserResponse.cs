namespace CleanArchitecture.Application.UseCases.DeleteUser
{
    public class DeleteUserResponse
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}
