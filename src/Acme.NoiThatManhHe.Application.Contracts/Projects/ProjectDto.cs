using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Projects
{
    public class ProjectDto : EntityDto<Guid>
    {
        public Guid DesignTypeId { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string ConstructionName { get; set; }
        public string Items { get; set; }
        public float Area { get; set; }
        public string AvatarUrl { get; set; }
        public string Style { get; set; }
    }
}
