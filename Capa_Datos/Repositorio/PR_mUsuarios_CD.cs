using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_mUsuarios_CD
    {
        public static readonly PR_mUsuarios_CD _Instancia = new PR_mUsuarios_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static PR_mUsuarios_CD Instancia
        { get { return PR_mUsuarios_CD._Instancia; } }

        public PR_mUsuarios_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_mUsuarios> Lista_Usuarios()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdUsuario, Nombres, Apellidos, Contraseña, Flag_Activo, IdNivelUsuario from PR_mUsuarios ";
                    return ConexionSQL.Query<PR_mUsuarios>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al Listar", ex); }
        }

        public PR_mUsuarios TraerPorIdUsuarios(string idusurio)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdUsuario, Nombres, Apellidos, Contraseña, Flag_Activo, IdNivelUsuario from PR_mUsuarios where IdUsuario = @id ";
                    return ConexionSQL.QueryFirst<PR_mUsuarios>(sql, new { id = idusurio });
                }
            }
            catch(Exception ex)
            { throw new Exception("error al Listar", ex); }
        }

        public string Agregar_Usuario(PR_mUsuarios usuario)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_mUsuarios (IdUsuario, Apellidos, Contraseña, Flag_Activo, IdNivelUsuario) value " +
                                    " (@idusuario, @apellidos, @contraseña, @flag_activo, @idnivelusuario) ";
                    ConexionSQL.Execute(sqlinsert, new {
                        idusuario = usuario.IdUsuario, apelidos = usuario.Apellidos, contraseña = usuario.Contraseña,
                        flag_activo = usuario.Flag_Activo, idnivelusuario = usuario.IdNivelUsuario
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }

        public string Actualizar_Usuario(PR_mUsuarios usuario)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_mUsuarios set IdUsuario = @idusuario, Apellidos = @apellidos, Contraseñas = @contraseñas, " +
                                    " Flag_Activo = @flag_activo, IdNivelUsuario = @idnivelusuario where IdUsuario = @id ";
                    ConexionSQL.ExecuteScalar(sqlupdate, new {
                        idusuario = usuario.IdUsuario, apelidos = usuario.Apellidos, contraseña = usuario.Contraseña,
                        flag_activo = usuario.Flag_Activo, idnivelusuario = usuario.IdNivelUsuario
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Actualizar", Ex); }
        }


        public string Eliminar_Usuario(string idusuario)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_mUsuarios where IdUsuario = @id ";
                    ConexionSQL.Execute(sqldelete, new { id = idusuario });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al eliminar", ex); }
        }




    }
}
