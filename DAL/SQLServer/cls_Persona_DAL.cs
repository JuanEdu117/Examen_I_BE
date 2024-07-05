using DAL.Interfaces;
using Dapper;
using Entidad.SQLServer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.SQLServer
{
    public class cls_Persona_DAL    : IPersona_DAL
    {
        #region VARIABLE PRIVADA
        private readonly IConfiguration _iConfiguracion;
        #endregion

        #region CONSTRUCTOR
        public cls_Persona_DAL(IConfiguration IConfig)
        {
            _iConfiguracion = IConfig;
        }

       
        #endregion

        #region METODOS
        public List<cls_Persona> ConsultarPersona(cls_Persona Obj_Entidad)
        {
            DynamicParameters parametros = new DynamicParameters();
            /*CREAMOS LOS PARAMETROS*/
            parametros.Add("@FILTRO", Obj_Entidad.iCedula, DbType.Int64, ParameterDirection.Input);

            using (var CNXSQL = new SqlConnection(_iConfiguracion.GetConnectionString("ConexionSQLServer")))
            {
                return (List<cls_Persona>)CNXSQL.Query<cls_Persona>("dbo.Sp_Consultar_Persona", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public bool AgregarPersona(cls_Persona Obj_Entidad)
        {
            DynamicParameters parametros = new DynamicParameters();
            /*CREAMOS LOS PARAMETROS*/
            parametros.Add("@idCedula", Obj_Entidad.iCedula, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@nomb", Obj_Entidad.sNombre, DbType.String, ParameterDirection.Input, 20);
            parametros.Add("@apellido", Obj_Entidad.sApellido, DbType.String, ParameterDirection.Input, 20);
            parametros.Add("@gen", Obj_Entidad.bGenero, DbType.Boolean, ParameterDirection.Input);
            parametros.Add("@nacimiento", Obj_Entidad.dtmFechaNacimiento, DbType.DateTime, ParameterDirection.Input);

            using (var CNXSQL = new SqlConnection(_iConfiguracion.GetConnectionString("ConexionSQLServer")))
            {
                return CNXSQL.Execute("dbo.Sp_Insertar_Persona", parametros, commandType: CommandType.StoredProcedure) > 0;
            }
        }
        public bool ModificarPersona(cls_Persona Obj_Entidad)
        {
            DynamicParameters parametros = new DynamicParameters();
            /*CREAMOS LOS PARAMETROS*/
            parametros.Add("@idCedula", Obj_Entidad.iCedula, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@nomb", Obj_Entidad.sNombre, DbType.String, ParameterDirection.Input, 20);
            parametros.Add("@apellido", Obj_Entidad.sApellido, DbType.String, ParameterDirection.Input, 20);
            parametros.Add("@gen", Obj_Entidad.bGenero, DbType.Boolean, ParameterDirection.Input);
            parametros.Add("@nacimiento", Obj_Entidad.dtmFechaNacimiento, DbType.DateTime, ParameterDirection.Input);

            using (var CNXSQL = new SqlConnection(_iConfiguracion.GetConnectionString("ConexionSQLServer")))
            {
                return CNXSQL.Execute("dbo.Sp_Modificar_Persona", parametros, commandType: CommandType.StoredProcedure) > 0;
            }
        }
        public bool EliminarPersona(cls_Persona Obj_Entidad)
        {
            DynamicParameters parametros = new DynamicParameters();
            /*CREAMOS LOS PARAMETROS*/
            parametros.Add("@idCedula", Obj_Entidad.iCedula, DbType.Int32, ParameterDirection.Input);

            using (var CNXSQL = new SqlConnection(_iConfiguracion.GetConnectionString("ConexionSQLServer")))
            {
                return CNXSQL.Execute("dbo.Sp_Eliminar_Persona", parametros, commandType: CommandType.StoredProcedure) > 0;
            }
        }

        #endregion
    }
}
