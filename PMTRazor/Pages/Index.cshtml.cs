using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMT_DataLayer.Extended_Enitities;

namespace PMTRazor.Pages
{
    public class IndexModel : BaseModel
    {
        private readonly PMTEntityContext _pMTEntityContext;

        public IEnumerable<PMT_DataLayer.CustomModels.PMT_Programs> Programs { get; set; }
        public int TotalTrainerCount { get; set; }
        public int TotalLanguageCount { get; set; }
        public int TotalProgramCount { get; set; }

        public string SubLevelSearchID { get; set; }

        public IndexModel(PMTEntityContext context)
        {
            _pMTEntityContext = context;           
        }
        public async Task OnGet(string searchString)
        {
            var totalsubProgam = await _pMTEntityContext.PMT_SubProgramLevel.Where(s => !s.IsDeleted).ToListAsync();
            TotalProgramCount = totalsubProgam.Count();

            var totalTrainers = await _pMTEntityContext.PMT_TrainerDetails.Where(s => !s.IsDeleted).ToListAsync();
            TotalTrainerCount = totalTrainers.Count();

            var programs = await _pMTEntityContext.PMT_Programs.Where(s => !s.IsDeleted).OrderBy(s => s.PriorityNumber).ToListAsync();
            Programs = programs;

            if (totalTrainers.Any())
            {
                List<string> langauges = new List<string>();
                var langugaeUsed = totalTrainers.Select(s => s.Langauge).Distinct().ToList();
                //var stringJoin = string.Join("@", langugaeUsed);
                foreach(var lng in langugaeUsed)
                {
                    var replaceString = lng.Replace(",", "").Replace(" ", "").Replace(".", "");
                    foreach (var res in replaceString.Split(";"))
                    {
                        if(!langauges.Contains(res.Trim()))
                        {
                            langauges.Add(res.Trim());
                        }
                    }
                }
                TotalLanguageCount = langauges.Count();
            }
           
            CurrentFilter = searchString;
            if(!string.IsNullOrEmpty(searchString))
            {
                //TODO redirect to page.
            }
        }

        public IActionResult OnGetSearch(string term)
        {
            List<string> appendSearch = new List<string>();
            var subProgramNames = _pMTEntityContext.PMT_SubPrograms.Where(p => p.SubProgramName.StartsWith(term)).Select(p => p.SubProgramName).ToList();
            appendSearch.AddRange(subProgramNames);
            //var subProgramLevelNames = _pMTEntityContext.PMT_SubProgramLevel.Where(p => p.SubProgramLevelName.StartsWith(term)).Select(p => p.SubProgramLevelName).ToList();
            //appendSearch.AddRange(subProgramLevelNames);
            //var searchTrainerNames = _pMTEntityContext.PMT_TrainerDetails.Where(p => p.TrainerName.StartsWith(term)).Select(p => p.TrainerName).ToList();
            //appendSearch.AddRange(searchTrainerNames);
            return new JsonResult(appendSearch);
        }

        public void OnPostAsync(string searchString)
        {

        }
    }
}
