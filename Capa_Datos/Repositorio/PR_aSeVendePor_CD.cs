using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class PR_aSeVendePor_CD
    {
        private Inicio Principal = new Inicio();
        private string cadenaconexion = "";
        public static readonly PR_aSeVendePor_CD _Instancia = new PR_aSeVendePor_CD();

        public static PR_aSeVendePor_CD Instancia
        { get { return PR_aSeVendePor_CD._Instancia; } }

        public PR_aSeVendePor_CD()
        {
            Principal.LeerConfiguracion();
            cadenaconexion = Principal.CadenaConexion;
        }






    }
}
