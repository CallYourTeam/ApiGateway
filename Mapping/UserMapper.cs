using ApiGateway.Models;
using UtilsModule;

namespace ApiGateway.Mapping
{
    public static class UserMapper
    {
        public static UserRegistrationResponse MapUserRegistrationResponse(RegisterUserGrpcResponse grpcResponse)
        {
            return new UserRegistrationResponse
            {
                UserId = Guid.Parse(grpcResponse.UserId)
            };
        }

        public static UserAuthenticationResponse MapUserAuthenticationResponse(AuthenticationUserGrpcResponse grpcResponse)
        {
            return new UserAuthenticationResponse
            {
                UserId = Guid.Parse(grpcResponse.UserId),
                Login = grpcResponse.Login,
                Email = grpcResponse.Email,
                PasswordHash = grpcResponse.PasswordHash,
                RegistrationDate = DateTime.Parse(grpcResponse.RegisterationDate),
                Freinds = Utils.StringToList(grpcResponse.Friends, Guid.Parse),
                Groups = Utils.StringToList(grpcResponse.Groups, Guid.Parse),
                Chanels = Utils.StringToList(grpcResponse.Chanels, Guid.Parse)
            };
        }
    }
}
