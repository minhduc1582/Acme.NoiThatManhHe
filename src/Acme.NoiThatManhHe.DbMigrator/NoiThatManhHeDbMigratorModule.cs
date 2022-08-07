using Acme.NoiThatManhHe.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Acme.NoiThatManhHe.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NoiThatManhHeMongoDbModule),
    typeof(NoiThatManhHeApplicationContractsModule)
    )]
public class NoiThatManhHeDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
