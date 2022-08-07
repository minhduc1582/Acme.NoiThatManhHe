using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Designs
{
    public class DesignTypeDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
