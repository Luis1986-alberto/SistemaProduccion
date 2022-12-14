using System.Collections.Generic;

namespace Capa_Entidades.Tablas
{
    public class PR_aTipoVenta
    {
        public PR_aTipoVenta()
        {
            this.PR_xPedidosIndustriales = new HashSet<PR_xPedidos>();
        }

        public byte IdTipoVenta { get; set; }
        public string TipoVenta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<PR_xPedidos> PR_xPedidosIndustriales { get; set; }
    }
}
