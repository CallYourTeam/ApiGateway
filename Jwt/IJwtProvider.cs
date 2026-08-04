namespace ApiGateway.Jwt
{
    public interface IJwtProvider
    {
        string GenerateToken(Guid userId);
    }
}
