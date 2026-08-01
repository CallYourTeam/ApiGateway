//using ApiGateway.Extensions;
//using ApiGateway.Models;
//using ApiGateway.Handlers;

using ApiGateway;
using ApiGateway.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//builder.Services.AddProducer<UserRegistrationRequest>(builder.Configuration.GetSection("Kafka:Producer:UserRegisterationRequest"));
//builder.Services.AddConsumer<UserRegistrationResponse, UserRegistrationHandler>(builder.Configuration.GetSection("Kafka:Consumer:UserRegistrationReply"));

builder.Services.AddGrpcClient<UserGrpc.UserGrpcClient>(options =>
{
    options.Address = new Uri(builder.Configuration["Microservices:UserMicroservice"] ?? throw new Exception("empty option 'Microservices:UserMicroservice'"));
});

builder.Services.AddScoped<IUserGrpcService, UserGrpcService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
