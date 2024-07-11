using Entidad.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IArticulo_BLL
    {
        List<cls_Articulo> Consultar();
        List<cls_Articulo> ConsultaFiltrada(cls_Articulo P_Entidad);
        bool AgregarArticulo(cls_Articulo P_Entidad);
        bool ModificarArticulo(cls_Articulo P_Entidad);
        bool EliminarArticulo(cls_Articulo P_Entidad);
    }
}
