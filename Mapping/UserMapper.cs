using ApiGateway.Models;
using ApiGateway.Utils;

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
                Freinds = Util.StringToList(grpcResponse.Friends, Guid.Parse),
                Groups = Util.StringToList(grpcResponse.Groups, Guid.Parse),
                Chanels = Util.StringToList(grpcResponse.Chanels, Guid.Parse)
            };
        }
    }
}
