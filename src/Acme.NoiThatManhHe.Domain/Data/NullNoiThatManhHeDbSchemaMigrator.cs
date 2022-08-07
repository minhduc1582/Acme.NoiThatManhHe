using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.NoiThatManhHe.Data;

/* This is used if database provider does't define
 * INoiThatManhHeDbSchemaMigrator implementation.
 */
public class NullNoiThatManhHeDbSchemaMigrator : INoiThatManhHeDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
