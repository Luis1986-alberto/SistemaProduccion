using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoFuelle_CD
    {
        public static readonly PR_aTipoFuelle_CD _Instancia = new PR_aTipoFuelle_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoFuelle_CD Instancia
        { get { return PR_aTipoFuelle_CD._Instancia; } }

        public PR_aTipoFuelle_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoFuelle> Lista_TipoFuelle()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoFuelle, Descripcion_TipoFuelle from PR_aTipoFuelle";
                    return conexionsql.Query<PR_aTipoFuelle>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoFuelle> Traer_TipoFuellePorId(Int32 idtipofuelle)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoFuelle, Descripcion_TipoFuelle from PR_aTipoFuelle where IdTipoFuelle = @id";
                    return conexionsql.Query<PR_aTipoFuelle>(sql, new { id = idtipofuelle });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoFuelle(PR_aTipoFuelle tipofuelle)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoFuelle (Descripcion_TipoFuelle) values(@descripcion_tipofuelle)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_tipofuelle = tipofuelle.Descripcion_TipoFuelle });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoFuelle(PR_aTipoFuelle tipofuelle)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoFuelle set Descripcion_TipoFuelle = @descripcion_tipofuelle where IdTipoFuelle = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipofuelle.IdTipoFuelle, descripcion_tipofuelle = tipofuelle.Descripcion_TipoFuelle });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoFuelle(Int32 idtipofuelle)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoFuelle where IdTipoFuelle = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipofuelle });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

        
    }
}
