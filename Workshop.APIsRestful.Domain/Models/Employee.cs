using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop.APIsRestful.Domain.Models
{
    public class Employee : BaseClass
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
