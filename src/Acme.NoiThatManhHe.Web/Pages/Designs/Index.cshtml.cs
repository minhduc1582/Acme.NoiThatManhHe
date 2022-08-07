using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Acme.NoiThatManhHe.Web.Pages.Designs
{
    public class IndexModel : PageModel
    {
        public Guid DesignTypeId { get; set; }
        public void OnGet(Guid id)
        {
            DesignTypeId = id;  
        }
    }
}
