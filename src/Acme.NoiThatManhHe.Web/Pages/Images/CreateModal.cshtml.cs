
using Acme.NoiThatManhHe.CloudinaryNet;
using Acme.NoiThatManhHe.Images;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.NoiThatManhHe.Web.Pages.Images
{
    public class CreateModalModel : NoiThatManhHePageModel
    {
        private readonly ImageAppService _imageAppService;
        private IHostingEnvironment _environment;
        private CloudinaryAppService _cloudinaryAppService;
        public CreateModalModel(
            IHostingEnvironment environment,
            ImageAppService imageAppService)
        {
            _environment = environment;
            _imageAppService = imageAppService;
        }
        [BindProperty]
        public CreateImageViewModel Image { get; set; }
        public async Task OnGet(Guid id)
        {
            Image = new CreateImageViewModel();
            Image.GenericId = id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _cloudinaryAppService = new CloudinaryAppService();
            var filePath = Path.Combine(_environment.ContentRootPath ="D:" , "Images", Image.Upload.FileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                await Image.Upload.CopyToAsync(stream);
            }
            string imgUrl = _cloudinaryAppService.UploadImageToCloudinary(filePath);
            CreateUpdateImageDto createUpdateImageDto = new CreateUpdateImageDto();
            createUpdateImageDto.ImageUrl = imgUrl;
            createUpdateImageDto.Description = Image.Description;
            createUpdateImageDto.Name = Image.Name;
            createUpdateImageDto.GenericId = Image.GenericId;
            await _imageAppService.CreateAsync(createUpdateImageDto);
            return NoContent();
        }
        public class CreateImageViewModel
        {
            [HiddenInput]
            public Guid GenericId { get; set; }
            public IFormFile Upload { get; set; }
            [TextArea]
            public string Description { get; set; }
            public string Name { get; set; }
        }
    }

}
