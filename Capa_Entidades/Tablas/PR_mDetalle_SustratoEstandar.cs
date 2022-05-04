using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mDetalle_SustratoEstandar
    {
        public decimal IdEstandarIndustrial { get; set; }
        public int Item { get; set; }
        public string Material { get; set; }
        public string Sustrato { get; set; }
        public string Espesor { get; set; }
        public Nullable<decimal> Gramaje { get; set; }

        public virtual PR_mEstandar PR_mEstandar { get; set; }

    }
}
