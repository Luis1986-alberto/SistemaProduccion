using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aColor_CD
    {

        public static readonly PR_aColor_CD _Instancia = new PR_aColor_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aColor_CD Instancia
        { get { return PR_aColor_CD._Instancia; } }

        public PR_aColor_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aColor> Lista_Color()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdColor, Nombre_Color, Codigo_Color from PR_aColor";
                    return conexionsql.Query<PR_aColor>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<PR_aColor> Traer_ColorPorId(Int32 idcolor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdColor, Nombre_Color, Codigo_Color from PR_aColor where IdColor = @id";
                    return conexionsql.Query<PR_aColor>(sql, new { id = idcolor });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Color(PR_aColor color)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aColor (Nombre_Color, Codigo_Color) values (@nombre_color, @codigo_color)";
                    conexionsql.Execute(sqlinsert, new { nombre_color = color.Nombre_Color, codigo_color = color.Codigo_Color });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_Color(PR_aColor color)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update PR_aColor set Nombre_Color = @nombre_color, Codigo_Color = @codigo_color  where IdColor = @idcolor";
                    conexionsql.ExecuteScalar(sqlupdate, new { nombre_color = color.Nombre_Color, codigo_color = color.Codigo_Color, idcolor = color.IdColor });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public string Eliminar_Color(Int32 idcolor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete PR_aColor where idcolor = @idcolor";
                    conexionsql.ExecuteScalar(sqlupdate, new { idcolor = idcolor });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }



    }
}
