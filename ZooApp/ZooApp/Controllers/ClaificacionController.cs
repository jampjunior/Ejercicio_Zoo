using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooApp.Controllers
{
    public class ClaificacionController : ApiController
    {
        // GET: api/Claificacion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Claificacion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Claificacion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Claificacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Claificacion/5
        public void Delete(int id)
        {
        }
    }
}
