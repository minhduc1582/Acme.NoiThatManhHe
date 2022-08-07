using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Acme.NoiThatManhHe.Web;

[Dependency(ReplaceServices = true)]
public class NoiThatManhHeBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "NoiThatManhHe";
}
