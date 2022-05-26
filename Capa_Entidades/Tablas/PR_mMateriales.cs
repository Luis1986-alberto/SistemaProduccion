using System;
using System.Collections.Generic;

namespace Capa_Entidades.Tablas
{
    public class PR_mMateriales
    {
        public PR_mMateriales()
        {
            this.PR_aEstandarColor = new HashSet<PR_aEstandarColor>();
            this.PR_xDetalleInsumo = new HashSet<PR_xDetalleInsumo>();
            this.PR_xDetalleProgramacionMezclado = new HashSet<PR_xDetalleProgramacionMezclado>();
            this.PR_xPedido_Productos = new HashSet<PR_xPedido_Productos>();
            this.PR_xModeloFormulacionGeneral = new HashSet<PR_xModeloFormulacionGeneral>();
            this.PR_xDetalleModeloFormulacion = new HashSet<PR_xDetalleModeloFormulacion>();
        }

        public short IdMaterial { get; set; }
        public Nullable<short> IdMarcaMaterial { get; set; }
        public Nullable<byte> IdTipoMaterialMezclar { get; set; }
        public Nullable<int> IdFabricanteMaterial { get; set; }
        public string Codigo_Insumo { get; set; }
        public string Propiedades { get; set; }
        public string Ruta_Imagen { get; set; }
        public string Codigo_Material { get; set; }
        public Nullable<decimal> Melt_Index { get; set; }
        public Nullable<decimal> Densidad_Material { get; set; }
        public string Aplicaciones { get; set; }
        public string Certificacion { get; set; }
        public Nullable<decimal> Brillo_x_Hanze { get; set; }
        public Nullable<decimal> Opacidad_x_Gloss { get; set; }
        public Nullable<decimal> Relacion_Soplado { get; set; }
        public Nullable<decimal> Temperatura_Masa { get; set; }
        public string Nota_FichaTecMaterial { get; set; }
        public Nullable<decimal> Stock_Minimo { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public Nullable<byte> IdCalificacion_Slip { get; set; }
        public Nullable<byte> IdCalificacion_Antiblock { get; set; }
        public Nullable<byte> IdCalificacion_Antioxidante { get; set; }
        public Nullable<byte> IdCalificacion_Ayuda_Proceso { get; set; }
        public Nullable<byte> IdCalificacion_Termo_Estabilizando { get; set; }
        public Nullable<byte> IdCalificacion_Opacidad { get; set; }
        public Nullable<byte> IdCalificacion_Brillo { get; set; }
        public Nullable<byte> IdCalificacion_Tipo { get; set; }
        public string Propiedades_Film { get; set; }
        public string Aplicaciones_Produccion { get; set; }
        public Nullable<byte> Calificacion { get; set; }
        public Nullable<decimal> Grado_Gloss { get; set; }
        public Nullable<decimal> DM { get; set; }
        public Nullable<decimal> DT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_aEstandarColor> PR_aEstandarColor { get; set; }
        public virtual PR_aFabricanteMaterial PR_aFabricanteMaterial { get; set; }
        public virtual MP_aMarcaMaterial PR_aMarcaMaterial { get; set; }
        public virtual PR_aTipoMaterialMezclar PR_aTipoMaterialMezclar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleInsumo> PR_xDetalleInsumo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleProgramacionMezclado> PR_xDetalleProgramacionMezclado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xPedido_Productos> PR_xPedido_Productos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xModeloFormulacionGeneral> PR_xModeloFormulacionGeneral { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleModeloFormulacion> PR_xDetalleModeloFormulacion { get; set; }
    }
}
