using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xEstandarIndustrial_Color
    {
        public byte Item { get; set; }
        public Nullable<short> IdEstandarColor { get; set; }
        public decimal IdEstandarIndustrial { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuario_PC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public Nullable<short> IdColor { get; set; }

        public virtual PR_aColor PR_aColor { get; set; }
        public virtual PR_aEstandarColor PR_aEstandarColor { get; set; }
        public virtual PR_mEstandar PR_mEstandar { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
    }
}
