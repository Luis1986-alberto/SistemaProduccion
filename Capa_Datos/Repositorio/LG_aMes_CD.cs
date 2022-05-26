using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aMes_CD
    {
        public static readonly LG_aMes_CD _Instancia = new LG_aMes_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_aMes_CD Instancia
        { get { return LG_aMes_CD._Instancia; } }

        public LG_aMes_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aMes> Lista_Mes()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdMes, Mes from LG_aMes ";
                    return ConexionSQL.Query<LG_aMes>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }


        public LG_aMes TraerporIdMes(Int32 idmes)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdMes, Mes from LG_aMes where IdMes = @id ";
                    return ConexionSQL.QueryFirst<LG_aMes>(sql, new { id = idmes });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }

        public string Agregar_Mes(LG_aMes mes)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into LG_aMes (Mes) values (@Mes )";
                    conexionsql.ExecuteScalar(sqlinsert, new { mes = mes.Mes });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_Mes(LG_aMes mes)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update LG_aMes set  mes = @mes where IdMes = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = mes.IdMes, mes = mes.Mes });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public string Eliminar_mes(Int32 idmes)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete LG_aMes where IdMes = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = idmes });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }

        public IEnumerable<LG_aMes> FiltroPorunCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            ConexionSQL.Open();
            var result = ConexionSQL.GetList<LG_aMes>(predicado);
            ConexionSQL.Close();
            return result;
        }
    }
}
