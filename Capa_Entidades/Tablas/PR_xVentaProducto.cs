using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xVentaProducto
    {
        public PR_xVentaProducto()
        {
            this.PR_xPedidosIndustriales = new HashSet<PR_xPedidosIndustriales>();
        }

        public byte IdVentaProducto { get; set; }
        public string TipoVenta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xPedidosIndustriales> PR_xPedidosIndustriales { get; set; }
    }
}
