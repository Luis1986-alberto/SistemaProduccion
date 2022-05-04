using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xLiquidacionLaminado
    {
        public byte IdTipoLaminado { get; set; }
        public string Flag_ActivoLiquidado { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_LiquidacionLaminado { get; set; }
        public Nullable<System.DateTime> Hora_LiquidacionLaminado { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string Codigo_Liquidacion { get; set; }
        public string Observacion { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_aTipoLaminacion PR_aTipoLaminacion { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }

    }
}
