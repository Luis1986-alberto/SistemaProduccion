using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xPedidos_DetSustrato_LM
    {
        public int item { get; set; }
        public Nullable<short> IdEstandarLaminado { get; set; }
        public Nullable<decimal> Kilos { get; set; }
        public Nullable<decimal> Metros { get; set; }
        public decimal IdNumeroPedido { get; set; }
        public string Numero_Pedido { get; set; }

        public virtual PR_mEstandarLaminado PR_mEstandarLaminado { get; set; }
        public virtual PR_xPedidosIndustriales PR_xPedidosIndustriales { get; set; }

    }
}
