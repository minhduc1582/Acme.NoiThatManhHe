using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.NoiThatManhHe.Products
{

    public class Product : AuditedAggregateRoot<Guid>
    {
        public Guid ProductTypeId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string WarrantyPeriod { get; set; }
        public float TransportFee { get; set; }
        public  string Description { get; set; }
        public string ImageAvatarUrl { get; set; }

    }
}
