using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.NoiThatManhHe.Products
{
    public interface IProductAppService :
        ICrudAppService<
            ProductDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateProductDto>
    {
        Task<ListResultDto<ProductTypeLookupDto>> GetProductTypeLookupAsync();
    }
}
