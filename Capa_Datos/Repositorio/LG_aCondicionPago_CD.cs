using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aCondicionPago_CD
    {
        public static readonly LG_aCondicionPago_CD _Instancia = new LG_aCondicionPago_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static LG_aCondicionPago_CD Instancia
        { get { return LG_aCondicionPago_CD._Instancia; } }

        public LG_aCondicionPago_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aCondicionPago> Lista_CondicionPago()
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdCondicionPago, Nombre_Condicion_Pago from LG_aCondicionPago";
                    return conexionsql.Query<LG_aCondicionPago>(sql);
                }
            }
            catch (Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public LG_aCondicionPago Traer_CondicionPagoPorId(Int32 idcondicionpago)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdCondicionPago, Nombre_Condicion_Pago from LG_aCondicionPago where IdCondicionPago = @id";
                    return conexionsql.QueryFirst<LG_aCondicionPago>(sql, new { id = idcondicionpago });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_CondicionPago(LG_aCondicionPago condicionpago)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into LG_aCondicionPago (Nombre_Condicion_Pago) values (@nombre_condicion_pago)";
                    conexionsql.ExecuteScalar(sqlinsert, new
                    {
                        nombre_condicion_pago = condicionpago.Nombre_Condicion_Pago
                    });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_CondicionPago(LG_aCondicionPago condicionpago)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update LG_aCondicionPago set  Nombre_Condicion_Pago = @nombre_condicion_pago where IdCondicionPago = @id ";
                    conexionsql.ExecuteScalar(sqlupdate, new
                                                            {
                                                                id = condicionpago.IdCondicionPago,
                                                                nombre_condicion_pago = condicionpago.Nombre_Condicion_Pago                       
                                                            });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public string Eliminar_CondicionPago(Int32 idcondicionpago)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete LG_aCondicionPago where IdCondicionPago = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = idcondicionpago });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }

        
    }
}
