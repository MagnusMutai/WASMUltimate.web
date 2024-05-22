﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASMUltra.Shared;

public class Employee
{
    public int EmployeeId { get; set; }

    //[Required]
    //[MinLength(2, ErrorMessage = "FirstName must contain at least 2 characters")]
    public string FirstName { get; set; }
    //[Required]
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public int DepartmentId { get; set; }
    public string PhotoPath { get; set; }
    public Department Department { get; set; }
}
