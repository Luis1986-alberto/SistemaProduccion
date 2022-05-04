using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aCodigoEvento_CD
    {
        public static readonly PR_aCodigoEvento_CD _Instancia = new PR_aCodigoEvento_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aCodigoEvento_CD Instancia
        { get { return PR_aCodigoEvento_CD._Instancia; } }

        public PR_aCodigoEvento_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aCodigoEvento> Lista_CodigoEvento()
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select CE.IdCodigoEvento, CE.Codigo_Evento, CE.Descripcion, CE.Flag_EventoMaquina, CE.Flag_EventoColaborador, CE.Flag_EventoMaterial, CE.IdArea, AR.Nombre_Area, CE.IdLocal, LO.Nombre_Local from PR_aCodigoEvento as CE " +
                              " inner join PR_aLocal as LO on CE.IdLocal = LO.IdLocal inner join PR_aArea as AR on CE.IdArea = AR.IdArea ";
                    return conexionsql.Query<PR_aCodigoEvento>(sql);
                }
            }
            catch (Exception ex)
            { throw new Exception("Error al listar", ex); }
        }
        public IEnumerable<PR_aCodigoEvento> Traer_CodigoEventoPorId(Int32 idcodigoevento)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdCodigoEvento, Codigo_Evento, Descripcion, Flag_EventoMaquina, Flag_EventoColaborador, Flag_EventoMaterial, IdArea, IdLocal from PR_aCodigoEvento where IdCodigoEvento = @id";
                    return conexionsql.Query<PR_aCodigoEvento>(sql, new { id = idcodigoevento });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_CodigoEvento(PR_aCodigoEvento codigoevento)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aCodigoEvento (Codigo_Evento, Descripcion, Flag_EventoMaquina, Flag_EventoColaborador, Flag_EventoMaterial, IdArea, IdLocal, IdUsuario) values " +
                                                              " (@codigo_evento, @descripcion, @flag_eventomaquina, @flag_eventocolaborador, @flag_eventomaterial, @idarea, @idlocal, @idusuario) ";
                        conexionsql.Execute(sqlinsert, new
                                                            {
                                                                codigo_evento = codigoevento.Codigo_Evento,
                                                                descripcion = codigoevento.Descripcion,
                                                                flag_eventomaquina = codigoevento.Flag_EventoMaquina,
                                                                flag_eventocolaborador = codigoevento.Flag_EventoColaborador,
                                                                flag_eventomaterial = codigoevento.Flag_EventoMaterial,
                                                                idarea = codigoevento.IdArea,
                                                                idlocal = codigoevento.IdLocal,
                                                                idusuario = codigoevento.IdUsuario
                                                            });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_CodigoEvento(PR_aCodigoEvento codigoevento)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "update PR_aCodigoEvento set Codigo_Evento = @codigo_evento, Descripcion = @descripcion, Flag_EventoMaquina = @flag_eventomaquina," +
                                    " Flag_EventoColaborador = @flag_eventocolaborador, Flag_EventoMaterial = @flag_eventomaterial, IdArea = @idarea, IdLocal = @idlocal, " +
                                    " IdUsuario = @idusuario where IdCodigoEvento = @idcodigoevento";
                    conexionsql.ExecuteScalar(sqlinsert, new
                    {
                        idcodigoevento = codigoevento.IdCodigoEvento,
                        codigo_evento = codigoevento.Codigo_Evento,
                        descripcion = codigoevento.Descripcion,
                        flag_eventomaquina = codigoevento.Flag_EventoMaquina,
                        flag_eventocolaborador = codigoevento.Flag_EventoColaborador,
                        flag_eventomaterial = codigoevento.Flag_EventoMaterial,
                        idarea = codigoevento.IdArea,
                        idlocal = codigoevento.IdLocal,
                        idusuario = codigoevento.IdUsuario
                    });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Eliminar_CodigoEvento(Int32 idcodigoevento)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "delete PR_aCodigoEvento where IdCodigoEvento = @idcodigoevento";
                    conexionsql.ExecuteScalar(sqlinsert, new
                    {
                        idcodigoevento = idcodigoevento
                    });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al inserta", ex); }
        }

       


    }
}
