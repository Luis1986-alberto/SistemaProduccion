using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Capa_Datos.Repositorio
{
    public class PR_mEstandar_CD
    {
        private Inicio principal = new Inicio();
        private string cadenaconexion;
        private Int32 OutPutId = 0;
        public static readonly PR_mEstandar_CD _Instancia = new PR_mEstandar_CD();

        public static PR_mEstandar_CD Instancia
        { get { return PR_mEstandar_CD._Instancia; } }

        public PR_mEstandar_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public List<PR_mEstandar> Listar_Estandar(PR_mEstandar omestandarindustriales, string flag_cliente, string flag_tipoproduccion,
                                                  string flag_rango, DateTime fech_inicio, DateTime fech_final)
        {
            List<PR_mEstandar> lista_estandares = null;
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    ConexionSQL.Open();
                    SqlCommand cmd = new SqlCommand("PRr_Estandares", ConexionSQL);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Flag_Cliente", flag_cliente);
                    cmd.Parameters.AddWithValue("@IdCliente", omestandarindustriales.IdCliente);
                    cmd.Parameters.AddWithValue("@Flag_TipoProduccion", flag_tipoproduccion);
                    cmd.Parameters.AddWithValue("@IdTipoProduccion", omestandarindustriales.IdTipoProduccion);
                    cmd.Parameters.AddWithValue("@Flag_Rango", flag_rango);
                    cmd.Parameters.AddWithValue("@Fecha_Inicial", fech_inicio);
                    cmd.Parameters.AddWithValue("@Fecha_Final", fech_final);

                    lista_estandares = new List<PR_mEstandar>();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        PR_mEstandar t = new PR_mEstandar();
                        t.IdEstandar = Int32.Parse(dr["IdEstandar"].ToString());
                        t.Nombre_CondicionProceso = dr["Nombre_CondicionProceso"].ToString();
                        t.IdCliente = Int32.Parse(dr["IdCliente"].ToString());
                        t.Razon_Social = dr["Razon_Social"].ToString();
                        t.IdProcesos = byte.Parse(dr["IdProcesos"].ToString());
                        t.Descripcion = dr["Descripcion"].ToString();
                        t.Diseño = dr["Diseño"].ToString();
                        t.Codigo_Estandar = dr["Codigo_estandar"].ToString();
                        t.Estructura_CodBar = dr["Estructura_CodBar"].ToString();
                        t.IdTipoProduccion = byte.Parse(dr["IdTipoProduccion"].ToString());
                        t.IdCondicionProceso = byte.Parse(dr["IdCondicionProceso"].ToString());
                        t.Ruta_Producto = dr["Ruta_Producto"].ToString();
                        t.Fecha_Creado = DateTime.Parse(dr["Fecha_Creado"].ToString());
                        lista_estandares.Add(t);
                    }
                    dr.Close();
                    return lista_estandares;
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Listar", Ex); }
        }

        public PR_mEstandar TraerPorID(Int32 idestandar)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = " select EST.IdEstandar, EST.IdCliente, EST.IdProcesos, EST.Descripcion, EST.Flag_NuevoRepetido, EST.Diseño, EST.IdUsuario, EST.Fecha_Creado, EST.Usuario_Creador, " +
                              " EST.Fecha_Modificado, EST.Flag_GeneradoOP, EST.Codigo_Estandar, EST.Estructura_CodBar, EST.Flag_EspecificacionesCC, EST.OrdenTrabajo_Clisses, EST.Ruta_Producto, " +
                              " EST.IdEstandarExtrusion_CC, EST.IdEstandarImpresion_CC, EST.Flag_Embobinado1, EST.Flag_Embobinado2, EST.Flag_Embobinado3, EST.Flag_Embobinado4,EST.Flag_Embobinado5, " +
                              " EST.Flag_Embobinado6, EST.Flag_Embobinado7, EST.Flag_Embobinado8, EST.IdTipoProduccion, EST.IdCondicionProceso, EST.IdTipoProducto, EST.Diametro_Solicitado, " +
                              " est.IdUnidadDiametroSolicitado, 'IdEstandarExtrusion' = ISNULL(EXT.IdEstandarExtrusion, 0), 'IdEstandarImpresion' = isnull(IMP.IdEstandarImpresion, 0), " +
                              " 'IdEstandarCorte' = ISNULL(CORT.IdEstandarCorte, 0), 'IdEstandarLaminado' = ISNULL(LAM.IdEstandarLaminado, 0), 'IdEstandarSellado' = ISNULL(SELL.IdEstandarSellado, 0) " +
                              " from PR_mEstandar  as EST left join PR_mEstandarExtrusion as EXT " +
                              " on EST.IdEstandar = EXT.IdEstandar LEFT JOIN PR_mEstandarImpresion as IMP ON EST.IdEstandar = IMP.IdEstandar LEFT JOIN PR_mEstandarCorte as CORT " +
                              " on EST.IdEstandar = CORT.IdEstandar left join PR_mEstandarLaminado as LAM on EST.IdEstandar = LAM.IdEstandar LEFT JOIN PR_mEstandarSellado as SELL " +
                              " on EST.IdEstandar = SELL.IdEstandar where EST.IdEstandar = @id ";
                    return ConexionSql.QueryFirst<PR_mEstandar>(sql, new { id = idestandar });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer Por Id", Ex); }
        }

        public void Descargar_Imagen(PictureBox imagen, long idestandar)
        {
            using(var conexionSql = new SqlConnection(cadenaconexion))
            {
                conexionSql.Open();
                SqlCommand cmd = new SqlCommand("Select Foto_Producto From PR_mEstandar where IdEstandar ='" + idestandar + "'", conexionSql);
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("Foto_Producto");
                dp.Fill(ds, "Foto_Producto");
                byte[] Datos = new byte[0];
                if(ds.Tables.Count == 0) return;
                DataRow DR = ds.Tables["Foto_Producto"].Rows[0];
                if(!DBNull.Value.Equals(DR["Foto_Producto"]))
                {
                    Datos = (byte[])DR["Foto_Producto"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Datos);
                    imagen.Image = System.Drawing.Bitmap.FromStream(ms);
                }
            }
        }

        public Int32 Procesar_Estandar(PR_mEstandar mestandar, string Actions, PictureBox Foto_Producto)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    SqlCommand cmd = new SqlCommand("PRt_Estandar", conexionsql);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Accion", Actions);
                    cmd.Parameters.AddWithValue("@IdEstandar", mestandar.IdEstandar);
                    cmd.Parameters.AddWithValue("@IdCliente", mestandar.IdCliente);
                    cmd.Parameters.AddWithValue("@IdProcesos", mestandar.IdProcesos);
                    cmd.Parameters.AddWithValue("@Descripcion", mestandar.Descripcion);
                    cmd.Parameters.AddWithValue("@Flag_NuevoRepetido", mestandar.Flag_NuevoRepetido);
                    cmd.Parameters.AddWithValue("@Diseño", mestandar.Diseño);
                    cmd.Parameters.AddWithValue("@IdUsuario", mestandar.IdUsuario);
                    cmd.Parameters.AddWithValue("@Fecha_Creado", mestandar.Fecha_Creado);
                    cmd.Parameters.AddWithValue("@Usuario_Creador", mestandar.Usuario_Creador);
                    cmd.Parameters.AddWithValue("@Fecha_Modificado", mestandar.Fecha_Modificado);
                    cmd.Parameters.AddWithValue("@Flag_GeneradoOP", mestandar.Flag_GeneradoOP);
                    cmd.Parameters.AddWithValue("@Codigo_Estandar", mestandar.Codigo_Estandar);
                    cmd.Parameters.AddWithValue("@Estructura_CodBar", mestandar.Estructura_CodBar);
                    cmd.Parameters.AddWithValue("@Flag_EspecificacionesCC", mestandar.Flag_EspecificacionesCC);
                    cmd.Parameters.AddWithValue("@OrdenTrabajo_Clisses", mestandar.OrdenTrabajo_Clisses);
                    cmd.Parameters.AddWithValue("@Ruta_Producto", mestandar.Ruta_Producto);
                    cmd.Parameters.AddWithValue("@IdEstandarExtrusion_CC", mestandar.IdEstandarExtrusion_CC);
                    cmd.Parameters.AddWithValue("@IdEstandarImpresion_CC", mestandar.IdEstandarImpresion_CC);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado1", mestandar.Flag_Embobinado1);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado2", mestandar.Flag_Embobinado2);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado3", mestandar.Flag_Embobinado3);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado4", mestandar.Flag_Embobinado4);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado5", mestandar.Flag_Embobinado5);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado6", mestandar.Flag_Embobinado6);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado7", mestandar.Flag_Embobinado7);
                    cmd.Parameters.AddWithValue("@Flag_Embobinado8", mestandar.Flag_Embobinado8);
                    cmd.Parameters.AddWithValue("@IdTipoProduccion", mestandar.IdTipoProduccion);
                    cmd.Parameters.AddWithValue("@Diametro_Solicitado", mestandar.Diametro_Solicitado);
                    cmd.Parameters.AddWithValue("@idUnidadDiametrosolicitado", mestandar.IdUnidadDiametroSolicitado);
                    cmd.Parameters.AddWithValue("@IdTipoProducto", mestandar.IdTipoProduccion);
                    cmd.Parameters.AddWithValue("@IdCondicionProceso", mestandar.IdCondicionProceso);

                    SqlParameter ValorRetorno = new SqlParameter("@Output_Id", SqlDbType.Int);
                    ValorRetorno.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ValorRetorno);
                    cmd.ExecuteNonQuery();
                    OutPutId = Convert.ToInt32(ValorRetorno.Value);
                    conexionsql.Close();
                }

                Actualizar_imagen(OutPutId, Foto_Producto);
            }
            catch(Exception Ex)
            { throw new Exception("Error al Procesad", Ex); }
            return OutPutId;
        }

        private long Actualizar_imagen(long videstandar, PictureBox Imagen)
        {
            try
            {
                using(var conexionSql = new SqlConnection(cadenaconexion))
                {
                    conexionSql.Open();

                    if(Imagen.Image != null)
                    {
                        SqlCommand cmd = new SqlCommand
                        ("Update PR_mEstandar set Foto_Producto = @Foto_Producto where IdEstandar = @Id", conexionSql);
                        cmd.Parameters.Add("@Foto_Producto", SqlDbType.Image);
                        cmd.Parameters.AddWithValue("@Id", videstandar);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        Imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        cmd.Parameters["@Foto_Producto"].Value = ms.GetBuffer();
                        cmd.ExecuteNonQuery();
                        conexionSql.Close();
                    }
                }
            }
            catch
            { return 0; }
            return 1;
        }

        public String Eliminar_Estandar(Int32 idEstandar)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "Delete PR_mEstandar where IdEstandar = @Id";
                    ConexionSql.Execute(sqldelete, new { Id = idEstandar });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Eliminar" + idEstandar, Ex); }
        }

        public IEnumerable<PR_mEstandar> FiltroPorUnCampo(IPredicate predicado)
        {
            using(var conexionSql = new SqlConnection(cadenaconexion))
            {
                conexionSql.Open();
                var result = conexionSql.GetList<PR_mEstandar>(predicado);
                conexionSql.Close();
                return result;
            }
        }

    }
}

