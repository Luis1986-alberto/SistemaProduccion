using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class LG_aTipoServicioMaquina
    {
        public byte IdTipoServicio { get; set; }
        public string Descripcion_TipoServicio { get; set; }

        public LG_aTipoServicioMaquina()
        {   }

        public LG_aTipoServicioMaquina(byte idtiposervicio, string descripcion_tiposervicio)
        {
            this.IdTipoServicio = idtiposervicio;
            this.Descripcion_TipoServicio = descripcion_tiposervicio;
        }


    }
}
