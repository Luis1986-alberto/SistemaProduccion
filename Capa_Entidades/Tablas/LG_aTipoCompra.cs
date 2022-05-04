using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class LG_aTipoCompra
    {
        public byte IdTipoCompra { get; set; }
        public string Descripcion_TipoCompra { get; set; }

        public LG_aTipoCompra()
        {   }

        public LG_aTipoCompra(byte idtipocompra, string descripcion_tipocompra)
        {
            this.IdTipoCompra = idtipocompra;
            this.Descripcion_TipoCompra = descripcion_tipocompra;
        }


    }
}
