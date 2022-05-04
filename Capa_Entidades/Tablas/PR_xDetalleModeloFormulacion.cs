using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalleModeloFormulacion
    {
        public decimal IdModeloFormulacion { get; set; }
        public byte IdItem { get; set; }
        public Nullable<decimal> Formula { get; set; }
        public Nullable<decimal> Porcentaje_Formula { get; set; }
        public Nullable<decimal> Numero_Cubos { get; set; }
        public Nullable<decimal> Peso_Saco { get; set; }
        public Nullable<decimal> Total_Kilos { get; set; }
        public Nullable<byte> IdColor { get; set; }
        public Nullable<short> IdMaterial { get; set; }

        public virtual PR_mMateriales PR_mMateriales { get; set; }
        public virtual PR_xModeloFormulacionGeneral PR_xModeloFormulacionGeneral { get; set; }

    }
}
