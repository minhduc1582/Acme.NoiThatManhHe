using Volo.Abp.Modularity;

namespace Acme.NoiThatManhHe;

[DependsOn(
    typeof(NoiThatManhHeApplicationModule),
    typeof(NoiThatManhHeDomainTestModule)
    )]
public class NoiThatManhHeApplicationTestModule : AbpModule
{

}
