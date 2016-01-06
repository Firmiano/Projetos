using System.Collections.Generic;
using System.Web.Http;
using Api.Hubs;
using Api.Models;

namespace Api.Controllers
{
    public class VisitaController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]Visita visita)
        {
            VisitaHub.PublicarNovaVisita(visita);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
