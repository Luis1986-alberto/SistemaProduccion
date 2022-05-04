using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalleAvanceExtruInd
    {
        public PR_xDetalleAvanceExtruInd()
        {
            this.PR_xDetalleMermaAvExtruInd = new HashSet<PR_xDetalleMermaAvExtruInd>();
        }

        public decimal Numero_Bobina { get; set; }
        public Nullable<System.DateTime> Fecha_Bobina { get; set; }
        public Nullable<System.DateTime> Hora_Inicio_Bobina { get; set; }
        public Nullable<short> IdPosicionMaquina { get; set; }
        public Nullable<decimal> Peso_Bruto_Bobina { get; set; }
        public Nullable<decimal> Peso_Tuco { get; set; }
        public Nullable<decimal> Peso_Neto { get; set; }
        public Nullable<decimal> Metros_Bobina { get; set; }
        public Nullable<decimal> Gramaje_Lineal_Bobina { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string Codigo_Barra { get; set; }
        public Nullable<short> Flag_Turno { get; set; }
        public Nullable<short> Flag_LiquidacionScrap { get; set; }
        public Nullable<short> Flag_LiquidacionProduccion { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }
        public Nullable<byte> IdEstadoCalificacion_CC { get; set; }
        public Nullable<byte> IdMotivoObservacion_CC { get; set; }
        public string IdUsuario_CC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor_CC { get; set; }
        public string IdUsuario_PC_CC { get; set; }
        public string Nota_CC { get; set; }
        public Nullable<short> IdTrabajador { get; set; }

        public virtual PR_aEstadoCalificacion_CC PR_aEstadoCalificacion_CC { get; set; }
        public virtual PR_aMotivoObservacion_CC PR_aMotivoObservacion_CC { get; set; }
        public virtual PR_mTrabajador PR_mTrabajador { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xAvanceExtrusionInd PR_xAvanceExtrusionInd { get; set; }
        public virtual PR_xPosicionMaquina PR_xPosicionMaquina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvExtruInd> PR_xDetalleMermaAvExtruInd { get; set; }
    }
}
