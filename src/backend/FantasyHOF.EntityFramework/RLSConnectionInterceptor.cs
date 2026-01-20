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

            Guid? userId = database.RLSUserId ?? await currentUser.TryGetUserIdAsync(ct);

            await using DbCommand command = connection.CreateCommand();

            command.CommandText = userId.HasValue
                ? $"SET app.current_user_id = '{userId.Value}'"
                : "SET app.current_user_id = ''";

            await command.ExecuteNonQueryAsync(ct);

            await base.ConnectionOpenedAsync(connection, eventData, ct);
        }
    }
}
