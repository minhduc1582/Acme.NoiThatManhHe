using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.NoiThatManhHe.Projects
{
    public class Project : AuditedAggregateRoot<Guid>
    {
        public Guid DesignTypeId { get; set; }
        public Guid CustomerId  { get; set; }
        public string Name { get; set; }
        public string ConstructionName { get; set; }
        public string Items { get; set; }
        public float Area { get; set; }
        public string AvatarUrl { get; set; }
        public string Style { get; set; }
    }
}
