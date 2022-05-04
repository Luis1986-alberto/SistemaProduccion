using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class MP_aPropiedadMaterial_CD 
    {
        public static readonly MP_aPropiedadMaterial_CD _Instancia = new MP_aPropiedadMaterial_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static MP_aPropiedadMaterial_CD Instancia
        { get { return MP_aPropiedadMaterial_CD._Instancia; } }

        public MP_aPropiedadMaterial_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<MP_aPropiedadesMaterial> Lista_PropiedadMaterial()
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdPropiedadMaterial, Propiedad_Material, Codigo_PropiedadMaterial from MP_aPropiedadesMaterial";
                    return ConexionSql.Query<MP_aPropiedadesMaterial>(sql);
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Listar", Ex);}
        }

        public MP_aPropiedadesMaterial TraerPorIdPropiedadMaterial(Int32 idpropiedadmaterial)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdPropiedadMaterial, Propiedad_Material, Codigo_PropiedadMaterial from MP_aPropiedadesMaterial where IdPropiedadMaterial = @id ";
                    return ConexionSql.QueryFirst<MP_aPropiedadesMaterial>(sql, new { id = idpropiedadmaterial });
                }
            }
            catch(Exception ex)
            {throw new Exception("Error al Traer Por ID ", ex);}
        }
       

        public String Agregar(MP_aPropiedadesMaterial entity)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into MP_aPropiedadesMaterial (Propiedad_Material, Codigo_PropiedadMaterial) values (@propiedad_material, @codigo_propiedadmaterial) ";
                    ConexionSql.Execute(sqlinsert, new { propiedad_material = entity.Propiedad_Material, codigo_propiedadmaterial = entity.Codigo_PropiedadMaterial });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Agregar", Ex);}
        }

        public String Actualizar(MP_aPropiedadesMaterial entity)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update MP_aPropiedadesMaterial set Propiedad_Material = @propiedad_material, Codigo_PropiedadMaterial = @codigo_propiedadmaterial where IdPropiedadMaterial = @id ";
                    ConexionSQL.Execute(sqlupdate, new {
                        id = entity.IdPropiedadMaterial,
                        propiedad_material = entity.Propiedad_Material,
                        codigo_propiedadmaterial = entity.Codigo_PropiedadMaterial
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Actualizar", Ex); }
        }

        public String Eliminar(Int32 id)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "Delete MP_aPropiedadesMaterial where IdPropiedadMaterial = @id";
                    ConexionSQL.Execute(sqldelete, new { id = id });
                    return "PROCESADO";
                }

            }
            catch(Exception EX)
            {throw new Exception ("Error al Eliminar", EX);}
        }

       
       
       

    }
}
