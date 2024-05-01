using System.Net.Http.Json;
using WASMUltimate.shared;
using WASMUltra.Shared;

namespace WASMUltimate.web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {

            var response = await httpClient.PostAsJsonAsync<Employee>("api/employees", employee);
            return await response.Content.ReadFromJsonAsync<Employee>();

        }

        public async Task DeleteEmployee(int employeeId)
        {
            await httpClient.DeleteAsync($"api/employees/{employeeId}");
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Employee>>($"api/employees/all");
        }

        public Task<Employee> GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeDataResult> GetEmployees(int skip, int take, string orderBy)
        {
            return await httpClient.GetFromJsonAsync<EmployeeDataResult>($"api/employees?skip={skip}&take={take}&orderBy={orderBy}");
        }

        public Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var response = await httpClient.PutAsJsonAsync<Employee>($"api/employees/{employee.EmployeeId}", employee);
            return await response.Content.ReadFromJsonAsync<Employee>();
        }
    }
}
