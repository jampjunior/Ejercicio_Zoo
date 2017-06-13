using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooApp.Controllers
{
    public class TipoAnimalController : ApiController
    {
      //  GET: api/TipoAnimal
        public RespuestaApi Get()
        {
            RespuestaApi resultado = new RespuestaApi();
            List<TiposAnimales> TiposAnimales = new List<TiposAnimales>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    TiposAnimales = Db.MostrarLosTiposDeAnimales();
                }
                resultado.Error = "";
                Db.Desconectar();

            }
            catch (Exception)
            {
                resultado.Error = "Te estoy petando Bro!";
            }
            resultado.TotalElemento = TiposAnimales.Count;
            resultado.TiposAnimales = TiposAnimales;
            return resultado;
        }

        // GET: api/TipoAnimal/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TipoAnimal
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TipoAnimal/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TipoAnimal/5
        public void Delete(int id)
        {
        }
    }
}
