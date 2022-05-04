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
    public class LG_aTipoMotivo_CD
    {
        public static readonly LG_aTipoMotivo_CD _Instancia = new LG_aTipoMotivo_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        private static LG_aTipoMotivo_CD Instancia
        { get { return LG_aTipoMotivo_CD._Instancia; } }

        public LG_aTipoMotivo_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aTipoMotivo> Listar_TipoMotivo()
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoMotivo, TipoMotivo from LG_aTipoMotivo ";
                    return ConexionSql.Query<LG_aTipoMotivo>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error aql llistar", Ex); }
        }

        public LG_aTipoMotivo TraerPorIdMotivo(Int32 idmotivo)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoMotivo, TipoMotivo from LG_aTipoMotivo where IdTipoMotivo = id ";
                    return ConexionSql.QueryFirst<LG_aTipoMotivo>(sql, new { id = idmotivo });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error aql llistar", Ex); }
        }

        public string Agregar_TipoMotivo(LG_aTipoMotivo tipomotivo)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aTipoMotivo (TipoMotivo) values (@tipo_motivo)";
                    ConexionSQL.Execute(sqlinsert, new { tipo_motivo = tipomotivo.TipoMotivo });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Agregar", Ex); }
        }

        public string Actualizar_TipoMotivo(LG_aTipoMotivo tipomotivo)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Update LG_aTipoMotivo SET TipoMotivo = @tipo_motivo where IdTipoMotivo = @id";
                    ConexionSQL.Execute(sqlinsert, new { id = tipomotivo.IdTipoMotivo, tipo_inmueble = tipomotivo.TipoMotivo });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Agregar", Ex); }
        }

        public string Eliminar_TipoMotivo(Int32 idtipomotivo)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Delete LG_aTipoMotivo where IdTipoMotivo = @id";
                    ConexionSQL.Execute(sqlinsert, new { id = idtipomotivo });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Agregar", Ex); }
        }

        public IEnumerable<LG_aTipoMotivo> FiltroPorunCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            ConexionSQL.Open();
            var result = ConexionSQL.GetList<LG_aTipoMotivo>(predicado);
            ConexionSQL.Close();
            return result;
        }

    }
}
