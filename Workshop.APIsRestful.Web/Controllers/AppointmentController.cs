using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        //METODO POST: Utilizado para inclusão de dados
        [HttpPost("{employeeId}")]
        public async Task<ActionResult> Create([FromRoute] Guid employeeId)
        {
            try
            {
                Appointment Appointment = await _service.CreateAsync(employeeId);
                return new OkObjectResult(Appointment);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new APIError(ex.Message, ex.StackTrace));
            }


        }
    }
}
