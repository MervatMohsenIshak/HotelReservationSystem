
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.IdentityModel.Tokens;

//var builder = WebApplication.CreateBuilder(args);

//// Configure services
//builder.Services.AddControllers();

//// Add authentication services
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true
//            //ValidIssuer = "yourIssuer",
//            //ValidAudience = "yourAudience",
//            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSecretKey"))
//        };
//    });

//var app = builder.Build();
