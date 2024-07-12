using BLL.Interfaces;
using Entidad.MongoDB;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi_Examen_I.Controllers
{
    [ApiController]
    [Route("api/Articulo")]
    public class ArticuloController : Controller
    {
        #region VARIABLE PRIVADA
        private IArticulo_BLL _IArticulo_BLL;

        #endregion

        #region CONSTRUCTOR
        public ArticuloController(IArticulo_BLL iArticulo_BLL) 
        {
            _IArticulo_BLL = iArticulo_BLL;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

        #region MANTENIMIENTOS
        [HttpGet]
        [Route(nameof(ConsultarArticulo))]
        public List<cls_Articulo> ConsultarArticulo() 
        {
            return _IArticulo_BLL.Consultar();
        }

        [HttpGet]
        [Route(nameof(FiltrarArticulo))]
        public List<cls_Articulo> FiltrarArticulo([FromHeader] string sIdArtic, [FromHeader] int iCod, [FromHeader] string sDescrip )
        {
            return _IArticulo_BLL.ConsultaFiltrada(new cls_Articulo {sId = sIdArtic, iCodigo = iCod, sDescripcion = sDescrip});
        }

        [HttpPost]
        [Route(nameof(AgregarArticulo))]
        public bool AgregarArticulo(cls_Articulo Obj_Articulo) //CON LA INSTRUCCION POST ESTABLECE EL FROM CON DEL BODY "[FROMBODY]"
        {
            return _IArticulo_BLL.AgregarArticulo(Obj_Articulo);
        }

        [HttpPut]
        [Route(nameof(ModificarArticulo))]
        public bool ModificarArticulo([FromHeader] string sIdArtic, [FromBody] cls_Articulo Obj_Articulo) 
        {
            return _IArticulo_BLL.ModificarArticulo(new cls_Articulo {    sId = sIdArtic,
                                                                      iCodigo = Obj_Articulo.iCodigo, 
                                                             iCant_Disponible = Obj_Articulo.iCant_Disponible,       //RECIBO POR EL ENCABEZADO EL "ID"
                                                                 sDescripcion = Obj_Articulo.sDescripcion,           //INICIALIZAMOS VARIABLES CON BASE A LAS PROPIEDADES 
                                                            dbPrecio_Unitario = Obj_Articulo.dbPrecio_Unitario,      //DATOS NUEVOS QUE RECIBO DEL BODY
                                                           dtmFecha_Caducidad = Obj_Articulo.dtmFecha_Caducidad});
        }

        [HttpDelete]
        [Route(nameof(EliminarArticulo))]
        public bool EliminarArticulo([FromHeader] string sIdArtic) 
        {
            return _IArticulo_BLL.EliminarArticulo(new cls_Articulo {sId = sIdArtic });
        }
        #endregion
    }
}
