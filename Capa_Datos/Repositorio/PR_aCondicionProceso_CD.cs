using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aCondicionProceso_CD
    {
        public static readonly PR_aCondicionProceso_CD _Instancia = new PR_aCondicionProceso_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static LG_aCondicionPago_CD Instancia
        { get { return LG_aCondicionPago_CD._Instancia; } }

        public PR_aCondicionProceso_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aCondicionProceso> Lista_CondicionProceso()
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdCondicionProceso, Nombre_CondicionProceso from PR_aCondicionProceso";
                    return conexionsql.Query<PR_aCondicionProceso>(sql);
                }
            }
            catch (Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<PR_aCondicionProceso> Traer_CondicionProcesoPorId(Int32 idcondicionproceso)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdCondicionProceso, Nombre_CondicionProceso from PR_aCondicionProceso where IdCondicionProceso = @id";
                    return conexionsql.Query<PR_aCondicionProceso>(sql, new { id = idcondicionproceso });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_CondicionProceso(PR_aCondicionProceso condicionproceso)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aCondicionProceso (Nombre_CondicionProceso) values (@nombre_condicionproceso)";
                    conexionsql.Execute(sqlinsert, new { nombre_condicionproceso = condicionproceso.Nombre_CondicionProceso });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_CondicionProceso(PR_aCondicionProceso condicionproceso)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update PR_aCondicionProceso set  Nombre_CondicionProceso = @nombre_condicionproceso where IdCondicionProceso = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new
                                                            {
                                                                id = condicionproceso.IdCondicionProceso,
                                                                nombre_condicionproceso = condicionproceso.Nombre_CondicionProceso,

                                                            });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public string Eliminar_CondicionProceso(Int32 idcondicionproceso)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete PR_aCondicionProceso where IdCondicionProceso = @idcondicionproceso";
                    conexionsql.ExecuteScalar(sqlupdate, new { idcondicionproceso = idcondicionproceso });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }

        
    }
}
