using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aEstado_OP_CD
    {
        public static readonly PR_aEstado_OP_CD _Instancia = new PR_aEstado_OP_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aEstado_OP_CD Instancia
        { get { return PR_aEstado_OP_CD._Instancia; } }

        public PR_aEstado_OP_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aEstado_OP> Lista_EstadoOP()
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEstado_OP, Descripcion_EstadoOP from PR_aEstado_OP";
                    return conexionsql.Query<PR_aEstado_OP>(sql);
                }
            }
            catch (Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aEstado_OP> Traer_EstadoOPPorId(Int32 idestadoop)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEstado_OP, Descripcion_EstadoOP from PR_aEstado_OP where IdEstado_OP = @id";
                    return conexionsql.Query<PR_aEstado_OP>(sql, new { id = idestadoop });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Estado_OP(PR_aEstado_OP aEstado_op)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aEstado_OP (Descripcion_EstadoOP) values(@descripcion_estadoop)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_estadoop = aEstado_op.Descripcion_EstadoOP});
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_EstadoOP(PR_aEstado_OP aEstado_op)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aEstado_OP set Descripcion_EstadoOP = @nombre_estado where IdEstado_OP = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = aEstado_op.IdEstado_OP, nombre_estado = aEstado_op.Descripcion_EstadoOP });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_EstadoOP(Int32 idestadoop)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aEstado_OP where IdEstado_OP = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idestadoop });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

       
    }
}
