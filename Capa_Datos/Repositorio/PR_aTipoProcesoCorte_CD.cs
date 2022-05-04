using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoProcesoCorte_CD
    {
        public static readonly PR_aTipoProcesoCorte_CD _Instancia = new PR_aTipoProcesoCorte_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoProcesoCorte_CD Instancia
        { get { return PR_aTipoProcesoCorte_CD._Instancia; } }

        public PR_aTipoProcesoCorte_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoProcesoCorte> Lista_TipoProcesoCorte()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoProcesoCorte, Nombre_TipoProcesoCorte from PR_aTipoProcesoCorte";
                    return conexionsql.Query<PR_aTipoProcesoCorte>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoProcesoCorte> Traer_TipoProcesoCortePorId(Int32 idtipoprocesocorte)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoProcesoCorte, Nombre_TipoProcesoCorte from PR_aTipoProcesoCorte where IdTipoProcesoCorte = @id";
                    return conexionsql.Query<PR_aTipoProcesoCorte>(sql, new { id = idtipoprocesocorte });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoProcesoCorte(PR_aTipoProcesoCorte tipoprocesocorte)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoProcesoCorte (Nombre_TipoProcesoCorte) values(@nombre_tipoprocesocorte)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_tipoprocesocorte = tipoprocesocorte.Nombre_TipoProcesoCorte });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoProcesoCorte(PR_aTipoProcesoCorte tipoprocesocorte)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoProcesoCorte set Nombre_TipoProcesoCorte = @nombre_tipoprocesocorte where IdTipoProcesoCorte = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipoprocesocorte.IdTipoProcesoCorte, nombre_tipoprocesocorte = tipoprocesocorte.Nombre_TipoProcesoCorte });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoProcesoCorte(Int32 idtipoprocesocorte)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoProcesoCorte where IdTipoProcesoCorte = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipoprocesocorte });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
