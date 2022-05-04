using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aSubFamilia_Produccion_CD
    {
        public static readonly PR_aSubFamilia_Produccion_CD _Instancia = new PR_aSubFamilia_Produccion_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aSubFamilia_Produccion_CD Instancia
        { get { return PR_aSubFamilia_Produccion_CD._Instancia; } }

        public PR_aSubFamilia_Produccion_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aSubFamilia_Produccion> Lista_SubFamiliaProduccion()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdSubFamiliaProd, Descripcion_SubFamiliaProd, Observacion from PR_aSubFamilia_Produccion";
                    return conexionsql.Query<PR_aSubFamilia_Produccion>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aSubFamilia_Produccion> Traer_subfamiliaproduccionPorId(Int32 idsubfamiliaprod)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdSubFamiliaProd, Descripcion_SubFamiliaProd, Observacion from PR_aSubFamilia_Produccion where IdSubFamiliaProd = @id";
                    return conexionsql.Query<PR_aSubFamilia_Produccion>(sql, new { id = idsubfamiliaprod });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_SubFamiliaProduccion(PR_aSubFamilia_Produccion subfamiliaproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aSubFamilia_Produccion (Descripcion_SubFamiliaProd, Observacion) values (@descripcion_subfamiliaProd, @observacion)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_subfamiliaProd = subfamiliaproduccion.Descripcion_SubFamiliaProd,
                                                               observacion = subfamiliaproduccion.Observacion
                                                             });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_SubFamiliaProduccion(PR_aSubFamilia_Produccion subfamiliaproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aSubFamilia_Produccion set Descripcion_SubFamiliaProd = @descripcion_subfamiliaProd, Observacion = @observacion  where IdSubFamiliaProd = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = subfamiliaproduccion.IdSubFamiliaProd,
                                                               descripcion_subfamiliaProd = subfamiliaproduccion.Descripcion_SubFamiliaProd,
                                                               observacion = subfamiliaproduccion.Observacion
                                                              });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_SubFamiliaProduccion(Int32 idsubfamiliaProd)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aSubFamilia_Produccion where IdSubFamiliaProd = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idsubfamiliaProd });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

    }
}
