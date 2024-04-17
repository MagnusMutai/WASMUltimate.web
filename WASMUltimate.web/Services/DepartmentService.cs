using System.Net.Http.Json;
using WASMUltra.Shared;

namespace WASMUltimate.web.Services;

public class DepartmentService : IDepartmentService
{
    private readonly HttpClient httpClient;

    public DepartmentService (HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Department>> GetAllDepartments()
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Department>>("api/departments");
    }

    public async Task<Department> GetDepartment(int departmentId)
    {
        return await httpClient.GetFromJsonAsync<Department>($"api/departments/{departmentId}");
    }
}
