using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xStockProdTerm_Comercial
    {
        public PR_xStockProdTerm_Comercial()
        {
            this.PR_xKardexCom_PT = new HashSet<PR_xKardexCom_PT>();
        }

        public decimal IdStockProdCom_PT { get; set; }
        public Nullable<decimal> IdCatalogo_Produccion { get; set; }
        public Nullable<decimal> Total_Cantidad_PFCR { get; set; }
        public Nullable<decimal> Total_Kilos { get; set; }
        public Nullable<decimal> Total_Millares { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xKardexCom_PT> PR_xKardexCom_PT { get; set; }

    }
}
