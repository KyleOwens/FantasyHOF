using FantasyHOF.Infrastructure.Enums;
using FantasyHOF.Infrastructure.Exceptions;

namespace FantasyHOF.Application.Types.Exceptions
{
    public class NotFoundException : CodedException
    {
        public NotFoundException(string entityName, object id)
            : base(AppErrorCode.FantasyHOFNotFound, $"{entityName} with ID {id} was not found") { }
    }
}
