using BLL.Interfaces;
using DAL.Interfaces;
using Entidad.SQLServer;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace BLL.SQLServer
{
    public class cls_Persona_BLL : IPersona_BLL
    {
        #region VARIABLE PRIVADA
        private readonly IPersona_DAL _iPersona_DAL;
        #endregion

        #region CONSTRUCTOR
        public cls_Persona_BLL(IPersona_DAL IPersona)
        {
            _iPersona_DAL = IPersona;
        }
        #endregion

        #region METODOS
        public List<cls_Persona> ConsultarPersona(cls_Persona Obj_Entidad)
        {
            return _iPersona_DAL.ConsultarPersona(Obj_Entidad);
        }
        public bool AgregarPersona(cls_Persona Obj_Entidad)
        {
            return _iPersona_DAL.AgregarPersona(Obj_Entidad);
        }
        public bool ModificarPersona(cls_Persona Obj_Entidad)
        {
            return _iPersona_DAL.ModificarPersona(Obj_Entidad);
        }
        public bool EliminarPersona(cls_Persona Obj_Entidad)
        {
            return _iPersona_DAL.EliminarPersona(Obj_Entidad);
        }

        #endregion
    }
}
