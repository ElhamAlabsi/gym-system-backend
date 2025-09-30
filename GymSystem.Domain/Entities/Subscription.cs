using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSystem.Domain.Enums;

namespace GymSystem.Domain.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public int MemberId {  get; set; }

        public User Member { get; set; }

        public int CoachId { get; set; }
        public User Coach { get; set; }

        public SubscriptionStatus Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

    }
}
