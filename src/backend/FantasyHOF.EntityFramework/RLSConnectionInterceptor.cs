using FantasyHOF.Infrastructure.ServiceDefinitions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace FantasyHOF.EntityFramework
{
    public class RLSConnectionInterceptor(ICurrentUserService currentUser) : DbConnectionInterceptor
    {
        public override async Task ConnectionOpenedAsync(
            DbConnection connection,
            ConnectionEndEventData eventData,
            CancellationToken ct = default)
        {
            if (eventData.Context is not FantasyHOFDBContext database) return;

            string userId = "";

            try
            {
                userId = database.RLSUserId is not null ? database.RLSUserId : currentUser.Id;
            }
            catch (UnauthorizedAccessException) { }

            await using DbCommand command = connection.CreateCommand();

            if (!string.IsNullOrEmpty(userId))
            {
                command.CommandText = $@"
                    SET app.current_user_id = '{userId}';
                    SELECT ensure_user_exists('{userId}');
                ";
            }
            else
            {
                command.CommandText = "SET app.current_user_id = ''";
            }

            await command.ExecuteNonQueryAsync(ct);

            await base.ConnectionOpenedAsync(connection, eventData, ct);
        }
    }
}
