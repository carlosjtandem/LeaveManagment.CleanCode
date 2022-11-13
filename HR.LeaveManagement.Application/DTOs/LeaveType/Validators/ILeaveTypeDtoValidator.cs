using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    // We create a interfaz to avoid creat the same code in all the validations, insted we can use the interface
    public class ILeaveTypeDtoValidator: AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is requiered")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must no exceed {ComparisonValue} characters");

            RuleFor(p => p.DefaultDays)
               .NotEmpty().WithMessage("{PropertyName} is requiered")
               .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.")
               .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}.");
        }
    }
}
