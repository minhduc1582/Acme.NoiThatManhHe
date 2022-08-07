using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.NoiThatManhHe.Designs
{
    public class CreateUpdateDesignDto
    {
        [Required]
        public Guid DesignCategoryId { get; set; }
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}