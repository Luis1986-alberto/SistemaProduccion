using Capa_Datos.Interface;
using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aCondicionCobranza_CD : IRepositori<LG_aCondicionCobranza>
    {
        private Inicio principal = new Inicio();
        private string cadenaconexion;
        public static readonly LG_aCondicionCobranza_CD _Instancia = new LG_aCondicionCobranza_CD();

        public static LG_aCondicionCobranza_CD Instancia
        { get { return LG_aCondicionCobranza_CD._Instancia; } }

        public LG_aCondicionCobranza_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public String Agregar(LG_aCondicionCobranza entidad)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aCondicionCobranza (Condicion_Cobranza) values (@condicion_cobranza) ";
                    ConexionSQL.Execute(sqlinsert, new { condicion_cobranza = entidad.Condicion_Cobranza });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al insertar", Ex); }
        }

        public String Actualizar(LG_aCondicionCobranza entidad)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Update LG_aCondicionCobranza set Condicion_Cobranza = @condicion_cobranza where IdCondicionCobranza = @id ";
                    ConexionSQL.Execute(sqlinsert, new { id = entidad.IdCondicionCobranza, condicion_cobranza = entidad.Condicion_Cobranza });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public String Eliminar(Int32 idcondicioncobranza)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "delete LG_aCondicionCobranza where IdCondicionCobranza = @id ";
                    ConexionSQL.Execute(sqlinsert, new { id = idcondicioncobranza });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar ", ex); }
        }

        public LG_aCondicionCobranza TraerPorId(Int32 id)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdCondicionCobranza, Condicion_Cobranza from LG_aCondicionCobranza where IdCondicionCobranza = @id";
                    return ConexionSQL.QueryFirst<LG_aCondicionCobranza>(sql, new { id = id });
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al traer ", ex); }
        }

        public IEnumerable<LG_aCondicionCobranza> Listar()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdCondicionCobranza, Condicion_Cobranza from LG_aCondicionCobranza";
                    return ConexionSQL.Query<LG_aCondicionCobranza>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Listar", Ex); }
        }

        public IEnumerable<LG_aCondicionCobranza> FiltroPorUnCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            {
                ConexionSQL.Open();
                var result = ConexionSQL.GetList<LG_aCondicionCobranza>(predicado);
                ConexionSQL.Close();
                return result;
            }  
        }

        
    }
}
