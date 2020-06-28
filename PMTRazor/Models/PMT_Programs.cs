using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMTRazor.Models
{
    public class PMT_Programs
    {
        public Guid ProgramId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }

    }
}
