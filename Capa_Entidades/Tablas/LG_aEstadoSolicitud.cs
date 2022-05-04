using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class LG_aEstadoSolicitud
    {
        public byte IdEstadoSolicitud { get; set; }
        public string Descripcion_EstadoSolicitud { get; set; }

        public LG_aEstadoSolicitud()
        {  }

        public LG_aEstadoSolicitud(byte idestadosolicitud, string descripcion_estadosolicitud)
        {
            this.IdEstadoSolicitud = idestadosolicitud;
            this.Descripcion_EstadoSolicitud = descripcion_estadosolicitud;
        }
    }
}
