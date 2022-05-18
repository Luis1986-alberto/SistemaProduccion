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
    public class PR_mEstandarSellado_CD
    {
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";
        private Int32 OutPutId = 0; 
        public static readonly PR_mEstandarSellado_CD _Instancia = new PR_mEstandarSellado_CD();

        public static PR_mEstandarSellado_CD Instancia
        { get { return PR_mEstandarSellado_CD._Instancia;} }

        public PR_mEstandarSellado_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }


        public string EstandarSellado_Procesar  (PR_mEstandarSellado mestandarsellado, Int32 idestandar, string accion, PictureBox planomecanicosellado )
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion) )
                {
                    ConexionSql.Open();
                    SqlCommand cmd = new SqlCommand("PRt_EstandarSellado", ConexionSql);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Accion", accion);
                    cmd.Parameters.AddWithValue("@IdEstandarSellado", mestandarsellado.IdEstandarSellado);
                    cmd.Parameters.AddWithValue("@IdEtiqueta", mestandarsellado.IdEtiqueta);
                    cmd.Parameters.AddWithValue("@IdEmpaquetado", mestandarsellado.IdEmpaquetado);
                    cmd.Parameters.AddWithValue("@IdAsa", mestandarsellado.IdAsa);
                    cmd.Parameters.AddWithValue("@IdTroquel", mestandarsellado.IdTroquel);
                    cmd.Parameters.AddWithValue("@IdTipoSello", mestandarsellado.IdTipoSello);
                    cmd.Parameters.AddWithValue("@Ancho", mestandarsellado.Ancho);
                    cmd.Parameters.AddWithValue("@Flag_Posicion_Sello", mestandarsellado.Flag_Posicion_Sello);
                    cmd.Parameters.AddWithValue("@Largo", mestandarsellado.Largo);
                    cmd.Parameters.AddWithValue("@UnidadxPaquete", mestandarsellado.UnidadxPaquete);
                    cmd.Parameters.AddWithValue("@PaqueteXCaja", mestandarsellado.PaquetexCaja);
                    cmd.Parameters.AddWithValue("@IdUnidadLargo", mestandarsellado.IdUnidadLargo);
                    cmd.Parameters.AddWithValue("@MillarXCaja", mestandarsellado.MillarxCaja);
                    cmd.Parameters.AddWithValue("@Flag_Etiqueta", mestandarsellado.Flag_Etiqueta);
                    cmd.Parameters.AddWithValue("@Flag_Solapa", mestandarsellado.Flag_Solapa);
                    cmd.Parameters.AddWithValue("@Flag_Etiqueta_Paquete", mestandarsellado.Flag_Etiqueta_Paquete);
                    cmd.Parameters.AddWithValue("@Medida_Solapa", mestandarsellado.Medida_Solapa);
                    cmd.Parameters.AddWithValue("@IdUnidadSolapa", mestandarsellado.IdUnidadSolapa);
                    cmd.Parameters.AddWithValue("@Flag_Etiqueta_Paqueta", mestandarsellado.Flag_Etiqueta_Paquete);
                    cmd.Parameters.AddWithValue("@Flag_Etiqueta_Caja", mestandarsellado.Flag_Etiqueta_Caja);
                    cmd.Parameters.AddWithValue("@Flag_Refile", mestandarsellado.Flag_Refile);
                    cmd.Parameters.AddWithValue("@Flag_DetalleEtiqueta", mestandarsellado.Flag_DetalleEtiqueta);
                    cmd.Parameters.AddWithValue("@Flag_Pestaña", mestandarsellado.Flag_Pestaña);
                    cmd.Parameters.AddWithValue("@Medida_Pestaña", mestandarsellado.Medida_Pestaña);
                    cmd.Parameters.AddWithValue("@Medida_Refile", mestandarsellado.Medida_Refile);
                    cmd.Parameters.AddWithValue("@IdUnidadRefile", mestandarsellado.IdUnidadRefile);                
                    cmd.Parameters.AddWithValue("@IdUnidadPestaña", mestandarsellado.IdUnidadPestaña);
                    cmd.Parameters.AddWithValue("@Flag_Perforaciones", mestandarsellado.Flag_Perforaciones);
                    cmd.Parameters.AddWithValue("@IdTipoFuelle", mestandarsellado.IdTipoFuelle);
                    cmd.Parameters.AddWithValue("@Medida_Fuelle", mestandarsellado.Medida_Fuelle);
                    cmd.Parameters.AddWithValue("@IdUnidadFuelle", mestandarsellado.IdUnidadFuelle);                              
                    cmd.Parameters.AddWithValue("@Numero_Pistas", mestandarsellado.Numero_Pistas);
                    cmd.Parameters.AddWithValue("@Numero_Perforaciones", mestandarsellado.Numero_Perforaciones);
                    cmd.Parameters.AddWithValue("@Medida_Perforaciones", mestandarsellado.Medida_Perforaciones);
                    cmd.Parameters.AddWithValue("@IdUnidadPerforaciones", mestandarsellado.IdUnidadPerforaciones);
                    cmd.Parameters.AddWithValue("@Flag_Etiqueta_Fardo", mestandarsellado.Flag_Etiqueta_Fardo);
                    cmd.Parameters.AddWithValue("@Nota_Sellado", mestandarsellado.Nota_Sellado);        
                    cmd.Parameters.AddWithValue("@Peso_Promedio_Fardo", mestandarsellado.Peso_Promedio_Fardo);
                    cmd.Parameters.AddWithValue("@Peso_Promedio_Millar", mestandarsellado.Peso_Promedio_Millar);
                    cmd.Parameters.AddWithValue("@Peso_promedio_Paquete", mestandarsellado.Peso_Promedio_Paquete);
                    cmd.Parameters.AddWithValue("@Peso_Tuco", mestandarsellado.Peso_Tuco);
                    cmd.Parameters.AddWithValue("@Peso_Envase", mestandarsellado.Peso_Envase);
                    cmd.Parameters.AddWithValue("@Ruta_FotoPlanoMecanicoSell", mestandarsellado.Ruta_FotoPlanoMecanicoSell);
                    cmd.Parameters.AddWithValue("@IdEstandar", idestandar);
                    SqlParameter ValorRetorno = new SqlParameter("@Output_Id", System.Data.SqlDbType.Int);
                    ValorRetorno.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(ValorRetorno);
                    cmd.ExecuteNonQuery();
                    OutPutId = Convert.ToInt32(ValorRetorno.Value);
                    ConexionSql.Close();
                }
                Actualizar_Imagen(OutPutId, planomecanicosellado);
                return "PROCESADO";
            }
            catch(Exception Ex)
            { throw new Exception("Error al procesar" + accion + " " + idestandar, Ex); }
        }

        public PR_mEstandarSellado TraerPorId(Int32 videstandarsellado)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select * from PR_mEstandarSellado where IdEstandarSellado = @Id";
                    return ConexionSql.QueryFirst<PR_mEstandarSellado>(sql, new { id = videstandarsellado });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por Id" + videstandarsellado, Ex); }
        }

        public string Eliminar_estandarSellado (Int32 videstandar)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "Delete From PR_mEstandarSellado where Idestandar = @Id";
                    ConexionSql.ExecuteScalar<PR_mEstandarSellado>(sqldelete, new { id = videstandar });
                }
                return "PROCESADO";
            }
            catch(Exception Ex)
            {throw new Exception("Error al Eliminar" + videstandar + " ",Ex);}
        }

        public void Descargar_Imagen(PictureBox imagen, Int32 videstandarsellado)
        {
            using(var ConexionSql = new SqlConnection(cadenaconexion))
            {
                ConexionSql.Open();
                SqlCommand cmd = new SqlCommand ("select Foto_PlanoMecanicoSell  from PR_mEstandarSellado where IdEstandarSellado ='" + videstandarsellado + "'", ConexionSql);
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("Foto_PlanoMecanicoSell");
                dp.Fill(ds, "Foto_PlanoMecanicoSell");
                byte[] Datos = new byte[0];
                DataRow DR = ds.Tables["Foto_PlanoMecanicoSell"].Rows[0];
                if(!DBNull.Value.Equals(DR["Foto_PlanoMecanicoSell"]))
                {
                    Datos = (byte[])DR["Foto_PlanoMecanicoSell"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Datos);
                    imagen.Image = System.Drawing.Bitmap.FromStream(ms);
                }
            }
        }

        public string Actualizar_Imagen (Int32 videstandarsellado, PictureBox imagen)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    ConexionSql.Open();

                    if(imagen.Image != null)
                    {
                        SqlCommand cmd = new SqlCommand
                            ("Update PR_mEstandarSellado set Foto_PlanoMecanicoSell = @Foto_PlanoMecanicoSell where IdEstandarSellado = @Id ", ConexionSql);
                        cmd.Parameters.AddWithValue("@Foto_PlanoMecanicoSell", SqlDbType.Image);
                        cmd.Parameters.AddWithValue("@Id", videstandarsellado);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        cmd.Parameters["@Foto_PlanoMecanicoSell"].Value = ms.GetBuffer();
                        cmd.ExecuteNonQuery();
                        ConexionSql.Close();
                    }
                }
                return "PROCESADO";
            }
            catch(Exception Ex)
            {throw new Exception ("Error al actualizar imagen " + videstandarsellado, Ex) ;}
        }


    }
}
