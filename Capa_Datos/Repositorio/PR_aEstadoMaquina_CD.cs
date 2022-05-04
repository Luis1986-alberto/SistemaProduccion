using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aEstadoMaquina_CD
    {
        public static readonly PR_aEstadoMaquina_CD _Instancia = new PR_aEstadoMaquina_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aEstadoMaquina_CD Instancia
        { get { return PR_aEstadoMaquina_CD._Instancia; } }

        public PR_aEstadoMaquina_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aEstadoMaquina> Lista_EstadoMaquina()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEstadoMaquina, Nombre_Estado from  PR_aEstadoMaquina";
                    return conexionsql.Query<PR_aEstadoMaquina>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }
        public IEnumerable<PR_aEstadoMaquina> Traer_EstadoMaquinaPorId(Int32 idestadomaquina)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEstadoMaquina, Nombre_Estado from  PR_aEstadoMaquina where IdEstadoMaquina = @id";
                    return conexionsql.Query<PR_aEstadoMaquina>(sql, new { id = idestadomaquina });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_EstadoMaquina(PR_aEstadoMaquina aestadomaquina)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aEstadoMaquina (Nombre_Estado) values (@nombre_estado)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_estado = aestadomaquina.Nombre_Estado });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_EstadoMaquina(PR_aEstadoMaquina aestadomaquina)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update PR_aEstadoMaquina set Nombre_Estado = @nombre_estado where IdEstadoMaquina = @id";
                    conexionsql.ExecuteScalar(sqledit, new { nombre_estado = aestadomaquina.Nombre_Estado, id = aestadomaquina.IdEstadoMaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_EstadoMaquina(Int32 idestadomaquina)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aEstadoMaquina where IdEstadoMaquina = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idestadomaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al eliminar", Ex); }
        }

    }
}
