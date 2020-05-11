using Cw10.DTOs.Requests;
using Cw10.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.Services
{
    public interface IStudentDbService
    {
        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request);
        public void PromoteStudents();

        public GetStudentResponse GetStudents();
        public void ModifyStudent(ModifyStudentRequest request);
        public void DeleteStudent(DeleteStudentRequest request);
    }
}
