using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.NoiThatManhHe.Products
{
    public class ProductAppService :
        CrudAppService<Product,
                    ProductDto,
                    Guid,
                    PagedAndSortedResultRequestDto,
                    CreateUpdateProductDto>,
        IProductAppService
    {
        //private readonly IProductTypeRepository _productTypeRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        public ProductAppService(IRepository<Product, Guid> repository
            , IProductTypeRepository productTypeRepository
            )
            : base(repository)
        {
            _productTypeRepository = productTypeRepository;
        }
        public async Task<ListResultDto<ProductDto>> GetProductsByProductTypeIDAsync(Guid id)
        {
            var queryable = await Repository.GetQueryableAsync();
            var products = await AsyncExecuter.ToListAsync(
                queryable.Where(product => id == product.ProductTypeId)
                );

            return new ListResultDto<ProductDto>(
                ObjectMapper.Map<List<Product>, List<ProductDto>>(products)
            );

        }

        public async Task<ListResultDto<ProductTypeLookupDto>> GetProductTypeLookupAsync()
        {
            var productTypes = await _productTypeRepository.GetListAsync();
            return new ListResultDto<ProductTypeLookupDto>(
                ObjectMapper.Map<List<ProductType>, List<ProductTypeLookupDto>>(productTypes)
            );

        }
    }
}
