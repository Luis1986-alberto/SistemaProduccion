using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aLinea_Produccion_CD
    {
        public static readonly PR_aLinea_Produccion_CD _Instancia = new PR_aLinea_Produccion_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aLinea_Produccion_CD Intancia
        { get { return PR_aLinea_Produccion_CD._Instancia; } }

        public PR_aLinea_Produccion_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aLinea_Produccion> Lista_LineaProduccion()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdLineaProd, Descripcion_Linea from PR_aLinea_Produccion";
                    return conexionsql.Query<PR_aLinea_Produccion>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aLinea_Produccion> Traer_LineaProduccionPorId(Int32 idlineaprod)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdLineaProd, Descripcion_Linea from PR_aLinea_Produccion where IdLineaProd = @id";
                    return conexionsql.Query<PR_aLinea_Produccion>(sql, new { id = idlineaprod });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_LineaProduccion(PR_aLinea_Produccion lineaproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aLinea_Produccion (Descripcion_Linea) values(@descripcion_linea)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_linea = lineaproduccion.Descripcion_Linea });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_LineaProduccion(PR_aLinea_Produccion lineaproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aLinea_Produccion set Descripcion_Linea = @descripcion_linea where IdLineaProd = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = lineaproduccion.IdLineaProd, descripcion_linea = lineaproduccion.Descripcion_Linea });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_LineaProduccion(Int32 idlineaproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aLinea_Produccion where IdLineaProd = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idlineaproduccion });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
