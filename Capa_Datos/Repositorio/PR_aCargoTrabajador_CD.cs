using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aCargoTrabajador_CD
    {
        public static readonly PR_aCargoTrabajador_CD _Instancia = new PR_aCargoTrabajador_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aCargoTrabajador_CD Instancia
        { get { return PR_aCargoTrabajador_CD._Instancia; } }

        public PR_aCargoTrabajador_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aCargoTrabajador>Lista_cargotrabajador()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    var sql = "select IdCargoTrabajador, Nombre_CargoTrabajador from PR_aCargoTrabajador";
                    return conexionsql.Query<PR_aCargoTrabajador>(sql);
                }
            }
            catch (Exception ex)
            {throw new Exception("Error al eliminar ", ex);}
        }

        public IEnumerable<PR_aCargoTrabajador> Traer_CargotrabajadorPorId(Int32 idcargotrabajador)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdCargoTrabajador, Nombre_CargoTrabajador from PR_aCargoTrabajador where IdCargoTrabajador = @id";
                    return conexionsql.Query<PR_aCargoTrabajador>(sql, new { id = idcargotrabajador });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_CargoTrabajador(PR_aCargoTrabajador cargotrabajador)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aCargoTrabajador (Nombre_CargoTrabajador) values (@nombre_cargotrabajador)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_cargotrabajador = cargotrabajador.Nombre_CargoTrabajador });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            {throw new Exception("Error al agregar ", ex);}
        }

        public string Actualizar_CargoTrabajador(PR_aCargoTrabajador cargotrabajador)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update PR_aCargoTrabajador set Nombre_CargoTrabajador = @nombre_cargotrabajador where IdCargoTrabajador = @idcargotrabajador ";
                    conexionsql.ExecuteScalar(sqlupdate, new { idcargotrabajador = cargotrabajador.IdCargoTrabajador, nombre_cargotrabajador = cargotrabajador.Nombre_CargoTrabajador });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            {throw new Exception("Error al Actualizar", ex);}
        }

        public string Eliminar_CargoTrabajador(Int32 idcargotrabajador)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aCargoTrabajador where IdCargoTrabajador = @idcargotrabajador";
                    conexionsql.ExecuteScalar(sqldelete, new { idcargotrabajador = idcargotrabajador });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            {throw new Exception("Error al eliminar", ex);}
        }


    }
}
