using EmployeeApplication.Models.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplication.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {

            RuleFor( x => x.FirstName)
                .NotEmpty().GreaterThan("2").LessThan("10");

            RuleFor(x => x.LastName)
               .NotEmpty().GreaterThan("2").LessThan("10");
            
            RuleFor(x => x.Phone)
               .NotEmpty().Length(10);

            RuleFor(x => x.Email)
                .NotEmpty().EmailAddress();
        }
    }
}
