using Acme.NoiThatManhHe.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.NoiThatManhHe.Images
{
    public class ImageAppService :
        CrudAppService<Image,
                    ImageDto,
                    Guid,
                    PagedAndSortedResultRequestDto,
                    CreateUpdateImageDto>,
        IImageAppService
    {
        private readonly IImageRepository _imageRepository;
        public ImageAppService(IRepository<Image, Guid> repository, IImageRepository imageRepository) : base(repository)
        {
            _imageRepository = imageRepository;
        }
        public async Task<PagedResultDto<ImageDto>> GetListByGenericIdAsync(GetImageListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Image.Name);
            }
            var images = await _imageRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _imageRepository.CountAsync()
                : await _imageRepository.CountAsync(
                    image => image.GenericId.Equals(input.Filter));

            return new PagedResultDto<ImageDto>(
                totalCount,
                ObjectMapper.Map<List<Image>, List<ImageDto>>(images)
            );
        }

    }
}
