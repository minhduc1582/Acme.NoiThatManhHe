using Acme.NoiThatManhHe.Designs;
using Acme.NoiThatManhHe.Projects;
using AutoMapper.Internal.Mappers;
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

namespace Acme.NoiThatManhHe.Web.Pages.Designs
{
    public class CreateModalModel : NoiThatManhHePageModel
    {
        [BindProperty]
        public CreateDesignViewModel Design { get; set; }

        public List<SelectListItem> DesignCategories { get; set; }

        private readonly IProjectAppService _projectAppService;
        private readonly IDesignAppService _designAppService;

        public CreateModalModel(
            IProjectAppService projectAppService,
            IDesignAppService designAppService)
        {
            _projectAppService = projectAppService;
            _designAppService = designAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            Design = new CreateDesignViewModel();
            GetDesignDto getDesignCategoryDto = new GetDesignDto();
            getDesignCategoryDto.Filter = id.ToString();
            var productCategoryLookup = await _designAppService.GetDesignCategoryByDesignTypeIdAsync(getDesignCategoryDto);
            DesignCategories = productCategoryLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _designAppService.CreateAsync(
                ObjectMapper.Map<CreateDesignViewModel, CreateUpdateDesignDto>(Design)
                );
            return NoContent();
        }

        public class CreateDesignViewModel
        {
            [SelectItems(nameof(DesignCategories))]
            [DisplayName("DesignCategory")]
            public Guid DesignCategoryId { get; set; }

            [Required]
            [StringLength(128)]
            public string Title { get; set; }
            [Required]
            public string Description { get; set; }
        }
    }
}
