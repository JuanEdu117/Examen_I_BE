using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidad.MongoDB
{
    public class cls_Articulo
    {
        #region VARIABLES PUBLICAS
        
        public int iCodigo { get; set; }
        public int iCant_Disponible {get; set;}
        public string sDescripcion { get; set; }
        public DateTime dtmFecha_Caducidad { get; set; }
        public double dbPrecio_Unitario { get; set; }
    #endregion
}
}
