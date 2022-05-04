using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mMotivoScrap
    {
        public PR_mMotivoScrap()
        {
            this.PR_xDetalleMermaAvExtruInd = new HashSet<PR_xDetalleMermaAvExtruInd>();
            this.PR_xDetalleMermaAvImpInd = new HashSet<PR_xDetalleMermaAvImpInd>();
            this.PR_xDetalleMermaSellaInd = new HashSet<PR_xDetalleMermaSellaInd>();
            this.PR_xDetalleMermaAvCorteInd = new HashSet<PR_xDetalleMermaAvCorteInd>();
            this.PR_xDetalleMermaAvLamInd = new HashSet<PR_xDetalleMermaAvLamInd>();
        }

        public short IdMotivoScrap { get; set; }
        public string Motivo_Scrap { get; set; }
        public Nullable<byte> IdArea { get; set; }

        public virtual PR_aArea PR_aArea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvExtruInd> PR_xDetalleMermaAvExtruInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvImpInd> PR_xDetalleMermaAvImpInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaSellaInd> PR_xDetalleMermaSellaInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvCorteInd> PR_xDetalleMermaAvCorteInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaAvLamInd> PR_xDetalleMermaAvLamInd { get; set; }
    }
}
