using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aPeriodo_CD
    {
        public static readonly PR_aPeriodo_CD _Instancia = new PR_aPeriodo_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aPeriodo_CD Instancia
        { get { return PR_aPeriodo_CD._Instancia; } }

        public PR_aPeriodo_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aPeriodo> Lista_Periodos()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdPeriodo, Nombre_Periodo, Flag_Activo from PR_aPeriodo";
                    return conexionsql.Query<PR_aPeriodo>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aPeriodo> Traer_PeriodosPorId(Int32 idperiodo)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdPeriodo, Nombre_Periodo, Flag_Activo from PR_aPeriodo where IdPeriodo = @id";
                    return conexionsql.Query<PR_aPeriodo>(sql, new { id = idperiodo });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Periodo(PR_aPeriodo periodo)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aPeriodo (Nombre_Periodo, Flag_Activo) values(@nombre_periodo, @flag_activo)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_periodo = periodo.Nombre_Periodo, flag_activo = periodo.Flag_Activo });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_Periodo(PR_aPeriodo periodo)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aPeriodo set Nombre_Periodo = @nombre_periodo, Flag_Activo = @Flag_activo where IdPeriodo = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = periodo.IdPeriodo, nombre_periodo = periodo.Nombre_Periodo, flag_activo = periodo.Flag_Activo });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_Periodo(Int32 idperiodo)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aPeriodo where IdPeriodo = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idperiodo });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
