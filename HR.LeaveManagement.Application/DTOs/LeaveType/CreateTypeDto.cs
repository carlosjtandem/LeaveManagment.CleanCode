using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.DTOs.LeaveType
{
    //this class is'not inherited for BaseDto(not need Id)
    public class CreateTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
