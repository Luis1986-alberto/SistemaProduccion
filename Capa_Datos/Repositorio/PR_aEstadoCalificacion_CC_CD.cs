using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aEstadoCalificacion_CC_CD
    {
        public static readonly PR_aEstadoCalificacion_CC_CD _Instancia = new PR_aEstadoCalificacion_CC_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aEstadoCalificacion_CC_CD Instancia
        { get { return PR_aEstadoCalificacion_CC_CD._Instancia; } }

        public PR_aEstadoCalificacion_CC_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aEstadoCalificacion_CC> Lista_EstadoCalñificacion_CC()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEstadoCalificacion_CC, Nombre_EstadoCaficacion_CC from  PR_aEstadoCalificacion_CC";
                    return conexionsql.Query<PR_aEstadoCalificacion_CC>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }

        public IEnumerable<PR_aEstadoCalificacion_CC> Traer_EstadoCalificacionPorId(Int32 idestadocalificacion_cc)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEstadoCalificacion_CC, Nombre_EstadoCaficacion_CC from  PR_aEstadoCalificacion_CC where IdEstadoCalificacion_CC = @id";
                    return conexionsql.Query<PR_aEstadoCalificacion_CC>(sql, new { id = idestadocalificacion_cc });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_EstadoCalificacion(PR_aEstadoCalificacion_CC aestadocalificacion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aEstadoCalificacion_CC (Nombre_EstadoCaficacion_CC) values (@nombre_estadocalificacion_cc)";
                    conexionsql.Execute(sqlinsert, new { nombre_estadocalificacion_cc = aestadocalificacion.Nombre_EstadoCaficacion_CC });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_EstadoCalificacion(PR_aEstadoCalificacion_CC aestadocalificacion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update PR_aEstadoCalificacion_CC set Nombre_EstadoCaficacion_CC = @nombre_estadocalificacion_cc where IdEstadoCalificacion_CC = @id";
                    conexionsql.ExecuteScalar(sqledit, new {
                        nombre_estadocalificacion_cc = aestadocalificacion.Nombre_EstadoCaficacion_CC,
                        id = aestadocalificacion.IdEstadoCalificacion_CC
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_EstadoCalificacion(Int32 idestadocalificacion_cc)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aEstadoCalificacion_CC where IdEstadoCalificacion_CC = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idestadocalificacion_cc });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al eliminar", Ex); }
        }


    }
}
