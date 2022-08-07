using System.ComponentModel.DataAnnotations;

namespace Acme.NoiThatManhHe.Projects
{
    public class CreateUpdateCustomerDto
    {
        [Required]
        [StringLength(128)]
        public string CustomerName { get; set; }
        [Required]
        public string Address { get; set; }
    }
}