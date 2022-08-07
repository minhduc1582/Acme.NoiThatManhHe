using Acme.NoiThatManhHe.CloudinaryNet;
using Acme.NoiThatManhHe.Images;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.NoiThatManhHe.Web.Pages.Images
{
    public class EditModalModel : NoiThatManhHePageModel
    {
        private readonly ImageAppService _imageAppService;
        private CloudinaryAppService _cloudinaryAppService;
        public EditModalModel(ImageAppService imageAppService)
        {
            _imageAppService = imageAppService;
        }
        [BindProperty]
        public EditImageViewModel Image { get; set; }
        public async Task OnGet(Guid id)
        {
            var imageDto = await _imageAppService.GetAsync(id);
            Image = ObjectMapper.Map<ImageDto, EditImageViewModel>(imageDto);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                _cloudinaryAppService = new CloudinaryAppService();
                var filePath = Path.Combine("D:", "Images", Image.Upload.FileName);
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
                await _imageAppService.UpdateAsync(
                    Image.Id,
                    createUpdateImageDto
                    );
            }
            catch(NullReferenceException e)
            {
                var imageDto = await _imageAppService.GetAsync(Image.Id);
                imageDto.Description = Image.Description;
                imageDto.Name = Image.Name;
                var updateImg = ObjectMapper.Map<ImageDto, CreateUpdateImageDto>(imageDto);
                await _imageAppService.UpdateAsync(Image.Id, updateImg);
            }
            return NoContent();
        }
        public class EditImageViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [HiddenInput]
            public Guid GenericId { get; set; }
            public IFormFile Upload { get; set; }
            [TextArea]
            public string Description { get; set; }
            public string Name { get; set; }
        }
    }
}
