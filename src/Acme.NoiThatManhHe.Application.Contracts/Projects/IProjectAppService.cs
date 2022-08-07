using Acme.NoiThatManhHe.Designs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.NoiThatManhHe.Projects
{
    public interface IProjectAppService :
        ICrudAppService<
            ProjectDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateProjectDto>
    {
        Task<ListResultDto<DesignTypeDto>> GetDesignTypeLookupAsync();
    }
}
