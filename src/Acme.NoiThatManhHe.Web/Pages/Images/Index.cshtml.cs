using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Acme.NoiThatManhHe.Web.Pages.Images
{
    public class IndexModel : PageModel
    {
        public Guid GenericId { get; set; }
        public void OnGet(Guid id)
        {
            GenericId = id;
        }
    }
}
