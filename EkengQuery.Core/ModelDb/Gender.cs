using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkengQuery.Core
{
    public partial class Gender
    {
        public Gender()
        {
            Applicant = new HashSet<Applicant>();
        }

        [Key]
        [Column("GenderID")]
        public int GenderId { get; set; }
        [Required]
        [StringLength(10)]
        public string GenderName { get; set; }

        [InverseProperty("Gender")]
        public virtual ICollection<Applicant> Applicant { get; set; }
    }
}
