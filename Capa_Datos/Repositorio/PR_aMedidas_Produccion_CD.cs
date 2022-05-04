using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aMedidas_Produccion_CD
    {
        public static readonly PR_aMedidas_Produccion_CD _Instancia = new PR_aMedidas_Produccion_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aMedidas_Produccion_CD Instancia
        { get { return PR_aMedidas_Produccion_CD._Instancia; } }

        public PR_aMedidas_Produccion_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aMedidas_Produccion> Lista_MedidasProduccion()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMedidaProd, Descripcion_Medida, Orden_Medida from PR_aMedidas_Produccion";
                    return conexionsql.Query<PR_aMedidas_Produccion>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }
        public IEnumerable<PR_aMedidas_Produccion> Traer_MedidaProduccionPorId(Int32 idmedidaprod)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMedidaProd, Descripcion_Medida, Orden_Medida from  PR_aMedidas_Produccion where IdMedidaProd = @id";
                    return conexionsql.Query<PR_aMedidas_Produccion>(sql, new { id = idmedidaprod });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_MedidasProduccion(PR_aMedidas_Produccion medidas_produccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aMedidas_Produccion (Descripcion_Medida, Orden_Medida) values (@descripcion_medida, @orden_medida)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_medida = medidas_produccion.Descripcion_Medida, orden_medida = medidas_produccion.Orden_Medida });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_MedidaProduccion(PR_aMedidas_Produccion medidas_produccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update PR_aMedidas_Produccion set Descripcion_Medida = @descripcion_medida, Orden_Medida = orden_medida  where IdMedidaProd = @id";
                    conexionsql.ExecuteScalar(sqledit, new { id = medidas_produccion.IdMedidaProd, descripcion_medida = medidas_produccion.Descripcion_Medida, orden_medida = medidas_produccion.Orden_Medida });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_MedidaProduccion(Int32 idmedidaprod)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aMedidas_Produccion where IdMedidaProd = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idmedidaprod });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al eliminar", Ex); }
        }

       
    }
}
