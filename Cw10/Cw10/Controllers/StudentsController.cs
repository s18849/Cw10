using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return Ok();
        }
    }
}