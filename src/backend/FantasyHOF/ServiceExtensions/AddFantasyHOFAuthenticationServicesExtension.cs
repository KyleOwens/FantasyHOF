using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FantasyHOF.ServiceExtensions
{
    public static class AddFantasyHOFAuthenticationServicesExtension
    {
        public static IServiceCollection AddFantasyHOFAuthenticationServices(this IServiceCollection services, string jwtAuthority)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = jwtAuthority;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtAuthority,
                        ValidateAudience = false,
                        ValidateLifetime = false
                    };
                });

            services.AddAuthorization();

            return services;
        }
    }
}
