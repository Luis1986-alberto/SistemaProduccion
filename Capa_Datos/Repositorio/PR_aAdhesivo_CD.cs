using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aAdhesivo_CD
    {
        public static readonly PR_aAdhesivo_CD _Instancia = new PR_aAdhesivo_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aAdhesivo_CD Instancia
        { get { return PR_aAdhesivo_CD._Instancia; } }

        public PR_aAdhesivo_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aAdhesivo> Lista_adhesivos()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAdhesivo, Descripcion_Adhesivo from  PR_aAdhesivo";
                    return conexionsql.Query<PR_aAdhesivo>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }
        public IEnumerable<PR_aAdhesivo> Traer_AdhesivoPorId(Int32 idadhesivo)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAdhesivo, Descripcion_Adhesivo from  PR_aAdhesivo where IdAdhesivo = @id";
                    return conexionsql.Query<PR_aAdhesivo>(sql, new { id = idadhesivo });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Adhesivo(PR_aAdhesivo aAdhesivo)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aAdhesivo (Descripcion_Adhesivo) values (@descripcion_adhesivo)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_adhesivo = aAdhesivo.Descripcion_Adhesivo });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_Adhesivo(PR_aAdhesivo aAdhesivo)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update PR_aAdhesivo set Descripcion_Adhesivo = @descripcion_adhesivo where IdAdhesivo = @idadhesivo";
                    conexionsql.ExecuteScalar(sqledit, new { descripcion_adhesivo = aAdhesivo.Descripcion_Adhesivo, idadhesivo = aAdhesivo.IdAdhesivo });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_Adhesivo(Int32 idadhesivo)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_Adhesivo where IdAdhesivo = @idadhesivo";
                    conexionsql.ExecuteScalar(sqldelete, new { idadhesivo = idadhesivo });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al eliminar", Ex); }
        }


    }
}
