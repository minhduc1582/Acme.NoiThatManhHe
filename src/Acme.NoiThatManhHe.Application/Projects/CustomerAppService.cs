﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.NoiThatManhHe.Projects
{
    public class CustomerAppService :
        CrudAppService<Customer,
                    CustomerDto,
                    Guid,
                    PagedAndSortedResultRequestDto,
                    CreateUpdateCustomerDto>,
        ICustomerAppService
    {
        public CustomerAppService(IRepository<Customer, Guid> repository)
            : base(repository)
        {
        }
    }
}
