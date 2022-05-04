using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class LG_aPropietario
    {
        public byte IdPropietario { get; set; }
        public string Nombre_Completo { get; set; }


        public LG_aPropietario()
        {  }

        public LG_aPropietario(byte idpropietario, string nombre_completo)
        {
            this.IdPropietario = idpropietario;
            this.Nombre_Completo = nombre_completo;
        }

    }
}
