using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class LG_aLinea
    {
        public Int32 IdLinea { get; set; }
        public string Nombre_Linea { get; set; }
        public string Codigo_Linea { get; set; }
        public DateTime Fecha_Servidor { get; set; }
        public string IdUsuario_PC { get; set; }
        public string IdUsuario { get; set; }

        public LG_aLinea()
        {   }

        public LG_aLinea(Int32 idlinea, string nombre_linea, string codigo_linea)
        {
            this.IdLinea = idlinea;
            this.Nombre_Linea = nombre_linea;
            this.Codigo_Linea = codigo_linea;
        }


    }
}
