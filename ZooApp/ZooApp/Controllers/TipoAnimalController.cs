﻿using System;
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
        public RespuestaApi Get(long id)
        {
            RespuestaApi resultado = new RespuestaApi();
            List<TiposAnimales> tipo = new List<TiposAnimales>();
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    tipo = Db.TiposPorId(id);

                }
                resultado.Error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.Error = "Te estoy petando Bro!";
            }
            resultado.TotalElemento = tipo.Count;
            resultado.TiposAnimales = tipo;
            return resultado;
        }

        // POST: api/TipoAnimal
        [HttpPost]
         public IHttpActionResult Post([FromBody]TiposAnimales TiposAnimales)
        {
            RespuestaApi respuesta = new RespuestaApi();
            respuesta.Error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.Agregaranimal(TiposAnimales);

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

        // PUT: api/TipoAnimal/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]TiposAnimales TiposAnimales)
        {
            RespuestaApi respuesta = new RespuestaApi();
            respuesta.Error = "";
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {


                    filasAfectadas = Db.Actualizartipos(id, TiposAnimales);

                    

                }
                respuesta.TotalElemento = filasAfectadas;
                Db.Desconectar();
            }
            catch (Exception ex)
            {

                respuesta.TotalElemento = 0;
                respuesta.Error = "error al actualizar la marca";
            }

            return Ok(respuesta);



        }

        // DELETE: api/TipoAnimal/5
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
                    filasAfectadas = Db.Eliminartipo(id);
                }
                respuesta.TotalElemento = filasAfectadas;
            }
            catch (Exception ex)
            {

                respuesta.TotalElemento = 0;
                respuesta.Error = "Te estoy pentando men";
            }
            return Ok(respuesta);
        }


             





    }
}
