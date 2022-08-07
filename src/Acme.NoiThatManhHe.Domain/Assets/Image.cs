using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.NoiThatManhHe.Assets
{
    public class Image : AuditedAggregateRoot<Guid>
    {
        public Guid GenericId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}
