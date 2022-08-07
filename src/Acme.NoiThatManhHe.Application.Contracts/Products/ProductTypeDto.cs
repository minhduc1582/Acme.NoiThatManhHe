using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Products
{
    public class ProductTypeDto : EntityDto<Guid>
    {
        public Guid ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
