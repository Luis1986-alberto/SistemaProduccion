using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Capa_Datos.Repositorio
{
    public class PR_mClientes_CD
    {
        public static readonly PR_mClientes_CD _Instancia = new PR_mClientes_CD();
        private Inicio principal = new Inicio();
        private string CadenaConexion = "";
        private int int_OutPutId;

        public static PR_mClientes_CD Instancia
        { get { return PR_mClientes_CD._Instancia; } }

        public PR_mClientes_CD()
        {
            principal.LeerConfiguracion();
            CadenaConexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_mClientes> Lista_Clientes()
        {
            using(SqlConnection ConexionSql = new SqlConnection(CadenaConexion))
            {
                try
                {

                    ConexionSql.Open();

                    SqlCommand cmd = new SqlCommand("PRs_Clientes", ConexionSql);
                    cmd.CommandType = CommandType.StoredProcedure;

                    List<PR_mClientes> Listado_Clientes = new List<PR_mClientes>();

                    SqlDataReader Datos = cmd.ExecuteReader();

                    while(Datos.Read())
                    {
                        PR_mClientes Entidad = new PR_mClientes();

                        Entidad.IdCliente = Int32.Parse(Datos["IdCliente"].ToString());
                        Entidad.Razon_Social = Datos["Razon_Social"].ToString();
                        Entidad.IdTipoRubro = byte.Parse(Datos["IdTipoRubro"].ToString());
                        Entidad.RUC_Empresa = Datos["RUC_Empresa"].ToString();
                        Entidad.Direccion = Datos["Direccion"].ToString();
                        Entidad.Direccion_Fiscal = Datos["Direccion_Fiscal"].ToString();
                        Entidad.Flag_Natural = byte.Parse(Datos["Flag_Natural"].ToString());
                        Entidad.Pagina_Web = Datos["Pagina_Web"].ToString();
                        Entidad.Nombre_Contacto = Datos["Nombre_Contacto"].ToString();
                        Entidad.Referencias = Datos["Referencias"].ToString();
                        Entidad.Observacion = Datos["Observacion"].ToString();
                        Entidad.Numero_Telefono1 = Datos["Numero_Telefono1"].ToString();
                        Entidad.Numero_Telefono2 = Datos["Numero_Telefono2"].ToString();
                        Entidad.Numero_Celular1 = Datos["Numero_Celular1"].ToString();
                        Entidad.Numero_Celular2 = Datos["Numero_Celular2"].ToString();
                        Entidad.Nombre_TipoRubro  = Datos["Nombre_TipoRubro"].ToString();

                        Listado_Clientes.Add(Entidad);
                    }

                    return Listado_Clientes;

                   
                }
                catch(Exception ex)
                {throw new Exception("Err al listar", ex); }                
            }
        }

        public int Agregar_Cliente(PR_mClientes oClientes)
        {
            using(SqlConnection ConexionSql = new SqlConnection(CadenaConexion))
            {
                try
                {
                    ConexionSql.Open();
                    SqlCommand cmd = new SqlCommand("spPRt_Cliente", ConexionSql);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Accion", "I");
                    cmd.Parameters.AddWithValue("@Razon_Social", oClientes.Razon_Social);
                    cmd.Parameters.AddWithValue("@IdTipoRubro", oClientes.IdTipoRubro);
                    cmd.Parameters.AddWithValue("@RUC_Empresa", oClientes.RUC_Empresa);
                    cmd.Parameters.AddWithValue("@Direccion", oClientes.Direccion);
                    cmd.Parameters.AddWithValue("@Direccion_Fiscal", oClientes.Direccion_Fiscal);
                    cmd.Parameters.AddWithValue("@Flag_Natural", oClientes.Flag_Natural);
                    cmd.Parameters.AddWithValue("@Pagina_Web", oClientes.Pagina_Web);
                    cmd.Parameters.AddWithValue("@Nombre_Contacto", oClientes.Nombre_Contacto);
                    cmd.Parameters.AddWithValue("@Referencias", oClientes.Referencias);
                    cmd.Parameters.AddWithValue("@Observacion", oClientes.Observacion);
                    cmd.Parameters.AddWithValue("@Numero_Telefono1", oClientes.Numero_Telefono1);
                    cmd.Parameters.AddWithValue("@Numero_Telefono2", oClientes.Numero_Telefono2);
                    cmd.Parameters.AddWithValue("@Numero_Celular1", oClientes.Numero_Celular1);
                    cmd.Parameters.AddWithValue("@Numero_Celular2", oClientes.Numero_Celular2);

                    SqlParameter ValorRetorno = new SqlParameter("@Output_Id", SqlDbType.Int);
                    ValorRetorno.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ValorRetorno);

                    cmd.ExecuteNonQuery();

                    int_OutPutId = Convert.ToInt32(ValorRetorno.Value);

                    ConexionSql.Close();

                    return int_OutPutId;

                }

                catch(Exception ex)
                { throw new Exception("Err al listar", ex); }
                
            }
        }

        public int Modificar_Cliente(PR_mClientes oClientes)
        {
            using(SqlConnection ConexionSql = new SqlConnection(CadenaConexion))
            {
                try
                {
                    ConexionSql.Open();
                    SqlCommand cmd = new SqlCommand("spPRt_Cliente", ConexionSql);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Accion", "U");
                    cmd.Parameters.AddWithValue("@IdCliente", oClientes.IdCliente);
                    cmd.Parameters.AddWithValue("@Razon_Social", oClientes.Razon_Social);
                    cmd.Parameters.AddWithValue("@IdTipoRubro", oClientes.IdTipoRubro);
                    cmd.Parameters.AddWithValue("@RUC_Empresa", oClientes.RUC_Empresa);
                    cmd.Parameters.AddWithValue("@Direccion", oClientes.Direccion);
                    cmd.Parameters.AddWithValue("@Direccion_Fiscal", oClientes.Direccion_Fiscal);
                    cmd.Parameters.AddWithValue("@Flag_Natural", oClientes.Flag_Natural);
                    cmd.Parameters.AddWithValue("@Pagina_Web", oClientes.Pagina_Web);
                    cmd.Parameters.AddWithValue("@Nombre_Contacto", oClientes.Nombre_Contacto);
                    cmd.Parameters.AddWithValue("@Referencias", oClientes.Referencias);
                    cmd.Parameters.AddWithValue("@Observacion", oClientes.Observacion);
                    cmd.Parameters.AddWithValue("@Numero_Telefono1", oClientes.Numero_Telefono1);
                    cmd.Parameters.AddWithValue("@Numero_Telefono2", oClientes.Numero_Telefono2);
                    cmd.Parameters.AddWithValue("@Numero_Celular1", oClientes.Numero_Celular1);
                    cmd.Parameters.AddWithValue("@Numero_Celular2", oClientes.Numero_Celular2);

                    SqlParameter ValorRetorno = new SqlParameter("@Output_Id", SqlDbType.Int);
                    ValorRetorno.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(ValorRetorno);

                    cmd.ExecuteNonQuery();

                    int_OutPutId = Convert.ToInt32(ValorRetorno.Value);

                    ConexionSql.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al conectarse a la base de datos Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    if(ConexionSql.State == ConnectionState.Open) ConexionSql.Close();
                }
                return int_OutPutId;
            }
        }

        public int Eliminar_Cliente(int vIdCliente)
        {
            using(SqlConnection ConexionSql = new SqlConnection(CadenaConexion))
            {
                try
                {
                    ConexionSql.Open();
                    SqlCommand cmd = new SqlCommand("spPRt_Cliente", ConexionSql);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Accion", "D");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al conectarse a la base de datos Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                finally
                {
                    if(ConexionSql.State == ConnectionState.Open) ConexionSql.Close();
                }
                return int_OutPutId;
            }
        }

        
    }
}
