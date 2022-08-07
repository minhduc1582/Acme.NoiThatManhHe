using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Products
{
    public class ProductTypeLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
