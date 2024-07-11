using DAL.Interfaces;
using Entidad.MongoDB;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.MongoDB
{
    public class cls_Articulo_DAL :IArticulo_DAL
    {
        #region VARIABLES PRIVADAS
        private readonly IConfiguration _IConfig;
        private string _sConexion = string.Empty;

        private MongoClient InstanciaDB;
        private IMongoDatabase _IDataBase;

        private const string _sNombreDB = "Artículos";   //CEDENCIALES
        #endregion

        #region METODOS

        #region PRIVADO
        private void EstablecerConexion() 
        {
            try
            {
                InstanciaDB = new MongoClient(_sConexion);          //ESTA CADEDA INICIALIZA LA INSTANCIA
                _IDataBase = InstanciaDB.GetDatabase(_sNombreDB);   //SOBRE LA INSTANCIA OBTENGA LA BASEDATOS 'NOMMBREDB' EN ESTE CASO 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region PUBLICOS
        public cls_Articulo_DAL(IConfiguration IConfiguracion)      //PRIMERO PASA POR ACA
        {
            _IConfig = IConfiguracion;                                                   //INICIALIZO
            _sConexion = IConfiguracion.GetConnectionString("ConexionMongoDBCompas");   //OBTENGO DESDE UN ARCHIVO DE CONFIG EL CONNECTIONSTRING
        }

        public List<cls_Articulo> Consultar() 
        {
            List<cls_Articulo> _lstResultado = new List<cls_Articulo>();

            try
            {
                EstablecerConexion();
                var Coleccion = _IDataBase.GetCollection<cls_Articulo>("ArticuloResgistro");                        // GENERO COLECCION OBTENGA DATOS DE LA TABLA Y GUARDE
                _lstResultado = Coleccion.Find(doc => true).ToList().OrderBy(orden => orden.sDescripcion).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                if (InstanciaDB != null)
                {
                    InstanciaDB = null;
                }
                if (_IDataBase != null)
                {
                    _IDataBase = null;
                }
            }
            return _lstResultado;
        }
        public List<cls_Articulo> ConsultaFiltrada(cls_Articulo P_Entidad)
        {
            List<cls_Articulo> _lstResultado = new List<cls_Articulo>();

            try
            {
                EstablecerConexion();
                var Coleccion = _IDataBase.GetCollection<cls_Articulo>("ArticuloResgistro");        // GENERO COLECCION OBTENGA DATOS DE LA TABLA Y GUARDE
                
                if (!string.IsNullOrEmpty(P_Entidad.iCodigo.ToString()))               //GENERO LAS CONDICIONES DE CONSULTA
                {
                    _lstResultado = Coleccion.Find(doc => doc.iCodigo.Equals(P_Entidad.iCodigo)).ToList().OrderBy(orden => orden.sDescripcion).ToList();
                }
                else if (!string.IsNullOrEmpty(P_Entidad.dbPrecio_Unitario.ToString()))
                {
                    _lstResultado = Coleccion.Find(doc => doc.dbPrecio_Unitario.Equals(P_Entidad.dbPrecio_Unitario)).ToList().OrderBy(orden => orden.sDescripcion).ToList();
                }
                else if (!string.IsNullOrEmpty(P_Entidad.sDescripcion))
                {                                                           //UTILIZA CONTAINS CONTENGA COSAS QUE AVERIGUE LA PALABRA
                    _lstResultado = Coleccion.Find(doc => doc.sDescripcion.Contains(P_Entidad.sDescripcion)).ToList().OrderBy(orden => orden.sDescripcion).ToList();
                }
                else
                {                                                           //DEVUELVA TODO "COMODIN"
                    _lstResultado = Coleccion.Find(doc => true).ToList().OrderBy(orden => orden.sDescripcion).ToList();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (InstanciaDB != null)
                {
                    InstanciaDB = null;
                }
                if (_IDataBase != null)
                {
                    _IDataBase = null;
                }
            }
            return _lstResultado;
        }
        public bool AgregarArticulo(cls_Articulo P_Entidad) 
        {
            bool _bResultado = false;
            try
            {
                EstablecerConexion();
                var Coleccion = _IDataBase.GetCollection<cls_Articulo>("ArticuloResgistro"); // GENERO COLECCION OBTENGA DATOS DE LA TABLA Y GUARDE
                Coleccion.InsertOne(P_Entidad);                                             //CREA LA INFO AUTOMATICO INSERT UNO A UNO
                _bResultado = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                if (InstanciaDB != null)
                {
                    InstanciaDB = null;
                }
                if (_IDataBase != null)
                {
                    _IDataBase = null;
                }
            }
            return _bResultado;
        }
        public bool ModificarArticulo(cls_Articulo P_Entidad)
        {
            bool _bResultado = false;
            try
            {
                EstablecerConexion();
                var Coleccion = _IDataBase.GetCollection<cls_Articulo>("ArticuloResgistro");                // GENERO COLECCION OBTENGA DATOS DE LA TABLA Y GUARDE
                Coleccion.ReplaceOne(registros => registros.iCodigo.Equals(P_Entidad.iCodigo),P_Entidad);   //INSTRUCCION REPLACE ONE //DE TODOS LOS REGISTROS BUSQUE EL ID                                            //CREA LA INFO AUTOMATICO INSERT UNO A UNO
                _bResultado = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (InstanciaDB != null)
                {
                    InstanciaDB = null;
                }
                if (_IDataBase != null)
                {
                    _IDataBase = null;
                }
            }
            return _bResultado;
        }
        public bool EliminarArticulo(cls_Articulo P_Entidad)
        {
            bool _bResultado = false;
            try
            {
                EstablecerConexion();
                var Coleccion = _IDataBase.GetCollection<cls_Articulo>("ArticuloResgistro");      // GENERO COLECCION OBTENGA DATOS DE LA TABLA Y GUARDE
                Coleccion.DeleteOne(registros => registros.iCodigo.Equals(P_Entidad.iCodigo));   //INTRUCCION DELETE ONE //DE TODOS LOS REGISTROS BUSQUE EL ID                                            //CREA LA INFO AUTOMATICO INSERT UNO A UNO
                _bResultado = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (InstanciaDB != null)
                {
                    InstanciaDB = null;
                }
                if (_IDataBase != null)
                {
                    _IDataBase = null;
                }
            }
            return _bResultado;
        }
        #endregion

        #endregion
    }
}
