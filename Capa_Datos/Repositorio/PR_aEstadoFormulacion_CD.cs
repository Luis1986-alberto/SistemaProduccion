using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aEstadoFormulacion_CD
    {
        public static readonly PR_aEstadoFormulacion_CD _Instancia = new PR_aEstadoFormulacion_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aEstadoFormulacion_CD Instancia
        { get { return PR_aEstadoFormulacion_CD._Instancia; } }

        public PR_aEstadoFormulacion_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aEstadoFormulacion> Lista_EstadoFormulacion()
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEstadoFormulacion, Nombre_EstadoFormulacion from  PR_aEstadoFormulacion";
                    return conexionsql.Query<PR_aEstadoFormulacion>(sql);
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }

        public IEnumerable<PR_aEstadoFormulacion> Traer_EstadoFormulacionId(Int32 idestadoformulacion)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEstadoFormulacion, Nombre_EstadoFormulacion from  PR_aEstadoFormulacion where IdEstadoFormulacion = @id";
                    return conexionsql.Query<PR_aEstadoFormulacion>(sql, new { id = idestadoformulacion });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_EstadoFormulacion(PR_aEstadoFormulacion aestadoformulacion)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aEstadoFormulacion (Nombre_EstadoFormulacion) values (@nombre_formulacion)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_formulacion = aestadoformulacion.Nombre_EstadoFormulacion });
                    return "PROCESADO";
                }
            }
            catch (Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_EstadoFormulacion(PR_aEstadoFormulacion aestadoformulacion)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update PR_aEstadoFormulacion set Nombre_EstadoFormulacion = @nombre_estadoformulacion where IdEstadoFormulacion = @id";
                    conexionsql.ExecuteScalar(sqledit, new { nombre_estadoformulacion = aestadoformulacion.Nombre_EstadoFormulacion, id = aestadoformulacion.IdEstadoFormulacion});
                    return "PROCESADO";
                }
            }
            catch (Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_EstadoFormulacion(Int32 idestadoformulacion)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aEstadoFormulacion where IdEstadoFormulacion = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idestadoformulacion });
                    return "PROCESADO";
                }
            }
            catch (Exception Ex) { throw new Exception("Error al eliminar", Ex); }
        }

       
    }
}
