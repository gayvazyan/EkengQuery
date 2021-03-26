using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkengQuery.Core
{
    public partial class TrainingCoursePart
    {
        [Key]
        [Column("TrainingCoursePartID")]
        public int TrainingCoursePartId { get; set; }
        [Column("ParticipantID")]
        public int ParticipantId { get; set; }
        [Column("TrainingCourseID")]
        public int TrainingCourseId { get; set; }
        public bool IsNotified { get; set; }
        public DateTime EmailSentTime { get; set; }

        [ForeignKey(nameof(ParticipantId))]
        [InverseProperty(nameof(Applicant.TrainingCoursePart))]
        public virtual Applicant Participant { get; set; }
        [ForeignKey(nameof(TrainingCourseId))]
        [InverseProperty("TrainingCoursePart")]
        public virtual TrainingCourse TrainingCourse { get; set; }
    }
}
