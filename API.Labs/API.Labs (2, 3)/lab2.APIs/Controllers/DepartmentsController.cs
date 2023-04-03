using lab2.BL;
using lab2.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab2.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsManager _departmentsManager;

        public DepartmentsController(IDepartmentsManager departmentsManager)
        {
            _departmentsManager = departmentsManager;
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<DepartmentReadVM> GetOneDepartmentById(int id) 
        {
            DepartmentReadVM? dept = _departmentsManager.GetDepartment(id);
            
            if(dept is null) return NotFound(new {Message = "No Department Found !!!"});
            
            return dept;
        }
    }
}
