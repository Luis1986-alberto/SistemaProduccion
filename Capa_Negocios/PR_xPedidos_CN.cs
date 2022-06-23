using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
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

        public PR_xPedidosIndustriales Traer_PorId(Int32 idpedido)
        {
            return PR_xPedidosIndustriales_CD._Instancia.TraerPorId(idpedido);
        }




    }
}
