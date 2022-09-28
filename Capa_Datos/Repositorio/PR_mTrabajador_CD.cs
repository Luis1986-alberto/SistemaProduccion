using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Datos.Repositorio
{
    public class PR_mTrabajador_CD
    {
        public static readonly PR_mTrabajador_CD _Instancia = new PR_mTrabajador_CD();
        private Inicio principal = new Inicio();
        private Int32 OutPutId = 0;
        private string cadenaconexion = "";

        private static PR_mTrabajador_CD Instancia
        { get { return PR_mTrabajador_CD._Instancia; } }

        public PR_mTrabajador_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public List<PR_mTrabajador>Lista_Trabajadores (string flag_idempresa, Int32 idempresa, string flag_tipotrabajador, Int32 idtipotrabajador )
        {
            List<PR_mTrabajador> Lst_Trabajadores = null;
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    SqlCommand cmd = new SqlCommand("PRr_Trabajadores", conexionsql);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag_IdEmpresa", flag_idempresa);
                    cmd.Parameters.AddWithValue("@IdEmpresa", idempresa);
                    cmd.Parameters.AddWithValue("@flag_IdTipoTrabajador", flag_tipotrabajador);
                    cmd.Parameters.AddWithValue("@IdTipoTrabajador", idtipotrabajador);

                    Lst_Trabajadores = new List<PR_mTrabajador>();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        PR_mTrabajador t = new PR_mTrabajador();
                        t.IdTrabajador = short.Parse(dr["IdTrabajador"].ToString());
                        t.Codigo_Trabajador = dr["Codigo_Trabajador"].ToString();
                        t.Apellido_Paterno = dr["Apellido_Paterno"].ToString();
                        t.Apellido_Materno = dr["Apellido_Materno"].ToString();
                        t.Nombre = dr["Nombre"].ToString();
                        t.Nombre_Completo = dr["Nombre_Completo"].ToString();
                        t.DNI = dr["DNI"].ToString();
                        t.Telefono = dr["Telefono"].ToString();
                        t.Ruta_Imagen = dr["Ruta_Imagen"].ToString();
                        t.IdTipoTrabajador = byte.Parse(dr["IdTipoTrabajador"].ToString());
                        t.Nombre_TipoTrabajador = dr["Nombre_TipoTrabajador"].ToString();
                        t.IdEmpresa = byte.Parse(dr["IdEmpresa"].ToString());
                        t.Nombre_Empresa = dr["Nombre_Empresa"].ToString();
                        t.IdLocalArea = short.Parse(dr["IdLocalArea"].ToString());
                        t.Nombre_Area = dr["Nombre_Area"].ToString();
                        t.Nombre_Local = dr["Nombre_Local"].ToString();
                        t.IdCargoTrabajador = byte.Parse(dr["IdCargoTrabajador"].ToString());
                        t.Nombre_CargoTrabajador = dr["Nombre_CargoTrabajador"].ToString();

                        Lst_Trabajadores.Add(t);
                    }
                    dr.Close();
                    return Lst_Trabajadores;
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Listar", Ex);}
        }

        public PR_mTrabajador Traer_PorId(Int32 idtrabajador)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select TR.IdTrabajador,  TR.Codigo_Trabajador, TR.Apellido_Paterno, TR.Apellido_Materno, TR.Nombre, TR.DNI, " +
                            " TR.Telefono, TR.Ruta_Imagen, TR.IdTipoTrabajador, TT.Nombre_TipoTrabajador, TR.IdEmpresa, EMP.Nombre_Empresa, TR.IdLocalArea, " +
                            " LA.IdArea, AR.Nombre_Area, LA.IdLocal, LO.Nombre_Local, TR.IdCargoTrabajador, CT.Nombre_CargoTrabajador " +
                            " from PR_mTrabajador as TR inner join PR_aTipoTrabajador as TT on TR.IdTipoTrabajador = TT.IdTipoTrabajador " +
                            " inner join PR_aEmpresa as EMP on TR.IdEmpresa = EMP.IdEmpresa inner join PR_xLocalArea as LA " +
                            " on TR.IdLocalArea = LA.IdLocalArea inner join PR_aArea as AR on LA.IdArea = AR.IdArea inner join PR_aLocal as LO " +
                            " on LA.IdLocal = LO.IdLocal inner join PR_aCargoTrabajador CT on TR.IdCargoTrabajador = CT.IdCargoTrabajador " +
                            " where TR.IdTrabajador = @id ";
                    return conexionsql.QueryFirst<PR_mTrabajador>(sql, new { id = idtrabajador });
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al traer por Id", Ex);}
        }

        public List<PR_mTrabajador>Filtrar_DescripcionTipoTrabajador(string desctipotrab)
        {
            List<PR_mTrabajador> Lst_Trabajadores = null;
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    SqlCommand cmd = new SqlCommand("select TR.IdTrabajador, 'Nombre_Completo'= TR.Apellido_Paterno + ' ' + TR.Apellido_Materno + ' ' + TR.Nombre" +
                               " from PR_mTrabajador as TR inner join PR_aTipoTrabajador as TT on TR.IdTipoTrabajador = TT.IdTipoTrabajador " +
                               " where TT.Nombre_TipoTrabajador LIKE '%" + desctipotrab + "%'", conexionsql);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Lst_Trabajadores = new List<PR_mTrabajador>();
                    
                    while(dr.Read())
                    {
                        PR_mTrabajador t = new PR_mTrabajador();
                        t.IdTrabajador = short.Parse(dr["IdTrabajador"].ToString());
                        t.Nombre_Completo = dr["Nombre_Completo"].ToString();
                        Lst_Trabajadores.Add(t);
                    }
                    conexionsql.Close();
                    return Lst_Trabajadores;
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al listar por Descripcion TipoTrabajador", Ex);}
        }

        public void Descargar_Imagen(PictureBox imagen, long idtrabajador)
        {
            using(var conexionSql = new SqlConnection(cadenaconexion))
            {
                conexionSql.Open();
                SqlCommand cmd = new SqlCommand("Select Foto_Trabajador From PR_mTrabajador where IdTrabajador ='" + idtrabajador + "'", conexionSql);
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("Foto_Trabajador");
                dp.Fill(ds, "Foto_Trabajador");
                byte[] Datos = new byte[0];
                if(ds.Tables.Count == 0) return;
                DataRow DR = ds.Tables["Foto_Trabajador"].Rows[0];
                if(!DBNull.Value.Equals(DR["Foto_Trabajador"]))
                {
                    Datos = (byte[])DR["Foto_Trabajador"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Datos);
                    imagen.Image = System.Drawing.Bitmap.FromStream(ms);
                }
            }
        }       
        
        public string Agregar_Trabajador(PR_mTrabajador trabajador, PictureBox fototrabajador)
        {
            
            try
            {
                using(var sqlconexion = new SqlConnection(cadenaconexion))
                {
                    sqlconexion.Open();
                    SqlCommand cmd = new SqlCommand(" Insert Into PR_mTrabajador (Codigo_Trabajador, Apellido_Paterno, Apellido_Materno, Nombre, DNI, Telefono, Ruta_Imagen,  " +
                                    " IdTipoTrabajador, IdEmpresa, IdLocalArea, IdCargoTrabajador) values (@codigo_trabajador, @apellido_paterno, " +
                                    " @apellido_materno, @nombre, @dni, @telefono, @ruta_imagen, @idtipotrabajador, @idempresa, @idlocalarea, @idcargotrabajador) select scope_identity()", sqlconexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@codigo_trabajador", trabajador.Codigo_Trabajador);
                    cmd.Parameters.AddWithValue("@apellido_paterno", trabajador.Apellido_Paterno);
                    cmd.Parameters.AddWithValue("@apellido_materno", trabajador.Apellido_Materno);
                    cmd.Parameters.AddWithValue("@nombre", trabajador.Nombre);
                    cmd.Parameters.AddWithValue("@DNI", trabajador.DNI);
                    cmd.Parameters.AddWithValue("@telefono", trabajador.Telefono);
                    cmd.Parameters.AddWithValue("@idtipotrabajador", trabajador.IdTipoTrabajador);
                    cmd.Parameters.AddWithValue("@idempresa", trabajador.IdEmpresa);
                    cmd.Parameters.AddWithValue("@idlocalarea", trabajador.IdLocalArea);
                    cmd.Parameters.AddWithValue("@idcargotrabajador", trabajador.IdCargoTrabajador);
                    cmd.Parameters.AddWithValue("@ruta_imagen", trabajador.Ruta_Imagen);
                    
                     OutPutId = Int32.Parse(cmd.ExecuteScalar().ToString());                        
                    sqlconexion.Close();                    
                }
                Actualizar_FotoTrabajador(OutPutId, fototrabajador);
                return "PROCESADO";
            }
            catch(Exception ex)
            {throw new Exception ("Error al agregar un trabajador", ex);}
        }

        public string Actualizar_Trabajador(PR_mTrabajador trabajador, PictureBox fototrabajador)
        {
            try
            {
                using(var sqlconexion = new SqlConnection(cadenaconexion))
                {
                    sqlconexion.Open();
                    SqlCommand cmd = new SqlCommand("Update PR_mTrabajador set Codigo_Trabajador = @codigo_trabajador, Apellido_Paterno = @apellido_paterno, " +
                                 " Apellido_Materno = @apellido_materno, Nombre = @nombre, DNI = @dni, Telefono = @Telefono, ruta_imagen = @ruta_imagen, " +
                                 " IdTipoTrabajador = @idtipotrabajador, IdEmpresa = @idempresa, " +
                                 " IdLocalArea = @idlocalarea, IdCargoTrabajador = @idcargotrabajador where IdTrabajador = @id ", sqlconexion);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@id", trabajador.IdTrabajador);
                    cmd.Parameters.AddWithValue("@codigo_trabajador", trabajador.Codigo_Trabajador);
                    cmd.Parameters.AddWithValue("@apellido_paterno", trabajador.Apellido_Paterno);
                    cmd.Parameters.AddWithValue("@apellido_materno", trabajador.Apellido_Materno);
                    cmd.Parameters.AddWithValue("@nombre", trabajador.Nombre);
                    cmd.Parameters.AddWithValue("@DNI", trabajador.DNI);
                    cmd.Parameters.AddWithValue("@telefono", trabajador.Telefono);
                    cmd.Parameters.AddWithValue("@idtipotrabajador", trabajador.IdTipoTrabajador);
                    cmd.Parameters.AddWithValue("@idempresa", trabajador.IdEmpresa);
                    cmd.Parameters.AddWithValue("@idlocalarea", trabajador.IdLocalArea);
                    cmd.Parameters.AddWithValue("@idcargotrabajador", trabajador.IdCargoTrabajador);
                    cmd.Parameters.AddWithValue("@ruta_imagen", trabajador.Ruta_Imagen);
                    cmd.ExecuteNonQuery();
                    sqlconexion.Close();
                }
                Actualizar_FotoTrabajador(trabajador.IdTrabajador, fototrabajador);
                return "PROCESADO";
            }
            catch(Exception Ex)
            {throw new Exception("Error al Atualizar", Ex);}
        }

        public String Eliminar_Trabajador(Int32 idtrabajador)
        {
            try
            {
                using(var sqlconexion = new SqlConnection(cadenaconexion))
                {
                    sqlconexion.Open();
                    SqlCommand cmd = new SqlCommand("delete PR_mTrabajador where IdTrabajador = @id ", sqlconexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", idtrabajador);
                    cmd.ExecuteNonQuery();
                    sqlconexion.Close();
                }
                return "PROCESADO";
            }
            catch(Exception Ex)
            {throw new Exception("Error al Eliminar", Ex);}
        }

        private long Actualizar_FotoTrabajador(long vidtrabajador, PictureBox Imagen)
        {
            try
            {
                using(var conexionSql = new SqlConnection(cadenaconexion))
                {
                    conexionSql.Open();

                    if(Imagen.Image != null)
                    {
                        SqlCommand cmd = new SqlCommand
                        ("Update PR_mTrabajador set Foto_Trabajador = @foto_trabajador where IdTrabajador = @Id", conexionSql);
                        cmd.Parameters.Add("@Foto_Trabajador", SqlDbType.Image);
                        cmd.Parameters.AddWithValue("@Id", vidtrabajador);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        Imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        cmd.Parameters["@Foto_Trabajador"].Value = ms.GetBuffer();
                        cmd.ExecuteNonQuery();
                        conexionSql.Close();
                    }
                }
            }
            catch
            { return 0; }
            return 1;
        }
    }
}