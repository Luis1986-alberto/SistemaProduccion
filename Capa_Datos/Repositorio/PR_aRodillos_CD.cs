using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aRodillos_CD
    {
        public static readonly PR_aRodillos_CD _Instancia = new PR_aRodillos_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aRodillos_CD Instancia
        { get { return PR_aRodillos_CD._Instancia; } }

        public PR_aRodillos_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aRodillos>Lista_Rodillos()
        {        
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdRodillo, Descripcion from  PR_aRodillos";
                    return conexionsql.Query<PR_aRodillos>(sql);
                }
               
            }
            catch(Exception ex)
            {throw new Exception("Error al listar", ex);}             
        }
        public IEnumerable<PR_aRodillos> Traer_PorIdRodillo(Int32 idrodillo)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdRodillo, Descripcion from  PR_aRodillos where IdRodillo = @Id";
                    return conexionsql.Query<PR_aRodillos>(sql, new { id = idrodillo });
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public string Agregar_Rodillo(PR_aRodillos arodillos)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aRodillos (Descripcion) values (@descripcion)";
                    conexionsql.Execute(sqlinsert, new { descripcion = arodillos.Descripcion });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_Rodillo(PR_aRodillos arodillos)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update PR_aRodillos set Descripcion = @descripcion where IdRodillo = @id";
                    conexionsql.ExecuteScalar(sqledit, new { descripcion = arodillos.Descripcion, id = arodillos.IdRodillo });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_Rodillo(Int32 idrodillo)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aRodillos where IdRodillo = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idrodillo });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al eliminar", Ex); }
        }

        

    }
}
