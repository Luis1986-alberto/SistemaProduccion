using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Capa_Datos.Repositorio
{
    public class PR_mMaquina_CD
    {
        public static readonly PR_mMaquina_CD _Instancia = new PR_mMaquina_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static PR_mMaquina_CD Instancia
        { get { return PR_mMaquina_CD._Instancia; } }

        public PR_mMaquina_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_mMaquina> Listar(PR_mMaquina entidad, string flag_tipomaquina, string flag_empresa, string flag_proveedormaquina)
        {
            List<PR_mMaquina> lista_Maquinas = null;
            using(var ConexionSQL = new SqlConnection(cadenaconexion))
            {
                ConexionSQL.Open();
                SqlCommand cmd = new SqlCommand("PRr_Maquina", ConexionSQL);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Flag_TipoMaquina", flag_tipomaquina);
                cmd.Parameters.AddWithValue("@IdTipoMaquina", entidad.IdTipoMaquina);
                cmd.Parameters.AddWithValue("@Flag_Empresa", flag_empresa);
                cmd.Parameters.AddWithValue("@IdEmpresa", entidad.IdEmpresa);
                cmd.Parameters.AddWithValue("@Flag_ProveedorMaquina", flag_proveedormaquina);
                cmd.Parameters.AddWithValue("@IdProveedorMaquina", entidad.IdProveedor);

                SqlDataReader dr = cmd.ExecuteReader();
                lista_Maquinas = new List<PR_mMaquina>();

                while(dr.Read())
                {
                    PR_mMaquina t = new PR_mMaquina();
                    t.IdMaquina = short.Parse(dr["IdMaquina"].ToString());
                    t.Alias_Maquina = dr["Alias_Maquina"].ToString();
                    t.Codigo_Maquina = dr["Codigo_Maquina"].ToString();
                    t.Fecha_Compra = DateTime.Parse(dr["Fecha_compra"].ToString());
                    t.Flag_Baja = byte.Parse(dr["Flag_Baja"].ToString());
                    t.Flag_Operativo = byte.Parse(dr["Flag_Operativo"].ToString());
                    t.IdAño_Fabricacion = byte.Parse(dr["IdAño_Fabricacion"].ToString());
                    t.IdEmpresa = byte.Parse(dr["IdEmpresa"].ToString());
                    t.IdEstadoMaquina = byte.Parse(dr["IdEstadoMaquina"].ToString());
                    t.IdMarcaMaquina = byte.Parse(dr["IdMarcaMaquina"].ToString());
                    t.Descripcion_MarcaMaquina = dr["Descripcion_MarcaMaquina"].ToString();
                    t.IdProveedor = short.Parse(dr["IdProveedor"].ToString());
                    t.IdTipoMaquina = byte.Parse(dr["IdTipoMaquina"].ToString());
                    t.Nombre_TipoMaquina = dr["Nombre_TipoMaquina"].ToString();
                    t.IdUsuario = dr["IdUsuario"].ToString();
                    t.Modelo_Maquina = dr["Modelo_Maquina"].ToString();
                    t.Numero_Maximo_OP = byte.Parse(dr["Numero_Maximo_OP"].ToString());
                    t.Procedencia = dr["Procedencia"].ToString();
                    t.Produccion_Kg = decimal.Parse(dr["Produccion_KG"].ToString());
                    t.Produccion_Metros = decimal.Parse(dr["Produccion_metros"].ToString());
                    t.Ruta_Imagen = dr["Ruta_Imagen"].ToString();
                    t.Serie_Maquina = dr["Serie_Maquina"].ToString();
                    t.Tiempo_Horas = decimal.Parse(dr["Tiempo_Horas"].ToString());
                    lista_Maquinas.Add(t);
                }
            }
            return lista_Maquinas;
        }

        public IEnumerable<PR_mMaquina> Listar()
        {
            List<PR_mMaquina> lista_Maquinas = null;
            using(var ConexionSQL = new SqlConnection(cadenaconexion))
            {
                ConexionSQL.Open();
                SqlCommand cmd = new SqlCommand("select * from PR_mMaquina ", ConexionSQL);
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();
                lista_Maquinas = new List<PR_mMaquina>();

                while(dr.Read())
                {
                    PR_mMaquina t = new PR_mMaquina();
                    t.IdMaquina = short.Parse(dr["IdMaquina"].ToString());
                    t.Alias_Maquina = dr["Alias_Maquina"].ToString();
                    t.Codigo_Maquina = dr["Codigo_Maquina"].ToString();
                    t.Fecha_Compra = DateTime.Parse(dr["Fecha_compra"].ToString());
                    t.Flag_Baja = byte.Parse(dr["Flag_Baja"].ToString());
                    t.Flag_Operativo = byte.Parse(dr["Flag_Operativo"].ToString());
                    t.IdAño_Fabricacion = byte.Parse(dr["IdAño_Fabricacion"].ToString());
                    t.IdEmpresa = byte.Parse(dr["IdEmpresa"].ToString());
                    t.IdEstadoMaquina = byte.Parse(dr["IdEstadoMaquina"].ToString());
                    t.IdMarcaMaquina = byte.Parse(dr["IdMarcaMaquina"].ToString());
                    t.IdProveedor = short.Parse(dr["IdProveedor"].ToString());
                    t.IdTipoMaquina = byte.Parse(dr["IdTipoMaquina"].ToString());
                    t.IdUsuario = dr["IdUsuario"].ToString();
                    t.Modelo_Maquina = dr["Modelo_Maquina"].ToString();
                    t.Numero_Maximo_OP = byte.Parse(dr["Numero_Maximo_OP"].ToString());
                    t.Procedencia = dr["Procedencia"].ToString();
                    t.Produccion_Kg = decimal.Parse(dr["Produccion_KG"].ToString());
                    t.Produccion_Metros = decimal.Parse(dr["Produccion_metros"].ToString());
                    t.Ruta_Imagen = dr["Ruta_Imagen"].ToString();
                    t.Serie_Maquina = dr["Serie_Maquina"].ToString();
                    t.Tiempo_Horas = decimal.Parse(dr["Tiempo_Horas"].ToString());
                    lista_Maquinas.Add(t);
                }
            }
            return lista_Maquinas;
        }

        public String Agregar(PR_mMaquina entidad, PictureBox imagen)
        {
            using(var ConexionSQL = new SqlConnection(cadenaconexion))
            {
                var sqlinsert = "Insert Into PR_mMaquina (IdMarcaMaquina, Modelo_Maquina, Serie_Maquina, Alias_Maquina, Numero_Maximo_OP, IdEmpresa, IdUsuario, " +
                                " Ruta_Imagen, Fecha_Compra, IdAño_Fabricacion, Procedencia, Produccion_Kg, Produccion_Metros, Tiempo_Horas, Flag_Operativo, Flag_Baja, Codigo_Maquina, " +
                                "IdEstadoMaquina, IdProveedor, IdTipoMaquina) values (@idmarcamaquina, @modelo_maquina, @serie_maquina, @alias_maquina, " +
                                "@numero_maximo_op, @idempresa, @idusuario, @ruta_imagen, @fecha_compra, @idaño_fabricacion, @procedencia, @produccion_kg, @produccion_metros, " +
                                "@tiempo_horas, @flag_operativo, @flag_baja, @codigo_maquina, @idestadomaquina,  @idproveedor, @IdTipoMaquina) SELECT SCOPE_IDENTITY()";
                int id = Convert.ToInt32(ConexionSQL.ExecuteScalar(sqlinsert, new {
                    idmarcamaquina = entidad.IdMarcaMaquina, modelo_maquina = entidad.Modelo_Maquina,
                    serie_maquina = entidad.Serie_Maquina, alias_maquina = entidad.Alias_Maquina,
                    numero_maximo_OP = entidad.Numero_Maximo_OP, idempresa = entidad.IdEmpresa, idusuario = entidad.IdUsuario,
                    ruta_imagen = entidad.Ruta_Imagen, fecha_compra = entidad.Fecha_Compra, idaño_fabricacion = entidad.IdAño_Fabricacion,
                    procedencia = entidad.Procedencia, produccion_KG = entidad.Produccion_Kg, produccion_metros = entidad.Produccion_Metros,
                    tiempo_horas = entidad.Tiempo_Horas, flag_operativo = entidad.Flag_Operativo, flag_baja = entidad.Flag_Baja,
                    codigo_maquina = entidad.Codigo_Maquina, idEstadomaquina = entidad.IdEstadoMaquina,
                    idproveedor = entidad.IdProveedor, IdTipoMaquina = entidad.IdTipoMaquina
                }));

                Actualizar_imagen(id, imagen);
                return "PROCESADO";
            }
        }

        public String Actualizar(PR_mMaquina entidad, PictureBox imagen)
        {
            using(var ConexionSQL = new SqlConnection(cadenaconexion))
            {
                var sqlinsert = "Update PR_mMaquina set IdMarcaMaquina = @idmarcamaquina, Modelo_Maquina = @modelo_maquina, Serie_Maquina = @serie_maquina, Alias_Maquina = @alias_maquina, " +
                                " Numero_Maximo_OP = @numero_maximo_op, IdEmpresa = @idempresa , IdUsuario =  @idusuario, Ruta_Imagen = @ruta_imagen, Fecha_Compra = @fecha_compra, " +
                                " IdAño_Fabricacion = @idaño_fabricacion, Procedencia = @procedencia, Produccion_Kg = @produccion_kg, Produccion_Metros = @produccion_metros, " +
                                " Tiempo_Horas = @tiempo_horas, Flag_Operativo =  @flag_operativo, Flag_Baja = @flag_baja, Codigo_Maquina = @codigo_maquina, " +
                                "IdEstadoMaquina = @idestadomaquina, IdProveedor = @idproveedor, IdTipoMaquina = @IdTipoMaquina where idmaquina = @id ";
                ConexionSQL.Execute(sqlinsert, new {
                    id = entidad.IdMaquina,
                    idmarcamaquina = entidad.IdMarcaMaquina, modelo_maquina = entidad.Modelo_Maquina,
                    serie_maquina = entidad.Serie_Maquina, alias_maquina = entidad.Alias_Maquina,
                    numero_maximo_OP = entidad.Numero_Maximo_OP, idempresa = entidad.IdEmpresa, idusuario = entidad.IdUsuario,
                    ruta_imagen = entidad.Ruta_Imagen, fecha_compra = entidad.Fecha_Compra, idaño_fabricacion = entidad.IdAño_Fabricacion,
                    procedencia = entidad.Procedencia, produccion_KG = entidad.Produccion_Kg, produccion_metros = entidad.Produccion_Metros,
                    tiempo_horas = entidad.Tiempo_Horas, flag_operativo = entidad.Flag_Operativo, flag_baja = entidad.Flag_Baja,
                    codigo_maquina = entidad.Codigo_Maquina, IdEstadomaquina = entidad.IdEstadoMaquina,
                    idproveedor = entidad.IdProveedor, IdTipoMaquina = entidad.IdTipoMaquina
                });
                Actualizar_imagen(entidad.IdMaquina, imagen);
                return "PROCESADO";
            }
        }

        public String Eliminar(Int32 id)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = " delete PR_mMaquina where idmaquina = @id";
                    ConexionSQL.Execute(sqldelete, new { id = id });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }

        }

        public IEnumerable<PR_mMaquina> TraerPorId(Int32 idmaquina)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMaquina, IdTipoMaquina, IdMarcaMaquina, Modelo_Maquina, Serie_Maquina, Alias_Maquina, Numero_Maximo_OP, IdEmpresa, " +
                              " IdUsuario, Fecha_Servidor, Ruta_Imagen, Fecha_Compra, IdAño_Fabricacion, Procedencia, Produccion_Kg, Produccion_Metros, " +
                              " Tiempo_Horas, Flag_Operativo, Flag_Baja, Codigo_Maquina, IdEstadoMaquina, IdProveedor, Flag_Operativo, Flag_Baja from PR_mMaquina " +
                              " where IdMaquina = @id ";
                    return ConexionSql.Query<PR_mMaquina>(sql, new { id = idmaquina });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public IEnumerable<PR_mMaquina> FiltroPorUnCampo(IPredicate predicado)
        {
            throw new NotImplementedException();
        }

        public void Descargar_Imagen(PictureBox imagen, long idmaquina)
        {
            using(var conexionSql = new SqlConnection(cadenaconexion))
            {
                conexionSql.Open();
                SqlCommand cmd = new SqlCommand("Select Foto_Maquina From PR_mMaquina where IdMaquina ='" + idmaquina + "'", conexionSql);
                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet("Foto_Maquina");
                dp.Fill(ds, "Foto_Maquina");
                byte[] Datos = new byte[0];
                if(ds.Tables.Count == 0) return;
                DataRow DR = ds.Tables["Foto_Maquina"].Rows[0];
                if(!DBNull.Value.Equals(DR["Foto_Maquina"]))
                {
                    Datos = (byte[])DR["Foto_Maquina"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Datos);
                    imagen.Image = System.Drawing.Bitmap.FromStream(ms);
                }
            }
        }

        private long Actualizar_imagen(long vidmaquina, PictureBox Imagen)
        {
            try
            {
                using(var conexionSql = new SqlConnection(cadenaconexion))
                {
                    conexionSql.Open();

                    if(Imagen.Image != null)
                    {
                        SqlCommand cmd = new SqlCommand
                        ("Update PR_mMaquina set Foto_Maquina = @Foto_Maquina where IdMaquina = @IdMaquina", conexionSql);
                        cmd.Parameters.Add("@Foto_Maquina", SqlDbType.Image);
                        cmd.Parameters.AddWithValue("@IdMaquina", vidmaquina);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        Imagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        cmd.Parameters["@Foto_Maquina"].Value = ms.GetBuffer();
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
