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
        [HttpPost]
        public IHttpActionResult Post([FromBody]Especies especie)
        {
            RespuestaApi respuesta = new RespuestaApi();
            respuesta.Error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarEspecie(especie);

                }
                respuesta.TotalElemento = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                respuesta.TotalElemento = 0;
                respuesta.Error = "Te estoy petando Bro!";
            }

            return Ok(respuesta);

        }

        // PUT: api/Especies/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Especies especie)
        {
            RespuestaApi respuesta = new RespuestaApi();
            respuesta.Error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.ActualizarEspecies(id, especie);

                }
                respuesta.TotalElemento = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {

                respuesta.TotalElemento = 0;
                respuesta.Error = "error al actualizar la especie";
            }

            return Ok(respuesta);



        }

        // DELETE: api/Especies/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            RespuestaApi respuesta = new RespuestaApi();
            respuesta.Error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.EliminarEspe(id);

                }
                respuesta.TotalElemento = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {

                respuesta.TotalElemento = 0;
                respuesta.Error = "Petardaso te salió men";
            }

            return Ok(respuesta);
        }
    }
}
