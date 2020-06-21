using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class StudentController : ApiController
    {
        List<Student> students = new List<Student>() { new Student { ID = 1 }, new Student { ID = 2 }, new Student { ID = 3 } };
        [Route("api/student/getall")]
        public IHttpActionResult GetAll()
        {
            return Json(students);
        }
    }
}
