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

        public List<PR_xPedidos>Lista_Pedidos ( string flag_cliente, Int32 idcliente, 
                                                           string flag_rango, DateTime fecha_inicio, DateTime fecha_final)
        {
            return PR_xPedidos_CD._Instancia.Lista_Pedidos( flag_cliente, idcliente,flag_rango, fecha_inicio, fecha_final );
        }

        public IEnumerable<PR_xPedidos> Traer_PorId(Int32 idpedido)
        {
            return PR_xPedidos_CD._Instancia.TraerPorId(idpedido);
        }

        public string Agregar_Pedidos(PR_xPedidos pedidos)
        {
            return PR_xPedidos_CD._Instancia.Pedidos_Procesar(pedidos, "I");
            
        }

        public string Actualizar_Pedidos(PR_xPedidos pedidos)
        {
            var predicado = Predicates.Field<PR_xPedidos>(x => x.IdNumeroPedido, Operator.Eq, pedidos.IdNumeroPedido);
            if (PR_xPedidos_CD.Instancia.FiltroPorUnCampo(predicado).Count() > 0) return "Existe una Orden Produccion con este Pedido ";
            return PR_xPedidos_CD._Instancia.Pedidos_Procesar(pedidos, "U");
        }

        public string Eliminar_Pedidos(Int32 idnumeropedido)
        {
            var predicado = Predicates.Field<PR_xPedidos>(x => x.IdNumeroPedido, Operator.Eq, idnumeropedido);
            if (PR_xPedidos_CD.Instancia.FiltroPorUnCampo(predicado).Count() > 0) return "Existe una Orden Produccion con este Pedido ";
            return PR_xPedidos_CD._Instancia.Eliminar_Pedidos(idnumeropedido);
        }

        public List<PR_xPedidos> Buscar_PedidosIndustrial(string numeropedido)
        {
            var lista = PR_xPedidos_CD._Instancia.Lista_Pedidos("0", 0, "0", DateTime.Now, DateTime.Now);
            return (from pedidos in lista where pedidos.Numero_Pedido == numeropedido select pedidos).ToList();
        }




    }
}
