using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xAvanceImpresionInd
    {
        public PR_xAvanceImpresionInd()
        {
            this.PR_xDetalleAvanceImpreInd = new HashSet<PR_xDetalleAvanceImpreInd>();
        }

        public Nullable<byte> IdEspesorTuco { get; set; }
        public string Observaciones { get; set; }
        public Nullable<short> Diferencia_Dias { get; set; }
        public Nullable<decimal> Gramaje_Tinta { get; set; }
        public Nullable<decimal> Peso_Promedio_Tuco { get; set; }
        public Nullable<byte> IdCarreta { get; set; }
        public Nullable<decimal> Kilos_Pesado_Impreso { get; set; }
        public Nullable<decimal> Kilos_Merma_Impreso { get; set; }
        public Nullable<decimal> Kilos_Faltante_Impreso { get; set; }
        public Nullable<decimal> Kilos_No_Autorizado_Impreso { get; set; }
        public Nullable<decimal> Total_Peso_Neto_Impreso { get; set; }
        public Nullable<decimal> Total_Peso_Tuco_Impreso { get; set; }
        public Nullable<decimal> Total_Kg_Peso_Tinta { get; set; }
        public Nullable<decimal> Total_Kg_Peso_Material { get; set; }
        public Nullable<decimal> Total_Kilometros_Impreso { get; set; }
        public Nullable<decimal> Total_Kg_Scrap_Impreso { get; set; }
        public Nullable<decimal> Factor_Tinta { get; set; }
        public Nullable<decimal> Total_Peso_Bruto_Impreso { get; set; }
        public Nullable<System.DateTime> FechaInicio_Imp_CD { get; set; }
        public Nullable<short> CantidadBobinas_Imp_CD { get; set; }
        public string NroMaquina_Imp_CD { get; set; }
        public Nullable<decimal> TotalKilos_Imp_CD { get; set; }
        public Nullable<System.DateTime> FechaTermino_Imp_CD { get; set; }
        public string Observacion_Imp_CD { get; set; }
        public string IdUsuario_Imp_CD { get; set; }
        public string IdUsuario_Imp_PC_CD { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor_Imp_CD { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_aCarreta PR_aCarreta { get; set; }
        public virtual PR_aEspesorTuco PR_aEspesorTuco { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceImpreInd> PR_xDetalleAvanceImpreInd { get; set; }
        public virtual PR_xLiquidacionImpresionInd PR_xLiquidacionImpresionInd { get; set; }
    }
}
