using Cw10.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.Services
{
    public interface IStudentDbService
    {
        public void EnrollStudent();
        public void PromoteStudents();

        public GetStudentResponse GetStudents();
    }
}
