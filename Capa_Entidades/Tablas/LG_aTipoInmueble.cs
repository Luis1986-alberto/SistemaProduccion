using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class LG_aTipoInmueble
    {
        public byte IdTipoInmueble { get; set; }
        public string Tipo_Inmueble { get; set; }

        public LG_aTipoInmueble()
        {  }

        public LG_aTipoInmueble(byte idtipoinmueble, string tipo_inmueble)
        {
            this.IdTipoInmueble = idtipoinmueble;
            this.Tipo_Inmueble = tipo_inmueble;
        }


    }
}
