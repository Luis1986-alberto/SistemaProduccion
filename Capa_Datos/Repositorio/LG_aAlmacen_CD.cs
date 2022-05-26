using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aAlmacen_CD
    {
        public static readonly LG_aAlmacen_CD _Instancia = new LG_aAlmacen_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_aAlmacen_CD Instancia
        { get { return LG_aAlmacen_CD._Instancia; } }

        public LG_aAlmacen_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aAlmacen> Lista_Almacenes()
        {
            List<LG_aAlmacen> Lst_Almacenes = null;
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    SqlCommand cmd = new SqlCommand("select ALM.IdAlmacen, ALM.Nombre_Almacen, ALM.Sigla_Almacen, ALM.IdEmpresa, EMP.Nombre_Empresa from LG_aAlmacen as ALM inner join PR_aEmpresa as EMP" +
                                                     " on ALM.IdEmpresa = EMP.IdEmpresa", conexionsql);
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    Lst_Almacenes = new List<LG_aAlmacen>();

                    while(dr.Read())
                    {
                        LG_aAlmacen t = new LG_aAlmacen();
                        t.IdAlmacen = byte.Parse(dr["IdAlmacen"].ToString());
                        t.Nombre_Almacen = dr["Nombre_Almacen"].ToString();
                        t.Sigla_Almacen = dr["Sigla_Almacen"].ToString();
                        t.IdEmpresa = byte.Parse(dr["IdEmpresa"].ToString());
                        t.Nombre_Empresa = dr["Nombre_Empresa"].ToString();
                        Lst_Almacenes.Add(t);
                    }
                    return Lst_Almacenes;
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }

        public IEnumerable<LG_aAlmacen> Traer_AlamcenPorId(Int32 idalmacen)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAlmacen, Nombre_Almacen, Sigla_Almacen, IdEmpresa from LG_aAlmacen where IdAlmacen = @id";
                    return conexionsql.Query<LG_aAlmacen>(sql, new { id = idalmacen });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Almacen(LG_aAlmacen almacen)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into LG_aAlmacen (Nombre_Almacen, Sigla_Almacen, IdEmpresa) values (@nombre_almacen, @sigla_almacen, @idempresa)";
                    conexionsql.Execute(sqlinsert, new { nombre_almacen = almacen.Nombre_Almacen, sigla_almacen = almacen.Sigla_Almacen, idempresa = almacen.IdEmpresa });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_Almacen(LG_aAlmacen almacen)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update LG_aAlmacen set Nombre_Almacen = @nombre_almacen, Sigla_Almacen = @sigla_almacen, IdEmpresa = @idempresa  where IdAlmacen = @idalmacen";
                    conexionsql.ExecuteScalar(sqledit, new {
                        id = almacen.IdAlmacen,
                        nombre_almacen = almacen.Nombre_Almacen,
                        sigla_almacen = almacen.Sigla_Almacen,
                        idempresa = almacen.IdEmpresa,
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_Almacen(Int32 idalmacen)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete LG_aAlmacen where IdAlmacen = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idalmacen });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al eliminar", Ex); }
        }

        public IEnumerable<LG_aAlmacen> FiltrarporUnCampo(IPredicate predicate)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            ConexionSQL.Open();
            var result = ConexionSQL.GetList<LG_aAlmacen>(predicate);
            ConexionSQL.Close();
            return result;
        }

    }
}
