using System;
using System.Collections.Generic;

namespace Capa_Entidades.Tablas
{
    public class PR_mTrabajador
    {
        public short IdTrabajador { get; set; }
        public string Codigo_Trabajador { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Ruta_Imagen { get; set; }
        public Nullable<byte> IdTipoTrabajador { get; set; }
        public virtual string Nombre_TipoTrabajador { get; set; }
        public byte IdEmpresa { get; set; }
        public virtual string Nombre_Emoresa { get; set; }
        public short IdLocalArea { get; set; }
        public virtual string Nombre_Area { get; set; }
        public virtual string Nombre_Local { get; set; }
        public byte[] Foto_Trabajador { get; set; }
        public Nullable<byte> IdCargoTrabajador { get; set; }
        public virtual string Nombre_CargoTrabajador { get; set; }


        public virtual PR_aCargoTrabajador PR_aCargoTrabajador { get; set; }
        public virtual PR_aEmpresa PR_aEmpresa { get; set; }
        public virtual PR_aTipoTrabajador PR_aTipoTrabajador { get; set; }
        public virtual PR_xLocalArea PR_xLocalArea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xPedidosIndustriales> PR_xPedidosIndustriales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaSellaInd> PR_xDetalleMermaSellaInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceCorte> PR_xDetalleAvanceCorte { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceExtruInd> PR_xDetalleAvanceExtruInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvExtruInd> PR_xDetalleMermaAvExtruInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceImpreInd> PR_xDetalleAvanceImpreInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceLaminado> PR_xDetalleAvanceLaminado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceMezclado> PR_xDetalleAvanceMezclado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleAvanceSellaInd> PR_xDetalleAvanceSellaInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvImpInd> PR_xDetalleMermaAvImpInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvCorteInd> PR_xDetalleMermaAvCorteInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvLamInd> PR_xDetalleMermaAvLamInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xProgramacionMezclado> PR_xProgramacionMezclado { get; set; }
    }
}
