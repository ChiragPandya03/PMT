using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMT_DataLayer.CustomModels
{
    public class PMT_TrainerProgramDetails
    {
        [Key]
        public Guid ProgramTrainerId { get; set; }

        public Guid SubProgramLevelId { get; set; }

        public Guid TrainerId { get; set; }
    }
}
