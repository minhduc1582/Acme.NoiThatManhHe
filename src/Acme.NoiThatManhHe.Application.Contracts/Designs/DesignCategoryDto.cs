using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Designs
{
    public class DesignCategoryDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid DesignTypeId { get; set; }
    }
}
