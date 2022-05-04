using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoProcesoLaminado_CD
    {
        public static readonly PR_aTipoProcesoLaminado_CD _Instancia = new PR_aTipoProcesoLaminado_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoProcesoLaminado_CD Instancia
        { get { return PR_aTipoProcesoLaminado_CD._Instancia; } }

        public PR_aTipoProcesoLaminado_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoProcesoLaminado> Lista_TipoProcesoLaminado()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoProcesoLaminado, Nombre_TipoProcesoLaminado from PR_aTipoProcesoLaminado";
                    return conexionsql.Query<PR_aTipoProcesoLaminado>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoProcesoLaminado> Traer_TipoProcesoLaminadoPorId(Int32 idtipoprocesolaminado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoProcesoLaminado, Nombre_TipoProcesoLaminado from PR_aTipoProcesoLaminado where IdTipoProcesoLaminado = @id";
                    return conexionsql.Query<PR_aTipoProcesoLaminado>(sql, new { id = idtipoprocesolaminado });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoProcesoLaminado(PR_aTipoProcesoLaminado tipoprocesolaminado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoProcesoLaminado (Nombre_TipoProcesoLaminado) values(@nombre_tipoprocesolaminado)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_tipoprocesolaminado = tipoprocesolaminado.Nombre_TipoProcesoLaminado });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoProcesoLaminado(PR_aTipoProcesoLaminado tipoprocesolaminado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoProcesoLaminado set Nombre_TipoProcesoLaminado = @descripcion_tipoprocesolaminado where IdTipoProcesoLaminado = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipoprocesolaminado.IdTipoProcesoLaminado, descripcion_tipoprocesolaminado = tipoprocesolaminado.Nombre_TipoProcesoLaminado });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoProcesoLaminado(Int32 idtipoprocesolaminado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoProcesoLaminado where IdTipoProcesoLaminado = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipoprocesolaminado });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

        
    }
}
