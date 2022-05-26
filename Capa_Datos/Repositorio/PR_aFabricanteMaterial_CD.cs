using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aFabricanteMaterial_CD
    {
        public static readonly PR_aFabricanteMaterial_CD _Instancia = new PR_aFabricanteMaterial_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aFabricanteMaterial_CD Instancia
        { get { return PR_aFabricanteMaterial_CD._Instancia; } }

        public PR_aFabricanteMaterial_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aFabricanteMaterial> Lista_FabricanteMaterial()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdFabricanteMaterial, Razon_Social, Direccion, Numero_RUC, Numero_Telefono, Pais from PR_aFabricanteMaterial";
                    return conexionsql.Query<PR_aFabricanteMaterial>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aFabricanteMaterial> Traer_FabricanteMaterialPorId(Int32 idfabricantematerial)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdFabricanteMaterial, Razon_Social, Direccion, Numero_RUC, Numero_Telefono, Pais from PR_aFabricanteMaterial where IdFabricanteMaterial = @id";
                    return conexionsql.Query<PR_aFabricanteMaterial>(sql, new { id = idfabricantematerial });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_FabricanteMaterial(PR_aFabricanteMaterial fabricantematerial)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aFabricanteMaterial (Direccion, Numero_Ruc, numero_Telefonico, Razon_Social, Pais) values(@direccion, @numero_ruc, @numero_telefonico, razon_social, pais)";
                    conexionsql.ExecuteScalar(sqlinsert, new {
                        direccion = fabricantematerial.Direccion,
                        numero_ruc = fabricantematerial.Numero_RUC,
                        numero_telefono = fabricantematerial.Numero_Telefono,
                        razon_social = fabricantematerial.Razon_Social,
                        pais = fabricantematerial.Pais
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_FabricanteMaterial(PR_aFabricanteMaterial fabricantematerial)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aFabricanteMaterial set Direccion = @direccion, Numero_Ruc = @numero_ruc, numero_Telefonico = @numero_telefonico, " +
                                    " Razon_Social = @razon_social, Pais = @pais where IdFabricanteMaterial = @id ";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                        id = fabricantematerial.IdFabricanteMaterial,
                        direccion = fabricantematerial.Direccion,
                        numero_ruc = fabricantematerial.Numero_RUC,
                        numero_telefono = fabricantematerial.Numero_Telefono,
                        razon_social = fabricantematerial.Razon_Social,
                        pais = fabricantematerial.Pais
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_Fabricantematerial(Int32 idfabricantematerial)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aFabricanteMaterial where IdFabricanteMaterial = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idfabricantematerial });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
