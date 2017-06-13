﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooApp.Controllers
{
    public class ClasificacionController : ApiController
    {
        // GET: api/Clasificacion
        public RespuestaApi Get()
        {
            RespuestaApi resultado = new RespuestaApi();
            List<Clasificacion> clasificacion = new List<Clasificacion>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    clasificacion = Db.clasificacion();
                }
                resultado.Error = "";
                Db.Desconectar();

            }
            catch (Exception)
            {
                resultado.Error = "Te estoy petando Bro!";
            }
            resultado.TotalElemento = clasificacion.Count;
            resultado.clasificacion = clasificacion;
            return resultado;
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
