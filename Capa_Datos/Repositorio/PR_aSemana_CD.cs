using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aSemana_CD
    {
        public static readonly PR_aSemana_CD _Instancia = new PR_aSemana_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aSemana_CD Instancia
        { get { return PR_aSemana_CD._Instancia; } }

        public PR_aSemana_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aSemana> Lista_Semanas()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdSemana, Nombre_Semana from PR_aSemana";
                    return conexionsql.Query<PR_aSemana>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aSemana> Traer_SemanaPorId(Int32 idsemana)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdSemana, Nombre_Semana from PR_aSemana where IdSemana = @id";
                    return conexionsql.Query<PR_aSemana>(sql, new { id = idsemana });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Semana(PR_aSemana semana)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aSemana (Nombre_Semana) values(@nombre_semana)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_semana = semana.Nombre_Semana });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_Semana(PR_aSemana semana)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aSemana set Nombre_Semana = @nombre_semana where IdSemana = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = semana.IdSemana, nombre_semana = semana.Nombre_Semana });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_Semana (Int32 idsemana)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aSemana where IdSemana = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idsemana });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

       
    }
}
