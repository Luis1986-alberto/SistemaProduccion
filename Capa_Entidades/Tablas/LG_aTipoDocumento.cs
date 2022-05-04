using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class LG_aTipoDocumento
    {
        public byte IdTipoDocumento { get; set; }
        public string Nombre_TipoDocumento { get; set; }
        public string Sigla_TipoDocumento { get; set; }
        public string Alias_TipoDocumento { get; set; }


        public LG_aTipoDocumento()
        {   }

        public LG_aTipoDocumento(byte idtipodocumento, string nombre_tipodocumento, string sigla_tipodocumeto, string alias_tipodocumento)
        {
            this.IdTipoDocumento = idtipodocumento;
            this.Nombre_TipoDocumento = nombre_tipodocumento;
            this.Sigla_TipoDocumento = sigla_tipodocumeto;
            this.Alias_TipoDocumento = alias_tipodocumento;
        }



    }
}
