using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aLineaColor_CD
    {
        public static readonly PR_aLineaColor_CD _Instancia = new PR_aLineaColor_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aLineaColor_CD Instancia
        { get { return PR_aLineaColor_CD._Instancia; } }

        public PR_aLineaColor_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aLineaColor> Lista_LineaColor()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdLineaColor, Nombre_LineaColor from PR_aLineaColor";
                    return conexionsql.Query<PR_aLineaColor>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aLineaColor> Traer_LineaColorPorId(Int32 idlineacolor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdLineaColor, Nombre_LineaColor from PR_aLineaColor where IdLineaColor = @id";
                    return conexionsql.Query<PR_aLineaColor>(sql, new { id = idlineacolor });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_LineaColor(PR_aLineaColor lineacolor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aLineaColor (Nombre_LineaColor) values(@linea_color)";
                    conexionsql.ExecuteScalar(sqlinsert, new { linea_color = lineacolor.Nombre_LineaColor });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_LineaColor(PR_aLineaColor lineacolor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aLineaColor set Nombre_LineaColor = @nombre_lineacolor where IdLineaColor = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = lineacolor.IdLineaColor, nombre_lineacolor = lineacolor.Nombre_LineaColor });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_LineaColor(Int32 idlineacolor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aLineaColor where IdLineaColor = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idlineacolor });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

    }
}
