using System.Threading.Tasks;

namespace Acme.NoiThatManhHe.Data;

public interface INoiThatManhHeDbSchemaMigrator
{
    Task MigrateAsync();
}
