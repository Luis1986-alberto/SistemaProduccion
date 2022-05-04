using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xPedidosIndustriales
    {
        public PR_xPedidosIndustriales()
        {
            this.PR_xOrdenProduccionInd = new HashSet<PR_xOrdenProduccionInd>();
            this.PR_xPedidos_DetSustrato_LM = new HashSet<PR_xPedidos_DetSustrato_LM>();
        }

        public string Numero_Pedido { get; set; }
        public string Numero_Orden_Compra { get; set; }
        public Nullable<decimal> IdEstandarIndustrial { get; set; }
        public Nullable<byte> IdEmpresa { get; set; }
        public Nullable<byte> IdCondicionPago { get; set; }
        public Nullable<System.DateTime> Fecha_Pedido { get; set; }
        public Nullable<System.DateTime> Fecha_Entrega { get; set; }
        public Nullable<decimal> Cantidad_Kilos { get; set; }
        public Nullable<decimal> Merma { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public Nullable<decimal> Porcentaje_Merma { get; set; }
        public Nullable<decimal> Total_Kilos { get; set; }
        public string Flag_Ventasx { get; set; }
        public Nullable<decimal> Cantidad_Millares { get; set; }
        public Nullable<decimal> Precio_Kilo { get; set; }
        public Nullable<decimal> Precio_Millar { get; set; }
        public Nullable<decimal> Reajuste_Precio_Kilo { get; set; }
        public Nullable<decimal> Reajuste_Precio_Millar { get; set; }
        public string Flag_IGV { get; set; }
        public string Flag_Incluido_Gastos { get; set; }
        public string Flag_DestararBobinaExtruida { get; set; }
        public string Flag_DestararBobinaImpresa { get; set; }
        public string Flag_PesarxPaquete { get; set; }
        public string Flag_PesarxFardo { get; set; }
        public string Flag_PesarxCaja { get; set; }
        public string Flag_Comision { get; set; }
        public string Nota_Pedido { get; set; }
        public string Flag_NuevoRepetidoHistorico { get; set; }
        public string Flag_NoExisteEspecificacion { get; set; }
        public string IdUsuario { get; set; }
        public string Pedido_General { get; set; }
        public Nullable<byte> IdVentaProducto { get; set; }
        public string Nota { get; set; }
        public string Flag_DestararBobinaLaminado { get; set; }
        public string Flag_DestararBobinaCorte { get; set; }
        public Nullable<decimal> Metros { get; set; }
        public Nullable<System.DateTime> Fecha_Orden_Compra { get; set; }
        public string Observacion_CD { get; set; }
        public string IdUsuario_CD { get; set; }
        public string IdUsuario_PC_CD { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor_CD { get; set; }
        public decimal IdNumeroPedido { get; set; }
        public Nullable<byte> IdCondicionProceso { get; set; }
        public Nullable<short> IdTrabajador { get; set; }

        public virtual LG_aCondicionPago PR_aCondicionPago { get; set; }
        public virtual PR_aCondicionProceso PR_aCondicionProceso { get; set; }
        public virtual PR_aEmpresa PR_aEmpresa { get; set; }
        public virtual PR_mEstandar PR_mEstandar { get; set; }
        public virtual PR_mTrabajador PR_mTrabajador { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xOrdenProduccionInd> PR_xOrdenProduccionInd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xPedidos_DetSustrato_LM> PR_xPedidos_DetSustrato_LM { get; set; }
        public virtual PR_xVentaProducto PR_xVentaProducto { get; set; }
    }
}
