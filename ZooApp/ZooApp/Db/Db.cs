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

        public static int Agregaranimal(TiposAnimales TiposAnimales)
        {
            string procedimiento = "dbo.AgregarTipoAnimal";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure; 
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "denominacion";
            parametro.SqlDbType = SqlDbType.NVarChar;
            parametro.SqlValue = TiposAnimales.denominacion; //donde quiero meter los parámetros
            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();


            return filasAfectadas;
        }

        public static int Agregarclasificar(Clasificacion clasificacion)
        {
            string procedimiento = "dbo.AgregarClasificacion";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "denominacion";
            parametro.SqlDbType = SqlDbType.NVarChar;
            parametro.SqlValue = clasificacion.denominacion; 
            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        public static int AgregarEspecie(Especies especie)
        {
            string procedimiento = "dbo.AgregarEspecie";
       
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            ////PK id
            //SqlParameter parametro = new SqlParameter();
            //parametro.ParameterName = "idEspecie";
            //parametro.SqlDbType = SqlDbType.BigInt;
            //parametro.SqlValue = especie.idEspecie;
            //comando.Parameters.Add(parametro);    
            //FK Clasificacion
            SqlParameter parametroClasi = new SqlParameter();
            comando.CommandType = CommandType.StoredProcedure;
            parametroClasi.ParameterName = "idClasificacion";
            parametroClasi.SqlDbType = SqlDbType.BigInt;
            parametroClasi.SqlValue = especie.clasificacion.idClasificacion;
            comando.Parameters.Add(parametroClasi);
            //Tipoanimal
            SqlParameter parametroTipo = new SqlParameter();       
            parametroTipo.ParameterName = "idTipoAnimal";
            parametroTipo.SqlDbType = SqlDbType.BigInt;
            parametroTipo.SqlValue = especie.tipoAnimales.idTipoAnimal;
            comando.Parameters.Add(parametroTipo);
            //Nombre
            SqlParameter parametroNombre = new SqlParameter();           
            parametroNombre.ParameterName = "nombre";
            parametroNombre.SqlDbType = SqlDbType.NVarChar;
            parametroNombre.SqlValue = especie.nombre;
            comando.Parameters.Add(parametroNombre);
            
            // nPatas
            SqlParameter parametroNpatas = new SqlParameter();         
            parametroNpatas.ParameterName = "nPatas";
            parametroNpatas.SqlDbType = SqlDbType.SmallInt;
            parametroNpatas.SqlValue = especie.nPatas;
            comando.Parameters.Add(parametroNpatas);
            
            // EsMascota
            SqlParameter parametroEs = new SqlParameter();
            parametroEs.ParameterName = "esMascota";
            parametroEs.SqlDbType = SqlDbType.Bit;
            parametroEs.SqlValue = especie.esMascota;
            comando.Parameters.Add(parametroEs);



            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        } 

        public static int ActualizarClasi(long id, Clasificacion clasificacion)
        {
            string procedimiento = "dbo.ActualizarClasificacion";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure; //lo que te voy a pasar no es un select y es un PA
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idClasificacion";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = clasificacion.idClasificacion; //donde quiero meter los parámetros  
            comando.Parameters.Add(parametro);
            //poner dos parámetros
            SqlParameter Denominacion = new SqlParameter();
            Denominacion.ParameterName = "denominacion";
            Denominacion.SqlDbType = SqlDbType.NVarChar;
            Denominacion.SqlValue = clasificacion.denominacion;
            comando.Parameters.Add(Denominacion);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int Actualizartipos(long id, TiposAnimales TiposAnimales)
        {
            string procedimiento = "dbo.ActualizarTipoAnimal";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure; //lo que te voy a pasar no es un select y es un PA
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idTipoAnimal";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = TiposAnimales.idTipoAnimal; //donde quiero meter los parámetros  
            comando.Parameters.Add(parametro);
            //poner dos parámetros
            SqlParameter Denominacion = new SqlParameter();
            Denominacion.ParameterName = "denominacion";
            Denominacion.SqlDbType = SqlDbType.NVarChar;
            Denominacion.SqlValue = TiposAnimales.denominacion;
            comando.Parameters.Add(Denominacion);


            int filasAfectadas = comando.ExecuteNonQuery();


            return filasAfectadas;
        }

<<<<<<< HEAD
<<<<<<< HEAD
        public static int ActualizarEspecies(long id, Especies especie)
        {
            string procedimiento = "dbo.ActualizarEspecie";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure; //lo que te voy a pasar no es un select y es un PA
=======
=======
>>>>>>> 0dd318a0b0644d9cbee33daecc7ae28aa5b624ac
        public static int ActualizarClasi(long id, TiposAnimales tipoAnimales)
        {
            string procedimiento = "dbo.ActualizarClasificacion";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure; //lo que te voy a pasar no es un select y es un PA
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idClasificacion";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = clasificacion.idClasificacion; //donde quiero meter los parámetros  
            comando.Parameters.Add(parametro);
            //poner dos parámetros
            SqlParameter Denominacion = new SqlParameter();
            Denominacion.ParameterName = "denominacion";
            Denominacion.SqlDbType = SqlDbType.NVarChar;
            Denominacion.SqlValue = clasificacion.denominacion;
            comando.Parameters.Add(Denominacion);
<<<<<<< HEAD
=======



            int filasAfectadas = comando.ExecuteNonQuery();


            return filasAfectadas;
        }
>>>>>>> 0dd318a0b0644d9cbee33daecc7ae28aa5b624ac



            int filasAfectadas = comando.ExecuteNonQuery();


            return filasAfectadas;
        }


>>>>>>> 0dd318a0b0644d9cbee33daecc7ae28aa5b624ac

            ////PK id
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idEspecie";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = especie.idEspecie;
            comando.Parameters.Add(parametro);
            //FK Clasificacion
            SqlParameter parametroClasi = new SqlParameter();
            comando.CommandType = CommandType.StoredProcedure;
            parametroClasi.ParameterName = "idClasificacion";
            parametroClasi.SqlDbType = SqlDbType.BigInt;
            parametroClasi.SqlValue = especie.clasificacion.idClasificacion;
            comando.Parameters.Add(parametroClasi);
            //Tipoanimal
            SqlParameter parametroTipo = new SqlParameter();
            parametroTipo.ParameterName = "idTipoAnimal";
            parametroTipo.SqlDbType = SqlDbType.BigInt;
            parametroTipo.SqlValue = especie.tipoAnimales.idTipoAnimal;
            comando.Parameters.Add(parametroTipo);
            //Nombre
            SqlParameter parametroNombre = new SqlParameter();
            parametroNombre.ParameterName = "nombre";
            parametroNombre.SqlDbType = SqlDbType.NVarChar;
            parametroNombre.SqlValue = especie.nombre;
            comando.Parameters.Add(parametroNombre);

            // nPatas
            SqlParameter parametroNpatas = new SqlParameter();
            parametroNpatas.ParameterName = "nPatas";
            parametroNpatas.SqlDbType = SqlDbType.SmallInt;
            parametroNpatas.SqlValue = especie.nPatas;
            comando.Parameters.Add(parametroNpatas);

            // EsMascota
            SqlParameter parametroEs = new SqlParameter();
            parametroEs.ParameterName = "esMascota";
            parametroEs.SqlDbType = SqlDbType.Bit;
            parametroEs.SqlValue = especie.esMascota;
            comando.Parameters.Add(parametroEs);

            int filasAfectadas = comando.ExecuteNonQuery();

            return filasAfectadas;
        }

        public static int EliminarClas(long idClasificacion)
        {
            string procedimiento = "dbo.EliminarClasificacion";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idClasificacion";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = idClasificacion; //el objeto de arriba  
            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }
        
        public static int Eliminartipo(long idTipoAnimal)
        {
            string procedimiento = "dbo.EliminarTipoAnimal";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idTipoAnimal";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = idTipoAnimal; //el objeto de arriba  
            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        public static int EliminarEspe(long idEspecie)
        {
            string procedimiento = "dbo.EliminarEspecie";
            SqlCommand comando = new SqlCommand(procedimiento, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "idEspecie";
            parametro.SqlDbType = SqlDbType.BigInt;
            parametro.SqlValue = idEspecie; //el objeto de arriba  
            comando.Parameters.Add(parametro);
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

    }
}