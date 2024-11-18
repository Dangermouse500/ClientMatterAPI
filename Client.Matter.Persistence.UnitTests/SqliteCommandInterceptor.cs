using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace Client.Matter.Persistence.UnitTests
{
    public class SqliteCommandInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbCommand> CommandCreating(CommandCorrelatedEventData eventData, InterceptionResult<DbCommand> interceptionResult)
        {
            using var command = eventData.Connection.CreateCommand();
            command.CommandText = "PRAGMA case_sensitive_like=ON;";
            command.ExecuteNonQuery();
            return base.CommandCreating(eventData, interceptionResult);
        }
    }
}