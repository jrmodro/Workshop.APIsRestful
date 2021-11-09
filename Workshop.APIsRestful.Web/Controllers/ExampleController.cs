using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Workshop.APIsRestful.Business;
using Workshop.APIsRestful.Domain.Models;

namespace Workshop.APIsRestful.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private static List<dynamic> _items = new List<dynamic>()
        {
                new { Id = Guid.NewGuid(), Name = "Exemplo de dado 1" },
                new { Id = Guid.NewGuid(), Name = "Exemplo de dado 2" },
                new { Id = Guid.NewGuid(), Name = "Exemplo de dado 3" },
        };

        //METODO GET: Responsável por ler dados
        [HttpGet]
        public ActionResult Get()
        {
            return new OkObjectResult(_items);
        }

        //METODO GET: Responsável por ler dados
        [HttpGet("{id}")]
        public ActionResult Get([FromRoute] Guid id)
        {
            return new OkObjectResult(_items.FirstOrDefault(x => x.Id == id));
        }

        //METODO POST: Utilizado para inclusão de dados
        [HttpPost]
        public ActionResult Post([FromBody] dynamic model)
        {
            _items.Add(model);

            return new OkResult();
        }

        //METODO PUT: Utilizado para substituir todas as informações do objeto
        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] Guid id, [FromBody]dynamic model)
        {
            _items.RemoveAll(x => x.Id == id);
            _items.Add(model);

            return new OkResult();
        }

        //METODO PATCH: Utilizado para substituir informações parciais do objeto
        [HttpPatch("{id}/name")]
        public ActionResult ChangeName([FromRoute] Guid id, [FromQuery] string name)
        {
            var model = _items.FirstOrDefault(x => x.Id == id);
            model.Name = name;

            return new OkObjectResult(model);
        }
    }
}
