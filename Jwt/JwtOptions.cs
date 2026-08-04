namespace ApiGateway.Jwt
{
    public class JwtOptions
    {
        public required string SecretKey { get; set; }
        public required int ExpiredHours { get; set; }
    }
}
