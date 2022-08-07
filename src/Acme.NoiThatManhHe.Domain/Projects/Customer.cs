using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.NoiThatManhHe.Projects
{
    public class Customer : AuditedAggregateRoot<Guid>
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
    }
}
