using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkengQuery.Core
{
    public partial class Community
    {
        public Community()
        {
            ApplicantCommunity = new HashSet<Applicant>();
            ApplicantTrainingCenterCommunity = new HashSet<Applicant>();
            TrainingCenter = new HashSet<TrainingCenter>();
        }

        [Key]
        [Column("CommunityID")]
        public int CommunityId { get; set; }
        [StringLength(10)]
        public string CommunityCode { get; set; }
        [Required]
        [StringLength(255)]
        public string CommunityName { get; set; }
        public bool? IsTraningCommunity { get; set; }
        [Column("RegionID")]
        public int RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        [InverseProperty("Community")]
        public virtual Region Region { get; set; }
        [InverseProperty(nameof(Applicant.Community))]
        public virtual ICollection<Applicant> ApplicantCommunity { get; set; }
        [InverseProperty(nameof(Applicant.TrainingCenterCommunity))]
        public virtual ICollection<Applicant> ApplicantTrainingCenterCommunity { get; set; }
        [InverseProperty("Community")]
        public virtual ICollection<TrainingCenter> TrainingCenter { get; set; }
    }
}
