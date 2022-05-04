using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aSectorAlmacenPT_CD
    {
        public static readonly PR_aSectorAlmacenPT_CD _Instancia = new PR_aSectorAlmacenPT_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aSectorAlmacenPT_CD Instancia
        { get { return PR_aSectorAlmacenPT_CD._Instancia; } }

        public PR_aSectorAlmacenPT_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aSectorAlmacenPT> Lista_SectorAlmacen()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdSectorAlmacenPT, Codigo_Sector from PR_aSectorAlmacenPT";
                    return conexionsql.Query<PR_aSectorAlmacenPT>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aSectorAlmacenPT> Traer_SectorAlmacenPorId(Int32 idsectoraalmacenpt)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdSectorAlmacenPT, Codigo_Sector from PR_aSectorAlmacenPT where IdSectorAlmacenPT = @id";
                    return conexionsql.Query<PR_aSectorAlmacenPT>(sql, new { id = idsectoraalmacenpt });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_SectorAlmacen(PR_aSectorAlmacenPT sectoralmacenpt)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aSectorAlmacenPT (Codigo_Sector) values (@codigo_sector)";
                    conexionsql.Execute(sqlinsert, new { codigo_sector = sectoralmacenpt.Codigo_Sector });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_SectorAlmacen(PR_aSectorAlmacenPT sectoralmacenpt)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aSectorAlmacenPT set Codigo_Sector = @codigo_sector where IdSectorAlmacenPT = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = sectoralmacenpt.IdSectorAlmacenPT, codigo_sector = sectoralmacenpt.Codigo_Sector });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_SectorAlmacen(Int32 idsectoralmacen)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aSectorAlmacenPT where IdSectorAlmacenPT = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idsectoralmacen });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

      
    }
}
