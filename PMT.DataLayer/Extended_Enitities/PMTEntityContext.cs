using Microsoft.EntityFrameworkCore;
using PMT_DataLayer.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMT_DataLayer.Extended_Enitities
{
    public class PMTEntityContext : DbContext
    {
        public PMTEntityContext(DbContextOptions<PMTEntityContext> options) : base(options)
        {
        }

        public DbSet<PMT_Programs> PMT_Programs { get; set; }
        public DbSet<PMT_SubPrograms> PMT_SubPrograms { get; set; }
        public DbSet<PMT_SubProgramLevel> PMT_SubProgramLevel { get; set; }

        public DbSet<PMT_TrainerDetails> PMT_TrainerDetails { get; set; }

        public DbSet<PMT_TrainerProgramDetails> PMT_TrainerProgramDetails { get; set; }

        
    }
}
