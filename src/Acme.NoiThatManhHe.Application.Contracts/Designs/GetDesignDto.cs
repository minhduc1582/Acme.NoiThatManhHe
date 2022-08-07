using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Designs
{
    public class GetDesignDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
