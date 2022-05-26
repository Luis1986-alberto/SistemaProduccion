using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aEspesorTuco_CD
    {
        public static readonly PR_aEspesorTuco_CD _Instancia = new PR_aEspesorTuco_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aEspesorTuco_CD Instancia
        { get { return PR_aEspesorTuco_CD._Instancia; } }

        public PR_aEspesorTuco_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aEspesorTuco> Lista_EspesorTuco()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    SqlCommand cmd = new SqlCommand("select ET.IdEspesorTuco, ET.Medida_EspesorTuco, ET.IdUnidadEspesorTuco, UM.Sigla_Unidad from PR_aEspesorTuco as ET inner join PR_aUnidadMedidas as UM " +
                                                    " on ET.IdUnidadEspesorTuco = UM.IdUnidadMedida", conexionsql);
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PR_aEspesorTuco> lsta_EspesorTuco = new List<PR_aEspesorTuco>();

                    while(dr.Read())
                    {
                        PR_aEspesorTuco t = new PR_aEspesorTuco();
                        t.IdEspesorTuco = byte.Parse(dr["IdEspesorTuco"].ToString());
                        t.Medida_EspesorTuco = decimal.Parse(dr["Medida_EspesorTuco"].ToString());
                        t.IdUnidadEspesorTuco = byte.Parse(dr["IdUnidadEspesorTuco"].ToString());
                        t.Sigla_Unidad = dr["Sigla_Unidad"].ToString();
                        lsta_EspesorTuco.Add(t);
                    }
                    return lsta_EspesorTuco;
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aEspesorTuco> Traer_EspesortucoPorId(Int32 idespesortuco)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEspesorTuco, Medida_EspesorTuco, IdUnidadEspesorTuco from PR_aEspesorTuco where IdEspesorTuco = @id";
                    return conexionsql.Query<PR_aEspesorTuco>(sql, new { id = idespesortuco });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }


        public string Agregar_EspesorTuco(PR_aEspesorTuco espesortuco)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aEspesorTuco (Medida_EspesorTuco, IdUnidadEspesorTuco) values(@medida_espesortuco, @idunidadespesortuco)";
                    conexionsql.ExecuteScalar(sqlinsert, new { medida_espesortuco = espesortuco.Medida_EspesorTuco, idunidadespesortuco = espesortuco.IdUnidadEspesorTuco });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_EspesorTuco(PR_aEspesorTuco espesortuco)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aEspesorTuco set Medida_EspesorTuco = @medida_espesortuco, IdUnidadEspesorTuco = @idunidadespesortuco where IdEspesorTuco = @idespesortuco";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                        idespesortuco = espesortuco.IdEspesorTuco,
                        medida_espesortuco = espesortuco.Medida_EspesorTuco,
                        idunidadespesortuco = espesortuco.IdUnidadEspesorTuco
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_EspesorTuco(Int32 idespesortuco)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aEspesorTuco where IdEspesorTuco = @idespesortuco";
                    conexionsql.ExecuteScalar(sqldelete, new { idespesortuco = idespesortuco });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

    }
}
