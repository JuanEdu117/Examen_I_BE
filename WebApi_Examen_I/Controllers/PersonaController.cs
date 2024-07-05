using BLL.Interfaces;
using Entidad.SQLServer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi_Examen_I.Controllers
{
    [ApiController]
    [Route("api/Persona")]
    public class PersonaController : Controller
    {
        #region VARIABLES PRIVADAS
        private IPersona_BLL _IPersona_BLL; //SE INCORPORA LA INTERFACE DEL SQL

        #endregion

        #region CONSTRUCTOR
        public PersonaController(IPersona_BLL iPersona_BLL) 
        {
            _IPersona_BLL = iPersona_BLL;
        }

        #endregion
        public IActionResult Index()
        {
            return View();
        }

        #region SQLServer
        [HttpGet]
        [Route(nameof(ConsultarPersona))]
        public List<cls_Persona> ConsultarPersona() 
        {
            return _IPersona_BLL.ConsultarPersona(new cls_Persona());
        }

        [HttpPost]
        [Route(nameof(AgregarPersona))]
        public bool AgregarPersona(cls_Persona Obj_Persona)
        {
            return _IPersona_BLL.AgregarPersona(Obj_Persona);
        }

        [HttpPut]
        [Route(nameof(ModificarPersona))]
        public bool ModificarPersona([FromHeader] int _iCed, [FromBody] cls_Persona Obj_Persona)
        {
            return _IPersona_BLL.ModificarPersona(new cls_Persona { iCedula = _iCed, sNombre = Obj_Persona.sNombre, sApellido = Obj_Persona.sApellido, bGenero = Obj_Persona.bGenero, dtmFechaNacimiento = Obj_Persona.dtmFechaNacimiento });
        }

        [HttpDelete]
        [Route(nameof(EliminarPersona))]
        public bool EliminarPersona([FromHeader] int _iCed)
        {
            return _IPersona_BLL.EliminarPersona(new cls_Persona { iCedula = _iCed });
        }
        #endregion
    }
}
