using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.NoiThatManhHe.Designs
{
    public class Design : AuditedAggregateRoot<Guid>
    {
        public Guid DesignCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
