using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestDto>>
    {
        private readonly ILeaveRequestRepository _LeaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListRequestHandler(ILeaveRequestRepository LeaveRequestRepository, IMapper mapper)
        {
            _LeaveRequestRepository = LeaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
        {
            var LeaveRequests = await _LeaveRequestRepository.GetLeaveRequestsWithDetails();
            return _mapper.Map<List<LeaveRequestDto>>(LeaveRequests);
        }
    }
}
