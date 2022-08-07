using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.NoiThatManhHe.Projects
{
    public interface ICustomerAppService :
        ICrudAppService<
            CustomerDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCustomerDto>
    {
    }
}
