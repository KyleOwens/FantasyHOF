using FantasyHOF.Infrastructure.Enums;
using FantasyHOF.Infrastructure.Exceptions;

namespace FantasyHOF.Application.Exceptions
{
    public class ForbiddenException : CodedException
    {
        public ForbiddenException(string message = "You don't have permission to perform this action")
            : base(AppErrorCode.FantasyHOFForbidden, message) { }
    }
}
