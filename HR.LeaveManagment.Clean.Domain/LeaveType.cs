using HR.LeaveManagment.Clean.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public class LeaveType: BaseDomainEntity
    {
        public string Name { get; set; }

        public LeaveType(string name, int defaultDays)
        {
            Name = name;
            DefaultDays = defaultDays;
        }

        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
