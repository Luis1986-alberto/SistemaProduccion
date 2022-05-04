using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalleAvanceLaminado
    {
        public PR_xDetalleAvanceLaminado()
        {
            this.PR_xDetalleMermaAvLamInd = new HashSet<PR_xDetalleMermaAvLamInd>();
        }

        public byte IdTipoProcesoLaminado { get; set; }
        public decimal Numero_Bobina_Laminado { get; set; }
        public Nullable<short> IdPosicionMaquina { get; set; }
        public Nullable<System.DateTime> Fecha_Bobina { get; set; }
        public Nullable<decimal> Peso_Bruto_Procesado { get; set; }
        public Nullable<decimal> Peso_Tuco_Procesado { get; set; }
        public Nullable<decimal> Peso_Neto_Procesado { get; set; }
        public Nullable<decimal> Metros_Procesado { get; set; }
        public string Codigo_Master1 { get; set; }
        public Nullable<decimal> Peso_Neto_Master1 { get; set; }
        public Nullable<decimal> Metros_Master1 { get; set; }
        public string Codigo_Master2 { get; set; }
        public Nullable<decimal> Peso_Neto_Master2 { get; set; }
        public Nullable<decimal> Metros_Master2 { get; set; }
        public string Observacion { get; set; }
        public Nullable<short> Flag_Liquidacion_Scrap { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuario_PC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public Nullable<decimal> Peso_Scrap { get; set; }
        public Nullable<short> Flag_Turno { get; set; }
        public string Codigo_Barra { get; set; }
        public Nullable<System.DateTime> Hora { get; set; }
        public Nullable<decimal> Peso_Adhesivo { get; set; }
        public Nullable<decimal> Peso_Correactante { get; set; }
        public Nullable<decimal> Peso_Mermas { get; set; }
        public Nullable<byte> IdTipoLaminadoActual { get; set; }
        public Nullable<short> Flag_LiquidacionProduccion { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }
        public Nullable<short> IdTrabajador { get; set; }

        public virtual PR_mTrabajador PR_mTrabajador { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xAvanceLaminado PR_xAvanceLaminado { get; set; }
        public virtual PR_xPosicionMaquina PR_xPosicionMaquina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvLamInd> PR_xDetalleMermaAvLamInd { get; set; }
    }
}
