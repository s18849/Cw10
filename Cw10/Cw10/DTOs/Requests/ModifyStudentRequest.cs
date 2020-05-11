using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.DTOs.Requests
{
    public class ModifyStudentRequest
    {
        public string indexNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public int idEnrollment { get; set; }
        public string password { get; set; }
        
    }
}
