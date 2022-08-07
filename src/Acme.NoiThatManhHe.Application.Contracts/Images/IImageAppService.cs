using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.NoiThatManhHe.Images
{
    public interface IImageAppService :
        ICrudAppService<
            ImageDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateImageDto>
    {
        Task<PagedResultDto<ImageDto>> GetListByGenericIdAsync(GetImageListDto input);
    }
}
