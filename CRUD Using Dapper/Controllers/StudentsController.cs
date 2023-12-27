using CRUD_Using_Dapper.Common;
using CRUD_Using_Dapper.IService;
using CRUD_Using_Dapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Using_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public Student Post([FromBody] Student student)
        {
            if(ModelState.IsValid) return _studentService.Save(student);
            return null;
        }
        [HttpGet]
        public IEnumerable<Student> Gets()
        {
            return _studentService.Gets();
            
        }
        [HttpGet("{studentId}")]
        public Student Get(int studentId)
        {
            return _studentService.Get(studentId);
            
        }
        [HttpDelete("{studentId}")]
        public Student Delete(int studentId)
        {
            return _studentService.Delete(studentId);
            
        }
    }
}
