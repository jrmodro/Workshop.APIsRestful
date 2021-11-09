using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Workshop.APIsRestful.Business;
using Workshop.APIsRestful.Domain.Models;

namespace Workshop.APIsRestful.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        AppointmentService _service;

        public AppointmentController(AppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Appointment> Get()
        {
            throw new NotImplementedException();
        }
    }
}
