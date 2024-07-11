using BLL.Interfaces;
using DAL.Interfaces;
using Entidad.MongoDB;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace BLL.MongoDB
{
    public class cls_Articulo_BLL : IArticulo_BLL
    {
        #region VARIABLE PRIVADA
        private IArticulo_DAL _IArticulo_DAL;
        #endregion

        #region CONSTRUCTOR
        public cls_Articulo_BLL(IArticulo_DAL iArticulo_DAL) 
        {
            _IArticulo_DAL = iArticulo_DAL;
        }
        #endregion

        #region METODOS
        public List<cls_Articulo> Consultar()
        {
            return _IArticulo_DAL.Consultar();
        }
        public List<cls_Articulo> ConsultaFiltrada(cls_Articulo P_Entidad)
        {
            return _IArticulo_DAL.ConsultaFiltrada(P_Entidad);
        }
        public bool AgregarArticulo(cls_Articulo P_Entidad)
        {
            return _IArticulo_DAL.AgregarArticulo(P_Entidad);
        }
        public bool ModificarArticulo(cls_Articulo P_Entidad)
        {
            return _IArticulo_DAL.ModificarArticulo(P_Entidad);
        }
        public bool EliminarArticulo(cls_Articulo P_Entidad)
        {
            return _IArticulo_DAL.EliminarArticulo(P_Entidad);
        }
        #endregion
    }
}
