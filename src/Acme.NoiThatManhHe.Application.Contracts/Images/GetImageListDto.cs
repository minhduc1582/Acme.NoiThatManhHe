using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.NoiThatManhHe.Images
{
    public class GetImageListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
