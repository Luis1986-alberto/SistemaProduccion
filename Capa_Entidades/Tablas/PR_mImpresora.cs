using System.Collections.Generic;

namespace Capa_Entidades.Tablas
{
    public class PR_mImpresora
    {
        public PR_mImpresora()
        {
            this.PR_mEstandarImpresion = new HashSet<PR_mEstandarImpresion>();
        }

        public short IdMaquina { get; set; }
        public byte IdRodillo { get; set; }
        public byte IdImpresora { get; set; }
        public virtual string Alias_Maquina { get; set; }
        public virtual string Descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_mEstandarImpresion> PR_mEstandarImpresion { get; set; }
        public virtual PR_mMaquina PR_mMaquina { get; set; }
        public virtual PR_aRodillos PR_aRodillos { get; set; }

    }
}
