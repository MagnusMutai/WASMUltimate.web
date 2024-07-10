using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WASMUltimate.shared
{
    public class AllowedEmailDomainAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null || value.ToString().Length == 0 )
            {
                return new ValidationResult("Email Address is required");
            }
            else
            {
                if(value.ToString().IndexOf('@') == -1)
                {
                    return new ValidationResult("Invalid Email Address");
                }

                string[] strings = value.ToString().Split('@');
                //magnus@magnusq.com
                if (strings[1].ToLower() == "magnusq.com" )
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Email domain must be magnusq.com")
                }
        }

    }
}
