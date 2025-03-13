using JWTSimpleAuthentication.Models;
using JWTSimpleAuthentication.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TokenServices>();

var app = builder.Build();
app.MapGet("/", (TokenServices services) => services.GenerateToken(new 
(1, "admin", 
    "admin@teste", "1234",
    new string[]{"admin", "op"})));

app.Run();
