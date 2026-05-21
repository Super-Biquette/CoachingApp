using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingApp
{
    public class TrainingSession
    {
        public int SessionId { get; set; }
        public DateTime SessionDate { get; set; }
        public string SessionType { get; set; }
        public int DurationMinutes { get; set; }
        public string CoachNotes { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; }
    }
}
