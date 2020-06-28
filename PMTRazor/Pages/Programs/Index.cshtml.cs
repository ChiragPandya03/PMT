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
using PMT_DataLayer.CustomModels;

namespace PMTRazor.Pages.Programs
{
    public class IndexModel : BaseModel
    {
        #region Properties
        private readonly PMTEntityContext _pMTEntityContext;

        public IEnumerable<PMT_DataLayer.CustomModels.PMT_SubPrograms> SubPrograms { get; set; }
        public IEnumerable<PMT_DataLayer.CustomModels.PMT_SubProgramLevel> SubProgramLevels { get; set; }

        public IEnumerable<PMT_DataLayer.CustomModels.PMT_TrainerDetails> TrainerDetails { get; set; }
        public string ProgramName { get; set; }
        public string ProgramDescription { get; set; }
        public int TotalLanguageCount { get; set; }
        public int TotalTopicHours { get; set; }
        public Guid SubProgramId { get; set; }

        public int TotalProgramCount { get; set; }
        #endregion

        #region Constructor
        public IndexModel(PMTEntityContext context)
        {
            _pMTEntityContext = context;
        } 
        #endregion

        public async Task OnGet(Guid id)
        {
            if (id != default(Guid))
            {
                GetProgramName(id);
                var subPrograms = await _pMTEntityContext.PMT_SubPrograms.Where(s => s.ProgramId == id && !s.IsDeleted).OrderBy(s => s.SubProgramName).ToListAsync();
                SubPrograms = subPrograms.OrderBy(s => s.SubProgramName).ToList();

                var subProgramIds = SubPrograms.Select(s => s.SubProgramId);
                var subPrgoramLevels = _pMTEntityContext.PMT_SubProgramLevel.Where(s => subProgramIds.Contains(s.SubProgramId)).ToList();
                SubProgramLevels = subPrgoramLevels.OrderBy(s => s.SubProgramLevelName).ToList();

                var subPrgramLevelIds = SubProgramLevels.Select(s => s.SubProgramLevelID);
                TotalProgramCount = SubProgramLevels.Count();

                ProgramDetailAssignment();
            }
        }       


        #region Private Methods
        private void ProgramDetailAssignment()
        {
            var subProgramLevelIds = SubProgramLevels.Select(s => s.SubProgramLevelID).ToList();
            List<TrainerProgramDetails> trainerDetails = new List<TrainerProgramDetails>();
            if (subProgramLevelIds.Any())
            {
                trainerDetails = (from tpd in _pMTEntityContext.PMT_TrainerProgramDetails.Where(s => subProgramLevelIds.Contains(s.SubProgramLevelId))
                                      join td in _pMTEntityContext.PMT_TrainerDetails on tpd.TrainerId equals td.TrainerId
                                      where !td.IsDeleted
                                      select new TrainerProgramDetails() { TrainerDetails = td,SubProgramLevelId = tpd.SubProgramLevelId }
                                  ).ToList();

            }

            foreach (var sp in SubPrograms)
            {
                var result = SubProgramLevels.Where(s => s.SubProgramId == sp.SubProgramId).Sum(p => Convert.ToDouble(p.TotalHours));
                sp.TotalTopicHours = result;

                //TODO :- Remove later for now it's fine
                var subProgramLevelIDs = SubProgramLevels.Where(s => s.SubProgramId == sp.SubProgramId).Select(p => p.SubProgramLevelID).Distinct();
                sp.TotalTrainerCount = subProgramLevelIDs.Count();

                sp.TotalProgramCount = SubProgramLevels.Count(s => s.SubProgramId == sp.SubProgramId);

                sp.TotalLanguageCount = CountLangauges(trainerDetails.Where(s => subProgramLevelIDs.Contains(s.SubProgramLevelId)).Select(s => s.TrainerDetails).ToList());
            }
        }

        private void GetProgramName(Guid programId)
        {
            var program = _pMTEntityContext.PMT_Programs.FirstOrDefault(s => s.ProgramId == programId);
            ProgramName = program != null ? program.Name : string.Empty;
            ProgramDescription = program != null ? program.Description : string.Empty;
        }

        /// <summary>
        /// Method to count langauges todo later change to database key referance.
        /// </summary>
        /// <param name="totalTrainers"></param>
        /// <returns></returns>
        private int CountLangauges(List<PMT_TrainerDetails> totalTrainers)
        {
            List<string> langauges = new List<string>();
            var langugaeUsed = totalTrainers.Select(s => s.Langauge).Distinct().ToList();
            foreach (var lng in langugaeUsed)
            {
                var replaceString = lng.Replace(",", "").Replace(" ", "").Replace(".", "");
                foreach (var res in replaceString.Split(";"))
                {
                    if (!langauges.Contains(res.Trim()))
                    {
                        langauges.Add(res.Trim());
                    }
                }
            }
            return langauges.Count();
        } 
        #endregion
    }

    public class TrainerProgramDetails
    {
        public PMT_TrainerDetails TrainerDetails { get; set; }

        public Guid SubProgramLevelId { get; set; }
    }
}