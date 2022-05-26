using System;
using System.Collections.Generic;

namespace Capa_Entidades.Tablas
{
    public class PR_xIngProdCom_PT
    {
        public PR_xIngProdCom_PT()
        {
            this.PR_xDetIngProdCom_PT = new HashSet<PR_xDetIngProdCom_PT>();
        }

        public decimal IdIngProdComercial { get; set; }
        public Nullable<decimal> IdCatalogo_Produccion { get; set; }
        public Nullable<byte> IdTipoIngreso_PT { get; set; }
        public Nullable<decimal> Total_Cantidad_PFCR_Ing { get; set; }
        public Nullable<decimal> Total_Millares_Ing { get; set; }
        public Nullable<decimal> Total_Kilos_Ing { get; set; }
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        public string Nota_Ingreso_PT { get; set; }
        public string IdUsuario_PC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string IdUsuario { get; set; }

        public virtual LG_aTipoIngreso PR_aTipoIngreso_PT { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetIngProdCom_PT> PR_xDetIngProdCom_PT { get; set; }
    }
}
