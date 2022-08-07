using Acme.NoiThatManhHe.MongoDB;
using Volo.Abp.Modularity;

namespace Acme.NoiThatManhHe;

[DependsOn(
    typeof(NoiThatManhHeMongoDbTestModule)
    )]
public class NoiThatManhHeDomainTestModule : AbpModule
{

}
