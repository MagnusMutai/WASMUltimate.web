using WASMUltra.Shared;

namespace WASMUltimate.web.Services;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetAllDepartments();
    Task<Department> GetDepartment(int departmentId);
}
