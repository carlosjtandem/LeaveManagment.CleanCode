using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator:AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository; // necesary because the entity in this part is the LeaveType

        public ILeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
           
            RuleFor(p => p.StartDate)
               .LessThan(DateTime.Now).WithMessage("{PropertyName} must be before {ComparisonValue}  ");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be before {ComparisonValue}  ");


            // 
            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveTypeRepository.Exists(id);
                    return !leaveTypeExists;
                }).WithMessage("{PropertyName} does not exist.");

        }
    }
}
