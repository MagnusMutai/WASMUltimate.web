using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WASMUltimate.shared;

namespace WASMUltra.Shared;

public class Employee
{
    public int EmployeeId { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "FirstName must contain at least 2 characters")]
    public string FirstName  { get; set; }
    //[Required]
    public string LastName { get; set; }
    [EmailAddress]
    [AllowedEmailDomain("magnusq.com", ErrorMessage = "Invalid Email Domain")]
    public string Email { get; set; }
    [DisplayFormat(DataFormatString = "d")]
    [Display(Name = "  DOB")]
    [Editable(false)]
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public int DepartmentId { get; set; }
    public string PhotoPath { get; set; }
    public Department Department { get; set; }
}
