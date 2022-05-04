using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Capa_Datos.Repositorio
{
    public class PR_aEmpresa_CD
    {
        public static readonly PR_aEmpresa_CD _Instancia = new PR_aEmpresa_CD();
        private readonly Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aEmpresa_CD Instancia
        { get { return PR_aEmpresa_CD._Instancia; } }

        public PR_aEmpresa_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aEmpresa> Listar_Empresas()
        {
            try
            {
                using (var conexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEmpresa, Nombre_Empresa, RUC_Empresa, Abreviatura_Empresa, Flag_Activo, Ruta_Foto_Empresa, Direccion_Empresa, Telefono1_Empresa, Telefono2_Empresa, Telefono3_Empresa from PR_aEmpresa";
                    return conexionSql.Query<PR_aEmpresa>(sql);
                }
            }
            catch (Exception ex)
            {throw new Exception("Error al listar",ex);}
            
        }

        public IEnumerable<PR_aEmpresa> Traer_EmpresaPorId(Int32 idempresa)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEmpresa, Nombre_Empresa, RUC_Empresa, Abreviatura_Empresa, Flag_Activo, Ruta_Foto_Empresa, Direccion_Empresa, Telefono1_Empresa, Telefono2_Empresa, Telefono3_Empresa from PR_aEmpresa where IdEmpresa = @id";
                    return conexionsql.Query<PR_aEmpresa>(sql, new { id = idempresa });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public String Agregar_Empresa(PR_aEmpresa empresa, PictureBox fotoempresa)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    SqlCommand cmd = new SqlCommand("insert into PR_aEmpresa ( Nombre_Empresa, RUC_Empresa, Abreviatura_Empresa, Flag_Activo, Ruta_Foto_Empresa, Direccion_Empresa, Telefono1_Empresa, Telefono2_Empresa, Telefono3_Empresa )" +
                                                    " values(@nombre_empresa, @ruc_empresa, @abreviatura_empresa, @flag_activo, @ruta_foto_empresa, @direccion_empresa, @telefono1_empresa, @telefono2_empresa, @telefono3_empresa)" + " SELECT SCOPE_IDENTITY() ", conexionsql);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@nombre_empresa", empresa.Nombre_Empresa);
                    cmd.Parameters.AddWithValue("@ruc_empresa", empresa.RUC_Empresa);
                    cmd.Parameters.AddWithValue("@abreviatura_empresa", empresa.Abreviatura_Empresa);
                    cmd.Parameters.AddWithValue("@flag_activo", empresa.Flag_Activo);
                    cmd.Parameters.AddWithValue("@ruta_foto_empresa", empresa.Ruta_Foto_Empresa);
                    cmd.Parameters.AddWithValue("@direccion_Empresa", empresa.Direccion_Empresa);
                    cmd.Parameters.AddWithValue("@telefono1_empresa", empresa.Telefono1_Empresa);
                    cmd.Parameters.AddWithValue("@telefono2_empresa", empresa.Telefono2_Empresa);
                    cmd.Parameters.AddWithValue("@telefono3_empresa", empresa.Telefono3_Empresa);

                    Int32 id = Int32.Parse(cmd.ExecuteScalar().ToString());
                    Actualizar_imagen(id, fotoempresa);
                }
                return "PROCESADO";
            }
            catch (Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_Empresa(PR_aEmpresa empresa, PictureBox fotoempresa)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update PR_aEmpresa set Nombre_Empresa = @nombre_empresa, RUC_Empresa = @ruc_empresa, Abreviatura_Empresa = @abreviatura_empresa, Flag_Activo = @flag_activo, " +
                                    " Ruta_Foto_Empresa = @ruta_foto_empresa, Direccion_Empresa = @direccion_empresa, Telefono1_Empresa = @telefono1_empresa, Telefono2_Empresa = @telefono2_empresa, Telefono3_Empresa = @telefono3_empresa  where IdEmpresa = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new
                                                            {
                                                                id = empresa.IdEmpresa,
                                                                nombre_empresa = empresa.Nombre_Empresa,
                                                                ruc_empresa = empresa.RUC_Empresa,
                                                                abreviatura_empresa = empresa.Abreviatura_Empresa,
                                                                flag_activo = empresa.Flag_Activo,
                                                                ruta_foto_empresa = empresa.Ruta_Foto_Empresa,
                                                                direccion_empresa = empresa.Direccion_Empresa,
                                                                telefono1_empresa = empresa.Telefono1_Empresa,
                                                                telefono2_empresa = empresa.Telefono2_Empresa,
                                                                telefono3_empresa = empresa.Telefono3_Empresa
                                                            });
                    conexionsql.Close();
                    Actualizar_imagen(empresa.IdEmpresa, fotoempresa);
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public string Eliminar_Empresa(Int32 idempresa)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aEmpresa where IdEmpresa = @idempresa";
                    conexionsql.ExecuteScalar(sqldelete, new { idempresa = idempresa });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }

        private long Actualizar_imagen(long vidempresa, PictureBox Imagen)
        {
            try
            {
                using(var conexionSql = new SqlConnection(cadenaconexion))
                {
                    conexionSql.Open();

                    if(Imagen.Image != null)
                    {
                        SqlCommand cmd = new SqlCommand
                        ("Update PR_aEmpresa set Foto_Empresa = @Foto_Empresa where IdEmpresa = @IdEmpresa", conexionSql);

                        cmd.Parameters.Add("@Foto_Empresa", SqlDbType.Image);
                        cmd.Parameters.AddWithValue("@IdEmpresa", vidempresa);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        Imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        cmd.Parameters["@Foto_Empresa"].Value = ms.GetBuffer();
                        cmd.ExecuteNonQuery();
                        conexionSql.Close();
                    }
                }
            }
            catch
            { return 0; }
            return 1;
        }

        public void Descargar_Imagen(PictureBox imagen, long vidempresa)
        {
            using(var conexionSql = new SqlConnection(cadenaconexion))
            {
                conexionSql.Open();
                SqlCommand cmd = new SqlCommand("Select Foto_Empresa From PR_aEmpresa where IdEmpresa ='" + vidempresa + "'", conexionSql);
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("Foto_Empresa");
                dp.Fill(ds, "Foto_Empresa");
                byte[] Datos = new byte[0];
                if(ds.Tables.Count == 0) return;
                DataRow DR = ds.Tables["Foto_Empresa"].Rows[0];
                if(!DBNull.Value.Equals(DR["Foto_Empresa"]))
                {
                    Datos = (byte[])DR["Foto_Empresa"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Datos);
                    imagen.Image = System.Drawing.Bitmap.FromStream(ms);
                }
            }
        }

    }
}
