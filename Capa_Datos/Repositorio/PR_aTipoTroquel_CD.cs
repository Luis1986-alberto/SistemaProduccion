using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoTroquel_CD
    {
        public static readonly PR_aTipoTroquel_CD _Instancia = new PR_aTipoTroquel_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoTroquel_CD Instancia
        { get { return PR_aTipoTroquel_CD._Instancia; } }

        public PR_aTipoTroquel_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoTroquel> Lista_TipoTroquel()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoTroquel, Descripcion_TipoTroquel from PR_aTipoTroquel";
                    return conexionsql.Query<PR_aTipoTroquel>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoTroquel> Traer_TipoTroquelId(Int32 idtipotroquel)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoTroquel, Descripcion_TipoTroquel from PR_aTipoTroquel where IdTipoTroquel = @id";
                    return conexionsql.Query<PR_aTipoTroquel>(sql, new { id = idtipotroquel });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoTroquel(PR_aTipoTroquel tipotroquel)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoTroquel (Descripcion_TipoTroquel) values(@descipcion_tipotroquel)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descipcion_tipotroquel = tipotroquel.Descripcion_TipoTroquel });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoTroquel(PR_aTipoTroquel tipotroquel)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoTroquel set Descripcion_TipoTroquel = @descripcion_tipotroquel where IdTipoTroquel = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipotroquel.IdTipoTroquel, descripcion_tipotroquel = tipotroquel.Descripcion_TipoTroquel });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoTroquel(Int32 idtipotrabajo)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoTroquel where IdTipoTroquel = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipotrabajo });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
