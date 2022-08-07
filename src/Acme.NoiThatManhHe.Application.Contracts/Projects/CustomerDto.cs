using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Projects
{
    public class CustomerDto : EntityDto<Guid>
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
    }
}
