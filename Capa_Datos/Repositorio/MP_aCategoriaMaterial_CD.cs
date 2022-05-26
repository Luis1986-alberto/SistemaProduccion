using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class MP_aCategoriaMaterial_CD
    {
        public static readonly MP_aCategoriaMaterial_CD _Intancia = new MP_aCategoriaMaterial_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static MP_aCategoriaMaterial_CD Intancia
        { get { return MP_aCategoriaMaterial_CD._Intancia; } }

        public MP_aCategoriaMaterial_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<MP_aCategoriaMaterial> Lista_CategoriaMaterial()
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdCategoriaMaterial, Nombre_Categoria_Material from MP_aCategoriaMaterial";
                    return conexionSQL.Query<MP_aCategoriaMaterial>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<MP_aCategoriaMaterial> Traer_CategoriaMaterialPorId(Int32 ididcategoriamaterial)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdCategoriaMaterial, Nombre_Categoria_Material from MP_aCategoriaMaterial where IdCategoriaMaterial = @id  ";
                    return conexionSQL.Query<MP_aCategoriaMaterial>(sql, new { id = ididcategoriamaterial });
                }
            }
            catch(Exception ex)
            { throw new Exception("Errort al traer por ID", ex); }
        }

        public string Agregar_CategoriaMaterial(MP_aCategoriaMaterial categoriamaterial)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into MP_aCategoriaMaterial (Nombre_Categoria_Material) values (@nombre_categoria_material)";
                    conexionSQL.Execute(sqlinsert, new { nombre_categoria_material = categoriamaterial.Nombre_Categoria_Material });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }

        public string Actualizar_CategoriaMaterial(MP_aCategoriaMaterial categoriamaterial)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update MP_aCategoriaMaterial set Nombre_Categoria_Material =  @nombre_categoria_material where IdCategoriaMaterial = @id ";
                    conexionSQL.ExecuteScalar(sqlupdate, new { id = categoriamaterial.IdCategoriaMaterial, nombre_categoria_material = categoriamaterial.Nombre_Categoria_Material });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }


        public string Eliminar_CategoriaMaterial(Int32 idcategoriamaterial)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete MP_aCategoriaMaterial where IdCategoriaMaterial = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idcategoriamaterial });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }



    }
}
