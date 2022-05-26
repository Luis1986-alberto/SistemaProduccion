using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aEtiquetadoras_CD
    {
        public static readonly PR_aEtiquetadoras_CD _Intancia = new PR_aEtiquetadoras_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aEtiquetadoras_CD Intancia
        { get { return PR_aEtiquetadoras_CD._Intancia; } }

        public PR_aEtiquetadoras_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aEtiquetadoras> Lista_Etiquetadoras()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEtiquetadora, Marca_Etiquetadora, Modelo_Etiquetadora, Codigo_Etiquetadora from PR_aEtiquetadoras";
                    return conexionsql.Query<PR_aEtiquetadoras>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aEtiquetadoras> Traer_EtiquetadoraPorId(Int32 idetiquetadora)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEtiquetadora, Marca_Etiquetadora, Modelo_Etiquetadora, Codigo_Etiquetadora from PR_aEtiquetadoras where IdEtiquetadora = @id";
                    return conexionsql.Query<PR_aEtiquetadoras>(sql, new { id = idetiquetadora });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Etiquetadoras(PR_aEtiquetadoras etiquetadoras)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aEtiquetadoras (Codigo_Etiquetadora, Marca_Etiquetadora, Modelo_Etiquetadora ) values(@codigo_etiquetadoras, @marca_etiquetadora, @modelo_etiquetadora)";
                    conexionsql.ExecuteScalar(sqlinsert, new {
                        codigo_etiquetadoras = etiquetadoras.Codigo_Etiquetadora,
                        marca_etiquetadora = etiquetadoras.Marca_Etiquetadora,
                        modelo_etiquetadora = etiquetadoras.Modelo_Etiquetadora
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_Etiquetadoras(PR_aEtiquetadoras etiquetadoras)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aEtiquetadoras set Codigo_Etiquetadora = @codigo_etiquetadoras, Marca_Etiquetadora = @marca_etiquetadora, Modelo_Etiquetadora = modelo_etiquetadora where IdEtiquetadora = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                        id = etiquetadoras.IdEtiquetadora,
                        codigo_etiquetadoras = etiquetadoras.Codigo_Etiquetadora,
                        marca_etiquetadora = etiquetadoras.Marca_Etiquetadora,
                        modelo_etiquetadora = etiquetadoras.Modelo_Etiquetadora
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_Etiquetadora(Int32 idetiquetadoras)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aEtiquetadoras where IdEtiquetadora = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idetiquetadoras });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
