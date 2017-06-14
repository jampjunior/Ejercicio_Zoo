using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ZooApp
{
    public class Db
    {
        private static SqlConnection conexion = null;
        

        public static void Conectar()
        {
            try
            {
                //CADENA DE CONEXIÓN A LA BD
                string cadenaConexion = @"Server=.\sqlexpress;
                                          Database=ZooApp;
                                          User Id=user;
                                          Password=TestUser17;";
                //Creacion de la Conexión
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;
                //Abrimos la conexion 
                conexion.Open();
               
            }
            catch (Exception)
            {
                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    conexion.Dispose();
                    conexion = null;
                }


            }
           
        }

        public static bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public static void Desconectar()
        {
            if (conexion != null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Clasificacion> ClasificacionDeAnimales()
        {
            List<Clasificacion> resultado = new List<Clasificacion>();
            //PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.GetClasificacion";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            //PARA EJECUTAR EL COMANDO  
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                //CREAR LA CLASIFICACION
                Clasificacion clasificacion = new Clasificacion();
                clasificacion.idClasificacion = (long)reader["idClasificacion"];
                clasificacion.denominacion = reader["denominacion"].ToString();
                resultado.Add(clasificacion);

            }    
            return resultado;
        }

        public static List<TiposAnimales> MostrarLosTiposDeAnimales()
        {
            List<TiposAnimales> resultado = new List<TiposAnimales>();
            //PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.GetTiposdeAnimales";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            //PARA EJECUTAR EL COMANDO  
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                //CREAR LA CLASIFICACION
                TiposAnimales tiposdeanimales = new TiposAnimales();
                tiposdeanimales.idTipoAnimal = (long)reader["idTipoAnimal"];
                tiposdeanimales.denominacion = reader["denominacion"].ToString();
                resultado.Add(tiposdeanimales);

            }


            return resultado;

        }

        public static List<Especies> MuestrameLasEspecies()
        {
            List<Especies> resultado = new List<Especies>();
            //PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.GetEspecies";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            //PARA EJECUTAR EL COMANDO  
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                //CREAR LA CLASIFICACION
                Especies especies = new Especies();
                especies.idEspecie = (long)reader["idEspecie"];
                especies.idClasificacion = (long)reader["idClasificacion"];
                especies.idTipoAnimal = (long)reader["idTipoAnimal"];
                especies.nombre = reader["nombre"].ToString();
                especies.nPatas = (short)reader["nPatas"];
                especies.esMascota = (bool)reader["esMascota"];

                resultado.Add(especies);

            }


            return resultado;

        }

        public static List<Clasificacion> ClasificacionPorId(long id)
        {
            List<Clasificacion> resultado = new List<Clasificacion>();

            // PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.GET_Clasificacion_ID";
            // PREPARO EL COMANDO PARA LA BD
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idClasificacion"; //aqui va el nombre del parámetro del sql
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
            while (reader.Read())
            {
                Clasificacion clasificacion = new Clasificacion();
               clasificacion.idClasificacion = (long)reader["idClasificacion"];
                clasificacion.denominacion = reader["denominacion"].ToString();
                // añadiro a la lista que voy
                // a devolver
                resultado.Add(clasificacion);
            }

            return resultado;


        }

        public static List<TiposAnimales> TiposPorId(long id)
        {
            List<TiposAnimales> resultado = new List<TiposAnimales>();

            // PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.GET_TipoAnimal_ID";  
        // PREPARO EL COMANDO PARA LA BD
        SqlCommand comando = new SqlCommand(procedimiento, conexion);
            // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idTipoAnimal"; //aqui va el nombre del parámetro del sql
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
            while (reader.Read())
            {
                TiposAnimales animal = new TiposAnimales();
                animal.idTipoAnimal = (long)reader["idTipoAnimal"];
                animal.denominacion = reader["denominacion"].ToString();
                // añadiro a la lista que voy
                // a devolver
                resultado.Add(animal);
            }

            return resultado;


        }

        public static List<Especies> EspeciesPorId(long id)
        {
            List<Especies> resultado = new List<Especies>();

            // PREPARO EL PROCEDIMIENTO A EJECUTAR
            string procedimiento = "dbo.GET_ESPECIE_ID";
            // PREPARO EL COMANDO PARA LA BD
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            // INDICO QUE LO QUE VOY A EJECUTAR ES UN PA
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idEspecie"; //aqui va el nombre del parámetro del sql
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.SqlValue = id;
            comando.Parameters.Add(parametroId);
            // EJECUTO EL COMANDO
            SqlDataReader reader = comando.ExecuteReader();
            // PROCESO EL RESULTADO Y LO MENTO EN LA VARIABLE
            while (reader.Read())
            {
                Especies especie = new Especies();
                especie.idEspecie = (long)reader["idEspecie"];
                especie.nombre = reader["nombre"].ToString();
                especie.idClasificacion = (long)reader["idClasificacion"];
                especie.idTipoAnimal = (long)reader["idTipoAnimal"];
                especie.nombre = reader["nombre"].ToString();
                especie.nPatas = (short)reader["nPatas"];
                especie.esMascota = (bool)reader["esMascota"];
                resultado.Add(especie);
            }

            return resultado;


        }






    }
}