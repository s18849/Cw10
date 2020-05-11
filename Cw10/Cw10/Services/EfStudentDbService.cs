using Cw10.DTOs.Requests;
using Cw10.DTOs.Responses;
using Cw10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.Services
{
    public class EfStudentDbService : IStudentDbService
    {
        private readonly s18849Context _dbContext;
        public EfStudentDbService(s18849Context context)
        {
            _dbContext = context;
        }
        public void EnrollStudent()
        {
            throw new NotImplementedException();
        }

        public GetStudentResponse GetStudents()
        {
            GetStudentResponse response = new GetStudentResponse();
            try
            {
                response.Students = _dbContext.Student.ToList();
            }catch(Exception exc)
            {
                throw new Exception("Blad przy zwracaniu studentow z bazy" + exc.StackTrace);
            }

            return response;

        }

        public void ModifyStudent(ModifyStudentRequest request)
        {
            try
            {
                Student student = _dbContext.Student.SingleOrDefault(x => x.IndexNumber.Equals(request.indexNumber));
                student.FirstName = request.firstName;
                student.LastName = request.lastName;
                student.BirthDate = request.birthDate;
                student.IdEnrollment = request.idEnrollment;
                student.Password = request.password;
                _dbContext.SaveChanges();
            }catch(Exception exc)
            {
                throw new Exception("Blad przy modyfikowaniu studenta" + exc.StackTrace);
            }
            
            
        }

        public void PromoteStudents()
        {
            throw new NotImplementedException();
        }
    }
}
