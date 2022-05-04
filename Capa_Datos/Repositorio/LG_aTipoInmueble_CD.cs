using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aTipoInmueble_CD
    {
        public static readonly LG_aTipoInmueble_CD _Instancia = new LG_aTipoInmueble_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;
        
        private static LG_aTipoInmueble_CD Instancia
        { get { return LG_aTipoInmueble_CD._Instancia; } }

        public LG_aTipoInmueble_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aTipoInmueble>Listar_TipoInmueble()
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoInmueble, Tipo_Inmueble from LG_aTipoInmueble ";
                    return ConexionSql.Query<LG_aTipoInmueble>(sql);
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error aql llistar", Ex);}
        }

        public LG_aTipoInmueble TraerPorIdInmueble(Int32 idtipoinmueble)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoInmueble, Tipo_Inmueble from LG_aTipoInmueble where IdTipoInmueble = id ";
                    return ConexionSql.QueryFirst<LG_aTipoInmueble>(sql, new { id = idtipoinmueble });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error aql llistar", Ex); }
        }

        public string Agregar_TipoInmueble(LG_aTipoInmueble tipoinmueble)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aTipoInmueble (Tipo_Inmueble) values (@tipo_inmueble)";
                    ConexionSQL.Execute(sqlinsert, new { tipo_inmueble = tipoinmueble.Tipo_Inmueble });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Agregar", Ex);}
        }

        public string Actualizar_TipoInmueble(LG_aTipoInmueble tipoinmueble)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Update LG_aTipoInmueble SET Tipo_Inmueble = @tipo_inmueble where IdTipoInmueble = @id";
                    ConexionSQL.Execute(sqlinsert, new {id = tipoinmueble.IdTipoInmueble, tipo_inmueble = tipoinmueble.Tipo_Inmueble });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Agregar", Ex); }
        }

        public string Eliminar_TipoInmueble(Int32  idtipoinmueble)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Delete LG_aTipoInmueble where IdTipoInmueble = @id";
                    ConexionSQL.Execute(sqlinsert, new { id = idtipoinmueble });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Agregar", Ex); }
        }

        public IEnumerable<LG_aTipoInmueble> FiltroPorunCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            ConexionSQL.Open();
            var result = ConexionSQL.GetList<LG_aTipoInmueble>(predicado);
            ConexionSQL.Close();
            return result;
        }


    }
}
