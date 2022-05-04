using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xPosicionMaquina
    {
        public PR_xPosicionMaquina()
        {
            this.PR_mCapacidadExtrusion = new HashSet<PR_mCapacidadExtrusion>();
            this.PR_mEstandarExtrusion = new HashSet<PR_mEstandarExtrusion>();
            this.PR_mEstandarImpresion = new HashSet<PR_mEstandarImpresion>();
            this.PR_xDetalleAvanceCorte = new HashSet<PR_xDetalleAvanceCorte>();
            this.PR_xDetalleAvanceExtruInd = new HashSet<PR_xDetalleAvanceExtruInd>();
            this.PR_xDetalleAvanceImpreInd = new HashSet<PR_xDetalleAvanceImpreInd>();
            this.PR_xDetalleAvanceLaminado = new HashSet<PR_xDetalleAvanceLaminado>();
            this.PR_xDetalleAvanceSellaInd = new HashSet<PR_xDetalleAvanceSellaInd>();
            this.PR_xDetalleMermaAvCorteInd = new HashSet<PR_xDetalleMermaAvCorteInd>();
            this.PR_xDetalleMermaAvExtruInd = new HashSet<PR_xDetalleMermaAvExtruInd>();
            this.PR_xDetalleMermaAvImpInd = new HashSet<PR_xDetalleMermaAvImpInd>();
            this.PR_xDetalleMermaAvLamInd = new HashSet<PR_xDetalleMermaAvLamInd>();
            this.PR_xMezcladoIndustrial = new HashSet<PR_xMezcladoIndustrial>();
            this.PR_xOrdenProduccionInd = new HashSet<PR_xOrdenProduccionInd>();
            this.PR_xProgramaCorteInd = new HashSet<PR_xProgramaCorteInd>();
            this.PR_xProgramaExtrusionInd = new HashSet<PR_xProgramaExtrusionInd>();
            this.PR_xProgramaImpresionInd = new HashSet<PR_xProgramaImpresionInd>();
            this.PR_xProgramaLaminadoInd = new HashSet<PR_xProgramaLaminadoInd>();
            this.PR_xProgramaMezclado = new HashSet<PR_xProgramaMezclado>();
            this.PR_xProgramaSelladoInd = new HashSet<PR_xProgramaSelladoInd>();
        }

        public short IdPosicionMaquina { get; set; }
        public string Codigo_Posicion { get; set; }
        public Nullable<short> IdMaquina { get; set; }
        public Nullable<byte> Orden_Posicion_Sistema { get; set; }
        public Nullable<short> IdLocalArea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_mCapacidadExtrusion> PR_mCapacidadExtrusion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_mEstandarExtrusion> PR_mEstandarExtrusion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_mEstandarImpresion> PR_mEstandarImpresion { get; set; }
        public virtual PR_mMaquina PR_mMaquina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceCorte> PR_xDetalleAvanceCorte { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceExtruInd> PR_xDetalleAvanceExtruInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceImpreInd> PR_xDetalleAvanceImpreInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceLaminado> PR_xDetalleAvanceLaminado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceSellaInd> PR_xDetalleAvanceSellaInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvCorteInd> PR_xDetalleMermaAvCorteInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvExtruInd> PR_xDetalleMermaAvExtruInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvImpInd> PR_xDetalleMermaAvImpInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvLamInd> PR_xDetalleMermaAvLamInd { get; set; }
        public virtual PR_xLocalArea PR_xLocalArea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xMezcladoIndustrial> PR_xMezcladoIndustrial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xOrdenProduccionInd> PR_xOrdenProduccionInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramaCorteInd> PR_xProgramaCorteInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramaExtrusionInd> PR_xProgramaExtrusionInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramaImpresionInd> PR_xProgramaImpresionInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramaLaminadoInd> PR_xProgramaLaminadoInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramaMezclado> PR_xProgramaMezclado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramaSelladoInd> PR_xProgramaSelladoInd { get; set; }
    }
}
