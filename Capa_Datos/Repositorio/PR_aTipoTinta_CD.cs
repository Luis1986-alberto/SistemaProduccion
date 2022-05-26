using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoTinta_CD
    {
        public static readonly PR_aTipoTinta_CD _Instancia = new PR_aTipoTinta_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoTinta_CD Instancia
        { get { return PR_aTipoTinta_CD._Instancia; } }

        public PR_aTipoTinta_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoTinta> Lista_TipoTinta()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoTinta, Descripcion_TipoTinta from PR_aTipoTinta";
                    return conexionsql.Query<PR_aTipoTinta>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoTinta> Traer_TipoTintaPorId(Int32 idtipotinta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoTinta, Descripcion_TipoTinta from PR_aTipoTinta where IdTipoTinta = @id";
                    return conexionsql.Query<PR_aTipoTinta>(sql, new { id = idtipotinta });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoTinta(PR_aTipoTinta tipotinta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoTinta (Descripcion_TipoTinta) values(@descipcion_tipotinta)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descipcion_tipotinta = tipotinta.Descripcion_TipoTinta });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoTinta(PR_aTipoTinta tipotinta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoTinta set Descripcion_TipoTinta = @descripcion_tipotinta where IdTipoTinta = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipotinta.IdTipoTinta, descripcion_tipotinta = tipotinta.Descripcion_TipoTinta }); return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoTinta(Int32 idtipotinta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoTinta where IdTipoTinta = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipotinta });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
