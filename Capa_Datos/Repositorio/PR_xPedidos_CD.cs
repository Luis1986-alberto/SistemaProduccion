using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class PR_xPedidos_CD
    {
        public static readonly PR_xPedidos_CD _Instancia = new PR_xPedidos_CD();
        private Inicio Principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_xPedidos_CD Instancia
        { get { return PR_xPedidos_CD._Instancia; } }

        public PR_xPedidos_CD()
        {
            Principal.LeerConfiguracion();
            cadenaconexion = Principal.CadenaConexion;
        }

        public List<PR_xPedidos> Lista_Pedidos( string flag_cliente, Int32 idcliente, string flag_rango,
                                                             DateTime fecha_inicio, DateTime fecha_final)
        {
            List<PR_xPedidos> lista_pedidos = null;
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

                    lista_pedidos = new List<PR_xPedidos>();
                    SqlDataReader dr = cmd.ExecuteReader(); 

                    while(dr.Read())
                    {
                        PR_xPedidos t = new PR_xPedidos();
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
                        t.IdSeVendePor = byte.Parse(dr["IdSeVendePor"].ToString());
                        t.Cantidad_Millares = decimal.Parse(dr["Cantidad_Millares"].ToString());
                        t.Precio_Kilo = decimal.Parse(dr["Precio_Kilo"].ToString());
                        t.Precio_Millar = decimal.Parse(dr["Precio_Millar"].ToString());
                        t.Reajuste_Precio_Kilo = decimal.Parse(dr["Reajuste_Precio_Kilo"].ToString());
                        t.Reajuste_Precio_Millar = decimal.Parse(dr["Reajuste_Precio_millar"].ToString());
                        t.Flag_MasIGV = dr["Flag_MasIGV"].ToString();
                        t.Flag_Incluido_Gastos = dr["Flag_Incluido_Gastos"].ToString();
                        t.Flag_DestararBobinaExtruida = dr["Flag_DestararBobinaExtruida"].ToString();
                        t.Flag_DestararBobinaImpresa = dr["Flag_DestararBobinaImpresa"].ToString();
                        t.Flag_DestararBobinaLaminado = dr["Flag_DestararBobinaLaminado"].ToString();
                        t.Flag_DestararBobinaCorte = dr["Flag_DestararBobinaCorte"].ToString();
                        //t.Flag_PesarxPaquete = dr["Flag_PesarxPaquete"].ToString();
                        //t.Flag_PesarxFardo = dr["Flag_PesarxFardo"].ToString();
                        //t.Flag_PesarxCaja = dr["Flag_PesarxCaja"].ToString();
                        t.Descripcion = dr["Descripcion"].ToString();
                        t.Razon_Social = dr["Razon_Social"].ToString();
                        t.Flag_Comision = dr["Flag_Comision"].ToString();
                        t.Nota_Pedido = dr["Nota_Pedido"].ToString();
                        t.Flag_NuevoRepetidoHistorico = dr["Flag_NuevoRepetidoHistorico"].ToString();
                        t.Flag_NoExisteEspecificacion = dr["Flag_NoExisteEspecificacion"].ToString();
                        t.Pedido_General = dr["Pedido_General"].ToString();
                        t.IdTipoVenta = byte.Parse(dr["IdTipoVenta"].ToString());
                        t.IdTipoMoneda = byte.Parse(dr["IdTipoMoneda"].ToString());
                        t.IdUsuario = dr["IdUsuario"].ToString();
                        t.IdCliente = Int32.Parse(dr["IdCliente"].ToString());
                        lista_pedidos.Add(t);
                    }
                    dr.Close();
                    return lista_pedidos;
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Listar", Ex);}
        }

        public IEnumerable<PR_xPedidos> TraerPorId (Int32 idpedidos)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    ConexionSQL.Open();
                    var sql = "select * from PR_xPedidos as PED INNER JOIN PR_mEstandar as EST " +
                              " on PED.IdEstandar = EST.IdEstandar  where PED.IdNumeroPedido = @id ";

                    return ConexionSQL.Query<PR_xPedidos>(sql, new { id = idpedidos });
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Traer por ID", Ex);}
        }

        public IEnumerable<PR_xPedidos> FiltroPorUnCampo(IPredicate predicado)
        {
            using(var conexionSql = new SqlConnection(cadenaconexion))
            {
                conexionSql.Open();
                var result = conexionSql.GetList<PR_xPedidos>(predicado);
                conexionSql.Close();
                return result;
            }
        }

        public string Pedidos_Procesar(PR_xPedidos pedidos, string accion)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    ConexionSQL.Open();
                    SqlCommand cmd = new SqlCommand("PRt_Pedidos", ConexionSQL);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Accion", accion);
                    cmd.Parameters.AddWithValue("@IdNumeroPedido", pedidos.IdNumeroPedido);
                    cmd.Parameters.AddWithValue("@Numero_Pedido", pedidos.Numero_Pedido);
                    cmd.Parameters.AddWithValue("@NUmero_Orden_Compra", pedidos.Numero_Orden_Compra);
                    cmd.Parameters.AddWithValue("@Idestandar", pedidos.IdEstandar);
                    cmd.Parameters.AddWithValue("@IdEmpresa", pedidos.IdEmpresa);
                    cmd.Parameters.AddWithValue("@IdCondicionCobranza", pedidos.IdCondicionCobranza);
                    cmd.Parameters.AddWithValue("@Fecha_Pedido", pedidos.Fecha_Pedido);
                    cmd.Parameters.AddWithValue("@Fecha_Entrega", pedidos.Fecha_Entrega);
                    cmd.Parameters.AddWithValue("@Cantidad_Kilos", pedidos.Cantidad_Kilos);
                    cmd.Parameters.AddWithValue("@Merma", pedidos.Merma);
                    cmd.Parameters.AddWithValue("@Porcentaje_Merma", pedidos.Porcentaje_Merma);
                    cmd.Parameters.AddWithValue("@Total_Kilos", pedidos.Total_Kilos);
                    cmd.Parameters.AddWithValue("@Flag_CantidadKg", pedidos.Flag_CantidadKg);
                    cmd.Parameters.AddWithValue("@Cantidad_Millares", pedidos.Cantidad_Millares);
                    cmd.Parameters.AddWithValue("@Precio_Kilo", pedidos.Precio_Kilo);
                    cmd.Parameters.AddWithValue("@Precio_Millar", pedidos.Precio_Millar);
                    cmd.Parameters.AddWithValue("@Reajuste_Precio_Kilo", pedidos.Reajuste_Precio_Kilo);
                    cmd.Parameters.AddWithValue("@Reajuste_Precio_Millar", pedidos.Reajuste_Precio_Millar);
                    cmd.Parameters.AddWithValue("@Flag_MasIGV", pedidos.Flag_MasIGV);
                    cmd.Parameters.AddWithValue("@Flag_Incluido_Gastos", pedidos.Flag_Incluido_Gastos);
                    cmd.Parameters.AddWithValue("@Flag_DestararBobinaExtruida", pedidos.Flag_DestararBobinaExtruida);
                    cmd.Parameters.AddWithValue("@Flag_DestararBobinaImpresa", pedidos.Flag_DestararBobinaImpresa);
                    cmd.Parameters.AddWithValue("@Flag_DestararBobinaLaminado", pedidos.Flag_DestararBobinaLaminado);
                    cmd.Parameters.AddWithValue("@Flag_DestararBobinaCorte", pedidos.Flag_DestararBobinaCorte);
                    cmd.Parameters.AddWithValue("@Flag_Comision", pedidos.Flag_Comision);
                    cmd.Parameters.AddWithValue("@Nota_Pedido", pedidos.Nota_Pedido);
                    cmd.Parameters.AddWithValue("@Flag_NuevoRepetidoHistorico", pedidos.Flag_NuevoRepetidoHistorico);
                    cmd.Parameters.AddWithValue("@Flag_NoExisteEspecificacion", pedidos.Flag_NoExisteEspecificacion);
                    cmd.Parameters.AddWithValue("@IdUsuario", pedidos.IdUsuario);
                    cmd.Parameters.AddWithValue("@Pedido_General", pedidos.Pedido_General);
                    cmd.Parameters.AddWithValue("@IdTipoVenta", pedidos.IdTipoVenta);                    
                    cmd.Parameters.AddWithValue("@Metros", pedidos.Metros);
                    cmd.Parameters.AddWithValue("@Fecha_Orden_Compra", pedidos.Fecha_Orden_Compra);
                    cmd.Parameters.AddWithValue("@IdCondicionProceso", pedidos.IdCondicionProceso);
                    cmd.Parameters.AddWithValue("@IdTrabajador", pedidos.IdTrabajador);
                    cmd.Parameters.AddWithValue("@IdTipoMoneda", pedidos.IdTipoMoneda);
                    cmd.Parameters.AddWithValue("@IdSeVendePor", pedidos.IdSeVendePor);
                    cmd.Parameters.AddWithValue("@Output_Id", 0);

                    cmd.ExecuteNonQuery();
                    ConexionSQL.Close();                    
                }
                return "PROCESADO";
            }
            catch(Exception Ex)
            {throw new Exception("Error al agregar", Ex);}
        }

        public string Eliminar_Pedidos(Int32 idpedido)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    var sqldelete = "delete from PR_xPedidos where IdNumeroPedido = @idnumeropedido ";
                    conexionsql.Execute(sqldelete, new { idnumeropedido = idpedido });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error alEliminar", Ex);}
        }

        public IEnumerable<PR_xPedidos>Pedidos_PorEstandart(Int32 idestandar)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    var sql = " select * from PR_xPedidos where IdEstandar = @Id";
                    return conexionsql.Query<PR_xPedidos>(sql, new { Id = idestandar });
                }
            }
            catch(Exception Ex) { throw new Exception("Error al traer por IdEstandart " + idestandar, Ex); }
        }

        public IEnumerable<PR_xPedidos> Pedidos_PorNumeroPedio(string numeropedido)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    var sql = " select * from PR_xPedidos where Numero_Pedido = @Numero_Pedido";
                    return conexionsql.Query<PR_xPedidos>(sql, new { Numero_Pedido = numeropedido });
                }
            }
            catch(Exception Ex) { throw new Exception("Error al traer por IdEstandart " + numeropedido, Ex); }
        }
    }
}
