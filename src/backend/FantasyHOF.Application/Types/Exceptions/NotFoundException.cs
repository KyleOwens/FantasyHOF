using FantasyHOF.Infrastructure.Enums;
using FantasyHOF.Infrastructure.Exceptions;

namespace FantasyHOF.Application.Types.Exceptions
{
    public class NotFoundException(string entityName, object id)
        : CodedException(AppErrorCode.FantasyHOFNotFound, $"{entityName} with ID {id} was not found");
}
