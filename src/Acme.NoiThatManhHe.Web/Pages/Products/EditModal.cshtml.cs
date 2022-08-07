using Acme.NoiThatManhHe.Products;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.NoiThatManhHe.Web.Pages.Products
{
    public class EditModalModel : NoiThatManhHePageModel
    {
        [BindProperty]
        public EditBookViewModel Product { get; set; }

        public List<SelectListItem> ProductTypes { get; set; }

        private readonly IProductAppService _productAppService;


        public EditModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var productDto = await _productAppService.GetAsync(id);
            Product = ObjectMapper.Map<ProductDto, EditBookViewModel>(productDto);

            var productTypeLookup = await _productAppService.GetProductTypeLookupAsync();
            ProductTypes = productTypeLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _productAppService.UpdateAsync(
                Product.Id,
                ObjectMapper.Map<EditBookViewModel, CreateUpdateProductDto>(Product)
            );

            return NoContent();
        }

        public class EditBookViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [SelectItems(nameof(ProductTypes))]
            [DisplayName("Author")]
            public Guid ProductTypeId { get; set; }

            [Required]
            [StringLength(128)]
            public string Name { get; set; }

            [Required]
            public float Price { get; set; }
            [Required]
            public string WarrantyPeriod { get; set; }
            [Required]
            public float TransportFee { get; set; }
            
            public string Description { get; set; }
            [Required]
            public string ImageAvatarUrl { get; set; }
        }
    }
}
