using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.DTOs.Requests
{
    public class EnrollStudentRequest
    {
        public string indexNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string Studies { get; set; }
    }
}
