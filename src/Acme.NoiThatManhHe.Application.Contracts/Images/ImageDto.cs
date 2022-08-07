using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Images
{
    public class ImageDto : EntityDto<Guid>
    {
        public Guid GenericId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}
