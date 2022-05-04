using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class MP_aAgenteAduanero_CD
    {
        public static readonly MP_aAgenteAduanero_CD _instancia = new MP_aAgenteAduanero_CD();
        public Inicio principal = new Inicio();
        public string cadenaconexion = "";

        public static MP_aAgenteAduanero_CD Instancia
        { get { return MP_aAgenteAduanero_CD._instancia; } }

        public MP_aAgenteAduanero_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<MP_aAgenteAduanero> Lista_AgenteAduanero()
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAgenteAduanero, Razon_Social_Agente, Direccion_Agente, Numero_RUC_Agente, Numero_Telefono_Agente, Numero_Celular_Agente," +
                               "Numero_Fax_Agente, Correo_Agente from MP_aAgenteAduanero ";
                    return conexionSQL.Query<MP_aAgenteAduanero>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<MP_aAgenteAduanero> Traer_AgenteAduaneroPorId(Int32 idagenteaduanero)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAgenteAduanero, Razon_Social_Agente, Direccion_Agente, Numero_RUC_Agente, Numero_Telefono_Agente, Numero_Celular_Agente," +
                               "Numero_Fax_Agente, Correo_Agente from MP_aAgenteAduanero where IdAgenteAduanero = @id  ";
                    return conexionSQL.Query<MP_aAgenteAduanero>(sql, new { id = idagenteaduanero });
                }
            }
            catch(Exception ex)
            { throw new Exception("Errort al traer por ID", ex); }
        }

        public string Agregar_AgenteAduanero(MP_aAgenteAduanero agenteaduanero)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into MP_aAgenteAduanero (Razon_Social_Agente, Direccion_Agente, Numero_RUC_Agente, Numero_Telefono_Agente, Numero_Celular_Agente, Numero_Fax_Agente, Correo_Agente )" +
                                    " values (@razon_social_agente, @direccion_agente, @numero_ruc_agente, @numero_telefono_agente, @numero_celular_agente, @numero_fax_agente, @correo_agente) ";
                    conexionSQL.Execute(sqlinsert, new {
                                                            razon_social_agente = agenteaduanero.Razon_Social_Agente,
                                                            direccion_agente = agenteaduanero.Direccion_Agente,
                                                            numero_ruc_agente = agenteaduanero.Numero_RUC_Agente,
                                                            numero_telefono_agente = agenteaduanero.Numero_Telefono_Agente,
                                                            numero_celular_agente = agenteaduanero.Numero_Celular_Agente,
                                                            numero_fax_agente = agenteaduanero.Numero_Fax_Agente,
                                                            correo_agente = agenteaduanero.Correo_Agente
                                                        });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }

        public string Actualizar_AgenteAduanero(MP_aAgenteAduanero agenteaduanero)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update MP_aAgenteAduanero set Razon_Social_Agente =  @razon_social_agente, Direccion_Agente = @direccion_agente, Numero_RUC_Agente = @numero_ruc_agente, " +
                                    " Numero_Telefono_Agente = @numero_telefono_agente, Numero_Celular_Agente = @numero_celular_agente, Numero_Fax_Agente = @numero_fax_agente, Correo_Agente = @correo_agente  where IdAgenteAduanero = @id ";
                    conexionSQL.Execute(sqlupdate, new {
                                                            id = agenteaduanero.IdAgenteAduanero,
                                                            razon_social_agente = agenteaduanero.Razon_Social_Agente,
                                                            direccion_agente = agenteaduanero.Direccion_Agente,
                                                            numero_ruc_agente = agenteaduanero.Numero_RUC_Agente,
                                                            numero_telefono_agente = agenteaduanero.Numero_Telefono_Agente,
                                                            numero_celular_agente = agenteaduanero.Numero_Celular_Agente,
                                                            numero_fax_agente = agenteaduanero.Numero_Fax_Agente,
                                                            correo_agente = agenteaduanero.Correo_Agente
                                                        });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }


        public string Eliminar_AgenteAduanero(Int32 idagenteaduanero)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete MP_aAgenteAduanero where IdAgenteAduanero = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idagenteaduanero });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}