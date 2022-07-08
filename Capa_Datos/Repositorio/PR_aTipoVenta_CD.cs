using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoVenta_CD
    {
        public static readonly PR_aTipoVenta_CD _Intancia = new PR_aTipoVenta_CD();
        private string cadenaconexion = "";
        private Inicio principal = new Inicio();

        public static PR_aTipoVenta_CD Instancia
        { get { return PR_aTipoVenta_CD._Intancia; } }

        public PR_aTipoVenta_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoVenta>Lista_TipoVenta()
        {
            try
            {
                using(var SQLConexion = new SqlConnection(cadenaconexion ))
                {
                    var sql = "Select IdTipoVenta, TipoVenta From PR_aTipoVenta";
                    return SQLConexion.Query<PR_aTipoVenta>(sql);
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Listar", Ex);}
        }

        public PR_aTipoVenta Traer_TipoVentaPorId(byte idtipoventa)
        {
            try
            {
                using(var SQLConexion = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoVenta, TipoVenta From PR_aTipoVenta where IdTipoVenta = @id";
                    return SQLConexion.QueryFirst<PR_aTipoVenta>(sql, new { id = idtipoventa });
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al traer por ID", Ex);}
        }

        public String Agregar_TipoVenta (PR_aTipoVenta tipoventa)
        {
            try
            {
                using(var SQLConexion = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoVenta (TipoVenta) values (@tipoventa)";
                    SQLConexion.ExecuteScalar(sqlinsert, new { tipoventa = tipoventa.TipoVenta });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Agregar TipoVenta", Ex);}
        }

        public String Actualizar_TipoVenta(PR_aTipoVenta tipoventa)
        {
            try
            {
                using(var SQLConexion = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoVenta set TipoVenta = @tipoventa where IdTipoVenta = @tipoventa";
                    SQLConexion.ExecuteScalar(sqlupdate, new { idtipoventa = tipoventa.IdTipoVenta, tipoventa = tipoventa.TipoVenta });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Actualizar TipoVenta", Ex);}
        }

        public String Eliminar_TipoVenta(byte idtipoventa)
        {
            try
            {
                using(var SQLConexion = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoVenta where IdTipoVenta = @idtipoventa";
                    SQLConexion.ExecuteScalar(sqldelete, new { idtipoventa = idtipoventa });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception ("Error al Eliminar TipoVenta", Ex);}
        }



    }
}
