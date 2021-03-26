using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkengQuery.Core
{
    public class ApplicantModel
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string TrainingCenter { get; set; }
        public int? Points { get; set; }
        public string CertificateNumber { get; set; }
        public string Date { get; set; }
    }
}
