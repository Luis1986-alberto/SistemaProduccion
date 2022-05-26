using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aPrecisionBalanza_CD
    {
        public static readonly PR_aPrecisionBalanza_CD _Instancia = new PR_aPrecisionBalanza_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aPrecisionBalanza_CD Instancia
        { get { return PR_aPrecisionBalanza_CD._Instancia; } }

        public PR_aPrecisionBalanza_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aPrecisionBalanza> Lista_PrecisionBalanza()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdPrecisionBalanza, Precision_Balanza from PR_aPrecisionBalanza";
                    return conexionsql.Query<PR_aPrecisionBalanza>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aPrecisionBalanza> Traer_PrecisionBalanzaPorId(Int32 idpresicionbalanza)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdPrecisionBalanza, Precision_Balanza from PR_aAsa where IdPrecisionBalanza = @id";
                    return conexionsql.Query<PR_aPrecisionBalanza>(sql, new { id = idpresicionbalanza });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_PresicionBalanza(PR_aPrecisionBalanza presicionbalanza)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aPrecisionBalanza (Precision_Balanza) values(@precision_balanza)";
                    conexionsql.ExecuteScalar(sqlinsert, new { precision_balanza = presicionbalanza.Precision_Balanza });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_PresicionBalanza(PR_aPrecisionBalanza presicionbalanza)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aPrecisionBalanza set Precision_Balanza = @precision_balanza where IdPrecisionBalanza = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = presicionbalanza.IdPrecisionBalanza, precision_balanza = presicionbalanza.Precision_Balanza });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_Presicionbalanza(Int32 idpresicionbalanza)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aPrecisionBalanza where IdPrecisionBalanza = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idpresicionbalanza });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
