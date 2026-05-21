using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CoachingApp
{
    public class ClubData : DbContext
    {
        public ClubData() : base("OODExam_HerveLAGNEAUX") { }

        public DbSet<Member> Members { get; set; }

        public DbSet<TrainingSession> TrainingSessions { get; set; }
    }
}
