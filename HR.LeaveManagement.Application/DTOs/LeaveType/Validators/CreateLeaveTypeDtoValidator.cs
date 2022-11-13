using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());
        }
    }
}
