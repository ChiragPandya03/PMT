using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMT_DataLayer.CustomModels
{
    public class PMT_TrainerDetails
    {
        [Key]
        public Guid TrainerId { get; set; }

        public string TrainerName { get; set; }

        public string TotalExperiance { get; set; }

        public string Location { get; set; }
        public string TagLine { get; set; }
        public int Age { get; set; }

        public string Description { get; set; }
        public string KeyIndustriesWorkedFor { get; set; }
        public string KeyCompaniesWorkedFor { get; set; }
        public string TrainingExperiance { get; set; }
        public string AreaofExpertise { get; set; }
        public string HighestEducationQualification { get; set; }
        public string OtherCertification { get; set; }
        public string MajorProjects { get; set; }
        public string MajorAchievement { get; set; }
        public string KindofProgramConducted { get; set; }

        public string LevelOfEmployeesConducted { get; set; }
        public string LinkedinProfile { get; set; }

        public byte[] Photo { get; set; }
        public double? MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Langauge { get; set; }
        public bool IsDeleted { get; set; }
    }
}
