using ApiGateway;
using ApiGateway.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();

builder.Services.AddGrpcClient<UserGrpc.UserGrpcClient>(options =>
{
    options.Address = new Uri(builder.Configuration["Microservices:UserMicroservice"] ?? throw new Exception("empty option 'Microservices:UserMicroservice'"));
});

builder.Services.AddScoped<IUserGrpcService, UserGrpcService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
