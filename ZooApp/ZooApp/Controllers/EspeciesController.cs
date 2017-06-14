using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooApp.Controllers
{
    public class EspeciesController : ApiController
    {
        // GET: api/Especies
        public RespuestaApi Get()
        {
            RespuestaApi resultado = new RespuestaApi();
            List<Especies> especie = new List<Especies>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    especie = Db.MuestrameLasEspecies();
                }
                resultado.Error = "";
                Db.Desconectar();

            }
            catch (Exception)
            {
                resultado.Error = "Te estoy petando Bro!";
            }
            resultado.TotalElemento = especie.Count;
            resultado.especie = especie;
            return resultado;
        }

        // GET: api/Especies/5
        public RespuestaApi Get(long id)
        {
            RespuestaApi resultado = new RespuestaApi();
            List<Especies> tipos = new List<Especies>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    tipos = Db.EspeciesPorId(id);

                }
                resultado.Error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.Error = "Te estoy petando Bro!";
            }
            resultado.TotalElemento = tipos.Count;
            resultado.especie = tipos;
            return resultado;
        }

        // POST: api/Especies
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Especies/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Especies/5
        public void Delete(int id)
        {
        }
    }
}
