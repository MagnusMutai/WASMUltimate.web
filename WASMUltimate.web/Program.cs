using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using WASMUltimate.web;
using WASMUltimate.web.Services;
using WASMUltra.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7159");
});
builder.Services.AddScoped<EmployeeAdaptor>();
builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7159");
});

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzIzOTM3NEAzMjM1MmUzMDJlMzBiQ1Q5ZS9URExDR3pLR29RVXlXdmV6b1JrR29razMrNFdKQjVIeVlOMkJVPQ==");

await builder.Build().RunAsync();
