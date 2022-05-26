using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aMarcaMaterial_CD
    {
        public static readonly PR_aMarcaMaterial_CD _Instancia = new PR_aMarcaMaterial_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aMarcaMaterial_CD Instancia
        { get { return PR_aMarcaMaterial_CD._Instancia; } }

        public PR_aMarcaMaterial_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<MP_aMarcaMaterial> Lista_aMarcaMaterial()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMarcaMaterial, Descripcion, Abreviatura_MarcaMaterial from PR_aMarcaMaterial";
                    return conexionsql.Query<MP_aMarcaMaterial>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }
        public IEnumerable<MP_aMarcaMaterial> Traer_MarcaMaterialPorId(Int32 idmarcamaterial)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMarcaMaterial, Descripcion, Abreviatura_MarcaMaterial from PR_aMarcaMaterial where IdMarcaMaterial = @id";
                    return conexionsql.Query<MP_aMarcaMaterial>(sql, new { id = idmarcamaterial });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_MarcaMaterial(MP_aMarcaMaterial amarcamaterial)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aAdhesivo (Descripcion, Abreviatura_MarcaMaterial) value (@descripcion, @Abreviatura_MarcaMaterial )";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion = amarcamaterial.Descripcion, abreviatura_marcamaterial = amarcamaterial.Abreviatura_MarcaMaterial });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_MarcaMaterial(MP_aMarcaMaterial amarcamaterial)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update PR_aMarcaMaterial set Descripcion = @descripcion, Abreviatura_MarcaMaterial = abreviatura_marcamaterial where IdMarcaMaterial = @id";
                    conexionsql.ExecuteScalar(sqledit, new { id = amarcamaterial.IdMarcaMaterial, descripcion = amarcamaterial.Descripcion, abreviatura_marcamaterial = amarcamaterial.Abreviatura_MarcaMaterial });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_MarcaMaterial(Int32 idmarcamaterial)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aMarcaMaterial where IdMarcaMaterial = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idmarcamaterial });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al eliminar", Ex); }
        }


    }
}
