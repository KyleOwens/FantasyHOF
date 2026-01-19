using FantasyHOF.Infrastructure.Enums;
using FantasyHOF.Infrastructure.Exceptions;

namespace FantasyHOF.Application.Types.Exceptions
{
    public class LeagueImportExistsException()
        : CodedException(AppErrorCode.FantasyHOFLeagueImportExists, "An import for that league already is already in progress. Wait for it to complete before adding it again");
}
