using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_xLocalArea_CD
    {
        public static readonly PR_xLocalArea_CD _Instancia = new PR_xLocalArea_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static PR_xLocalArea_CD Instancia
        { get { return PR_xLocalArea_CD._Instancia; } }

        public PR_xLocalArea_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_xLocalArea> Lista_LocalArea()
        {
            List<PR_xLocalArea> lst_LocalArea = null;
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    SqlCommand cmd = new SqlCommand("select LA.IdLocalArea, LA.IdLocal, LO.Nombre_Local, LA.IdArea, AR.Nombre_Area " +
                                      " from PR_xLocalArea as LA inner join PR_aLocal as LO on LA.IdLocal = LO.IdLocal inner join PR_aArea as AR on LA.IdArea = AR.IdArea ", conexionsql);
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst_LocalArea = new List<PR_xLocalArea>();

                    while(dr.Read())
                    {
                        PR_xLocalArea t = new PR_xLocalArea();
                        t.IdLocalArea = short.Parse(dr["IdLocalArea"].ToString());
                        t.IdLocal = byte.Parse(dr["IdLocal"].ToString());
                        t.Nombre_Local = dr["Nombre_Local"].ToString();
                        t.IdArea = byte.Parse(dr["IdArea"].ToString());
                        t.Nombre_Area = dr["nombre_Area"].ToString();
                        lst_LocalArea.Add(t);
                    }
                    return lst_LocalArea;
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }

        public IEnumerable<PR_xLocalArea> Filtrar_IdLocal(byte idlocal)
        {
            List<PR_xLocalArea> lst_LocalArea = null;
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    SqlCommand cmd = new SqlCommand("select LA.IdLocalArea, LA.IdLocal, LO.Nombre_Local, LA.IdArea, AR.Nombre_Area from PR_xLocalArea as LA inner join PR_aLocal as LO " +
                                      " on LA.IdLocal = LO.IdLocal inner join PR_aArea as AR on LA.IdArea = AR.IdArea where LA.IdLocal = @idlocal ", conexionsql);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@idlocal", idlocal);
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst_LocalArea = new List<PR_xLocalArea>();

                    while(dr.Read())
                    {
                        PR_xLocalArea t = new PR_xLocalArea();
                        t.IdLocalArea = short.Parse(dr["IdLocalArea"].ToString());
                        t.IdLocal = byte.Parse(dr["IdLocal"].ToString());
                        t.Nombre_Local = dr["Nombre_Local"].ToString();
                        t.IdArea = byte.Parse(dr["IdArea"].ToString());
                        t.Nombre_Area = dr["nombre_Area"].ToString();
                        lst_LocalArea.Add(t);
                    }
                    return lst_LocalArea;
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }

        public IEnumerable<PR_xLocalArea> Traer_LocalAreaPorId(Int32 idlocalarea)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select LA.IdLocalArea, LA.IdLocal, LO.Nombre_Local, LA.IdArea, AR.Nombre_Area from PR_xLocalArea as LA inner join PR_aLocal as LO " +
                            " on LA.IdLocal = LO.IdLocal inner join PR_Area as AR on LA.IdArea = AR.IdArea  where IdAlmacen = @id";
                    return conexionsql.Query<PR_xLocalArea>(sql, new { id = idlocalarea });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_LocalArea(PR_xLocalArea localarea)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_xLocalArea (IdLocal, IdArea) values (@idlocal, @idarea)";
                    conexionsql.Execute(sqlinsert, new { idlocal = localarea.IdLocal, idarea = localarea.IdArea });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_LocalArea(PR_xLocalArea localarea)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update PR_xLocalArea set IdLocal = @idlocal, IdArea = @idarea where IdLocalArea = @id";
                    conexionsql.ExecuteScalar(sqledit, new {
                        id = localarea.IdLocalArea,
                        idlocal = localarea.IdLocal,
                        idarea = localarea.IdArea,
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_LocalArea(byte id)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_xLocalArea where IdLocalArea = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = id });
                }
                return "PROCESADO";
            }
            catch(Exception ex) { throw new Exception("Error alEliminar", ex); }
        }

    }
}
