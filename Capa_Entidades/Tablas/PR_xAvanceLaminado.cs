using System;
using System.Collections.Generic;

namespace Capa_Entidades.Tablas
{
    public class PR_xAvanceLaminado
    {
        public PR_xAvanceLaminado()
        {
            this.PR_xDetalleAvanceLaminado = new HashSet<PR_xDetalleAvanceLaminado>();
        }

        public byte IdTipoProcesoLaminado { get; set; }
        public Nullable<decimal> Kilos_Pesado_Procesado { get; set; }
        public Nullable<decimal> Kilos_Merma_Procesado { get; set; }
        public Nullable<decimal> Kilos_Faltante_Procesado { get; set; }
        public Nullable<decimal> Kilos_No_Autorizado_Procesado { get; set; }
        public Nullable<decimal> Total_Peso_Bruto_Procesado { get; set; }
        public Nullable<decimal> Total_Peso_Merma_Procesado { get; set; }
        public Nullable<decimal> Total_Peso_Neto_Procesado { get; set; }
        public Nullable<decimal> Total_Peso_Tuco_Procesado { get; set; }
        public Nullable<decimal> Total_Metros_Procesado { get; set; }
        public string Nota { get; set; }
        public Nullable<byte> IdTipoLaminadoActual { get; set; }
        public Nullable<decimal> Total_Peso_Scrap_Procesado { get; set; }
        public Nullable<decimal> Total_Peso_Adhesivo_Procesado { get; set; }
        public Nullable<decimal> Total_Peso_Correactante_Procesado { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_aTipoProcesoLaminado PR_aTipoProcesoLaminado { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceLaminado> PR_xDetalleAvanceLaminado { get; set; }
    }
}
