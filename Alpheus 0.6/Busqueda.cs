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
        }

        [Serializable()]
        public class GridVDisp
        { 
            public string NoSerieDisp { get; set; }
            public string TipoDisp { get; set; }
            public string MarcaDisp { get; set; }
            public string ModeloDisp { get; set; }
            public string NoInventarioDisp { get; set; }
        }

        [Serializable()]
        public class Mantenimiento
        {
            public string Folio { get; set; }
            public string Nombre { get; set; }
            public string Area { get; set; }
            public string Marca { get; set; }
            public string NoSerie { get; set; }
            public string NoInventario { get; set; }
            public string Modelo { get; set; }
            public string Servicio { get; set; }
            public string Tipo { get; set; }
            public string DescripcionTecnica { get; set; }
            public string DescripcionSoporte { get; set; }
        }

        [Serializable()]
        public class Cambio
        {
            public string Folio { get; set; }
            public string Nombre { get; set; }
            public string Area { get; set; }
            public string MarcaRetira { get; set; }
            public string MarcaEntrega { get; set; }
            public string NoSerieRetira { get; set; }
            public string NoInventarioRetira { get; set; }
            public string ModeloRetira {get; set; }
            public string NoSerieEntrega { get; set; }
            public string NoInventarioEntrega { get; set; }
            public string ModeloEntrega { get; set; }
            public string Razon { get; set; }
            public string TipoRetira { get; set; }
            public string TipoEntrega { get; set; }
        }
    }
}