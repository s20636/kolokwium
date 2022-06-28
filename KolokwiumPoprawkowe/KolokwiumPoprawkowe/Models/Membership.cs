using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumPoprawkowe.Models
{
    public class Membership
    {
        public int MemberId { get; set; }
        public int TeamId { get; set; }

        public DateTime MembershipDate { get; set; }

        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
    }
}
