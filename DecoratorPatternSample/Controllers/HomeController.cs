using AdapterPatternSample.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdapterPatternSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeesService;

        public HomeController(IEmployeeService employeesService)
        {
            _employeesService = employeesService;
        }
        [HttpGet]

        public IActionResult GetEmployees()
        {
            var employees = _employeesService.GetEmployees();
            return Ok(employees);
        }
    }
}