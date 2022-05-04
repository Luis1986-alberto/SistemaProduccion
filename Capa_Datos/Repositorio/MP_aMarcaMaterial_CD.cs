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
    public class MP_aMarcaMaterial_CD
    {
        public static readonly MP_aMarcaMaterial_CD _Instancia = new MP_aMarcaMaterial_CD();
        public Inicio Principal = new Inicio();
        public string cadenaconexion;

        public static MP_aMarcaMaterial_CD Instancia
        { get { return MP_aMarcaMaterial_CD._Instancia; } }

        public MP_aMarcaMaterial_CD()
        {
            Principal.LeerConfiguracion();
            cadenaconexion = Principal.CadenaConexion;
        }

        public IEnumerable<MP_aMarcaMaterial> Lista_MarcaMaterial()
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMarcaMaterial, Descripcion, Abreviatura_MarcaMaterial from MP_aMarcaMaterial";
                    return conexionSQL.Query<MP_aMarcaMaterial>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<MP_aMarcaMaterial> Traer_MarcaMaterialPorId(Int32 idmarcamaterial)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMarcaMaterial, Descripcion, Abreviatura_MarcaMaterial from MP_aMarcaMaterial where IdMarcaMaterial = @id  ";
                    return conexionSQL.Query<MP_aMarcaMaterial>(sql, new { id = idmarcamaterial });
                }
            }
            catch(Exception ex)
            { throw new Exception("Errort al traer por ID", ex); }
        }

        public string Agregar_MarcaMaterial(MP_aMarcaMaterial marcamaterial)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into MP_aMarcaMaterial (Descripcion, Abreviatura_MarcaMaterial) values (@descripcion, @abreviatura_marcamaterial)";
                    conexionSQL.Execute(sqlinsert, new { descripcion = marcamaterial.Descripcion, abreviatura_marcamaterial = marcamaterial.Abreviatura_MarcaMaterial });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }

        public string Actualizar_MarcaMaterial(MP_aMarcaMaterial marcamaterial)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update MP_aMarcaMaterial set Descripcion =  @descripcion, Abreviatura_MarcaMaterial = @abreviatura_marcamaterial  where IdMarcaMaterial = @id ";
                    conexionSQL.ExecuteScalar(sqlupdate, new { id = marcamaterial.IdMarcaMaterial, 
                                                               descripcion = marcamaterial.Descripcion, 
                                                               abreviatura_marcamaterial = marcamaterial.Abreviatura_MarcaMaterial,
                                                             });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_MarcaMaterial(Int32 idmarcamaterial)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete MP_aMarcaMaterial where IdMarcaMaterial = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idmarcamaterial });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
