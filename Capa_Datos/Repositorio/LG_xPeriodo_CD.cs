using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class LG_xPeriodo_CD
    {
        public static readonly LG_xPeriodo_CD _Instacia = new LG_xPeriodo_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static LG_xPeriodo_CD Instancia
        { get { return LG_xPeriodo_CD._Instacia; } }

        public LG_xPeriodo_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }


        public IEnumerable<LG_xPeriodo>Lista_Periodo()
        {
            try
            {
                List<LG_xPeriodo> lst_Periodo = null;
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    ConexionSQL.Open();
                    SqlCommand cmd = new SqlCommand("select * from LG_xPeriodo as PR inner join LG_aAño as a on PR.IdAño = a.IdAño inner join LG_aMes as M on PR.IdMes = M.IdMes", ConexionSQL);
                    var dr = cmd.ExecuteReader();
                    lst_Periodo = new List<LG_xPeriodo>();

                    while(dr.Read())
                    {
                        LG_xPeriodo t = new LG_xPeriodo();
                        t.IdPeriodo = Int32.Parse(dr["IdPeriodo"].ToString());
                        t.IdAño = Int32.Parse(dr["IdAño"].ToString());
                        t.IdMes = byte.Parse(dr["IdMes"].ToString());
                        t.Nombre_Periodo = dr["Nombre_Periodo"].ToString();
                        t.Flag_Cerrado = byte.Parse(dr["Flag_Cerrado"].ToString());
                        t.Fecha_Inicio = DateTime.Parse(dr["Fecha_Inicio"].ToString());
                        t.Fecha_Final = DateTime.Parse(dr["Fecha_Final"].ToString());
                        t.Mes = dr["Mes"].ToString();
                        lst_Periodo.Add(t);
                    }
                    return lst_Periodo;
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Listar", Ex);}
        }

        public LG_xPeriodo TraerPorIdPeriodo(Int32 idperiodo)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select * from LG_Periodo where IdPeriodo = @id";
                    return ConexionSQL.QueryFirst<LG_xPeriodo>(sql, new { id = idperiodo });
                }
            }
            catch(Exception ex)
            {throw new Exception("Error al Traer Por Id", ex);}
        }

        public string Agregar_Periodo(LG_xPeriodo periodo)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var SqlInsert = "Insert into LG_xPeriodo (Nombre_Periodo, IdAño, IdMes, Flag_Cerrado, Fecha_Inicio, Fecha_Final) Values ( @Nombre_Periodo, " +
                              " @IdAño, @IdMes, @Flag_Cerrado, @Fecha_Inicio, @Fecha_Final)";
                    ConexionSql.ExecuteScalar(SqlInsert, new {
                        Nombre_Periodo = periodo.Nombre_Periodo,
                        IdAño = periodo.IdAño,
                        IdMes = periodo.IdMes,
                        Flag_Cerrado = periodo.Flag_Cerrado,
                        Fecha_Inicio = periodo.Fecha_Inicio,
                        Fecha_Final = periodo.Fecha_Final,
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }

        public string Actualizar_Periodo(LG_xPeriodo periodo)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_xPeriodo set Nombre_Periodo = @Nombre_Periodo, IdAño = @IdAño, IdMes = @IdMes, Flag_Cerrado = @Flag_Cerrado, " +
                                    " Fecha_Inicio = @Fecha_Inicio, Fecha_Final = @Fecha_Final where IdPeriodo = @Id ";
                    ConexionSql.ExecuteScalar(sqlupdate, new {
                                                                Id = periodo.IdPeriodo,
                                                                Nombre_Periodo = periodo.Nombre_Periodo,
                                                                IdAño = periodo.IdAño,
                                                                IdMes = periodo.IdMes,
                                                                Flag_Cerrado = periodo.Flag_Cerrado,
                                                                Fecha_Inicio = periodo.Fecha_Inicio,
                                                                Fecha_Final = periodo.Fecha_Final,
                                                            });
                    return "PROCESADO";

                }

            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_Periodo(Int32 idperiodo)
        {
            try
            {
                using (var SQLConexion = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "Delete LG_xPeriodo where IdPeriodo = @id";
                    SQLConexion.ExecuteScalar<LG_xPeriodo>(sqldelete, new { id = idperiodo });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al eliminar el registro", ex); }
        }



    }
}
