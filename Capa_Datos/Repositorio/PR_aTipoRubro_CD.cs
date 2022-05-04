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
    public class PR_aTipoRubro_CD
    {
        public static readonly PR_aTipoRubro_CD _Instancia = new PR_aTipoRubro_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoRubro_CD Instancia
        { get { return PR_aTipoRubro_CD._Instancia; } }

        public PR_aTipoRubro_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoRubro>Lista_TipoRubros()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    var sql = "select IdTipoRubro, Nombre_TipoRubro from PR_aTipoRubro";
                    return conexionsql.Query<PR_aTipoRubro>(sql);
                }
            }
            catch(Exception ex)
            {throw new Exception("Error al listar", ex);}
        }

        public IEnumerable<PR_aTipoRubro>Traer_TipoRubrosPorId(byte idtiporubro)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    var sql = "select IdTipoRubro, Nombre_TipoRubro from PR_aTipoRubro where IdTipoRubro = @id ";
                    return conexionsql.Query<PR_aTipoRubro>(sql, new { id = idtiporubro });

                }
            }
            catch(Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public string Agregar_TipoRubro(PR_aTipoRubro tiporubro)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {   
                    var sqlinsert = "Insert Into PR_aTipoRubro (Nombre_TipoRubro) values (@nombre_tiporubro)";
                    conexionsql.Execute(sqlinsert, new { nombre_tiporubro = tiporubro.Nombre_TipoRubro});
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Insertar", ex); }
        }

        public string Actualizar_TipoRubro(PR_aTipoRubro tiporubro)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoRubro set Nombre_TipoRubro = @nombre_tiporubro where IdTipoRubro = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tiporubro.IdTipoRubro, nombre_tiporubro = tiporubro.Nombre_TipoRubro });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

        public string Eliminar_TipoRubro(byte idtiporubro)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "Delete PR_aTipoRubro where IdTipoRubro = @id";
                    conexionsql.Execute(sqldelete, new { id = idtiporubro });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al eliminar", ex);}
        }


    }
}
