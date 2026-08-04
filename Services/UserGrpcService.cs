using UtilsModule;

namespace ApiGateway.Services
{
    public class UserGrpcService(UserGrpc.UserGrpcClient client) : IUserGrpcService
    {
        private readonly UserGrpc.UserGrpcClient _client = client;

        public async Task<AuthenticationUserGrpcResponse> AuthenticateUserAsync(string login, string password)
        {
            return await _client.AuthenticationtUserAsync(new AuthenticationUserGrpcRequest { Login = login, Password = password });
        }

        public async Task<DeleteUserGrpcResponse> DeleteUserAsync(Guid userId, string password)
        {
            return await _client.DeleteUserAsync(new DeleteUserGrpcRequest { UserId = userId.ToString(), Password = password });
        }

        public async Task<RegisterUserGrpcResponse> RegisterUserAsync(string login, string email, string password)
        {
            return await _client.RegisterUserAsync(new RegisterUserGrpcRequest { Login = login, Email = email, Password = password });
        }

        public async Task<UpdateUserGrpcResponse> UpdateUserAsync(Guid userId, string login, string email, string password, List<Guid> friends, List<Guid> groups, List<Guid> chanels)
        {
            return await _client.UpdateUserAsync(new UpdateUserGrpcRequest
            {
                UserId = userId.ToString(),
                Login = login,
                Email = email,
                Password = password,
                Friends = Utils.ListToString(friends),
                Groups = Utils.ListToString(groups),
                Chanels = Utils.ListToString(chanels)
            });
        }
    }
}
