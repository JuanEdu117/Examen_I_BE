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
        [BsonId]                                    //INDICA SOBRE LA PROPIEDAD AL ESTABLECER
        [BsonRepresentation(BsonType.ObjectId)]     //REPRESENTADA COMO EL TYPE DATO OBJ ID

        [BsonElement("Codigo")]                       //LE PODEMOS CAMBIAR EL NOMBRE POR EL CUAL GUARDAR " "
        public int iCodigo { get; set; }

        [BsonElement("Cantidad Disponible")]
        public int iCant_Disponible {get; set;}

        [BsonElement("Descripción")]
        public string sDescripcion { get; set; }

        [BsonElement("Fecha Caducidad")]
        public DateTime dtmFecha_Caducidad { get; set; }

        [BsonElement("Precio Unitario")]
        public double dbPrecio_Unitario { get; set; }

        public cls_Articulo() 
        {
            iCodigo = 0;
            iCant_Disponible = 0;
            sDescripcion = string.Empty;
            dtmFecha_Caducidad = DateTime.MinValue;
            dbPrecio_Unitario = 0;
        }
    #endregion
}
}
