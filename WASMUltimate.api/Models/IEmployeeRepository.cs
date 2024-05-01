using WASMUltimate.shared;
using WASMUltra.Shared;

namespace WASMUltimate.api.Models;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> Search(string name, Gender? gender);
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<EmployeeDataResult> GetEmployees(int skip, int take, string orderBy);
    Task<Employee> GetEmployee(int employeeId);
    Task<Employee> GetEmployeeByEmail(string email);
    Task<Employee> AddEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    Task DeleteEmployee(int employeeId);
}
