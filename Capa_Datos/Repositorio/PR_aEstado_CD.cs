using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aEstado_CD
    {
        public static readonly PR_aEstado_CD _Instancia = new PR_aEstado_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aEstado_CD Instancia
        { get { return PR_aEstado_CD._Instancia; } }

        public PR_aEstado_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aEstado> Lista_Estado()
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEstado, Nombre_estado from PR_aEstado";
                    return conexionsql.Query<PR_aEstado>(sql);
                }
            }
            catch (Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aEstado> Traer_EstadoPorId(Int32 idestado)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEstado, Nombre_estado from PR_aEstado where IdEstado = @id";
                    return conexionsql.Query<PR_aEstado>(sql, new { id = idestado });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Estado(PR_aEstado aestado)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aEstado (Nombre_estado) values(@nombre_estado)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_estado = aestado.Nombre_Estado });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_Estado(PR_aEstado aestado)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aEstado set Nombre_estado = @nombre_estado where IdEstado = @idestado";
                    conexionsql.ExecuteScalar(sqlupdate, new { idestado = aestado.IdEstado, nombre_estado = aestado.Nombre_Estado });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_Estado(Int32 idestado)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aEstado where IdEstado = @idestado";
                    conexionsql.ExecuteScalar(sqldelete, new { idestado = idestado });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

      
    }
}
