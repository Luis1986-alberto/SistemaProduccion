using Capa_Entidades.Tablas;
using Dapper;
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
    public class PR_mEstandarExtrusion_CD
    {
        private Inicio principal = new Inicio();
        private string cadenaconexion;
        private Int32 OutPutId = 0;
        public static readonly PR_mEstandarExtrusion_CD _Instancia = new PR_mEstandarExtrusion_CD();

        public static PR_mEstandarExtrusion_CD Instancia
        { get { return PR_mEstandarExtrusion_CD._Instancia; } }

        public PR_mEstandarExtrusion_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public  string EstandartExtrusion_Procesar(PR_mEstandarExtrusion mEstandarExtrusion, Int32 idestandar, string accion,  PictureBox Plano_extrusion )
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    ConexionSql.Open();
                    SqlCommand cmd = new SqlCommand("PRt_EstandarExtrusion", ConexionSql);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Accion", accion);
                    cmd.Parameters.AddWithValue("@IdestandarExtrusion", mEstandarExtrusion.IdEstandarExtrusion);
                    cmd.Parameters.AddWithValue("@IdUsoProducto", mEstandarExtrusion.IdUsoProducto);
                    cmd.Parameters.AddWithValue("@Color", mEstandarExtrusion.Color);
                    cmd.Parameters.AddWithValue("@Flag_AditivoUV", mEstandarExtrusion.Flag_AditivoUV);
                    cmd.Parameters.AddWithValue("@Flag_Apilar", mEstandarExtrusion.Flag_Apilar);
                    cmd.Parameters.AddWithValue("@Flag_BIodegradable", mEstandarExtrusion.Flag_Biodegradable);
                    cmd.Parameters.AddWithValue("@Flag_Congelado", mEstandarExtrusion.Flag_Congelado);
                    cmd.Parameters.AddWithValue("@Flag_Impresion", mEstandarExtrusion.Flag_Impresion);
                    cmd.Parameters.AddWithValue("@Flag_Refile", mEstandarExtrusion.Flag_Refile);
                    cmd.Parameters.AddWithValue("@Flag_MasLineal", mEstandarExtrusion.Flag_MasLineal);
                    cmd.Parameters.AddWithValue("@Medida_Refile", mEstandarExtrusion.Medida_Refile);                    
                    cmd.Parameters.AddWithValue("@IdUnidadRefile", mEstandarExtrusion.IdUnidadRefile);
                    cmd.Parameters.AddWithValue("@Flag_Termocontraible", mEstandarExtrusion.Flag_Termocontraible);
                    cmd.Parameters.AddWithValue("@Flag_Gofrado", mEstandarExtrusion.Flag_Gofrado);
                    cmd.Parameters.AddWithValue("@Flag_UsoPesado", mEstandarExtrusion.Flag_UsoPesado);
                    cmd.Parameters.AddWithValue("@Flag_Otros", mEstandarExtrusion.Flag_Otros);
                    cmd.Parameters.AddWithValue("@Medida_Fuelle", mEstandarExtrusion.Medida_Fuelle);
                    cmd.Parameters.AddWithValue("@Nota_Otros", mEstandarExtrusion.Nota_Otros);
                    cmd.Parameters.AddWithValue("@Medida_Manga", mEstandarExtrusion.Medida_Manga);
                    cmd.Parameters.AddWithValue("@Flag_Fuelle", mEstandarExtrusion.Flag_Fuelle);
                    cmd.Parameters.AddWithValue("@IdUnidadFuelle", mEstandarExtrusion.IdUnidadFuelle);
                    cmd.Parameters.AddWithValue("@Nota_Tratado", mEstandarExtrusion.Nota_Tratado);
                    cmd.Parameters.AddWithValue("@IdUnidadManga", mEstandarExtrusion.IdUnidadManga);
                    cmd.Parameters.AddWithValue("@Medida_Espesor", mEstandarExtrusion.Medida_Espesor);
                    cmd.Parameters.AddWithValue("@Flag_FuelleIncluido", mEstandarExtrusion.Flag_FuelleIncluido);
                    cmd.Parameters.AddWithValue("@IdUnidadEspesor", mEstandarExtrusion.IdUnidadEspesor);
                    cmd.Parameters.AddWithValue("@Nota_Extrusion", mEstandarExtrusion.Nota_Extrusion);
                    cmd.Parameters.AddWithValue("@Gramaje_Total", mEstandarExtrusion.Gramaje_Total);
                    cmd.Parameters.AddWithValue("@Gramaje_Lineal", mEstandarExtrusion.Gramaje_Lineal);
                    cmd.Parameters.AddWithValue("@Relacion_Soplado", mEstandarExtrusion.Relacion_Soplado);
                    cmd.Parameters.AddWithValue("@Ruta_FotoPlanoMecanicoExtr", mEstandarExtrusion.Ruta_FotoPlanoMecanicoExtr);
                    cmd.Parameters.AddWithValue("@Diametro_Cabezal", mEstandarExtrusion.Diametro_Cabezal);
                    cmd.Parameters.AddWithValue("@Diametro_Tuco_Extrusion", mEstandarExtrusion.Diametro_Tuco_Extrusion);
                    cmd.Parameters.AddWithValue("@IdUnidadMedidaDiametroTuco", mEstandarExtrusion.IdUnidadMedidaDiametroTuco);
                    cmd.Parameters.AddWithValue("@Medida_Tuco_Extrusion", mEstandarExtrusion.Medida_Tuco_Extrusion);
                    cmd.Parameters.AddWithValue("@IdUnidadMedidaTuco", mEstandarExtrusion.IdUnidadMedidaTuco);
                    cmd.Parameters.AddWithValue("@Peso_Tuco_Extrusion", mEstandarExtrusion.Peso_Tuco_Extrusion);
                    cmd.Parameters.AddWithValue("@IdUnidadMedidaPesoTuco", mEstandarExtrusion.IdUnidadMedidaPesoTuco);
                    cmd.Parameters.AddWithValue("@Gap_Extrusion", mEstandarExtrusion.Gap_Extrusion);
                    cmd.Parameters.AddWithValue("@Dynas_Extrusion", mEstandarExtrusion.Dynas_Extrusion);
                    cmd.Parameters.AddWithValue("@IdTipoTratado", mEstandarExtrusion.IdTipoTratado);
                    cmd.Parameters.AddWithValue("@IdTipoMaterialExtruir", mEstandarExtrusion.IdTipoMaterialExtruir);
                    cmd.Parameters.AddWithValue("@IdFormaSustrato", mEstandarExtrusion.IdFormaSustrato);
                    cmd.Parameters.AddWithValue("@IdTipoFuelle", mEstandarExtrusion.IdTipoFuelle);
                    cmd.Parameters.AddWithValue("@IdEstandar", idestandar);
                    SqlParameter ValorRetorno = new SqlParameter("@Output_Id", SqlDbType.Int);
                    ValorRetorno.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ValorRetorno);
                    cmd.ExecuteNonQuery();
                    OutPutId = Convert.ToInt32(ValorRetorno.Value);
                    ConexionSql.Close();
                }
                Actualizar_imagen(OutPutId, Plano_extrusion);
                return "PROCESADO";
            }
            catch(Exception Ex)
            {throw new Exception("Error al Procesar Estandart Extrusion", Ex);}
        }

        public PR_mEstandarExtrusion TraerPorID(Int32 idestandarextrusion)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select * from PR_mEstandarExtrusion where IdEstandarExtrusion = @id ";

                    return ConexionSql.QueryFirst<PR_mEstandarExtrusion>(sql, new { id = idestandarextrusion });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer Por Id", Ex); }
        }

        public void Descargar_Imagen(PictureBox imagen, long idestandarextr)
        {
            using(var conexionSql = new SqlConnection(cadenaconexion))
            {
                conexionSql.Open();
                SqlCommand cmd = new SqlCommand("Select Foto_PlanoMecanicoExtr From PR_mEstandarExtrusion where IdEstandarExtrusion ='" + idestandarextr + "'", conexionSql);
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("Foto_PlanoMecanicoExtr");
                dp.Fill(ds, "Foto_PlanoMecanicoExtr");
                byte[] Datos = new byte[0];
                if(ds.Tables.Count == 0) return;
                DataRow DR = ds.Tables["Foto_PlanoMecanicoExtr"].Rows[0];
                if(!DBNull.Value.Equals(DR["Foto_PlanoMecanicoExtr"]))
                {
                    Datos = (byte[])DR["Foto_PlanoMecanicoExtr"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Datos);
                    imagen.Image = System.Drawing.Bitmap.FromStream(ms);
                }
            }
        }

        private long Actualizar_imagen(long videstandarextr, PictureBox Imagen)
        {
            try
            {
                using(var conexionSql = new SqlConnection(cadenaconexion))
                {
                    conexionSql.Open();

                    if(Imagen.Image != null)
                    {
                        SqlCommand cmd = new SqlCommand
                        ("Update PR_mEstandarExtrusion set Foto_PlanoMecanicoExtr = @Foto_PlanoMecanicoExtr where IdEstandarExtrusion = @Id", conexionSql);
                        cmd.Parameters.Add("@Foto_PlanoMecanicoExtr", SqlDbType.Image);
                        cmd.Parameters.AddWithValue("@Id", videstandarextr);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        Imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        cmd.Parameters["@Foto_PlanoMecanicoExtr"].Value = ms.GetBuffer();
                        cmd.ExecuteNonQuery();
                        conexionSql.Close();
                    }
                }
            }
            catch { return 0; }
            return 1;
        }

        
        public String Eliminar_EstandarExtrusion(Int32 idEstandar)
        {
            try
            {
                using (var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "Delete PR_mEstandarExtrusion where IdEstandar = @Id";

                    ConexionSql.Execute(sqldelete, new { Id = idEstandar });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception ("Error al Eliminar" + idEstandar, Ex );}
        }

    }
}
