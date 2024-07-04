using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLServer
{
    public class cls_Persona_DAL
    {
        #region VARIABLES PUBLICAS
        public int iCedula {get;set;}
        public string sNombre { get; set; }
        public string sApellido { get; set; }
        public bool bGenero { get; set; }
        public DateTime dtmFechaNacimiento { get; set; }

        public cls_Persona_DAL()
        {
            iCedula = 0;
            sNombre = string.Empty;
            sApellido = string.Empty;
            bGenero = true;
            dtmFechaNacimiento = DateTime.MinValue;
        }
        #endregion
    }
}
