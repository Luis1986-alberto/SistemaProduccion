using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoProcesoLaminado_CN
    {
        public static readonly PR_aTipoProcesoLaminado_CN _Instancia = new PR_aTipoProcesoLaminado_CN();

        public static PR_aTipoProcesoLaminado_CN Instancia
        { get { return PR_aTipoProcesoLaminado_CN._Instancia; } }

        public List<PR_aTipoProcesoLaminado> Lista_TipoProcesoLaminado()
        { return PR_aTipoProcesoLaminado_CD._Instancia.Lista_TipoProcesoLaminado().ToList(); }

        public IEnumerable<PR_aTipoProcesoLaminado> TraerPorID(Int32 id)
        { return PR_aTipoProcesoLaminado_CD._Instancia.Traer_TipoProcesoLaminadoPorId(id); }

        public IEnumerable<PR_aTipoProcesoLaminado> Buscar_TipoProcesoLaminado(string procesolaminado)
        {
            var lista = PR_aTipoProcesoLaminado_CD._Instancia.Lista_TipoProcesoLaminado().ToList();
            return from buscar in lista where buscar.Nombre_TipoProcesoLaminado == procesolaminado select buscar;
        }

        public string Agregar_TipoProcesoLaminado(PR_aTipoProcesoLaminado tipoproclaminado)
        {
            if (Buscar_TipoProcesoLaminado(tipoproclaminado.Nombre_TipoProcesoLaminado).Count() > 0) return "EXISTE TIPO PROCESO LAMINADO";
            return PR_aTipoProcesoLaminado_CD._Instancia.Agregar_TipoProcesoLaminado(tipoproclaminado);
        }

        public string Actualizar_TipoProcesoLaminado(PR_aTipoProcesoLaminado tipoproclaminado)
        {
            if (Buscar_TipoProcesoLaminado(tipoproclaminado.Nombre_TipoProcesoLaminado).Count() > 0) return "EXISTE TIPO PROCESO LAMINADO";
            return PR_aTipoProcesoLaminado_CD._Instancia.Actualizar_TipoProcesoLaminado(tipoproclaminado);
        }

        public string Eliminar_TipoProcesoLaminado(Int32 idtipoprocesolam)
        { return PR_aTipoProcesoLaminado_CD._Instancia.Eliminar_TipoProcesoLaminado(idtipoprocesolam); }

    }
}
