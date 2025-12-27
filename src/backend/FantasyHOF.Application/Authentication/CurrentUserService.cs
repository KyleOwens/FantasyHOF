using FantasyHOF.Domain.Types;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using FantasyHOF.Application.Mutations;

namespace FantasyHOF.Infrastructure.Authentication
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
        bool IsAdmin { get; }
        string ClerkUserId { get; }
        Task<Guid> GetUserIdAsync(CancellationToken ct = default);
    }

    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMediator _mediator;
        private User? _cachedUser;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            IMediator mediator)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        private ClaimsPrincipal Principal =>
            _httpContextAccessor.HttpContext?.User
            ?? throw new InvalidOperationException("No HttpContext available");

        public bool IsAuthenticated =>
            Principal.Identity?.IsAuthenticated == true;

        public bool IsAdmin =>
            Principal.FindFirstValue(ClaimTypes.Role) == "admin";

        public string ClerkUserId =>
            Principal.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new UnauthorizedAccessException("Request is not authenticated by Clerk");

        public async Task<Guid> GetUserIdAsync(CancellationToken ct = default)
        {
            if (!IsAuthenticated)
                throw new UnauthorizedAccessException();

            if (_cachedUser != null)
                return _cachedUser.Id;

            _cachedUser = await _mediator.Send(
                new GetOrCreateUserByClerkIdCommand(ClerkUserId),
                ct);

            return _cachedUser.Id;
        }
    }
}
