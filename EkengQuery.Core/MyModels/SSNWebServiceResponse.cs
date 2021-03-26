﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkengQuery.Core
{
    public class SSNWebServiceResponse
    {
        public string Status { get; set; }
        public string Opaque { get; set; }
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PNum { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }

        public string ErrorMessage { get; set; }
    }
}
