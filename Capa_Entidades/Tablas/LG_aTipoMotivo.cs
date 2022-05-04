using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class LG_aTipoMotivo
    {
        public Int32 IdTipoMotivo { get; set; }
        public string TipoMotivo { get; set; }

        public LG_aTipoMotivo()
        {   }

        public LG_aTipoMotivo(Int32 idtipomotivo, string tipomotivo)
        {
            this.IdTipoMotivo = idtipomotivo;
            this.TipoMotivo = tipomotivo;
        }

    }
}
