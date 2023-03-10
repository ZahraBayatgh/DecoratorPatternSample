using AdapterPatternSample.Data;
using AdapterPatternSample.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Numerics;

namespace DecoratorPatternSample.Decorators
{
    public class EmployeeServiceCachingDecorator : IEmployeeService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMemoryCache _memoryCache;
        private const string GET_EMPLOYEE_LIST_CACHE_KEY = "players.list";

        public EmployeeServiceCachingDecorator(IEmployeeService employeeService, IMemoryCache memoryCache)
        {
            _employeeService = employeeService;
            _memoryCache = memoryCache;
        }
        public List<Employee> GetEmployees()
        {
            // Look for the cache key.
            if (_memoryCache.TryGetValue(GET_EMPLOYEE_LIST_CACHE_KEY, out List<Employee> employees)) return employees;
           
            // Cache key is not in cache, so fetch players list.
            employees = _employeeService.GetEmployees();

            // Set cache options
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep the players in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromMinutes(1));


            // Save players list in cache.
            _memoryCache.Set(GET_EMPLOYEE_LIST_CACHE_KEY, employees, cacheEntryOptions);


            return employees;
        }
    }

}
