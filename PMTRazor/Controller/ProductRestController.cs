using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PMTRazor.Controller
{
    public class ProductRestController : ControllerBase
    {
        [Produces("application/json")]
        [HttpGet("search")]
        public IActionResult Search()
        {
            try
            {
                //string term = HttpContext.Request.Query["term"].ToString();
                var names = new List<string>() { "chirag", "asdf" };
                return Ok(names);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}