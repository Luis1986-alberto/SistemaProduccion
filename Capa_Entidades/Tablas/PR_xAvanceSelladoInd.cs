using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xAvanceSelladoInd
    {
        public PR_xAvanceSelladoInd()
        {
            this.PR_xDetalleAvanceSellaInd = new HashSet<PR_xDetalleAvanceSellaInd>();
        }

        public Nullable<byte> PaquetexFardo { get; set; }
        public Nullable<decimal> MillarxFardo { get; set; }
        public string Observaciones { get; set; }
        public Nullable<short> Diferencia_Dias { get; set; }
        public Nullable<decimal> Peso_Envase { get; set; }
        public Nullable<decimal> Peso_Funda { get; set; }
        public Nullable<decimal> Peso_Caja { get; set; }
        public Nullable<byte> IdCarreta { get; set; }
        public Nullable<decimal> Kilos_Merma { get; set; }
        public Nullable<decimal> Kilos_Faltante { get; set; }
        public Nullable<short> Total_Fardos { get; set; }
        public Nullable<short> Total_Cajas { get; set; }
        public Nullable<int> Total_Paquetes { get; set; }
        public Nullable<decimal> Total_Millares { get; set; }
        public Nullable<decimal> Total_Kg_Bruto { get; set; }
        public Nullable<decimal> Total_Kg_Envase { get; set; }
        public Nullable<decimal> Total_Kg_Funda { get; set; }
        public Nullable<decimal> Total_Kg_Caja { get; set; }
        public Nullable<decimal> Total_Kg_Tinta { get; set; }
        public Nullable<decimal> Total_Kg_Material { get; set; }
        public Nullable<decimal> Total_Kg_Scrap { get; set; }
        public Nullable<decimal> Total_Kg_Troquel { get; set; }
        public Nullable<decimal> Total_Kg_Refile { get; set; }
        public Nullable<decimal> Total_Kg_Perforaciones { get; set; }
        public Nullable<decimal> Total_Cantidad { get; set; }
        public Nullable<decimal> Total_Kg_Neto { get; set; }
        public Nullable<decimal> Total_kg_Fuelle { get; set; }
        public Nullable<decimal> Total_Cantidad_L { get; set; }
        public Nullable<decimal> Total_Millares_L { get; set; }
        public Nullable<decimal> Total_Kg_Neto_L { get; set; }
        public Nullable<System.DateTime> FechaInicio_Sel_CD { get; set; }
        public string NroMaquina_Sel_CD { get; set; }
        public Nullable<decimal> TotalKilos_Sel_CD { get; set; }
        public Nullable<decimal> TotalMillares_Sel_CD { get; set; }
        public Nullable<System.DateTime> FechaTermino_Sel_CD { get; set; }
        public string Observacion_Sel_CD { get; set; }
        public string IdUsuario_Sel_CD { get; set; }
        public string IdUsuario_Sel_PC_CD { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor_Sel_CD { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_aCarreta PR_aCarreta { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceSellaInd> PR_xDetalleAvanceSellaInd { get; set; }
        public virtual PR_xLiquidacionSelladoInd PR_xLiquidacionSelladoInd { get; set; }

    }
}
