using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class PR_mVendedores_CD
    {
        public static readonly PR_mVendedores_CD _Instancia = new PR_mVendedores_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_mVendedores_CD Instancia
        { get { return PR_mVendedores_CD._Instancia; } }

        public PR_mVendedores_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_mVendedores> Lista_Vendedores()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdVendedor, Nombre_Vendedor from PR_mVendedores ";
                    return conexionsql.Query<PR_mVendedores>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }

        public PR_mVendedores TraerPorId(Int32 idvendedor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdVendedor, Nombre_Vendedor from PR_mVendedores where IdVendedor = @id ";
                    return conexionsql.QueryFirst<PR_mVendedores>(sql, new { id = idvendedor });
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al traer por Id", Ex);}
        }

        public PR_mVendedores TraerPorNombre(string nombrevendedor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdVendedor, Nombre_Vendedor from PR_mVendedores where Nombre_Vendedor = @nombre ";
                    return conexionsql.QueryFirst<PR_mVendedores>(sql, new { nombre = nombrevendedor });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al traer por Nombre", Ex); }
        }

        public string Agregar_Vendedores(PR_mVendedores vendedores)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_mVendedores (Nombre_Vendedor) values (@Nombre_Vendedor)";
                    conexionsql.ExecuteScalar(sqlinsert, new { Nombre_Vendedor = vendedores.Nombre_Vendedor });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception ("Error al Agregar ", Ex);}
        }

        public String Actualizar_Vendedores(PR_mVendedores vendedores)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_mVendedores Nombre_Vendedor = @Nombre_Vendedor where IdVendedor = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { Nombre_Vnededor = vendedores.Nombre_Vendedor, id = vendedores.IdVendedor });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Actualizar", Ex);}
        }

        public String Eliminar_Vendedores(Int32 idvendedor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_mVendedores where IdVendedor = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idvendedor });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Eliminar", Ex); }
        }

    }
}
