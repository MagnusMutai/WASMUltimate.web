using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WASMUltra.Shared;

namespace WASMUltimate.shared
{
    public class EmployeeDataResult
    {
        public IEnumerable<Employee> Employees { get; set; }
        public int Count { get; set; }
    }
}
