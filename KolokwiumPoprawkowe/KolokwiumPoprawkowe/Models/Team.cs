using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumPoprawkowe.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public int OrganizationId { get; set; }
        [Required]
        [MaxLength(50)]
        public string TeamName { get; set; }
        [MaxLength(500)]
        public string TeamDescription { get; set; }

        public virtual ICollection<File> Files { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
