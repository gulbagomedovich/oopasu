using Microsoft.AspNetCore.Mvc;
using OOPASU.Domain;
using OOPASU.Infrastructure.Repository;
using System.Collections.Generic;

namespace OOPASU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : Controller
    {
        private IClassRepository classRepository;

        public ClassesController(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        [HttpGet]
        public IEnumerable<Class> GetClasses()
        {
            return classRepository.GetClasses();
        }

        [HttpGet]
        [Route("{ClassId}")]
        public Class GetClass(int ClassId)
        {
            return classRepository.GetClassByID(ClassId);
        }

        [HttpPost]
        public Class AddClass(Class c)
        {
            classRepository.AddClass(c);
            return c;
        }

        [HttpPut]
        [Route("{ClassId}")]
        public Class UpdateClass([FromRoute] int ClassId,
            [FromBody] Class Class)
        {
            classRepository.UpdateClass(ClassId, Class);
            return classRepository.GetClassByID(ClassId);
        }

        [HttpDelete]
        [Route("{ClassId}")]
        public void DeleteClass(int ClassId)
        {
            classRepository.DeleteClass(ClassId);
        }
    }
}
