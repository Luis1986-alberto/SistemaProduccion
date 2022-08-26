using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_xPedidos_CN
    {
        public static readonly PR_xPedidos_CN _Instancia = new PR_xPedidos_CN();

        public static PR_xPedidos_CN Instancia
        { get { return PR_xPedidos_CN._Instancia; } }

        public List<PR_xPedidosIndustriales>Lista_Pedidos ( string flag_cliente, Int32 idcliente, 
                                                           string flag_rango, DateTime fecha_inicio, DateTime fecha_final)
        {
            return PR_xPedidosIndustriales_CD._Instancia.Lista_Pedidos( flag_cliente, idcliente,flag_rango, fecha_inicio, fecha_final );
        }

        public IEnumerable<PR_xPedidosIndustriales> Traer_PorId(Int32 idpedido)
        {
            return PR_xPedidosIndustriales_CD._Instancia.TraerPorId(idpedido);
        }

        public string Agregar_Pedidos(PR_xPedidosIndustriales pedidosindustriales)
        {
            return PR_xPedidosIndustriales_CD._Instancia.Pedidos_Procesar(pedidosindustriales, "I");
        }

        public string Actualizar_Pedidos(PR_xPedidosIndustriales pedidosindustriales)
        {
            var predicado = Predicates.Field<PR_xPedidosIndustriales>(x => x.IdNumeroPedido, Operator.Eq, pedidosindustriales.IdNumeroPedido);
            if (PR_xPedidosIndustriales_CD.Instancia.FiltroPorUnCampo(predicado).Count() > 0) return "Existe una Orden Produccion con este Pedido ";
            return PR_xPedidosIndustriales_CD._Instancia.Pedidos_Procesar(pedidosindustriales, "U");
        }

        public string Eliminar_Pedidos(Int32 idnumeropedido)
        {
            var predicado = Predicates.Field<PR_xPedidosIndustriales>(x => x.IdNumeroPedido, Operator.Eq, idnumeropedido);
            if (PR_xPedidosIndustriales_CD.Instancia.FiltroPorUnCampo(predicado).Count() > 0) return "Existe una Orden Produccion con este Pedido ";
            return PR_xPedidosIndustriales_CD._Instancia.Eliminar_Pedidos(idnumeropedido);
        }






    }
}
