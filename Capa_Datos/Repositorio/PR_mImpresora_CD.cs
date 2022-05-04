using Capa_Datos.Interface;
using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_mImpresora_CD : IRepositori<PR_mImpresora>
    {
        private Inicio principal = new Inicio();
        private string cadenaconexion;
        public static readonly PR_mImpresora_CD _Instancia = new PR_mImpresora_CD();

        public static PR_mImpresora_CD Instancia
        { get { return PR_mImpresora_CD._Instancia; } }

        public PR_mImpresora_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public String Agregar(PR_mImpresora entidad)
        {
           using(var ConexionSQL = new SqlConnection(cadenaconexion))
            {
                var sqlinsert = "Insert Into PR_mImpresora (IdMaquina, IdRodillo) values (@idmaquina, @idrodillo) ";
                ConexionSQL.Execute(sqlinsert, new { idmaquina = entidad.IdMaquina, idrodillo = entidad.IdRodillo });
                return "PROCESADO";
            }
        }

        public String Actualizar(PR_mImpresora entidad)
        {
            using(var ConexionSQL = new SqlConnection(cadenaconexion))
            {
                var sqlinsert = "Update PR_mImpresora Set IdMaquina = @idmaquina, IdRodillo = @idrodillo where IdImpresora = @id ";
                ConexionSQL.Execute(sqlinsert, new {id = entidad.IdImpresora,  idmaquina = entidad.IdMaquina, idrodillo = entidad.IdRodillo });
                return "PROCESADO";
            }
        }

        public String Eliminar(Int32 idimpresora)
        {
            using(var ConexionSQL = new SqlConnection(cadenaconexion))
            {
                var sqlinsert = "Delete PR_mImpresora where IdImpresora = @id) ";
                ConexionSQL.Execute(sqlinsert, new { id = idimpresora });
                return "PROCESADO";
            }
        }

        public IEnumerable<PR_mImpresora> TraerPorId(Int32 idimpresora)
        {
            using(var ConexionSQL = new SqlConnection(cadenaconexion))
            {
                var sql = "Select IdImpresora, IdMaquina, IdRodillo from PR_mImpresora  where IdImpresora = @id ";
                return ConexionSQL.Query<PR_mImpresora>(sql, new { id = idimpresora });
            }
        }

        public IEnumerable<PR_mImpresora> Listar()
        {
            using(var ConexionSQL = new SqlConnection(cadenaconexion))
            {
                var sql = " Select IMP.IdImpresora, IMP.IdMaquina, MQ.Alias_Maquina, IMP.IdRodillo, RD.Descripcion from PR_mImpresora as IMP inner join PR_mMaquina as MQ " +
                          " on IMP.IdMaquina = MQ.IdMaquina inner join PR_aRodillos as RD on IMP.IdRodillo = RD.IdRodillo";
                return ConexionSQL.Query<PR_mImpresora>(sql);
            }
        }

        public IEnumerable<PR_mImpresora> FiltroPorUnCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            {
                ConexionSQL.Open();
                var result = ConexionSQL.GetList<PR_mImpresora>(predicado);
                ConexionSQL.Close();
                return result;
            }
        }

        PR_mImpresora IRepositori<PR_mImpresora>.TraerPorId(Int32 id)
        {
            throw new NotImplementedException();
        }
    }
}
