using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aTipo_CD
    {
        public static readonly LG_aTipo_CD _Instancia = new LG_aTipo_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_aTipo_CD Instancia
        { get { return LG_aTipo_CD._Instancia; } }

        public LG_aTipo_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aTipo> Lista_Tipos()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipo, Nombre_Tipo, IdUsuario_PC, Fecha_Servidor, Codigo_Tipo, IdUsuario from LG_aTipo ";
                    return ConexionSQL.Query<LG_aTipo>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Listar", Ex); }
        }

        public LG_aTipo TraerPorIdTipo(Int32 idtipo)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipo, Nombre_Tipo, IdUsuario_PC, Fecha_Servidor, Codigo_Tipo, IdUsuario from LG_aTipo where IdTipo = @id ";
                    return ConexionSQL.QueryFirst<LG_aTipo>(sql, new { id = idtipo });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al traer por Id", Ex); }
        }

        public string Agregar_Tipo(LG_aTipo tipo)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aTipo (Nombre_Tipo, Codigo_Tipo, IdUsuario, IdUsuario_PC ) values " +
                                    " (@nombre_tipo, @codigo_tipo, @idusuario, @idusuario_pc)";
                    ConexionSQL.Execute(sqlinsert, new {
                        nombre_tipo = tipo.Nombre_Tipo, codigo_tipo = tipo.Codigo_Tipo, idusuario = tipo.IdUsuario,
                        idusuario_pc = Environment.UserName
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Agregar", Ex); }
        }

        public string Actualizar_Tipo(LG_aTipo tipo)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_aTipo set Nombre_Tipo = @nombre_tipo, Codigo_Tipo = @codigo_tipo, IdUsuario = @idusuario, IdUsuario_PC = @idusuario_pc" +
                                     " where IdTipo = @id )";
                    ConexionSQL.Execute(sqlupdate, new {
                        id = tipo.IdTipo, nombre_tipo = tipo.Nombre_Tipo, codigo_tipo = tipo.Codigo_Tipo,
                        idusuario = tipo.IdUsuario, idusuario_pc = Environment.UserName
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Agregar", Ex); }
        }

        public String Eliminar_Tipo(Int32 idtipo)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete LG_aTipo where IdTipo = @id ";
                    ConexionSQL.Execute(sqldelete, new { id = idtipo });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Eliminar", Ex); }
        }

        public IEnumerable<LG_aTipo> FiltroPorunCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            ConexionSQL.Open();
            var result = ConexionSQL.GetList<LG_aTipo>(predicado);
            ConexionSQL.Close();
            return result;
        }

    }
}
