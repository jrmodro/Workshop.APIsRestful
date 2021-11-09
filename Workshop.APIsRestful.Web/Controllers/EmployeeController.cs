using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Workshop.APIsRestful.Business;
using Workshop.APIsRestful.Domain.Models;

namespace Workshop.APIsRestful.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Employee> Employee = await _service.GetAsync();
            return new OkObjectResult(Employee);
        }


        //METODO GET: Responsável por ler dados
        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] Guid id)
        {
            Employee Employee = await _service.GetAsync(id);

            return new OkObjectResult(Employee);
        }

        //METODO POST: Utilizado para inclusão de dados
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] Employee model)
        {
            Employee Employee = await _service.CreateAsync(model);

            return new OkObjectResult(Employee);
        }

        //METODO PUT: Utilizado para substituir todas as informações do objeto
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] Employee model)
        {
            try
            {
                await _service.UpdateAsync(id, model);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new APIError(ex.Message, ex.StackTrace));
            }

        }

        //METODO DELETE: Utilizado para excluir um objeto
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new APIError(ex.Message, ex.StackTrace));
            }

        }
    }
}
