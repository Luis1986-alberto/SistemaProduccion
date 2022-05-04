using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aFamilia_Produccion_CD
    {
        public static readonly PR_aFamilia_Produccion_CD _Instancia = new PR_aFamilia_Produccion_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aFamilia_Produccion_CD Instancia
        { get { return PR_aFamilia_Produccion_CD._Instancia; } }

        public PR_aFamilia_Produccion_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aFamilia_Produccion> Lista_FamiliasProduccion()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdFamiliaProd, Descripcion_Familia, Observacion, Orden_Gerencia from PR_aFamilia_Produccion";
                    return conexionsql.Query<PR_aFamilia_Produccion>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aFamilia_Produccion> Traer_FamiliaProdPorId(Int32 idfamiliaprod)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdFamiliaProd, Descripcion_Familia, Observacion, Orden_Gerencia from PR_aFamilia_Produccion where IdFamiliaProd = @id";
                    return conexionsql.Query<PR_aFamilia_Produccion>(sql, new { id = idfamiliaprod });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_FamiliaProduccion(PR_aFamilia_Produccion afamiliaproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aFamilia_Produccion (Descripcion_Familia, Observacion, Orden_Gerencia ) values(@descripcion_familia, @observacion, @orden_gerencia)";
                    conexionsql.ExecuteScalar(sqlinsert, new {
                                                                descripcion_familia = afamiliaproduccion.Descripcion_Familia,
                                                                observacion = afamiliaproduccion.Observacion,
                                                                orden_gerencia = afamiliaproduccion.Orden_Gerencia,
                                                                });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_FamiliaProduccion(PR_aFamilia_Produccion afamiliaproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aFamilia_Produccion set Descripcion_Familia = @descripcion_familia, Observacion = @observacion, orden_gerencia = @Orden_Gerencia " + 
                                    " where IdFamiliaProd = @id ";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                                                                id = afamiliaproduccion.IdFamiliaProd,
                                                                descripcion_familia = afamiliaproduccion.Descripcion_Familia,
                                                                observacion = afamiliaproduccion.Observacion,
                                                                orden_gerencia = afamiliaproduccion.Orden_Gerencia,
                                                            });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_FamiliaProduccion(Int32 idfamiliaprod)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aFamilia_Produccion where IdFamiliaProd = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idfamiliaprod });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

       
    }
}
