using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class LG_aInmueble
    {
        public Int32 IdInmueble { get; set; }
        public string Codigo_Predio { get; set; }
        public string Direccion_Predial { get; set; }

        public LG_aInmueble()
        {   }

        public LG_aInmueble(Int32 idinmueble, string codigo_predio, string direccion_predial)
        {
            this.IdInmueble = idinmueble;
            this.Codigo_Predio = codigo_predio;
            this.Direccion_Predial = direccion_predial;
        }


    }
}
