using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpheus_0._6
{
    public class Busqueda
    { 
        [Serializable()]
        public class GridV
        {
            public string NoSerie { get; set; }
            public string Tipo { get; set; }
            public string Usuario { get; set; }
            public string Nombre { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public string RAM { get; set; }
            public string DiscoDuro { get; set; }
            public string SO { get; set; }
            public string Office { get; set; }
            public string Procesador { get; set; }
            public string NoInventario { get; set; }
            //public string Dat2;
        }
    }
}