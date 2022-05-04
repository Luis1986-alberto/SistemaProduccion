using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class LG_aTipoDocumento_CD
    {
        public static readonly LG_aTipoDocumento_CD _Instancia = new LG_aTipoDocumento_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_aTipoDocumento_CD Instancia
        { get { return LG_aTipoDocumento_CD._Instancia; } }

        public LG_aTipoDocumento_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aTipoDocumento> Lista_TipoDocumento()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoDocumento, Nombre_TipoDocumento, Sigla_TipoDocumento, Alias_TipoDocumento from LG_aTipoDocumento ";
                    return ConexionSQL.Query<LG_aTipoDocumento>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("ERror al Listar", Ex); }
        }

        
        public LG_aTipoDocumento traerPorIdTipoDocumento(Int32 idtipodocumento)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoDocumento, Nombre_TipoDocumento, Sigla_TipoDocumento, Alias_TipoDocumento from LG_aTipoDocumento where IdTipoDocumento = @id ";
                    return ConexionSQL.QueryFirst<LG_aTipoDocumento>(sql, new { id = idtipodocumento });
                }
            }
            catch(Exception Ex)
            { throw new Exception("ERror al Listar", Ex); }
        }

        public string Agregar_TipoDocumento(LG_aTipoDocumento tipodocumento)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aTipoDocumento (Nombre_TipoDocumento, Sigla_TipoDocumento, Alias_TipoDocumento) values " +
                              " (@nombre_tipodocumento, @sigla_TipoDocumento, @alias_tipodocumento) ";
                    ConexionSQL.Execute(sqlinsert, new { nombre_tipodocumento = tipodocumento.Nombre_TipoDocumento,
                                                         sigla_TipoDocumento = tipodocumento.Sigla_TipoDocumento,
                                                         alias_tipodocumento = tipodocumento.Alias_TipoDocumento
                                                       });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("ERror al Listar", Ex); }
        }

        public string Actualizar_TipoDocumento(LG_aTipoDocumento td)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Update LG_aTipoDocumento set Nombre_TipoDocumento = @nombre_tipodocumento, Sigla_TipoDocumento = @sigla_TipoDocumento, " +
                                    "Alias_TipoDocumento = @alias_tipodocumento where IdTipoDocumento = @id";
                    ConexionSQL.Execute(sqlinsert, new {id = td.IdTipoDocumento, nombre_tipodocumento = td.Nombre_TipoDocumento,
                                                        sigla_TipoDocumento = td.Sigla_TipoDocumento, alias_tipodocumento = td.Alias_TipoDocumento
                                                        });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("ERror al Listar", Ex); }
        }

        public string Eliminar_TipoDocumento(Int32 idtipodocumento)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete LG_aTipoDocumento where IdTipoDocumento = @id ";
                    ConexionSQL.Execute(sqldelete, new { id = idtipodocumento });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Eliminar", Ex);}
        }

        public IEnumerable<LG_aTipoDocumento> FiltroPorunCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            ConexionSQL.Open();
            var result = ConexionSQL.GetList<LG_aTipoDocumento>(predicado);
            ConexionSQL.Close();
            return result;
        }


    }
}
