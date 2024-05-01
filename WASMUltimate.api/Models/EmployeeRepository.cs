using Microsoft.EntityFrameworkCore;
using WASMUltimate.shared;
using WASMUltra.Shared;
using System.Linq.Dynamic.Core;

namespace WASMUltimate.api.Models;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext appDbContext;
    private readonly IDepartmentRepository departmentRepository;

    public EmployeeRepository(AppDbContext appDbContext, IDepartmentRepository departmentRepository)
    {
        this.appDbContext = appDbContext;
        this.departmentRepository = departmentRepository;
    }
    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await appDbContext.Employees.Include(e => e.Department).ToListAsync();
    }
    public async Task<Employee> AddEmployee(Employee employee)
    {
        if (employee.DepartmentId == 0)
        {
            throw new Exception("Employee DepartmentId cannot be zero");
        }
        else
        {
            Department department = await departmentRepository.GetDepartment(employee.DepartmentId);
            if(department == null)
            {
                throw new Exception($"Invalid Employee DepartmentId {employee.DepartmentId}");
            }
            employee.Department = department;
        }

        var result = await appDbContext.Employees.AddAsync(employee);
        await appDbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task DeleteEmployee(int employeeId)
    {
        var result = await appDbContext.Employees
                 .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        if(result != null)
        {
            appDbContext.Remove(result);
            await appDbContext.SaveChangesAsync();
        }
    }


    public async Task<Employee> GetEmployee(int employeeId)
    {
        return await appDbContext.Employees
                 .Include(e => e.Department)
                 .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
    }

    public async Task<Employee> GetEmployeeByEmail(string email)
    {
        return await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.Email == email);
    }

    public async Task<EmployeeDataResult> GetEmployees(int skip = 0, int take = 5, string orderBy = "EmlployeeId")
    {

        EmployeeDataResult result = new EmployeeDataResult()
        {
            Employees = appDbContext.Employees.OrderBy(orderBy).Skip(skip).Take(take),
            Count = await appDbContext.Employees.CountAsync()
        
        };

        return result;
                
    }

    public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
    {
        IQueryable<Employee> query = appDbContext.Employees;

        if(!string.IsNullOrEmpty(name))
        {
            query = query.Where(e => e.FirstName.Contains(name)
            || e.LastName.Contains(name));
        }

        if(gender != null)
        {
            query = query.Where(e => e.Gender == gender);
        }

        return await query.ToListAsync();
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        var result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

        if (result != null)
        {
            result.FirstName = employee.FirstName;
            result.LastName = employee.LastName;
            result.Email = employee.Email;
            result.DateOfBirth = employee.DateOfBirth;
            result.Gender = employee.Gender;
            if (employee.DepartmentId != 0)
            {
                result.DepartmentId = employee.DepartmentId;
            }
            else if (employee.Department != null)
            {
                result.DepartmentId = employee.Department.DepartmentId;
            }
            result.PhotoPath = employee.PhotoPath;

            await appDbContext.SaveChangesAsync();
            
            return result;
        }

        return null;
    }
}
