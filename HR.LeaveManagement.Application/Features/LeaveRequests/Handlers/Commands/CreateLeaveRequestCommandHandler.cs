using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Responses;
using leave_management.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository _LeaveRequestRepository;
        private readonly ILeaveTypeRepository _LeaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository LeaveRequestRepository, ILeaveTypeRepository LeaveTypeRepository, IMapper mapper)
        {
            _LeaveRequestRepository = LeaveRequestRepository;
            _LeaveTypeRepository = LeaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            //Initializes the response
            var response = new BaseCommandResponse();

            //Validation
            var validator = new CreateLeaveRequestDtoValidator(_LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                //throw new Exception(); // TODO improve the handle exception
            }

            //Logic
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await _LeaveRequestRepository.Add(leaveRequest);

            //If is success don't forget to add the response details
            response.Success = true;
            response.Message = "Creation successful";
            response.Id = leaveRequest.Id;

            return response;
        }
    }
}
