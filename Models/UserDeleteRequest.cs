namespace ApiGateway.Models
{
    public class UserDeleteRequest
    {
        public required Guid UserId { get; set; }
        public required string Password { get; set; }
    }
}
