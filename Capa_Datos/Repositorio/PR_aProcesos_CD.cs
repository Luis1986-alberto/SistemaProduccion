using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aProcesos_CD
    {
        public static readonly PR_aProcesos_CD _Instancia = new PR_aProcesos_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aProcesos_CD Instancia
        { get { return PR_aProcesos_CD._Instancia; } }

        public PR_aProcesos_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aProcesos> Lista_Procesos()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdProcesos, Secuencia_Procesos, Flag_Extrusion, Flag_Impresion, Flag_Sellado, Flag_Corte , Flag_Laminado, Flag_Doblado, Secuencia_Procesos from PR_aProcesos";
                    return conexionsql.Query<PR_aProcesos>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aProcesos> Traer_ProcesosPorId(Int32 idprocesos)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdProcesos, Secuencia_Procesos, Flag_Extrusion, Flag_Impresion, Flag_Sellado, Flag_Corte , Flag_Laminado, Flag_Doblado, Secuencia_Procesos from PR_aProcesos " +
                             " where IdProcesos = @id";
                    return conexionsql.Query<PR_aProcesos>(sql, new { id = idprocesos });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Procesos(PR_aProcesos procesos)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aProcesos (Secuencia_Procesos, Flag_Extrusion, Flag_Impresion, Flag_Laminado, Flag_Sellado, Flag_Corte, Flag_Doblado) " +
                                    " values(@secuencia_procesos, @flag_extrusion, @flag_impresion, @flag_laminado, @flag_sellado, @flag_corte, @flag_doblado)";
                    conexionsql.ExecuteScalar(sqlinsert, new {
                                                               secuencia_procesos = procesos.Secuencia_Procesos,
                                                               flag_extrusion = procesos.Flag_Extrusion,
                                                               flag_impresion = procesos.Flag_Impresion,
                                                               flag_laminado = procesos.Flag_Laminado,
                                                               flag_sellado = procesos.Flag_Sellado,
                                                               flag_corte = procesos.Flag_Corte,
                                                               flag_doblado = procesos.Flag_Doblado
                                                            });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_Procesos(PR_aProcesos procesos)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aProcesos set Secuencia_Procesos = @secuencia_procesos, Flag_Extrusion = @flag_extrusion, Flag_Impresion = @flag_impresion, Flag_Laminado = @flag_laminado, " +
                                    " Flag_Sellado = @flag_sellado, Flag_Corte = @flag_corte, Flag_Doblado = @flag_doblado  where IdProcesos = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                                                                id = procesos.IdProcesos,
                                                                secuencia_procesos = procesos.Secuencia_Procesos,
                                                                flag_extrusion = procesos.Flag_Extrusion,
                                                                flag_impresion = procesos.Flag_Impresion,
                                                                flag_laminado = procesos.Flag_Laminado,
                                                                flag_sellado = procesos.Flag_Sellado,
                                                                flag_corte = procesos.Flag_Corte,
                                                                flag_doblado = procesos.Flag_Doblado
                                                                });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_Procesos(Int32 idprocesos)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aProcesos where IdProcesos = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idprocesos });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

        
    }
}
