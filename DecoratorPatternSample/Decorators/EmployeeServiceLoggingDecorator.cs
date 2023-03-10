using AdapterPatternSample.Data;
using AdapterPatternSample.Interfaces;
using System.Diagnostics;

namespace DecoratorPatternSample.Decorators
{
    public class EmployeeServiceLoggingDecorator: IEmployeeService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeServiceLoggingDecorator> _logger;

        public EmployeeServiceLoggingDecorator(IEmployeeService employeeService,ILogger<EmployeeServiceLoggingDecorator> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }
        public List<Employee> GetEmployees()
        {
            _logger.LogInformation("Starting to fetch data");
            var stopwatch = Stopwatch.StartNew();

            var employees = _employeeService.GetEmployees();
            
            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation($"Finished fetching data in {elapsedTime} milliseconds");

            return employees;
        }
    }
}
