using System;
using System.Collections.Generic;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalleAvanceCorte
    {
        public PR_xDetalleAvanceCorte()
        {
            this.PR_xDetalleMermaAvCorteInd = new HashSet<PR_xDetalleMermaAvCorteInd>();
        }

        public byte IdTipoProcesoCorte { get; set; }
        public decimal Numero_Bobina_Corte { get; set; }
        public Nullable<short> IdPosicionMaquina { get; set; }
        public Nullable<System.DateTime> Fecha_Bobina { get; set; }
        public Nullable<decimal> Peso_Bruto_Procesado { get; set; }
        public Nullable<decimal> Peso_Tuco_Procesado { get; set; }
        public Nullable<decimal> Peso_Neto_Procesado { get; set; }
        public Nullable<decimal> Metros_Procesado { get; set; }
        public Nullable<decimal> Peso_Scrap_Procesado { get; set; }
        public Nullable<decimal> Pallet { get; set; }
        public string Codigo_Master1 { get; set; }
        public Nullable<decimal> Peso_Neto_Master1 { get; set; }
        public Nullable<decimal> Metros_Master1 { get; set; }
        public string Codigo_Master2 { get; set; }
        public Nullable<decimal> Peso_Neto_Master2 { get; set; }
        public Nullable<decimal> Metros_Master2 { get; set; }
        public string Observacion { get; set; }
        public Nullable<short> Flag_Turno { get; set; }
        public Nullable<short> Flag_Liquidacion_Scrap { get; set; }
        public string IdUsuario_PC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string Codigo_Barra { get; set; }
        public Nullable<short> Flag_LiquidacionProduccion { get; set; }
        public string IdUsuario { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }
        public Nullable<short> IdTrabajador { get; set; }

        public virtual PR_mTrabajador PR_mTrabajador { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xAvanceCorte PR_xAvanceCorte { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvCorteInd> PR_xDetalleMermaAvCorteInd { get; set; }
        public virtual PR_xPosicionMaquina PR_xPosicionMaquina { get; set; }
    }
}
