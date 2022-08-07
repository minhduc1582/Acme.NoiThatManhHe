using Acme.NoiThatManhHe.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.NoiThatManhHe.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class NoiThatManhHePageModel : AbpPageModel
{
    protected NoiThatManhHePageModel()
    {
        LocalizationResourceType = typeof(NoiThatManhHeResource);
    }
}
