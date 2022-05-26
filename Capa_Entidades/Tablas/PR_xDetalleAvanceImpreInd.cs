using System;
using System.Collections.Generic;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalleAvanceImpreInd
    {
        public PR_xDetalleAvanceImpreInd()
        {
            this.PR_xDetalleMermaAvImpInd = new HashSet<PR_xDetalleMermaAvImpInd>();
        }

        public decimal Numero_Bobina_Impresa { get; set; }
        public Nullable<short> Flag_Turno { get; set; }
        public Nullable<System.DateTime> Fecha_Bobina { get; set; }
        public Nullable<System.DateTime> Hora_Inicio_Bobina { get; set; }
        public Nullable<System.DateTime> Hora_Termino_Bobina { get; set; }
        public Nullable<short> IdPosicionMaquina { get; set; }
        public Nullable<decimal> Numero_Bobina1_Impreso { get; set; }
        public Nullable<decimal> Numero_Bobina2_Impreso { get; set; }
        public Nullable<decimal> Numero_Bobina3_Impreso { get; set; }
        public Nullable<decimal> Peso_Neto_Impresion { get; set; }
        public Nullable<decimal> Peso_Tuco_Impreso { get; set; }
        public Nullable<decimal> Peso_Tinta_Impreso { get; set; }
        public Nullable<decimal> Peso_Material_Impreso { get; set; }
        public Nullable<decimal> m_Impreso { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public Nullable<decimal> Peso_Scrap_Impreso { get; set; }
        public Nullable<decimal> Peso_Bruto_Impresion { get; set; }
        public string Codigo_Barra { get; set; }
        public Nullable<byte> IdCarreta { get; set; }
        public Nullable<short> Flag_LiquidacionScrap { get; set; }
        public Nullable<short> Flag_LiquidacionProduccion { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }
        public Nullable<short> IdTrabajador { get; set; }

        public virtual PR_aCarreta PR_aCarreta { get; set; }
        public virtual PR_mTrabajador PR_mTrabajador { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xAvanceImpresionInd PR_xAvanceImpresionInd { get; set; }
        public virtual PR_xPosicionMaquina PR_xPosicionMaquina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvImpInd> PR_xDetalleMermaAvImpInd { get; set; }
    }
}
