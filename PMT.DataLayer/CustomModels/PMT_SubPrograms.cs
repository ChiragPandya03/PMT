using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PMT_DataLayer.CustomModels
{
    public class PMT_SubPrograms
    {
        [Key]
        public Guid SubProgramId { get; set; }

        public Guid ProgramId { get; set; }

        public string SubProgramName { get; set; }

        public string Description { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageName { get; set; }

        public string TotalHours { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped]
        public int TotalTrainerCount { get; set; }
        [NotMapped]
        public double TotalTopicHours { get; set; }

        [NotMapped]
        public int TotalProgramCount { get; set; }

        [NotMapped]
        public int TotalLanguageCount { get; set; }
    }
}
