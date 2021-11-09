using System;

namespace Workshop.APIsRestful.Domain.Models
{
    public class Appointment : BaseClass
    {
        public DateTime CreateDate { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
