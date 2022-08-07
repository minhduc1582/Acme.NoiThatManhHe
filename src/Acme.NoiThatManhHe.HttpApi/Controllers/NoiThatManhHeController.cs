using Acme.NoiThatManhHe.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.NoiThatManhHe.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NoiThatManhHeController : AbpControllerBase
{
    protected NoiThatManhHeController()
    {
        LocalizationResource = typeof(NoiThatManhHeResource);
    }
}
