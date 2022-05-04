using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mStockProdTerminados
    {
        public int IdStockProdTerminados { get; set; }
        public string Flag_IndustrialComercial { get; set; }
        public string IdOrdenProduccion { get; set; }
        public Nullable<decimal> Numero_Bobina_FardoCajaPqte { get; set; }
        public Nullable<decimal> Cantidad_Kilos { get; set; }
        public Nullable<decimal> Cantidad_Millares { get; set; }
        public Nullable<decimal> IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
    }
}
