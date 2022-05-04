using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xOrdenProduccionInd
    {
        public PR_xOrdenProduccionInd()
        {
            this.PR_mAlmacenBobinas = new HashSet<PR_mAlmacenBobinas>();
            this.PR_mAlmacenBobinas_Hist = new HashSet<PR_mAlmacenBobinas_Hist>();
            this.PR_mAlmacenBobinasImpresas = new HashSet<PR_mAlmacenBobinasImpresas>();
            this.PR_mStockProdTerminados = new HashSet<PR_mStockProdTerminados>();
            this.PR_xAvanceCorte = new HashSet<PR_xAvanceCorte>();
            this.PR_xAvanceLaminado = new HashSet<PR_xAvanceLaminado>();
            this.PR_xDetalle_OP = new HashSet<PR_xDetalle_OP>();
            this.PR_xDetalleInsumo = new HashSet<PR_xDetalleInsumo>();
            this.PR_xDetIngProdCom_PT = new HashSet<PR_xDetIngProdCom_PT>();
            this.PR_xHistorialLiquidacionProd = new HashSet<PR_xHistorialLiquidacionProd>();
            this.PR_xLiquidacionLaminado = new HashSet<PR_xLiquidacionLaminado>();
            this.PR_xProgramaCorteInd = new HashSet<PR_xProgramaCorteInd>();
            this.PR_xProgramaExtrusionInd = new HashSet<PR_xProgramaExtrusionInd>();
            this.PR_xProgramaImpresionInd = new HashSet<PR_xProgramaImpresionInd>();
            this.PR_xProgramacionMezclado = new HashSet<PR_xProgramacionMezclado>();
            this.PR_xProgramaLaminadoInd = new HashSet<PR_xProgramaLaminadoInd>();
            this.PR_xProgramaMezclado = new HashSet<PR_xProgramaMezclado>();
            this.PR_xProgramaSelladoInd = new HashSet<PR_xProgramaSelladoInd>();
        }

        public string IdOrdenProduccionInd { get; set; }
        public string Nota_OrdenProduccionInd { get; set; }
        public string Numero_Pedido { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public Nullable<byte> IdPeriodo { get; set; }
        public string Prefijo { get; set; }
        public Nullable<decimal> Nro_MP { get; set; }
        public Nullable<short> IdPosicionMaquina { get; set; }
        public Nullable<byte> Flag_Produccion { get; set; }
        public Nullable<decimal> Ordenando { get; set; }
        public decimal IdOrdProd { get; set; }
        public Nullable<decimal> IdNumeroPedido { get; set; }
        public Nullable<byte> IdCondicionProceso { get; set; }

        public virtual PR_aCondicionProceso PR_aCondicionProceso { get; set; }
        public virtual PR_aPeriodo PR_aPeriodo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_mAlmacenBobinas> PR_mAlmacenBobinas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_mAlmacenBobinas_Hist> PR_mAlmacenBobinas_Hist { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_mAlmacenBobinasImpresas> PR_mAlmacenBobinasImpresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_mStockProdTerminados> PR_mStockProdTerminados { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xAvanceAlmacenPT PR_xAvanceAlmacenPT { get; set; }
        public virtual PR_xAvanceCalidad PR_xAvanceCalidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xAvanceCorte> PR_xAvanceCorte { get; set; }
        public virtual PR_xAvanceDespacho PR_xAvanceDespacho { get; set; }
        public virtual PR_xAvanceExtrusionInd PR_xAvanceExtrusionInd { get; set; }
        public virtual PR_xAvanceImpresionInd PR_xAvanceImpresionInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xAvanceLaminado> PR_xAvanceLaminado { get; set; }
        public virtual PR_xAvanceMezclado PR_xAvanceMezclado { get; set; }
        public virtual PR_xAvanceSelladoInd PR_xAvanceSelladoInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalle_OP> PR_xDetalle_OP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleInsumo> PR_xDetalleInsumo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetIngProdCom_PT> PR_xDetIngProdCom_PT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xHistorialLiquidacionProd> PR_xHistorialLiquidacionProd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xLiquidacionLaminado> PR_xLiquidacionLaminado { get; set; }
        public virtual PR_xMezcladoIndustrial PR_xMezcladoIndustrial { get; set; }
        public virtual PR_xPedidosIndustriales PR_xPedidosIndustriales { get; set; }
        public virtual PR_xPosicionMaquina PR_xPosicionMaquina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramaCorteInd> PR_xProgramaCorteInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramaExtrusionInd> PR_xProgramaExtrusionInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramaImpresionInd> PR_xProgramaImpresionInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramacionMezclado> PR_xProgramacionMezclado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramaLaminadoInd> PR_xProgramaLaminadoInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramaMezclado> PR_xProgramaMezclado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramaSelladoInd> PR_xProgramaSelladoInd { get; set; }
    }
}
