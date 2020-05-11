using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw10.DTOs.Requests;
using Cw10.Models;
using Cw10.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentDbService _context;
        public StudentsController(IStudentDbService context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            IActionResult response;
            try
            {
                response = Ok(_context.GetStudents());
            } catch (Exception exc)
            {
                response = BadRequest(exc);
            }

            return response;
        }
        [HttpPost("modifyStudent")]
        public IActionResult ModifyStudent(ModifyStudentRequest request)
        {
            IActionResult response;
            try
            {
                _context.ModifyStudent(request);
                response = Ok("Pomyslnie zmodyfikowano studenta o indexie " + request.indexNumber);
            }
            catch (Exception exc)
            {
                response = BadRequest(exc);
            }

            return response;
        }
        [HttpPost("deleteStudent")]
        public IActionResult DeleteStudent(DeleteStudentRequest request)
        {
            IActionResult response;
            try
            {
                _context.DeleteStudent(request);
                response = Ok("Pomyslnie usunieto studenta o indexie " + request.indexNumber);
            }
            catch (Exception exc)
            {
                response = BadRequest(exc);
            }

            return response;
        }
    }
}