using System.Threading.Tasks;
using EFCoreTester.Repos;
using Supermodel.Persistence.EFCore.SQLServer;

namespace EFCoreTester.DataContexts;

public class SqlServerDbContext : EFCoreSQLServerDataContext
{
    public SqlServerDbContext() : base(@"Data Source=.; Initial Catalog=EFCoreTesterDb; Trusted_Connection=True; TrustServerCertificate=True", new CustomRepoFactory()){}

    public override Task SeedDataAsync()
    {
        return DataSeeder.SeedDataAsync();
    }
}