using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xProgramacionMezclado
    {
        public PR_xProgramacionMezclado()
        {
            this.PR_xDetalleProgramacionMezclado = new HashSet<PR_xDetalleProgramacionMezclado>();
        }

        public decimal IdProgramacionMezclado { get; set; }
        public Nullable<decimal> IdOrdProd { get; set; }
        public Nullable<byte> IdMezcladora { get; set; }
        public Nullable<byte> IdEstadoFormulacion { get; set; }
        public Nullable<System.DateTime> Fecha_Proceso { get; set; }
        public Nullable<decimal> Capacidad_Cubo { get; set; }
        public Nullable<byte> Total_Cubos { get; set; }
        public string Nota_Programacion_Mezclado { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string IdUsuario_PC { get; set; }
        public Nullable<short> IdTrabajador { get; set; }

        public virtual PR_aEstadoFormulacion PR_aEstadoFormulacion { get; set; }
        public virtual PR_aMezcladora PR_aMezcladora { get; set; }
        public virtual PR_mTrabajador PR_mTrabajador { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleProgramacionMezclado> PR_xDetalleProgramacionMezclado { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
    }
}
