using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace FantasyHOF.ServiceExtensions
{
    public static class AddFantasyHOFAuthenticationServicesExtension
    {
        public static IServiceCollection AddFantasyHOFAuthenticationServices(this IServiceCollection services, IWebHostEnvironment environment, string jwtAuthority)
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
                        ValidateLifetime = environment.IsDevelopment() ? false : true
                    };
                });

            services.AddAuthorization();

            return services;
        }
    }
}
