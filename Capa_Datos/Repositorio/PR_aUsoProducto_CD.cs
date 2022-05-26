using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aUsoProducto_CD
    {
        public static readonly PR_aUsoProducto_CD _Instancia = new PR_aUsoProducto_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aUsoProducto_CD Instancia
        { get { return PR_aUsoProducto_CD._Instancia; } }

        public PR_aUsoProducto_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aUsoProducto> Lista_UsoProductos()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdUsoProducto, Descripcion_UsoProducto from PR_aUsoProducto";
                    return conexionsql.Query<PR_aUsoProducto>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aUsoProducto> Traer_UsoProductoPorId(Int32 idusoproducto)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdUsoProducto, Descripcion_UsoProducto from PR_aUsoProducto where IdUsoProducto = @id";
                    return conexionsql.Query<PR_aUsoProducto>(sql, new { id = idusoproducto });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_UsoProducto(PR_aUsoProducto uso_producto)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aUsoProducto (Descripcion_UsoProducto) values(@descripcion_usoproducto)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_usoproducto = uso_producto.Descripcion_UsoProducto });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_UsoProducto(PR_aUsoProducto uso_producto)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aUsoProducto set Descripcion_UsoProducto = @descripcion_usoproducto where IdUsoProducto = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = uso_producto.IdUsoProducto, descripcion_usoproducto = uso_producto.Descripcion_UsoProducto });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_UsoProducto(Int32 idusoproducto)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aUsoProducto where IdUsoProducto = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idusoproducto });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
