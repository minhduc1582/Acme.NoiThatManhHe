using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Designs
{
    public class DesignDto : EntityDto<Guid>
    {
        public Guid DesignCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
