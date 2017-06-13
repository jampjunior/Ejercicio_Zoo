using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooApp
{
    public class RespuestaApi
    {
        public int TotalElemento { get; set; }


        public string Error { get; set; }


        public List<Clasificacion> clasificacion { get; set; }

        public List<Especies> especie { get; set; }

        public List<TiposAnimales> TiposAnimales { get; set; }




    }
}