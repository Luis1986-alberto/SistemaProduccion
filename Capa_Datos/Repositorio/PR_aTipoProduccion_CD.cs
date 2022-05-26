using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoProduccion_CD
    {
        public static readonly PR_aTipoProduccion_CD _Instancia = new PR_aTipoProduccion_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoProduccion_CD Instancia
        { get { return PR_aTipoProduccion_CD._Instancia; } }

        public PR_aTipoProduccion_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoProduccion> Lista_TipoProduccion()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoProduccion, Detalle_TipoProduccion, Siglas_TipoProduccion from PR_aTipoProduccion";
                    return conexionsql.Query<PR_aTipoProduccion>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoProduccion> Traer_TipoProduccionPorId(Int32 idtipoproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoProduccion, Detalle_TipoProduccion, Siglas_TipoProduccion from PR_aTipoProduccion where IdTipoProduccion = @id";
                    return conexionsql.Query<PR_aTipoProduccion>(sql, new { id = idtipoproduccion });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoProduccion(PR_aTipoProduccion tipoproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoProduccion (Detalle_TipoProduccion, Siglas_TipoProduccion) values(@detalle_produccion, @sigla_produccion)";
                    conexionsql.ExecuteScalar(sqlinsert, new { detalle_produccion = tipoproduccion.Detalle_TipoProduccion, sigla_produccion = tipoproduccion.Siglas_TipoProduccion });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoProduccion(PR_aTipoProduccion tipoproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoProduccion set Detalle_TipoProduccion = @descripcion_tipoproduccion, Siglas_TipoProduccion = @sigla_tipoproduccion where IdTipoProduccion = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                        id = tipoproduccion.IdTipoProduccion,
                        descripcion_tipoproduccion = tipoproduccion.Detalle_TipoProduccion,
                        sigla_tipoproduccion = tipoproduccion.Siglas_TipoProduccion
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoProduccion(Int32 idtipoproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoProduccion where IdTipoProduccion = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipoproduccion });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
