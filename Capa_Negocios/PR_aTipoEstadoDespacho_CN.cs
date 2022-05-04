using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoEstadoDespacho_CN
    {
        public static readonly PR_aTipoEstadoDespacho_CN _Instancia = new PR_aTipoEstadoDespacho_CN();

        public static PR_aTipoEstadoDespacho_CN Instancia
        { get { return PR_aTipoEstadoDespacho_CN._Instancia; } }

        public List<PR_aTipoEstadoDespacho> Lista_TipoEstadoDespacho()
        { return PR_aTipoEstadoDespacho_CD._Instancia.Lista_TipoEstadoDespacho().ToList(); }

        public IEnumerable<PR_aTipoEstadoDespacho> TraerPorID(Int32 id)
        { return PR_aTipoEstadoDespacho_CD._Instancia.Traer_TipoEstadoDespachoPorId(id); }

        public IEnumerable<PR_aTipoEstadoDespacho> Buscar_TipoEstadoDespacho(string tipodespacho)
        {
            var lista = PR_aTipoEstadoDespacho_CD._Instancia.Lista_TipoEstadoDespacho().ToList();
            return from buscar in lista where buscar.TipoEstadoDespacho == tipodespacho select buscar;
        }

        public string Agregar_TipoDespacho(PR_aTipoEstadoDespacho tipoestadodespacho)
        {
            if (Buscar_TipoEstadoDespacho(tipoestadodespacho.TipoEstadoDespacho).Count() > 0) return "EXISTE";
            return PR_aTipoEstadoDespacho_CD._Instancia.Agregar_TipoEstadoDespacho(tipoestadodespacho);
        }

        public string Actualizar_TipoDespacho(PR_aTipoEstadoDespacho tipoestadodespacho)
        {
            if (Buscar_TipoEstadoDespacho(tipoestadodespacho.TipoEstadoDespacho).Count() > 0) return "EXISTE";
            return PR_aTipoEstadoDespacho_CD._Instancia.Actualizar_TipoDespacho(tipoestadodespacho);
        }

        public string Eliminar_TipoDespacho(Int32 idtipodespacho)
        { return PR_aTipoEstadoDespacho_CD._Instancia.Eliminar_TipoDespacho(idtipodespacho); }

    }
}
