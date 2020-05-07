using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(new s18849Context().Student.ToList());
        }
    }
}