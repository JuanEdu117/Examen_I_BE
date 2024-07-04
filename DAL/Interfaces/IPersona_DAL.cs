using Entidad.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPersona_DAL
    {
        List<cls_Persona> ConsultarPersona(cls_Persona Obj_Entidad);
        bool AgregarPersona(cls_Persona Obj_Entidad);
        bool ModificarPersona(cls_Persona Obj_Entidad);
        bool EliminarPersona(cls_Persona Obj_Entidad);
    }
}
