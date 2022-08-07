using Acme.NoiThatManhHe.Projects;
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

namespace Acme.NoiThatManhHe.Web.Pages.Projects
{
    public class EditModalModel : NoiThatManhHePageModel
    { 
        [BindProperty]
        public EditProjectViewModel Project { get; set; }
        public List<SelectListItem> DesignTypes { get; set; }
        private readonly IProjectAppService _projectAppService;
        private readonly ICustomerAppService _customerAppService;

        public EditModalModel(IProjectAppService projectAppService, ICustomerAppService customerAppService)
        {
            _projectAppService = projectAppService;
            _customerAppService = customerAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var projectDto = await _projectAppService.GetAsync(id);
            Project = ObjectMapper.Map<ProjectDto, EditProjectViewModel>(projectDto);

            var designTypeLookup = await _projectAppService.GetDesignTypeLookupAsync();
            DesignTypes = designTypeLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
            var customer = await _customerAppService.GetAsync(projectDto.CustomerId);
            Project.CustomerId = customer.Id;
            Project.CustomerName = customer.CustomerName;
            Project.Address = customer.Address;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            CreateUpdateCustomerDto createUpdateCustomerDto = new CreateUpdateCustomerDto { CustomerName = Project.CustomerName, Address = Project.Address };
            var createCustomerDto = await _customerAppService.UpdateAsync(Project.CustomerId, createUpdateCustomerDto);

            CreateUpdateProjectDto projectDto = new CreateUpdateProjectDto
            {
                DesignTypeId = Project.DesignTypeId,
                CustomerId = createCustomerDto.Id,
                Name = Project.Name,
                Area = Project.Area,
                AvatarUrl = Project.AvatarUrl,
                Style = Project.Style,
                ConstructionName = Project.ConstructionName,
                Items = Project.Items
            };
            await _projectAppService.UpdateAsync(
                Project.Id,
                projectDto
            );

            return NoContent();
        }

        public class EditProjectViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [SelectItems(nameof(DesignTypes))]
            [DisplayName("DesignType")]
            public Guid DesignTypeId { get; set; }
            [HiddenInput]
            public Guid CustomerId { get; set; }
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
