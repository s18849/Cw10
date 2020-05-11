using Cw10.DTOs.Requests;
using Cw10.DTOs.Responses;
using Cw10.Models;
using Microsoft.EntityFrameworkCore;
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

        public void DeleteStudent(DeleteStudentRequest request)
        {
            try
            {
                var s = new Student
                {
                    IndexNumber = request.indexNumber
                };
            _dbContext.Attach(s);
            _dbContext.Remove(s);
            _dbContext.SaveChanges();
            }
            catch (Exception exc)
            {
                throw new Exception("Blad przy usuwaniu studenta" + exc.StackTrace);
            }
        }

        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request)
        {
            EnrollStudentResponse response = new EnrollStudentResponse();
            try
            {
                var studies = _dbContext.Studies
                                        .Where(s => s.Name.Equals(request.Studies))
                                        .Single();

                var Enrollment = _dbContext.Enrollment
                                            .Where(e => e.IdStudy == studies.IdStudy && e.Semester == 1)
                                            .Single();

                
                    

                var student = new Student
                {
                    IndexNumber = request.indexNumber,
                    FirstName = request.firstName,
                    LastName = request.lasttName,
                    BirthDate = request.birthDate

                };
                _dbContext.Student.Add(student);
                _dbContext.SaveChanges();
            }catch(Exception exc)
            {
                throw new Exception("Blad przy dodawaniu nowego studenta " + exc.StackTrace);
            }
            return response;
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
                var s = new Student
                {
                    IndexNumber = request.indexNumber,
                    FirstName = request.firstName,
                    LastName = request.lastName,
                    BirthDate = request.birthDate,
                    IdEnrollment = request.idEnrollment,
                    Password = request.password
                };
                _dbContext.Attach(s);
                _dbContext.Entry(s).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }catch(Exception exc)
            {
                throw new Exception("Błąd przy modyfikowaniu studenta" + exc.StackTrace);
            }
        }
        

        public void PromoteStudents()
        {
            throw new NotImplementedException();
        }
    }
}
