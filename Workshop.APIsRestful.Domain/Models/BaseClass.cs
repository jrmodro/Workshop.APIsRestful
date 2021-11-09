using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop.APIsRestful.Domain.Models
{
    public class BaseClass
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
