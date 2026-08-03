using ApiGateway.Contracts;
using UtilsModule;

namespace ApiGateway.Mapping
{
    public static class UserMapper
    {
        public static UserRegistrationResponse MapUserRegistrationResponse(RegisterUserGrpcResponse grpcResponse)
        {
            return new UserRegistrationResponse(Guid.Parse(grpcResponse.UserId));
        }

        public static UserAuthenticationResponse MapUserAuthenticationResponse(AuthenticationUserGrpcResponse grpcResponse)
        {
            return new UserAuthenticationResponse
            (
                Guid.Parse(grpcResponse.UserId),
                grpcResponse.Login,
                grpcResponse.Email,
                grpcResponse.PasswordHash,
                DateTime.Parse(grpcResponse.RegisterationDate),
                Utils.StringToList(grpcResponse.Friends, Guid.Parse),
                Utils.StringToList(grpcResponse.Groups, Guid.Parse),
                Utils.StringToList(grpcResponse.Chanels, Guid.Parse)
            );
        }
    }
}
