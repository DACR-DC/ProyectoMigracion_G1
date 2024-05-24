using Microsoft.AspNetCore.Mvc;
using ApiERP.Models;
using ApiERP.Models.Templates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceivableInvoiceController : ControllerBase
    {
        public InvoiceSentences sn = new InvoiceSentences();
        // GET: api/<ReceivableInvoice>
        [HttpGet]
        public IEnumerable<FacturaPorCobrar> Get()
        {
            return this.sn.getAllInvoicesX();
        }

        // GET api/<ReceivableInvoice>/5
        [HttpGet("{id}")]
        public List<FacturaPorCobrar> Get(string id)
        {
            return this.sn.getInvoicesByClient(id);
        }

        // POST api/<ReceivableInvoice>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReceivableInvoice>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReceivableInvoice>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
