using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xAvanceExtrusionInd
    {
        public PR_xAvanceExtrusionInd()
        {
            this.PR_xDetalleAvanceExtruInd = new HashSet<PR_xDetalleAvanceExtruInd>();
        }

        public Nullable<byte> IdEspesorTuco { get; set; }
        public string Observaciones { get; set; }
        public Nullable<short> Diferencia_Dias { get; set; }
        public Nullable<decimal> Gramaje_Lineal_Film { get; set; }
        public Nullable<decimal> Peso_Promedio_Tuco { get; set; }
        public Nullable<byte> IdCarreta { get; set; }
        public Nullable<decimal> Kilos_Pesado_Extruido { get; set; }
        public Nullable<decimal> Kilos_Merma { get; set; }
        public Nullable<decimal> Kilos_Faltante { get; set; }
        public Nullable<decimal> Kilos_No_Autorizado { get; set; }
        public Nullable<decimal> Total_Kg_Bruto { get; set; }
        public Nullable<decimal> Total_Kg_Tuco { get; set; }
        public Nullable<decimal> Total_Kg_Neto { get; set; }
        public Nullable<decimal> Total_Kilometros_Bobina { get; set; }
        public Nullable<decimal> Total_Kg_Scrap { get; set; }
        public Nullable<decimal> Total_Kg_Chancaca { get; set; }
        public Nullable<System.DateTime> FechaInicio_Ext_CD { get; set; }
        public Nullable<short> CantidadBobinas_Ext_CD { get; set; }
        public string NroMaquina_Ext_CD { get; set; }
        public Nullable<decimal> TotalKilos_Ext_CD { get; set; }
        public Nullable<System.DateTime> FechaTermino_Ext_CD { get; set; }
        public string Observacion_Ext_CD { get; set; }
        public string IdUsuario_Ext_CD { get; set; }
        public string IdUsuario_Ext_PC_CD { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor_Ext_CD { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_aCarreta PR_aCarreta { get; set; }
        public virtual PR_aEspesorTuco PR_aEspesorTuco { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceExtruInd> PR_xDetalleAvanceExtruInd { get; set; }
        public virtual PR_xLiquidacionExtrusionInd PR_xLiquidacionExtrusionInd { get; set; }

    }
}
