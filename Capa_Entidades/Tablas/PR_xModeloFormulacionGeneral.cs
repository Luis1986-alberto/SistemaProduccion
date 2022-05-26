using System;
using System.Collections.Generic;

namespace Capa_Entidades.Tablas
{
    public class PR_xModeloFormulacionGeneral
    {
        public PR_xModeloFormulacionGeneral()
        {
            this.PR_xDetalleModeloFormulacion = new HashSet<PR_xDetalleModeloFormulacion>();
        }

        public decimal IdModeloFormulacion { get; set; }
        public string Nota_General_Modelo { get; set; }
        public Nullable<decimal> IdEstandarIndustrial { get; set; }
        public Nullable<decimal> Numero_Cubos { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<decimal> Total_Kilos_General { get; set; }
        public string IdUsuario_PC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string Version { get; set; }
        public Nullable<short> IdMaterial { get; set; }

        public virtual PR_mEstandar PR_mEstandar { get; set; }
        public virtual PR_mMateriales PR_mMateriales { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleModeloFormulacion> PR_xDetalleModeloFormulacion { get; set; }
    }
}
