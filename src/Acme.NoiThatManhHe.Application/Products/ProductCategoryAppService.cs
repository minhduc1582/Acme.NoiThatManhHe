using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.NoiThatManhHe.Products
{
    public class ProductCategoryAppService : CrudAppService<ProductCategory,
                    ProductCategoryDto,
                    Guid,
                    PagedAndSortedResultRequestDto>,
                    IProductCategoryAppService
    {
        public ProductCategoryAppService(IRepository<ProductCategory, Guid> repository)
           : base(repository)
        {

        }

    }
}
