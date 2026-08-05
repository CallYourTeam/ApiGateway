namespace ApiGateway.Contracts.User
{
    public record UserGetResponse(
        string Login,
        DateTime RegisterationDate,
        List<Guid> Friends,
        List<Guid> Groups,
        List<Guid> Chanels
        );
}
