using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Presentacion.Clases
{
    public class Variables_Globales
    {
        public static string IdUsuario;
        public static Int32 IdPeriodo = 0;
        public static string Periodo_Actual = "";
        public static string Base_Datos = "";
        public static string Servidor = "";
        public static void Cargar_DatosIngresoSistema(string _IdUsuario, Int32 _IdPeriodo, string _Periodo_Actual)
        {
            IdUsuario = "Lqwuiroz";
            IdPeriodo = _IdPeriodo;
            Periodo_Actual = _Periodo_Actual;
        }

        public static void Cargar_DatosServidor(string _BaseDatos, string _Servidor)
        {
            Base_Datos = _BaseDatos;
            Servidor = _Servidor;
        }
    }
}
