using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkengQuery.Core
{
    public partial class Applicant
    {
        public Applicant()
        {
            TrainingCoursePart = new HashSet<TrainingCoursePart>();
        }

        [Key]
        [Column("ApplicantID")]
        public int ApplicantId { get; set; }
        [StringLength(255)]
        public string ApplicantFirstName { get; set; }
        [StringLength(255)]
        public string ApplicantLastName { get; set; }
        [StringLength(255)]
        public string ApplicantMiddleName { get; set; }
        [StringLength(25)]
        public string PassportNumber { get; set; }
        public DateTime? DateOfIssue { get; set; }
        [StringLength(10)]
        public string Authority { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Column("SSN")]
        [StringLength(25)]
        public string Ssn { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [Column("CommunityID")]
        public int? CommunityId { get; set; }
        [Column("TrainingCenterCommunityID")]
        public int? TrainingCenterCommunityId { get; set; }
        [Column("GenderID")]
        public int? GenderId { get; set; }
        public string CreatorAccountId { get; set; }
        public string ModifierAccountId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Column("CreatorOrganizationID")]
        public int? CreatorOrganizationId { get; set; }
        public string PassportType { get; set; }
        public DateTime? CertificateIssue { get; set; }
        public int? CertificateNumber { get; set; }
        public int? Points { get; set; }
        [StringLength(100)]
        public string Questionnaire { get; set; }
        [StringLength(10)]
        public string TrainingCourseCode { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        [Column("TrainingCourseID")]
        public int? TrainingCourseId { get; set; }

        [ForeignKey(nameof(CommunityId))]
        [InverseProperty("ApplicantCommunity")]
        public virtual Community Community { get; set; }
        [ForeignKey(nameof(GenderId))]
        [InverseProperty("Applicant")]
        public virtual Gender Gender { get; set; }
        [ForeignKey(nameof(TrainingCenterCommunityId))]
        [InverseProperty("ApplicantTrainingCenterCommunity")]
        public virtual Community TrainingCenterCommunity { get; set; }
        [InverseProperty("Participant")]
        public virtual ICollection<TrainingCoursePart> TrainingCoursePart { get; set; }
    }
}
