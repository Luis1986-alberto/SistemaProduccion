using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalle_OP
    {
        public byte Item { get; set; }
        public string IdOP_Secundarias { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Total_Kilos { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }

    }
}
