using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMT_DataLayer.CustomModels
{
    public class PMT_SubProgramLevel
    {
        [Key]
        public Guid SubProgramLevelID { get; set; }
        public Guid SubProgramId { get; set; }
        public string SubProgramLevelName { get; set; }
        public string Description { get; set; }
        public string Benefits { get; set; }
        public string ProgramObjectives { get; set; }
        public string CourseContent { get; set; }
        public string TotalHours { get; set; }
        public bool IsDeleted { get; set; }

    }
}
