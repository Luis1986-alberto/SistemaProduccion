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
    public class PR_mEstandarImpresion_CD
    {
        private Inicio principal = new Inicio();
        private string cadenaconexion;
        private Int32 OutPutId = 0;
        public static readonly PR_mEstandarImpresion_CD _Instancia = new PR_mEstandarImpresion_CD();

        public static PR_mEstandarImpresion_CD Instancia
        { get { return PR_mEstandarImpresion_CD._Instancia; } }

        public PR_mEstandarImpresion_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }


        public String EstandarImpresion_Procesar(PR_mEstandarImpresion mestandarimpresion, Int32 idestandar, string accion, PictureBox Plano_Impresion)
        {
            try
            {
                using(var Conexionsql = new SqlConnection(cadenaconexion))
                {
                    Conexionsql.Open();
                    SqlCommand cmd = new SqlCommand("PRt_EstandarImpresion", Conexionsql);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Accion", accion);
                    cmd.Parameters.AddWithValue("@IdEstandarImpresion", mestandarimpresion.IdEstandarImpresion);
                    cmd.Parameters.AddWithValue("@Numero_Repeticiones", mestandarimpresion.Numero_Repeticiones);
                    cmd.Parameters.AddWithValue("@Medida_Repeticiones", mestandarimpresion.Medida_Repeticiones);
                    cmd.Parameters.AddWithValue("@IdUnidadRepeticiones", mestandarimpresion.IdUnidadRepeticiones);
                    cmd.Parameters.AddWithValue("@Numero_Bandas", mestandarimpresion.Numero_Bandas);
                    cmd.Parameters.AddWithValue("@Medida_Bandas", mestandarimpresion.Medida_Bandas);
                    cmd.Parameters.AddWithValue("@IdUnidadBandas", mestandarimpresion.IdUnidadBandas);
                    cmd.Parameters.AddWithValue("@Numero_Pistas", mestandarimpresion.Numero_Pistas);
                    cmd.Parameters.AddWithValue("@Flag_CodigoBarra", mestandarimpresion.Flag_CodigoBarra);
                    cmd.Parameters.AddWithValue("@Flag_pieImprenta", mestandarimpresion.Flag_PieImprenta);
                    cmd.Parameters.AddWithValue("@IdPieImprenta", mestandarimpresion.IdPieImprenta);
                    cmd.Parameters.AddWithValue("@IdTipoTinta", mestandarimpresion.IdPieImprenta);
                    cmd.Parameters.AddWithValue("@Flag_Agua", mestandarimpresion.Flag_Agua);
                    cmd.Parameters.AddWithValue("@Flag_Calor", mestandarimpresion.Flag_Calor);
                    cmd.Parameters.AddWithValue("@Calor_C", mestandarimpresion.Calor_C);
                    cmd.Parameters.AddWithValue("@Flag_Congelamiento", mestandarimpresion.Flag_Congelamiento);
                    cmd.Parameters.AddWithValue("@Congelamiento_C", mestandarimpresion.Congelamiento_C);
                    cmd.Parameters.AddWithValue("@Flag_Detergente", mestandarimpresion.Flag_Detergente);
                    cmd.Parameters.AddWithValue("@Flag_Frote", mestandarimpresion.Flag_Frote);
                    cmd.Parameters.AddWithValue("@Flag_Grasa", mestandarimpresion.Flag_Grasa);
                    cmd.Parameters.AddWithValue("@Flag_UV", mestandarimpresion.Flag_UV);
                    cmd.Parameters.AddWithValue("@Flag_Otros", mestandarimpresion.Flag_Otros);
                    cmd.Parameters.AddWithValue("@Nota_Otros", mestandarimpresion.Nota_Otros);
                    cmd.Parameters.AddWithValue("@Numero_Clisse", mestandarimpresion.Numero_Clisse);
                    cmd.Parameters.AddWithValue("@Flag_ColorMuestraPantone", mestandarimpresion.Flag_ColorMuestraPantone);
                    cmd.Parameters.AddWithValue("@Flag_ImpresionInternaExterna", mestandarimpresion.Flag_ImpresionInternaExterna);
                    cmd.Parameters.AddWithValue("@Numero_Negativos", mestandarimpresion.Numero_Negativos);
                    cmd.Parameters.AddWithValue("@Nota_Negativos", mestandarimpresion.Nota_Negativos);
                    cmd.Parameters.AddWithValue("@Flag_TiraRetira", mestandarimpresion.Flag_TiraRetira);
                    cmd.Parameters.AddWithValue("@Numero_Colores", mestandarimpresion.Numero_Colores);
                    cmd.Parameters.AddWithValue("@Nota_NombreColores", mestandarimpresion.Nota_NombreColores);
                    cmd.Parameters.AddWithValue("@Numero_Colores2", mestandarimpresion.Numero_Colores2);
                    cmd.Parameters.AddWithValue("@Nota_NombreColores2", mestandarimpresion.Nota_NombreColores2);
                    cmd.Parameters.AddWithValue("@Flag_Taca", mestandarimpresion.Flag_Taca);
                    cmd.Parameters.AddWithValue("@IdPosicionTaca", mestandarimpresion.IdPosicionTaca);
                    cmd.Parameters.AddWithValue("@Medida_AnchoTaca", mestandarimpresion.Medida_AnchoTaca);
                    cmd.Parameters.AddWithValue("@Medida_LargoTaca", mestandarimpresion.Medida_LargoTaca);
                    cmd.Parameters.AddWithValue("@IdUnidadTaca", mestandarimpresion.IdUnidadTaca);
                    cmd.Parameters.AddWithValue("@Medida_EspesorClisse", mestandarimpresion.Medida_EspesorClisse);
                    cmd.Parameters.AddWithValue("@IdUnidadEspesorClisse", mestandarimpresion.IdUnidadEspesorClisse);
                    cmd.Parameters.AddWithValue("@IdImpresora", mestandarimpresion.IdImpresora);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado1", mestandarimpresion.Flag_Embobinado1);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado2", mestandarimpresion.Flag_Embobinado2);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado3", mestandarimpresion.Flag_Embobinado3);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado4", mestandarimpresion.Flag_Embobinado4);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado5", mestandarimpresion.Flag_Embobinado5);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado6", mestandarimpresion.Flag_Embobinado6);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado7", mestandarimpresion.Flag_Embobinado7);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado8", mestandarimpresion.Flag_Embobinado8);
                    cmd.Parameters.AddWithValue("@Gramaje_Tinta", mestandarimpresion.Gramaje_Tinta);
                    cmd.Parameters.AddWithValue("@Gramaje_Impresion", mestandarimpresion.Gramaje_Impresion);
                    cmd.Parameters.AddWithValue("@Ruta_FotoPlanoMecanicoIMP", mestandarimpresion.Ruta_FotoPlanoMecanicoIMP);
                    cmd.Parameters.AddWithValue("@Nota_Impresion", mestandarimpresion.Nota_Impresion);
                    cmd.Parameters.AddWithValue("@Flag_DueñoClisse", mestandarimpresion.Flag_DueñoClisseEmpresaCliente);
                    cmd.Parameters.AddWithValue("@IdEstandar", idestandar);
                    SqlParameter ValorRetorno = new SqlParameter("@Output_Id", SqlDbType.Int);
                    ValorRetorno.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ValorRetorno);
                    cmd.ExecuteNonQuery();
                    OutPutId = Convert.ToInt32(ValorRetorno.Value);
                    Conexionsql.Close();
                }
                Actualizar_imagen(OutPutId, Plano_Impresion);
                return "PROCESADO";
            }
            catch(Exception Ex)
            {throw new Exception ("Error al procesar "+ accion +" "+ idestandar, Ex);}
        }

        public PR_mEstandarImpresion TraerPorID(Int32 videstandarimp)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select * from PR_mEstandarImpresion where IdEstandarImpresion = @id";
                    return conexionsql.QueryFirst<PR_mEstandarImpresion>(sql, new { id = videstandarimp });
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Traer Por ID", Ex);}
        }

        public string Eliminar_EstandarImpresion (Int32 videstandar)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    SqlCommand cmd = new SqlCommand("delete PR_mEstandarImpresion where IdEstandar = @idEstandar", conexionsql);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idEstandar", videstandar);
                    cmd.ExecuteNonQuery();
                    conexionsql.Close();
                }
                return "PROCESADO";
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer Por ID", Ex); }
        }

        public void Descargar_Imagen(PictureBox imagen, long videstandarimp)
        {
            using(var conexionSql = new SqlConnection(cadenaconexion))
            {
                conexionSql.Open();
                SqlCommand cmd = new SqlCommand("Select Foto_PlanoMecanicoIMP From PR_mEstandarImpresion where IdEstandarImpresion ='" + videstandarimp + "'", conexionSql);
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("Foto_PlanoMecanicoIMP");
                dp.Fill(ds, "Foto_PlanoMecanicoIMP");
                byte[] Datos = new byte[0];
                if(ds.Tables.Count == 0) return;
                DataRow DR = ds.Tables["Foto_PlanoMecanicoIMP"].Rows[0];
                if(!DBNull.Value.Equals(DR["Foto_PlanoMecanicoIMP"]))
                {
                    Datos = (byte[])DR["Foto_PlanoMecanicoIMP"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Datos);
                    imagen.Image = System.Drawing.Bitmap.FromStream(ms);
                }
            }
        }

        private long Actualizar_imagen(long videstandarimp, PictureBox Imagen)
        {
            try
            {
                using(var conexionSql = new SqlConnection(cadenaconexion))
                {
                    conexionSql.Open();

                    if(Imagen.Image != null)
                    {
                        SqlCommand cmd = new SqlCommand
                        ("Update PR_mEstandarImpresion set Foto_PlanoMecanicoIMP = @Foto_PlanoMecanicoIMP where IdEstandarImpresion = @Id", conexionSql);
                        cmd.Parameters.Add("@Foto_PlanoMecanicoIMP", SqlDbType.Image);
                        cmd.Parameters.AddWithValue("@Id", videstandarimp);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        Imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        cmd.Parameters["@Foto_PlanoMecanicoIMP"].Value = ms.GetBuffer();
                        cmd.ExecuteNonQuery();
                        conexionSql.Close();
                    }
                }
            }
            catch { return 0; }
            return 1;
        }

       
    }
}
