using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class PR_xOrdenProduccionInd_CD
    {
        public static readonly PR_xOrdenProduccionInd_CD _Instancia = new PR_xOrdenProduccionInd_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_xOrdenProduccionInd_CD Instancia
        {get { return PR_xOrdenProduccionInd_CD._Instancia; } }

        public PR_xOrdenProduccionInd_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public List<PR_xOrdenProduccionInd>Lista_OrdenProduccion()
        {
            List<PR_xOrdenProduccionInd> Lst_OrdenProducion = null;
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    SqlCommand cmd = new SqlCommand("PRr_OrdenesProduccion", conexionsql);

                    Lst_OrdenProducion = new List<PR_xOrdenProduccionInd>();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        PR_xOrdenProduccionInd t = new PR_xOrdenProduccionInd();
                        t.IdOrdProd = Int32.Parse(dr["IdOrdProd"].ToString());
                        t.IdOrdenProduccionInd = dr["IdOrdenProduccionInd"].ToString();
                        t.Numero_Pedido = dr["Numero_Pedido"].ToString();
                        t.Prefijo = dr["Prefijo"].ToString();
                        t.Nro_MP = decimal.Parse(dr["Nro_MP"].ToString());
                        t.IdPosicionMaquina = short.Parse(dr["IdPosicionMaquina"].ToString());
                        t.Flag_Produccion = byte.Parse(dr["Flag_Produccion"].ToString());
                        t.IdNumeroPedido = decimal.Parse(dr["IdNumeroPedido"].ToString());
                        t.IdPeriodo = byte.Parse(dr["IdPeriodo"].ToString());
                        t.IdUsuario = dr["IdUsuario"].ToString();
                        t.Fecha_Servidor = DateTime.Parse(dr["Fecha_Servidor"].ToString());
                        
                        Lst_OrdenProducion.Add(t);
                    }
                    dr.Close();
                    return Lst_OrdenProducion;
                }
            }       
            catch(Exception Ex)
            {throw new Exception("Error al Listar", Ex);}
        }

        public PR_xOrdenProduccionInd TraerPorId(Int32 idordenproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {

                    var sql = "select * from PR_xOrdenProduccionInd as OP inner join PR_xPedidosIndustriales as PED on OP.IdNumeroPedido = PED.IdNumeroPedido " +
                              " where OP.IdOrdenProduccionInd = @id ";
                    return conexionsql.QueryFirst<PR_xOrdenProduccionInd>(sql, new { id = idordenproduccion });                        
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Traer por Id", Ex);}
        }



        public IEnumerable<PR_xOrdenProduccionInd> FiltrarPorUnCampo(IPredicate predicado)
        {
            using(var conexionSql = new SqlConnection(cadenaconexion))
            {
                conexionSql.Open();
                var result = conexionSql.GetList<PR_xOrdenProduccionInd>(predicado);
                conexionSql.Close();
                return result;
            }
        }

    }
}

 
