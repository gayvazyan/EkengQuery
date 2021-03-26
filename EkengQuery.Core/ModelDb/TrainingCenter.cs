using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkengQuery.Core
{
    public partial class TrainingCenter
    {
        public TrainingCenter()
        {
            TrainingCourse = new HashSet<TrainingCourse>();
        }

        [Key]
        [Column("TrainingCenterID")]
        public int TrainingCenterId { get; set; }
        [Column("CommunityID")]
        public int CommunityId { get; set; }
        [StringLength(255)]
        public string Address { get; set; }

        [ForeignKey(nameof(CommunityId))]
        [InverseProperty("TrainingCenter")]
        public virtual Community Community { get; set; }
        [InverseProperty("TrainingCenter")]
        public virtual ICollection<TrainingCourse> TrainingCourse { get; set; }
    }
}
