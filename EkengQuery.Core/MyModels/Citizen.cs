using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkengQuery.Core
{
    public class Data
    {
        public string PNum { get; set; }
        public string full_name { get; set; }
        public string AVVRegistrationAddress { get; set; }
    }

    public class Citizen
    {
        public string opaque { get; set; }
        public Data data { get; set; }
       
    }
}
