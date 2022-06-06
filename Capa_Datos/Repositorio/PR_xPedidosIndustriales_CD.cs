using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class PR_xPedidosIndustriales_CD
    {
        public static readonly PR_xPedidosIndustriales_CD _Instancia = new PR_xPedidosIndustriales_CD();
        private Inicio Principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_xPedidosIndustriales_CD Instancia
        { get { return PR_xPedidosIndustriales_CD._Instancia; } }

        public PR_xPedidosIndustriales_CD()
        {
            Principal.LeerConfiguracion();
            cadenaconexion = Principal.CadenaConexion;
        }


        public List<PR_xPedidosIndustriales> Lista_Pedidos(PR_xPedidosIndustriales pedidos, string flag_cliente, Int32 idcliente, 
                                                                  string flag_rango, DateTime fecha_inicio, DateTime fecha_final)
        {
            List<PR_xPedidosIndustriales> lista_pedidos = null;
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    ConexionSQL.Open();
                    SqlCommand cmd = new SqlCommand("PRr_Pedidos", ConexionSQL);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Flag_Cliente", flag_cliente);
                    cmd.Parameters.AddWithValue("@IdCliente", idcliente);
                    cmd.Parameters.AddWithValue("@Flag_Rango", flag_rango);
                    cmd.Parameters.AddWithValue("@Fecha_Inicial", fecha_inicio);
                    cmd.Parameters.AddWithValue("@Fecha_Final", fecha_final);

                    lista_pedidos = new List<PR_xPedidosIndustriales>();
                    SqlDataReader dr = cmd.ExecuteReader(); 

                    while(dr.Read())
                    {
                        PR_xPedidosIndustriales t = new PR_xPedidosIndustriales();
                        t.IdNumeroPedido = Int32.Parse(dr["IdNumeroPedido"].ToString());
                        t.Numero_Pedido = dr["Numero_Pedido"].ToString();
                        t.Numero_Orden_Compra = dr["Numero_Orden_Compra"].ToString();
                        t.IdEmpresa = byte.Parse(dr["IdEmpresa"].ToString());
                        t.IdCondicionCobranza = byte.Parse(dr["IdCondicionCobranza"].ToString());
                        t.Fecha_Pedido = DateTime.Parse(dr["Fecha_Pedido"].ToString());
                        t.Fecha_Entrega = DateTime.Parse(dr["Fecha_Entrega"].ToString());
                        t.Cantidad_Kilos = decimal.Parse(dr["Cantidad_Kilos"].ToString());
                        t.Merma = decimal.Parse(dr["Merma"].ToString());
                        t.Porcentaje_Merma = decimal.Parse(dr["Porcentaje_Merma"].ToString());
                        t.Total_Kilos = decimal.Parse(dr["Total_Kilos"].ToString());
                        t.Flag_Ventasx = dr["Flag_Ventasx"].ToString();
                        t.Cantidad_Millares = decimal.Parse(dr["Cantidad_Millares"].ToString());
                        t.Precio_Kilo = decimal.Parse(dr["Precio-Kilo"].ToString());
                        t.Precio_Millar = decimal.Parse(dr["Precio_Millar"].ToString());
                        t.Reajuste_Precio_Kilo = decimal.Parse(dr["Reajuste_Precio_Kilo"].ToString());
                        t.Reajuste_Precio_Millar = decimal.Parse(dr["Reajuste_Precio_millar"].ToString());
                        t.Flag_IGV = dr["Flag_IGV"].ToString();
                        t.Flag_Incluido_Gastos = dr["Flag_Incluidos_Gastos"].ToString();
                        t.Flag_DestararBobinaExtruida = dr["Flag_DestararBobinaExtruida"].ToString();
                        t.Flag_DestararBobinaImpresa = dr["Flag_DestararBobinaImpresa"].ToString();
                        t.Flag_DestararBobinaLaminado = dr["Flag_DestararBobinaLaminado"].ToString();
                        t.Flag_DestararBobinaCorte = dr["Flag_DestararBobinaCorte"].ToString();
                        t.Flag_PesarxPaquete = dr["Flag_PesarxPaquete"].ToString();
                        t.Flag_PesarxFardo = dr["Flag_PesarxFardo"].ToString();
                        t.Flag_PesarxCaja = dr["Flag_PesarxCaja"].ToString();
                        t.Flag_Comision = dr["Flag_Comision"].ToString();
                        t.Nota_Pedido = dr["Nota_Pedido"].ToString();
                        t.Flag_NuevoRepetidoHistorico = dr["Flag_NuevoRepetidoHistorico"].ToString();
                        t.Flag_NoExisteEspecificacion = dr["Flag_NoExisteEspecificacion"].ToString();
                        t.Pedido_General = dr["Pedido_General"].ToString();
                        t.IdVentaProducto = byte.Parse(dr["IdVentaProducto"].ToString());
                        t.Nota = dr["Nota"].ToString();
                        t.Nota_Pedido = dr["Nota_Pedido"].ToString();
                        t.IdUsuario = dr["IdUsuario"].ToString();                     

                        lista_pedidos.Add(t);
                    }
                    dr.Close();
                    return lista_pedidos;
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Listar", Ex);}
        }


    }
}
