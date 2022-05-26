using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aFamilia_CD
    {
        public static readonly LG_aFamilia_CD _Instancia = new LG_aFamilia_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_aFamilia_CD Instancia
        { get { return LG_aFamilia_CD._Instancia; } }

        public LG_aFamilia_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aFamilia> Lista_Familia()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdFamilia, Nombre_Familia, Codigo_Familia, IdUsuario_PC, Fecha_Servidor, IdUsuario from LG_aFamilia ";
                    return ConexionSQL.Query<LG_aFamilia>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }


        public LG_aFamilia TraerporIDFamilia(Int32 idfamilia)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdFamilia, Nombre_Familia, Codigo_Familia, IdUsuario_PC, Fecha_Servidor, IdUsuario from LG_aFamilia where IdFamilia = @id ";
                    return ConexionSQL.QueryFirst<LG_aFamilia>(sql, new { id = idfamilia });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }

        public string Agregar_Familia(LG_aFamilia familia)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into LG_aFamilia (Nombre_Familia, Codigo_Familia, IdUsuario_PC,  IdUsuario) values " +
                                                            "(@nombre_familia, @codigo_familia, @idusuario_pc, @idusuario)";
                    conexionsql.ExecuteScalar(sqlinsert, new {
                        nombre_familia = familia.Nombre_Familia,
                        codigo_familia = familia.Codigo_Familia,
                        idusuario_pc = Environment.UserName,
                        idusuario = familia.IdUsuario
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_Familia(LG_aFamilia familia)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update LG_aFamilia set  Nombre_Familia = @nombre_familia, Codigo_Familia = @codigo_familia, IdUsuario_PC = @idusuario_pc, " +
                                    " IdUsuario = @idusuario  where IdFamilia = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                        id = familia.IdFamilia,
                        nombre_familia = familia.Nombre_Familia,
                        codigo_familia = familia.Codigo_Familia,
                        idusuario_pc = Environment.UserName,
                        idusuario = familia.IdUsuario
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public string Eliminar_Familia(Int32 idfamilia)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete LG_aFamilia where IdFamilia = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = idfamilia });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }

    }
}
