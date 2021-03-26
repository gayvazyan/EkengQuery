using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkengQuery.Core
{
    public partial class Region
    {
        public Region()
        {
            Community = new HashSet<Community>();
        }

        [Key]
        [Column("RegionID")]
        public int RegionId { get; set; }
        [Required]
        [StringLength(10)]
        public string RegionCode { get; set; }
        [Required]
        [StringLength(255)]
        public string RegionName { get; set; }

        [InverseProperty("Region")]
        public virtual ICollection<Community> Community { get; set; }
    }
}
