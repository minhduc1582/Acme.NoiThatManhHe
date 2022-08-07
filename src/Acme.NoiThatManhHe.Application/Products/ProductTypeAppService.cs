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
    public class ProductTypeAppService : CrudAppService<ProductType,
                    ProductTypeDto,
                    Guid,
                    PagedAndSortedResultRequestDto>,
                    IProductTypeAppService
    {
        public ProductTypeAppService(IRepository<ProductType, Guid> repository)
           : base(repository)
        {

        }

    }
}
