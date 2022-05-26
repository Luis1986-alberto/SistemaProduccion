using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aPrioridad_CD
    {
        public static readonly PR_aPrioridad_CD _Instancia = new PR_aPrioridad_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aPrioridad_CD Instancia
        { get { return PR_aPrioridad_CD._Instancia; } }

        public PR_aPrioridad_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aPrioridad> Lista_Priodidades()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdPrioridad, Descripcion_Prioridad from PR_aPrioridad";
                    return conexionsql.Query<PR_aPrioridad>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aPrioridad> Traer_PrioridadesPorId(Int32 idprioridad)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdPrioridad, Descripcion_Prioridad from PR_aPrioridad where IdPrioridad = @id";
                    return conexionsql.Query<PR_aPrioridad>(sql, new { id = idprioridad });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Prioriad(PR_aPrioridad prioridad)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aPrioridad (Descripcion_Prioridad) values(@descripcion_prioridad)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_prioridad = prioridad.Descripcion_Prioridad });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_Prioridad(PR_aPrioridad prioridad)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aPrioridad set Descripcion_Prioridad = @descripcion_prioridad where IdPrioridad = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = prioridad.IdPrioridad, descripcion_prioridad = prioridad.Descripcion_Prioridad });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_Prioridad(Int32 idprioridad)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aPrioridad where IdPrioridad = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idprioridad });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
