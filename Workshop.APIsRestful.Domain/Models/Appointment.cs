using System;

namespace Workshop.APIsRestful.Domain.Models
{
    public class Appointment : BaseClass
    {
        public Guid EmployeeId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public Employee Employee { get; set; }
    }
}
