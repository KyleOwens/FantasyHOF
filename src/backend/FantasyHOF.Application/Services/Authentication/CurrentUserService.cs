using FantasyHOF.Infrastructure.ServiceDefinitions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FantasyHOF.Application.Services.Authentication
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor)
        : ICurrentUserService
    {
        private ClaimsPrincipal? Principal =>
            httpContextAccessor.HttpContext?.User;

        public bool IsAuthenticated =>
            Principal?.Identity?.IsAuthenticated == true;

        public bool IsAdmin =>
            Principal?.FindFirstValue(ClaimTypes.Role) == "admin";

        public string Id =>
            Principal?.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw new UnauthorizedAccessException("Request is not authenticated");
    }
}
