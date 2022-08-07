using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Products
{
    public class ProductDto : EntityDto<Guid>
    {
        public Guid ProductTypeId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string WarrantyPeriod { get; set; }
        public float TransportFee { get; set; }
        public string Description { get; set; }
        public string ImageAvatarUrl { get; set; }
    }
}
