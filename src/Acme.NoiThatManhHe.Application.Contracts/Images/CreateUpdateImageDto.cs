using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.NoiThatManhHe.Images
{
    public class CreateUpdateImageDto
    {
        [Required]
        public Guid GenericId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}
