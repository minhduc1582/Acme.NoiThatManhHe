using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.NoiThatManhHe.Products
{
    public class ProductType : AuditedAggregateRoot<Guid>
    {
        public Guid ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
