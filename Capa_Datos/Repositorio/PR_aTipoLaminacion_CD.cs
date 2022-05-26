using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoLaminacion_CD
    {
        public static readonly PR_aTipoLaminacion_CD _Instancia = new PR_aTipoLaminacion_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoLaminacion_CD Instancia
        { get { return PR_aTipoLaminacion_CD._Instancia; } }

        public PR_aTipoLaminacion_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoLaminacion> Lista_TipoLaminacion()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoLaminado, Detalle_Laminacion, Nota_Laminacion from PR_aTipoLaminacion";
                    return conexionsql.Query<PR_aTipoLaminacion>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoLaminacion> Traer_TipoLaminacionPorId(Int32 idtipolaminacion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoLaminado, Detalle_Laminacion, Nota_Laminacion from PR_aTipoLaminacion where IdTipoLaminado = @id";
                    return conexionsql.Query<PR_aTipoLaminacion>(sql, new { id = idtipolaminacion });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoLaminacion(PR_aTipoLaminacion tipolaminacion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoLaminacion (Detalle_Laminacion, Nota_Laminacion) values(@detalle_laminacion, @nota_laminacion)";
                    conexionsql.ExecuteScalar(sqlinsert, new { detalle_laminacion = tipolaminacion.Detalle_Laminacion, nota_laminacion = tipolaminacion.Nota_Laminacion });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoLaminacion(PR_aTipoLaminacion tipolaminacion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoLaminacion set Detalle_Laminacion = @detalle_laminacion, Nota_Laminacion = @nota_laminacion where IdTipoLaminado = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipolaminacion.IdTipoLaminado, detalle_laminacion = tipolaminacion.Detalle_Laminacion, nota_laminacion = tipolaminacion.Nota_Laminacion });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoLaminacion(Int32 idlaminacion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoLaminacion where IdTipoLaminado = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idlaminacion });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
