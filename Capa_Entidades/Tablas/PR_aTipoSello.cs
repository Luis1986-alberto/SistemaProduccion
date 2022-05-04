using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aTipoSello
    {
        public byte IdTipoSello { get; set; }
        public string Descripcion_TipoSello { get; set; }

        public PR_aTipoSello()
        {  }

        public PR_aTipoSello(byte idTipoSello, string descripcion_TipoSello)
        {
            IdTipoSello = idTipoSello;
            Descripcion_TipoSello = descripcion_TipoSello;
        }

    }
}
