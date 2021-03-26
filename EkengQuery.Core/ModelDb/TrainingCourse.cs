using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkengQuery.Core
{
    public partial class TrainingCourse
    {
        public TrainingCourse()
        {
            TrainingCoursePart = new HashSet<TrainingCoursePart>();
        }

        [Key]
        [Column("TrainingCourseID")]
        public int TrainingCourseId { get; set; }
        [Column("TrainingCenterID")]
        public int TrainingCenterId { get; set; }
        public DateTime DateTime { get; set; }
        [Column("TrainerID")]
        public string TrainerId { get; set; }
        [StringLength(10)]
        public string TrainingCourseCode { get; set; }
        public bool IsFormed { get; set; }
        public byte SubGroups { get; set; }

        [ForeignKey(nameof(TrainingCenterId))]
        [InverseProperty("TrainingCourse")]
        public virtual TrainingCenter TrainingCenter { get; set; }
        [InverseProperty("TrainingCourse")]
        public virtual ICollection<TrainingCoursePart> TrainingCoursePart { get; set; }
    }
}
