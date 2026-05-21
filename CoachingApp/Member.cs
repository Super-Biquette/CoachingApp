using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingApp
{
    public class Member
    {
        public int MemberId { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ContactNumber { get; set; }
        public string MembershipType { get; set; }

        public List<TrainingSession> TrainingSessions { get; set; }

        public Member()
        {
            TrainingSessions = new List<TrainingSession>();
        }
    }
}
