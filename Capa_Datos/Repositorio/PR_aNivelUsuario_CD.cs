using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aNivelUsuario_CD
    {
        public static readonly PR_aNivelUsuario_CD _Instancia = new PR_aNivelUsuario_CD();
        public Inicio principal = new Inicio();
        public string cadenaconexion = "";

        public static PR_aNivelUsuario_CD Instancia
        { get { return PR_aNivelUsuario_CD._Instancia; } }

        public PR_aNivelUsuario_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aNivelUsuario> Lista_nivelusuarios()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdNivelUsuario, Descripcion from PR_aNivelUsuario";
                    return conexionsql.Query<PR_aNivelUsuario>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<PR_aNivelUsuario> Lista_TraerNivelUsuarioPorId(Int32 idnivelusuario)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdNivelUsuario, Descripcion from PR_aNivelUsuario where IdNivelUsuario = @id ";
                    return conexionsql.Query<PR_aNivelUsuario>(sql, new { id = idnivelusuario });
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public string Agregar_NivelUsuario(PR_aNivelUsuario nivelusuario)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aNivelUsuario (Descripcion) value (@descripcion)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion = nivelusuario.Descripcion });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_NivelUsuario(PR_aNivelUsuario nivelusuario)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update PR_aNivelUsuario set Descripcion = @descripcion where IdNivelUsuario = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = nivelusuario.IdNivelUsuario, descripcion = nivelusuario.Descripcion });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public String Eliminar_NivelUsuario(Int32 idnivelusuario)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aNivelUsuario where IdNivelUsuario = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idnivelusuario });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de eliminar", ex); }
        }
    }
}
