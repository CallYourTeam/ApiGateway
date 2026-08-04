namespace ApiGateway.Services
{
    public interface IUserGrpcService
    {
        Task<RegisterUserGrpcResponse> RegisterUserAsync(string login, string email, string password);
        Task<AuthenticationUserGrpcResponse> AuthenticateUserAsync(string login, string password);
        Task<UpdateUserGrpcResponse> UpdateUserAsync(Guid userId, string login, string email, string password, List<Guid> friends, List<Guid> groups, List<Guid> chanels);
        Task<DeleteUserGrpcResponse> DeleteUserAsync(Guid userId, string password);
    }
}
