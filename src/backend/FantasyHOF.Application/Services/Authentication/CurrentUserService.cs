using FantasyHOF.Application.Mutations;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Infrastructure.ServiceDefinitions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FantasyHOF.Application.Services.Authentication
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor, IMediator mediator)
        : ICurrentUserService
    {
        private User? _cachedUser;

        private ClaimsPrincipal? Principal =>
            httpContextAccessor.HttpContext?.User;

        public bool IsAuthenticated =>
            Principal?.Identity?.IsAuthenticated == true;

        public bool IsAdmin =>
            Principal?.FindFirstValue(ClaimTypes.Role) == "admin";

        public string ClerkUserId =>
            Principal?.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new UnauthorizedAccessException("Request is not authenticated");

        public async Task<Guid> GetUserIdAsync(CancellationToken ct = default)
        {
            if (!IsAuthenticated)
                throw new UnauthorizedAccessException();

            if (_cachedUser != null)
                return _cachedUser.Id;

            _cachedUser = await mediator.Send(
                new GetOrCreateUserByClerkIdCommand(ClerkUserId),
                ct);

            return _cachedUser.Id;
        }

        public async Task<Guid?> TryGetUserIdAsync(CancellationToken ct = default)
        {
            if (!IsAuthenticated) return null;
            if (_cachedUser != null) return _cachedUser.Id;

            _cachedUser = await mediator.Send(
                new GetOrCreateUserByClerkIdCommand(ClerkUserId),
                ct);

            return _cachedUser.Id;
        }
    }
}
