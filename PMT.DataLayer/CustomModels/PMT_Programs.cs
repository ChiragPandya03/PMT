using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMT_DataLayer.CustomModels
{
    public class PMT_Programs
    {
        [Key]
        public Guid ProgramId { get; set; }
        public string Name { get; set; }
        public string CssClass { get; set; }
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
        public int PriorityNumber { get; set; }

    }
}
