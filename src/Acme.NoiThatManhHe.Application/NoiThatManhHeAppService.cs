using System;
using System.Collections.Generic;
using System.Text;
using Acme.NoiThatManhHe.Localization;
using Volo.Abp.Application.Services;

namespace Acme.NoiThatManhHe;

/* Inherit your application services from this class.
 */
public abstract class NoiThatManhHeAppService : ApplicationService
{
    protected NoiThatManhHeAppService()
    {
        LocalizationResource = typeof(NoiThatManhHeResource);
    }
}
