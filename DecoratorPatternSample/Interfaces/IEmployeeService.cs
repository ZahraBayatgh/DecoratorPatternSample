using AdapterPatternSample.Data;

namespace AdapterPatternSample.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
    }
}
