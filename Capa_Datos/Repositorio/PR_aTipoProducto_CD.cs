using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoProducto_CD
    {
        public static readonly PR_aTipoProducto_CD _Instancia = new PR_aTipoProducto_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoProducto_CD Instancia
        { get { return PR_aTipoProducto_CD._Instancia; } }

        public PR_aTipoProducto_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoProducto> Lista_TipoProducto()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoProducto, Nombre_TipoProducto from PR_aTipoProducto";
                    return conexionsql.Query<PR_aTipoProducto>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoProducto> Traer_TipoProductoPorId(Int32 idtipoproducto)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoProducto, Nombre_TipoProducto from PR_aTipoProducto where IdTipoProducto = @id";
                    return conexionsql.Query<PR_aTipoProducto>(sql, new { id = idtipoproducto });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoProducto(PR_aTipoProducto tipoproducto)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoProducto (Nombre_TipoProducto) values(@nombre_tipoproducto)";
                    conexionsql.Execute(sqlinsert, new { nombre_tipoproducto = tipoproducto.Nombre_TipoProducto });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoProducto(PR_aTipoProducto tipoproducto)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoProducto set Nombre_TipoProducto = @nombre_tipoproducto where IdTipoProducto = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipoproducto.IdTipoProducto, nombre_tipoproducto = tipoproducto.Nombre_TipoProducto });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoProducto(Int32 idtipoproducto)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoProducto where IdTipoProducto = @idasa";
                    conexionsql.ExecuteScalar(sqldelete, new { idasa = idtipoproducto });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
