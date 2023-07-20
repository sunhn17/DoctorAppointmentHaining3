using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DoctorAppointmentHaining.API.Security
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddSlotAppointmentAuthentication(this IServiceCollection services,
    IConfiguration configuration)
        {
            JwtOptions jwtConfig = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>()!;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtConfig.Issuer,
                        ValidAudience = jwtConfig.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            return services;
        }
    }
}

