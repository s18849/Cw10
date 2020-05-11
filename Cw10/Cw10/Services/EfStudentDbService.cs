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
            var s = new Student
            {
              IndexNumber = request.indexNumber
            };
            _dbContext.Attach(s);
            _dbContext.Remove(s);
            _dbContext.SaveChanges();

        }

        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request)
        {
            EnrollStudentResponse response = new EnrollStudentResponse();


            
                var studies = _dbContext.Studies
                                        .Where(s => s.Name.Equals(request.Studies))
                                        .Single();
                var enrollment = _dbContext.Enrollment
                                            .Where(e => e.IdStudy == studies.IdStudy && e.Semester == 1)
                                            .SingleOrDefault();
                
              
            int idEnrollment;
            if (enrollment == null)
            {
                idEnrollment = _dbContext.Enrollment.Count();
                var e = new Enrollment
                {
                    IdEnrollment = idEnrollment,
                    Semester = 1,
                    IdStudy = studies.IdStudy,
                    StartDate = DateTime.Now
                };
                
                _dbContext.Enrollment.Add(e);
                _dbContext.SaveChanges();
            }
            else
            {
                idEnrollment = enrollment.IdEnrollment;
            }

            var student = new Student
            {
                IndexNumber = request.indexNumber,
                FirstName = request.firstName,
                LastName = request.lastName,
                BirthDate = request.birthDate,
                IdEnrollment = idEnrollment

                };
                _dbContext.Student.Add(student);
                _dbContext.SaveChanges();
            response = new EnrollStudentResponse
            {
                lastName = student.LastName,
                semester = enrollment.Semester,
                startDate = enrollment.StartDate.Value
            };
            return response;
        }

        public GetStudentResponse GetStudents()
        {
            GetStudentResponse response = new GetStudentResponse();
            response.Students = _dbContext.Student.ToList();
            return response;
        }

        public void ModifyStudent(ModifyStudentRequest request)
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
        }

        public PromoteStudentResponse PromoteStudents(PromoteStudentRequest request)
        {
            PromoteStudentResponse response = new PromoteStudentResponse();
            List<Student> stud = new List<Student>();
            
            var studies = _dbContext.Studies
                                        .Where(s => s.Name.Equals(request.Studies))
                                        .Single();
            var OldEnrollment = _dbContext.Enrollment
                                        .Where(e => e.IdStudy == studies.IdStudy && e.Semester == request.Semester)
                                        .Single();
            var enrollment = _dbContext.Enrollment
                                        .Where(e => e.IdStudy == studies.IdStudy && e.Semester == request.Semester+1)
                                        .SingleOrDefault();
            int idEnrollment;
            if (enrollment == null)
            {
                idEnrollment = _dbContext.Enrollment.Count()+1;
                var e = new Enrollment
                {
                    IdEnrollment = idEnrollment,
                    Semester = request.Semester+1,
                    IdStudy = studies.IdStudy,
                    StartDate = DateTime.Now
                };

                _dbContext.Enrollment.Add(e);
                _dbContext.SaveChanges();
            }
            else
            {
                idEnrollment = enrollment.IdEnrollment;
            }

            var students = _dbContext.Student
                                        .Where(s => s.IdEnrollment == OldEnrollment.IdEnrollment)
                                        .ToList();
            foreach(Student s in students)
            {
                s.IdEnrollment = idEnrollment;
               _dbContext.SaveChanges();
                var s1 = new Student
                {
                    IndexNumber = s.IndexNumber,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    BirthDate = s.BirthDate,
                    IdEnrollment = idEnrollment,

                };
                stud.Add(s1);
 
            }
            
            response.students = stud;


            return response;





        }
    }
}
