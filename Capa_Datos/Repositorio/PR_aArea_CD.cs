using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aArea_CD
    {
        public static readonly PR_aArea_CD _Intancia = new PR_aArea_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aArea_CD Intancia
        { get { return PR_aArea_CD._Intancia; } }

        public PR_aArea_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aArea> Lista_Areas()
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdArea, Nombre_Area from PR_aArea";
                    return conexionsql.Query<PR_aArea>(sql);
                }
            }
            catch (Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aArea> Traer_AreaPorId(Int32 idarea)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdArea, Nombre_Area from PR_aArea where IdArea = @id";
                    return conexionsql.Query<PR_aArea>(sql, new { id = idarea });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Area(PR_aArea aArea )
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aArea (Nombre_Area) values(@nombre_area)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_area = aArea.Nombre_Area });
                    return "PROCESADO";
                }
            }
            catch (Exception ex )
            { throw new Exception("Error asl agregar", ex);}
        }

        public string Actualizar_Area(PR_aArea aArea)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aArea set Nombre_Area = @nombre_area where IdArea = @idarea";
                    conexionsql.ExecuteScalar(sqlupdate, new { idarea = aArea.IdArea, nombre_area = aArea.Nombre_Area });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            {throw new Exception ("Error al Actualizar", ex);}
        }

        public string Eliminar_Area(Int32 idarea)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aArea where IdArea = @idarea";
                    conexionsql.ExecuteScalar(sqldelete, new { idrea = idarea });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            {throw new Exception ("Error al Eliminar",ex);}
        }

        

    }
}
