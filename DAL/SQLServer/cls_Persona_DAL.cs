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
                return (List<cls_Persona>)CNXSQL.Query<cls_Persona>("dbo.Sp_Consultar_Perfil", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public bool AgregarPersona(cls_Persona Obj_Entidad)
        {
            throw new NotImplementedException();
        }
        public bool ModificarPersona(cls_Persona Obj_Entidad)
        {
            throw new NotImplementedException();
        }
        public bool EliminarPersona(cls_Persona Obj_Entidad)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
