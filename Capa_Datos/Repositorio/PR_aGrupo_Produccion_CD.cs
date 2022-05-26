using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aGrupo_Produccion_CD
    {
        public static readonly PR_aGrupo_Produccion_CD _Instancia = new PR_aGrupo_Produccion_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aGrupo_Produccion_CD Instancia
        { get { return PR_aGrupo_Produccion_CD._Instancia; } }

        public PR_aGrupo_Produccion_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aGrupo_Produccion> Lista_GrupoProduccion()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdGrupoProd, Descripcion_GrupoProd from PR_aGrupo_Produccion";
                    return conexionsql.Query<PR_aGrupo_Produccion>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aGrupo_Produccion> Traer_GrupoProduccionPorId(Int32 idgrupoproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdGrupoProd, Descripcion_GrupoProd from PR_aGrupo_Produccion where IdGrupoProd = @id";
                    return conexionsql.Query<PR_aGrupo_Produccion>(sql, new { id = idgrupoproduccion });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_GrupoProduccion(PR_aGrupo_Produccion grupo_produccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aGrupo_Produccion (Descripcion_GrupoProd) values(@descripcion_grupoprod)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_grupoprod = grupo_produccion.Descripcion_GrupoProd });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_GrupoProduccion(PR_aGrupo_Produccion grupo_produccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aGrupo_Produccion set Descripcion_GrupoProd = @descripcion_grupoprod where IdGrupoProd = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = grupo_produccion.IdGrupoProd, descripcion_grupoprod = grupo_produccion.Descripcion_GrupoProd });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_GrupoProduccion(Int32 idgrupoprod)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aGrupo_Produccion where IdGrupoProd = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idgrupoprod });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
