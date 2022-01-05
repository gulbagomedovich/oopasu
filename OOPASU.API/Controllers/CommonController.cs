using Microsoft.AspNetCore.Mvc;
using OOPASU.Domain;
using OOPASU.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace OOPASU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : Controller
    {
        private readonly Context context;

        public CommonController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("classes")]
        public ActionResult GetClasses()
        {
            List<Class> classes = (List<Class>)context.Classes.ToList();
            ViewData["Classes"] = classes;

            return View();
        }

        [HttpGet]
        [Route("students")]
        public ActionResult GetStudentsByGroupId([FromQuery(Name = "groupId")] int groupId)
        {
            List<Student> students = context.Students.Where(s => s.GroupId == groupId).ToList();
            ViewData["Students"] = students;

            return View();
        }

        [HttpGet]
        [Route("visits")]
        public ActionResult GetVisits()
        {
            List<Visit> visits = (List<Visit>)context.Visits.ToList();
            ViewData["Visits"] = visits;

            return View();
        }

        [HttpPut]
        [Route("visits")]
        public void PostVisit(
            [FromQuery(Name = "classId")] int classId,
            [FromQuery(Name = "studentId")] int studentId,
            [FromQuery(Name = "status")] string status)
        {
            Visit savedVisit = context.Visits.First(v => v.ClassId == classId && v.StudentId == studentId);
            savedVisit.Status = status;

            context.SaveChanges();
        }
    }
}
