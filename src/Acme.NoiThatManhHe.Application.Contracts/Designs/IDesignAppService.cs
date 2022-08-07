using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.NoiThatManhHe.Designs
{
    public interface IDesignAppService :
        ICrudAppService<
            DesignDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDesignDto>
    {
        Task<ListResultDto<DesignCategoryDto>> GetDesignCategoryByDesignTypeIdAsync(GetDesignDto input);
    }
}
