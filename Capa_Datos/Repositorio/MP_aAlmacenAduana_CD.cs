using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class MP_aAlmacenAduana_CD
    {
        public static readonly MP_aAlmacenAduana_CD _Instancia = new MP_aAlmacenAduana_CD();
        public Inicio principal = new Inicio();
        public string cadenaconexion = "";

        public static MP_aAlmacenAduana_CD Instancia
        { get { return MP_aAlmacenAduana_CD._Instancia; } }

        public MP_aAlmacenAduana_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<MP_aAlmacenAduana> Lista_AlmacenAduanero()
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAlmacenAduana, Nombre_AlmacenAduana from MP_aAlmacenAduana ";
                    return conexionSQL.Query<MP_aAlmacenAduana>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<MP_aAlmacenAduana> Traer_AgenteAduaneroPorId(Int32 idagenteaduanero)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAlmacenAduana, Nombre_AlmacenAduana from MP_aAlmacenAduana where IdAlmacenAduana = @id  ";
                    return conexionSQL.Query<MP_aAlmacenAduana>(sql, new { id = idagenteaduanero });
                }
            }
            catch(Exception ex)
            { throw new Exception("Errort al traer por ID", ex); }
        }

        public string Agregar_AlmacenAduana(MP_aAlmacenAduana almacenaduana)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into MP_aAlmacenAduana (Nombre_AlmacenAduana ) values (@nombre_almacenaduana)";
                    conexionSQL.Execute(sqlinsert, new { nombre_almacenaduana = almacenaduana.Nombre_AlmacenAduana });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }

        public string Actualizar_AgenteAduanero(MP_aAlmacenAduana almacenaduana)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update MP_aAlmacenAduana set Nombre_AlmacenAduana =  @nombre_almacenaduana  where IdAlmacenAduana = @id ";
                    conexionSQL.Execute(sqlupdate, new { id = almacenaduana.IdAlmacenAduana, nombre_almacenaduana = almacenaduana.Nombre_AlmacenAduana });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }


        public string Eliminar_AgenteAduanero(Int32 idalmacenaduana)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete MP_aAlmacenAduana where IdAlmacenAduana = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idalmacenaduana });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }



    }
}
