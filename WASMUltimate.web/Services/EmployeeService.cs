﻿using System.Net.Http.Json;
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
        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/employees");
        }

        public Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
