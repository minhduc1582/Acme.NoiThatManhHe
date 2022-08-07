using Acme.NoiThatManhHe.Projects;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Acme.NoiThatManhHe.Web.Pages.Projects
{
    public class CreateModalModel : NoiThatManhHePageModel
    {
        [BindProperty]
        public CreateProjectViewModel Project { get; set; }
        public List<SelectListItem> DesignTypes { get; set; }
        private readonly IProjectAppService _projectAppService;
        private readonly ICustomerAppService _customerAppService;
        public CreateModalModel( IProjectAppService projectAppService, ICustomerAppService customerAppService)
        {
            _projectAppService = projectAppService;
            _customerAppService = customerAppService;
        }
        public async Task OnGetAsync()
        {
            Project = new CreateProjectViewModel();
            var designTypeLookup = await _projectAppService.GetDesignTypeLookupAsync();
            DesignTypes = designTypeLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            CreateUpdateCustomerDto createUpdateCustomerDto = new CreateUpdateCustomerDto { CustomerName = Project.CustomerName,Address = Project.Address};
            var createCustomerDto = await _customerAppService.CreateAsync(createUpdateCustomerDto);

            CreateUpdateProjectDto projectDto = new CreateUpdateProjectDto {
                DesignTypeId = Project.DesignTypeId,
                CustomerId = createCustomerDto.Id,
                Name = Project.Name,Area = Project.Area,
                AvatarUrl = Project.AvatarUrl, Style = Project.Style,
                ConstructionName = Project.ConstructionName,
                Items = Project.Items 
            };
            await _projectAppService.CreateAsync(projectDto);
            return NoContent();
        }
        public class CreateProjectViewModel
        {
            [SelectItems(nameof(DesignTypes))]
            [DisplayName("DesignType")]
            public Guid DesignTypeId { get; set; }
            [Required]
            [StringLength(128)]
            public string Name { get; set; }
            [Required]
            public string ConstructionName { get; set; }
            public string Items { get; set; }
            [Required]
            public string CustomerName { get; set; }
            [Required]
            public string Address { get; set; }
            public float Area { get; set; }
            [Required]
            public string AvatarUrl { get; set; }
            [Required]
            public string Style { get; set; }
        }
    }
    
}
