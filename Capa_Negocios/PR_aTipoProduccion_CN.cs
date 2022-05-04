using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoProduccion_CN
    {
        public static readonly PR_aTipoProduccion_CN _Instancia = new PR_aTipoProduccion_CN();

        public static PR_aTipoProduccion_CN Instancia
        { get { return PR_aTipoProduccion_CN._Instancia; } }

        public List<PR_aTipoProduccion> Lista_TipoProduccion()
        { return PR_aTipoProduccion_CD._Instancia.Lista_TipoProduccion().ToList(); }

        public IEnumerable<PR_aTipoProduccion> TraerPorID(Int32 id)
        { return PR_aTipoProduccion_CD._Instancia.Traer_TipoProduccionPorId(id); }

        public IEnumerable<PR_aTipoProduccion> Buscar_TipoProduccion(string detalletipoproduccion)
        {
            var lista = PR_aTipoProduccion_CD._Instancia.Lista_TipoProduccion().ToList();
            return from buscar in lista where buscar.Detalle_TipoProduccion == detalletipoproduccion select buscar;
        }

        public string Agregar_TipoProduccion(PR_aTipoProduccion tipoproduccion)
        {
            if (Buscar_TipoProduccion(tipoproduccion.Detalle_TipoProduccion).Count() > 0) return "EXISTE TIPO PRODUCCION";
            return PR_aTipoProduccion_CD._Instancia.Agregar_TipoProduccion(tipoproduccion);
        }

        public string Actualizar_TipoProduccion(PR_aTipoProduccion tipoproduccion)
        {
            if (Buscar_TipoProduccion(tipoproduccion.Detalle_TipoProduccion).Count() > 0) return "EXISTE TIPO PRODUCCION";
            return PR_aTipoProduccion_CD._Instancia.Actualizar_TipoProduccion(tipoproduccion);
        }

        public string Eliminar_TipoProduccion(Int32 idtipoproduccion)
        { return PR_aTipoProduccion_CD._Instancia.Eliminar_TipoProduccion(idtipoproduccion); }
    }
}
