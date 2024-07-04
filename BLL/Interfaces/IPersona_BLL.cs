using Entidad.SQLServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IPersona_BLL
    {
        List<cls_Persona> ConsultarPersona(cls_Persona Obj_Entidad);
        bool AgregarPersona(cls_Persona Obj_Entidad);
        bool ModificarPersona(cls_Persona Obj_Entidad);
        bool EliminarPersona(cls_Persona Obj_Entidad);
    }
}
