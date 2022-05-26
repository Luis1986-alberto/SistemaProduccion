using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aAsa_CD
    {
        public static readonly PR_aAsa_CD _Intancia = new PR_aAsa_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aAsa_CD Intancia
        { get { return PR_aAsa_CD._Intancia; } }

        public PR_aAsa_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aAsa> Lista_Asas()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAsa, Descripcion_Asa from PR_aAsa";
                    return conexionsql.Query<PR_aAsa>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aAsa> Traer_AsaPorId(Int32 idasa)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAsa, Descripcion_Asa from PR_aAsa where IdAsa = @id";
                    return conexionsql.Query<PR_aAsa>(sql, new { id = idasa });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Asa(PR_aAsa aAsa)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aAsa (Descripcion_Asa) values(@descripcion_asa)";
                    conexionsql.Execute(sqlinsert, new { descripcion_asa = aAsa.Descripcion_Asa });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_Asa(PR_aAsa aAsa)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aAsa set Descripcion_Asa = @descripcion_asa where IdAsa = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = aAsa.IdAsa, descripcion_asa = aAsa.Descripcion_Asa });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_Asa(Int32 idasa)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aAsa where IdAsa = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idasa });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
