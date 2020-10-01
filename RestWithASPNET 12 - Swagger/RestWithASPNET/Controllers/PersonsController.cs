using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Business;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using RestWithASPNET.Repository;
using Swashbuckle.Swagger.Annotations;
using Tapioca.HATEOAS;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]")]
    public class PersonsController : ControllerBase
    {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        //GET api/values
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]//
        [ProducesResponseType(400)]//nao encontrado
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get()
        {
            var persons = _personBusiness.FindAll();
            return new OkObjectResult(persons);
        }

        //GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]//
        [ProducesResponseType(400)]//nao encontrado
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return new OkObjectResult(person);
        }

        //GET api/values
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();

            return new ObjectResult(_personBusiness.Create(person));
        }

        //GET api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType((202), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            var updatePerson = _personBusiness.Update(person);
            if (updatePerson == null) NoContent();

            return new ObjectResult(updatePerson);
        }

        //GET api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]//nao encontrado
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
