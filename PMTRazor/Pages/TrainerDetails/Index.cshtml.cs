using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMT_DataLayer.Extended_Enitities;
using PMT_DataLayer.CustomModels;

namespace PMTRazor.Pages.TrainerDetails
{
    public class IndexModel : BaseModel
    {
        private readonly PMTEntityContext _pMTEntityContext;

        public PMT_TrainerDetails TrainerDetail { get; set; }
        public IndexModel(PMTEntityContext context)
        {
            _pMTEntityContext = context;
        }
        public async Task OnGet(Guid id)
        {
            if (id != default(Guid))
            {
                var trainerDetails = await _pMTEntityContext.PMT_TrainerDetails.FirstOrDefaultAsync(s=>s.TrainerId==id);
                if(trainerDetails!=null)
                {
                    TrainerDetail = trainerDetails;
                }
            }
            //    var programs = await _pMTEntityContext.PMT_Programs.ToListAsync();
            //Programs = programs.Select(s =>
            //    new SelectListItem()
            //    {
            //        Value = s.ProgramId.ToString(),
            //        Text = s.Name
            //    }
            //).ToList();

            //Language = new List<SelectListItem>() { new SelectListItem() { Text = "English", Value = "1" } };
        }

        public void OnPost()
        {

        }
        public void SendMail()
        {

        }
    }
}