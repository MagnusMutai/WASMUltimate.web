using WASMUltra.Shared;

namespace WASMUltimate.api.Models;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetDepartments();
    Task<Department> GetDepartment(int departmentId);
}
