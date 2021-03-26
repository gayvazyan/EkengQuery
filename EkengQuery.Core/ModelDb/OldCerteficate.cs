using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkengQuery.Core
{
    public partial class OldCerteficate
    {
        public int? Id { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [StringLength(50)]
        public string Passport { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(250)]
        public string TrainingCenter { get; set; }
        public int? Points { get; set; }
        [StringLength(250)]
        public string Certeficate { get; set; }
        [StringLength(250)]
        public string Date { get; set; }
    }
}
