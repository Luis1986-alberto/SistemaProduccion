using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aTipoCompra_CD
    {
        public static readonly LG_aTipoCompra_CD _Instancia = new LG_aTipoCompra_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_aTipoCompra_CD Instancia
        { get { return LG_aTipoCompra_CD._Instancia; } }

        public LG_aTipoCompra_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aTipoCompra> Lista_TipoCompra()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoCompra, Descripcion_TipoCompra from LG_aTipoCompra ";
                    return ConexionSQL.Query<LG_aTipoCompra>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Listar", Ex); }
        }

        public LG_aTipoCompra TraerPorIdTipoCompra(Int32 idtipocompra)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoCompra, Descripcion_TipoCompra from LG_aTipoCompra where IdTipoCompra = @id ";
                    return ConexionSQL.QueryFirst<LG_aTipoCompra>(sql, new { id = idtipocompra });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al traer por Id", Ex); }
        }

        public string Agregar_TipoCompra(LG_aTipoCompra tipocompra)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aTipoCompra (Descripcion_TipoCompra) values (@descripcion_tipocompra)";
                    ConexionSQL.Execute(sqlinsert, new { descripcion_tipocompra = tipocompra.Descripcion_TipoCompra });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Agregar", Ex); }
        }

        public string Actualizar_TipoCompra(LG_aTipoCompra tipocompra)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_aTipoCompra set Descripcion_TipoCompra = @descripcion_tipocompra where IdTipoCompra = @id ";
                    ConexionSql.Execute(sqlupdate, new { id = tipocompra.IdTipoCompra, descripcion_tipocompra = tipocompra.Descripcion_TipoCompra });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Actualizar", Ex); }
        }

        public String Eliminar_TipoCompra(Int32 idtipocompra)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete LG_aTipoCompra where IdTipoCompra = @id ";
                    ConexionSQL.Execute(sqldelete, new { id = idtipocompra });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Eliminar", Ex); }
        }

        public IEnumerable<LG_aTipoCompra> FiltroPorunCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            ConexionSQL.Open();
            var result = ConexionSQL.GetList<LG_aTipoCompra>(predicado);
            ConexionSQL.Close();
            return result;
        }

    }
}
