using Cw10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.DTOs.Responses
{
    public class GetStudentResponse
    {
        public List<Student> Students { get; set; }
    }
}
