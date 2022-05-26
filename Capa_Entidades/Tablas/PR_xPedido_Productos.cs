using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xPedido_Productos
    {
        public decimal IdPedidoProducto { get; set; }
        public string Numero_Pedido { get; set; }
        public string Lote_Material { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuario_PC { get; set; }
        public Nullable<byte> IdEmpresa_Compras { get; set; }
        public Nullable<short> IdMaterial { get; set; }

        public virtual PR_mMateriales PR_mMateriales { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }

    }
}
