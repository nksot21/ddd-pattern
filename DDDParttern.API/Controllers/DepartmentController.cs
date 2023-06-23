using DDDParttern.Domain.Entities;
using DDDParttern.API.IServices;
using DDDParttern.Infrastructure.Helpers;
using DDDParttern.Infrastructure.Models;
using DDDParttern.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDDParttern.API.Controllers
{
    [Route("api/v1/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService DepartmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            DepartmentService = departmentService;
        }
        [HttpGet]
        async public Task<IActionResult> GetAllDepartment()
        {
            var departments = await DepartmentService.GetAll();
            return Ok(ResponseHelper.HandleSuccessResponse("Get success", departments));
        }

        [HttpPost]
        async public Task<IActionResult> CreateDepartment([FromBody] Departments department)
        {
            Departments dpm = await DepartmentService.GetByName(department.Name);
            if(dpm != null)
            {
                throw new RequestException("Department name already existed");
            }
            await DepartmentService.Create(department);
            return Ok(ResponseHelper.HandleSuccessResponse("Created", null));
        }

    }
}
