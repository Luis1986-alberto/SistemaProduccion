using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aMotivoObservacion_CC_CD
    {
        public static readonly PR_aMotivoObservacion_CC_CD _Instancia = new PR_aMotivoObservacion_CC_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aMotivoObservacion_CC_CD Instancia
        { get { return PR_aMotivoObservacion_CC_CD._Instancia; } }

        public PR_aMotivoObservacion_CC_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aMotivoObservacion_CC> Lista_MotivoObservacion()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMotivoObservacion_CC, Motivo_Observacion_CC from PR_aMotivoObservacion_CC";
                    return conexionsql.Query<PR_aMotivoObservacion_CC>(sql);
                }
            }
            catch(Exception ex) { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<PR_aMotivoObservacion_CC> Traer_MotivoObservacionPorId(Int32 idmotivoobservacion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMotivoObservacion_CC, Motivo_Observacion_CC from PR_aMotivoObservacion_CC where IdMotivoObservacion_CC = @id";
                    return conexionsql.Query<PR_aMotivoObservacion_CC>(sql, new { id = idmotivoobservacion });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_MotivoObservacion_CC(PR_aMotivoObservacion_CC motivoobservacion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aMotivoObservacion_CC (Motivo_Observacion_CC) values (@motibo_observacion)";
                    conexionsql.ExecuteScalar(sqlinsert, new { motibo_observacion = motivoobservacion.Motivo_Observacion_CC });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_MotivoObservacion_CC(PR_aMotivoObservacion_CC motivoobservacion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update PR_aMotivoObservacion_CC set Motivo_Observacion_CC = @motivo_observacion_cc where IdMotivoObservacion_CC = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = motivoobservacion.IdMotivoObservacion_CC, motivo_observacion_cc = motivoobservacion.Motivo_Observacion_CC });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public String Eliminar_MotivoObservacion_CC(Int32 idmotivoobservacion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aMotivoObservacion_CC where IdMotivoObservacion_CC = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idmotivoobservacion });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de eliminar", ex); }
        }

        
    }
}
