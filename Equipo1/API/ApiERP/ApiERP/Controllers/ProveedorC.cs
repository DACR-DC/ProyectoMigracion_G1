using Microsoft.AspNetCore.Mvc;
using ApiERP.Models;
using ApiERP.Models.Templates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorC : ControllerBase
    {
        ProveedorSentence prvSentence = new ProveedorSentence();
        // GET: api/<Proveedor>
        [HttpGet]
        public IEnumerable<Proveedor> Get()
        {
            return prvSentence.getAllProvs().ToList();
        }

        // GET api/<Proveedor>/5
        [HttpGet("{id}")]
        public Proveedor Get(string id)
        {
            return prvSentence.getProvByNit(id);
        }

        // POST api/<Proveedor>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Proveedor>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Proveedor>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
