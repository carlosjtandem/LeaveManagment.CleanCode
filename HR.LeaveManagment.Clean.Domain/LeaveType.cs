using HR.LeaveManagment.Clean.Domain.Common;


namespace leave_management.Data
{
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
