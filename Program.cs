using ApiGateway;
using ApiGateway.Extensions;
using ApiGateway.Jwt;
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

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddApiAuthentication(builder.Configuration);

builder.Services.AddGrpcClient<UserGrpc.UserGrpcClient>(options =>
{
    options.Address = new Uri(builder.Configuration["Microservices:UserMicroservice"] ?? throw new Exception("empty option 'Microservices:UserMicroservice'"));
});


builder.Services.AddSingleton<IUserGrpcService, UserGrpcService>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
