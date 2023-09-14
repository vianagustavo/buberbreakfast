using System.Text;
using BuberBreakfast.Database;
using BuberBreakfast.Repositories;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes("95d0f5a5-3fba-415f-a811-7627a86571bb");

{
    builder.Services.AddControllers();
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });
    builder.Services.AddDbContext<BreakfastContext>(options =>
        options.UseNpgsql("Server=localhost;Port=5432;Database=breakfasts;User ID=postgres;Password=docker;"));
    builder.Services.AddScoped<ITokenService, TokenService>();
    builder.Services.AddScoped<ILoginService, LoginService>();
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
    builder.Services.AddScoped<IBreakfastsRepository, BreakfastRepository>();
    builder.Services.AddScoped<IUsersRepository, UsersRepository>();
    builder.Services.AddScoped<IUserService, UserService>();
}


var app = builder.Build();
{
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

