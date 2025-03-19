using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Internal;

public class NoLockNpgsqlHistoryRepository : NpgsqlHistoryRepository, IHistoryRepository
{
    public NoLockNpgsqlHistoryRepository(HistoryRepositoryDependencies dependencies)
        : base(dependencies) { }

    public override string GetBeginIfNotExistsScript(string migrationId) => string.Empty;

    public override string GetBeginIfExistsScript(string migrationId) => string.Empty;
}
