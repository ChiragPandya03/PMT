using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PMT_DataLayer;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PMTRazor.Extention;
using PMT_DataLayer.Extended_Enitities;

namespace PMTRazor.Pages
{
    public class SearchPMTModel : PageModel
    {
        private readonly PMTEntityContext _pMTEntityContext;

        public string SubLevelSearchString { get; set; }
        public SearchPMTModel(PMTEntityContext context)
        {
            _pMTEntityContext = context;
        }
        public void OnGet(string searchString)
        {
            
        }

        public IActionResult OnGetSearch(string term)
        {
            var subProgramLevelNames = _pMTEntityContext.PMT_SubProgramLevel.Where(p => p.SubProgramLevelName.Contains(term)).OrderBy(s=>s.SubProgramLevelName).Select(p => p.SubProgramLevelName).ToList();
            return new JsonResult(subProgramLevelNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchString"></param>
        public void OnGetSearchTest(string searchString)
        {

        }
    }
}