using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Products
{
    public class ProductCategoryDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
