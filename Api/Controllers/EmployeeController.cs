using Api.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeServices;
        public EmployeeController(IEmployee EmployeeServisces)
        {
            _employeeServices = EmployeeServisces;
        }
        [HttpDelete]
        public bool Delete(int empId)
        {
            bool isDeleted = _employeeServices.DeleteEmployeeById(empId);
            return isDeleted;
        }
    }
}
