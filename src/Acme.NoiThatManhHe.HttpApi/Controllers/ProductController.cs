using Acme.NoiThatManhHe.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Controllers
{
    [Route("noithatmanhhe/v1/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        [HttpGet]
        public async Task<ActionResult<PagedResultDto<ProductDto>>> GetProducts()   
        {
            PagedAndSortedResultRequestDto page = new PagedAndSortedResultRequestDto();
            return await _productAppService.GetListAsync(page);
        }

    }
}
