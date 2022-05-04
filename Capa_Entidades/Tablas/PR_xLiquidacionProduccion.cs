using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xLiquidacionProduccion
    {
        public decimal IdLiquidacionProduccion { get; set; }
        public Nullable<System.DateTime> Fecha_Liquidacion { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string Nota_LiquidacionProduccion { get; set; }
        public string IdUsuario_PC { get; set; }
        public string IdUsuario { get; set; }

        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
    }
}
