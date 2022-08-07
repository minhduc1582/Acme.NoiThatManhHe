using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.NoiThatManhHe.Products
{
    public interface IProductTypeAppService : ICrudAppService<
            ProductTypeDto,
            Guid,
            PagedAndSortedResultRequestDto>
    {
    }
}
