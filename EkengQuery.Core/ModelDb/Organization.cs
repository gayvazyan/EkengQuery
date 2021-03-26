using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkengQuery.Core
{
    public partial class Organization
    {
        [Key]
        [Column("OrganizationID")]
        public int OrganizationId { get; set; }
        [Required]
        public string OrganizationCode { get; set; }
        [Required]
        [StringLength(255)]
        public string OrganizationName { get; set; }
    }
}
