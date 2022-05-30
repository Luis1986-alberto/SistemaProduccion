using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_xProveedor_CD
    {
        public static readonly LG_xProveedor_CD _Instancia = new LG_xProveedor_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_xProveedor_CD Instancia
        { get { return LG_xProveedor_CD._Instancia; } }

        public LG_xProveedor_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public List<LG_xProveedor> Lista_Proveedores()
        {
            try
            {
                List<LG_xProveedor> lst_proveedores = null;
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    ConexionSQL.Open();
                    SqlCommand cmd = new SqlCommand("select * from LG_xProveedor as PR inner join LG_aTipoProveedor as TP on PR.IdTipoProveedor = TP.IdTipoProveedor ", ConexionSQL);
                    cmd.CommandType = System.Data.CommandType.Text;
                    var dr = cmd.ExecuteReader();
                    lst_proveedores = new List<LG_xProveedor>();

                    while(dr.Read())
                    {
                        LG_xProveedor t = new LG_xProveedor();
                        t.IdProveedor = Int32.Parse(dr["IdProveedor"].ToString());
                        t.Razon_Social_Proveedor = dr["Razon_Social_Proveedor"].ToString();
                        t.RUC_Proveedor = dr["RUC_Proveedor"].ToString();
                        t.Pagina_Web_Proveedor = dr["Pagina_Web_Proveedor"].ToString();
                        t.Telefono1_Proveedor = dr["Telefono1_Proveedor"].ToString();
                        t.Telefono2_Proveedor = dr["Telefono2_Proveedor"].ToString();
                        t.Direccion_Proveedor = dr["Direccion_Proveedor"].ToString();
                        t.Correo_Proveedor = dr["Correo_Proveedor"].ToString();
                        t.Correo_Contacto = dr["Correo_Contacto"].ToString();
                        t.Contacto_Proveedor = dr["Contacto_Proveedor"].ToString();
                        t.Telefono_Contacto = dr["Telefono_Contacto"].ToString();
                        t.Celular1_Proveedor = dr["Celular1_Proveedor"].ToString();
                        t.Nota = dr["Nota"].ToString();
                        t.IdTipoProveedor = byte.Parse(dr["IdTipoProveedor"].ToString());
                        //t.tipoproveedor = new LG_aTipoProveedor();
                        t.Tipo_Proveedor = dr["Tipo_Proveedor"].ToString();
                        lst_proveedores.Add(t);
                    }
                }
                return lst_proveedores;
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }

        public LG_xProveedor TraerPorIDProveedor(Int32 idproveedor)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select * from LG_xProveedor where IdProveedor = @id";
                    return ConexionSQL.QueryFirst<LG_xProveedor>(sql, new { id = idproveedor });
                }
            }
            catch(Exception Ex)
            { throw new Exception("error al Traer por ID", Ex); }

        }

        public string Agregar_Proveedor(LG_xProveedor proveedor)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = " Insert Into LG_xProveedor (Razon_Social_Proveedor, RUC_Proveedor, Telefono1_Proveedor, Telefono2_Proveedor, Pagina_Web_Proveedor, " +
                                    " Direccion_Proveedor, Correo_Proveedor, Contacto_Proveedor, Telefono_Contacto, Correo_Contacto, Nota, Celular1_Proveedor, IdTipoProveedor ) values " +
                                    " (@razon_social_proveedor, @ruc_proveedor, @telefono1_proveedor, @telefono2_proveedor, @pagina_web_proveedor, @direccion_proveedor, @correo_proveedor, " +
                                    " @contacto_proveedor, @telefono_contacto, @correo_contacto, @nota, @celular1_proveedor, @idtipoproveedor)";
                    ConexionSQL.ExecuteScalar(sqlinsert, new {
                        razon_social_proveedor = proveedor.Razon_Social_Proveedor,
                        ruc_proveedor = proveedor.RUC_Proveedor,
                        telefono1_proveedor = proveedor.Telefono1_Proveedor,
                        telefono2_proveedor = proveedor.Telefono2_Proveedor,
                        pagina_web_proveedor = proveedor.Pagina_Web_Proveedor,
                        direccion_proveedor = proveedor.Direccion_Proveedor,
                        correo_proveedor = proveedor.Correo_Proveedor,
                        contacto_proveedor = proveedor.Contacto_Proveedor,
                        telefono_contacto = proveedor.Telefono_Contacto,
                        correo_contacto = proveedor.Correo_Contacto,
                        nota = proveedor.Nota,
                        celular1_proveedor = proveedor.Celular1_Proveedor,
                        idtipoproveedor = proveedor.IdTipoProveedor,
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception eX)
            { throw new Exception("Error al Agregar", eX); }
        }

        public string Actualizar_Proveedor(LG_xProveedor proveedor)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_xProveedor set Razon_Social_Proveedor = @razon_social_proveedor, RUC_Proveedor = @ruc_proveedor, Telefono1_Proveedor = @telefono1_proveedor, " +
                                    " Telefono2_Proveedor = @telefono2_proveedor, Pagina_Web_Proveedor = @pagina_web_proveedor, Direccion_Proveedor = @direccion_proveedor, Correo_Proveedor = @correo_proveedor, " +
                                    " Contacto_Proveedor = @contacto_proveedor, Telefono_Contacto = @telefono_contacto, Correo_Contacto = @correo_contacto, Nota = @nota, Celular1_Proveedor = @celular1_proveedor," +
                                    " IdTipoProveedor  = @idtipoproveedor where  IdProveedor = @id";
                    ConexionSQL.Execute(sqlupdate, new {
                        id = proveedor.IdProveedor,
                        razon_social_proveedor = proveedor.Razon_Social_Proveedor,
                        ruc_proveedor = proveedor.RUC_Proveedor,
                        telefono1_proveedor = proveedor.Telefono1_Proveedor,
                        telefono2_proveedor = proveedor.Telefono2_Proveedor,
                        pagina_web_proveedor = proveedor.Pagina_Web_Proveedor,
                        direccion_proveedor = proveedor.Direccion_Proveedor,
                        correo_proveedor = proveedor.Correo_Proveedor,
                        contacto_proveedor = proveedor.Contacto_Proveedor,
                        telefono_contacto = proveedor.Telefono_Contacto,
                        correo_contacto = proveedor.Correo_Contacto,
                        nota = proveedor.Nota,
                        celular1_proveedor = proveedor.Celular1_Proveedor,
                        idtipoproveedor = proveedor.IdTipoProveedor,
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception eX)
            { throw new Exception("Error al Agregar", eX); }
        }

        public string Eliminar_Proveedor(Int32 idproveedor)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "Delete LG_xProveedor where where  IdProveedor = @id";
                    ConexionSQL.Execute(sqldelete, new { id = idproveedor });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Eliminar", Ex); }
        }




    }
}
