using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using WASMUltimate.shared;

namespace WASMUltimate.web.Services;


public class EmployeeAdaptor : DataAdaptor
{
    private readonly EmployeeService employeeService;

    public EmployeeAdaptor(EmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }
    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string additionalParam = null)
    {
       EmployeeDataResult result = await employeeService.GetEmployees(dataManagerRequest.Skip, dataManagerRequest.Take);

        DataResult dataResult = new DataResult()
        {
            Result = result.Employees,
            Count = result.Count
        };

        return dataResult;
    }
}
