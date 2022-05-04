using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xAvanceMezclado
    {
        public PR_xAvanceMezclado()
        {
            this.PR_xDetalleAvanceMezclado = new HashSet<PR_xDetalleAvanceMezclado>();
        }

        public Nullable<short> Dias_Restantes { get; set; }
        public Nullable<decimal> Total_Material_MEZ { get; set; }
        public Nullable<decimal> Total_Material_FAL { get; set; }
        public Nullable<decimal> Total_Material_No_AUT { get; set; }
        public Nullable<decimal> Total_Nº_Tolvas { get; set; }
        public Nullable<decimal> Total_Kilos { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string Nota_Mezclado { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceMezclado> PR_xDetalleAvanceMezclado { get; set; }
        public virtual PR_xLiquidacionMezclado PR_xLiquidacionMezclado { get; set; }
    }
}
