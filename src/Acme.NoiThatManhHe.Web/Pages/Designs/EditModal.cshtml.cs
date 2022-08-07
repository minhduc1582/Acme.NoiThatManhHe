using Acme.NoiThatManhHe.Designs;
using Acme.NoiThatManhHe.Projects;
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
    public class EditModalModel : NoiThatManhHePageModel
    {
        [BindProperty]
        public EditDesignModel Design { get; set; }

        public List<SelectListItem> DesignCategories { get; set; }

        private readonly IProjectAppService _projectAppService;
        private readonly IDesignAppService _designAppService;

        public EditModalModel(
            IProjectAppService projectAppService,
            IDesignAppService designAppService)
        {
            _projectAppService = projectAppService;
            _designAppService = designAppService;
        }
        public async Task OnGetAsync(Guid id,Guid designTypeId)
        {
            var designDto = await _designAppService.GetAsync(id);
            Design = ObjectMapper.Map<DesignDto, EditDesignModel>(designDto);

            //var productCategoryLookup = await _designAppService.GetDesignCategoryLookupAsync();
            //DesignCategories = productCategoryLookup.Items
            //    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            //    .ToList();
            GetDesignDto getDesignCategoryDto = new GetDesignDto();
            getDesignCategoryDto.Filter = designTypeId.ToString();
            var productCategoryLookup = await _designAppService.GetDesignCategoryByDesignTypeIdAsync(getDesignCategoryDto);
            DesignCategories = productCategoryLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _designAppService.UpdateAsync(
                Design.Id,
                ObjectMapper.Map<EditDesignModel, CreateUpdateDesignDto>(Design)
            );

            return NoContent();
        }
        public class EditDesignModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
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
