using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.NoiThatManhHe.Products
{
    public class CreateUpdateProductDto
    {
        public Guid ProductTypeId { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public float Price { get; set; }
        [Required]
        public string WarrantyPeriod { get; set; }
        public float TransportFee { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageAvatarUrl { get; set; }
    }
}
