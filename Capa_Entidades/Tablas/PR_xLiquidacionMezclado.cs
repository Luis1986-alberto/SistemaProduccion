using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xLiquidacionMezclado
    {
        public string Flag_ActivoLiquidado { get; set; }
        public Nullable<System.DateTime> Fecha_LiquidacionMezclado { get; set; }
        public Nullable<System.DateTime> Hora_LiquidacionMezclado { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string Codigo_Liquidacion { get; set; }
        public string Observacion { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xAvanceMezclado PR_xAvanceMezclado { get; set; }

    }
}
