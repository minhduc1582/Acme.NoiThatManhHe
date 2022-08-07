using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.NoiThatManhHe.Projects
{
    public class CreateUpdateProjectDto
    {
        public Guid DesignTypeId { get; set; }
        public Guid CustomerId { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        public string ConstructionName { get; set; }
        [Required]
        public string Items { get; set; }
        public float Area { get; set; }
        [Required]
        public string AvatarUrl { get; set; }
        [Required]
        public string Style { get; set; }
    }
}
