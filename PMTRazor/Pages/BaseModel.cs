using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMTRazor.Pages
{
    /// <summary>
    /// BaseModel
    /// </summary>
    public class BaseModel : PageModel
    {
        public string CurrentFilter { get; set; }
    }
}
