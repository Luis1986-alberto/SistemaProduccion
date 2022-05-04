using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aEtiqueta_CD
    {

        public static readonly PR_aEtiqueta_CD _Instancia = new PR_aEtiqueta_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aEtiqueta_CD Instancia
        { get { return PR_aEtiqueta_CD._Instancia; } }

        public PR_aEtiqueta_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aEtiqueta> Lista_Etiquetas()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEtiqueta, Descripcion, Orden_Sistemas from PR_aEtiqueta";
                    return conexionsql.Query<PR_aEtiqueta>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aEtiqueta> Traer_EtiquetaPorId(Int32 idetiqueta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEtiqueta, Descripcion, Orden_Sistemas from PR_aEtiqueta where IdEtiqueta = @id";
                    return conexionsql.Query<PR_aEtiqueta>(sql, new { id = idetiqueta });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Etiqueta(PR_aEtiqueta aetiqueta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aEtiqueta (Descripcion, Orden_Sistemas) values(@descripcion, @orden_sistemas)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion = aetiqueta.Descripcion, orden_sistemas = aetiqueta.Orden_Sistemas});
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_Etiqueta(PR_aEtiqueta aetiqueta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aEtiqueta set Descripcion = @descripcion, Orden_Sistemas = orden_sistemas where IdEtiqueta = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = aetiqueta.IdEtiqueta, descripcion = aetiqueta.Descripcion, orden_sistemas = aetiqueta.Orden_Sistemas });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_Etiqueta(Int32 idetiqueta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aEtiqueta where IdEtiqueta = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idetiqueta });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

       
    }
}
