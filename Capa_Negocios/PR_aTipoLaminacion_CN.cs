using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoLaminacion_CN
    {
        public static readonly PR_aTipoLaminacion_CN _Instancia = new PR_aTipoLaminacion_CN();

        public static PR_aTipoLaminacion_CN Instancia
        { get { return PR_aTipoLaminacion_CN._Instancia; } }

        public List<PR_aTipoLaminacion> Lista_TipoLaminacion()
        { return PR_aTipoLaminacion_CD._Instancia.Lista_TipoLaminacion().ToList(); }

        public IEnumerable<PR_aTipoLaminacion> TraerPorID(Int32 id)
        { return PR_aTipoLaminacion_CD._Instancia.Traer_TipoLaminacionPorId(id); }

        public IEnumerable<PR_aTipoLaminacion> Buscar_TipoLaminacion(string detallelaminacion)
        {
           var lista = PR_aTipoLaminacion_CD._Instancia.Lista_TipoLaminacion().ToList();
            return from buscar in lista where buscar.Detalle_Laminacion == detallelaminacion select buscar;
        }

        public string Agregar_TipoLaminacion(PR_aTipoLaminacion tipolaminacion)
        {
            if (Buscar_TipoLaminacion(tipolaminacion.Detalle_Laminacion).Count() > 0) return "EXISTE TIPO LAMINACION";
            return PR_aTipoLaminacion_CD._Instancia.Agregar_TipoLaminacion(tipolaminacion);
        }

        public string Actualizar_TipoLaminacion(PR_aTipoLaminacion tipolaminacion)
        {
            if (Buscar_TipoLaminacion(tipolaminacion.Detalle_Laminacion).Count() > 0) return "EXISTE TIPO LAMINACION";
            return PR_aTipoLaminacion_CD._Instancia.Actualizar_TipoLaminacion(tipolaminacion);
        }

        public string Eliminar_TipoLaminacion(Int32 idtipolaminacion)
        { return PR_aTipoLaminacion_CD._Instancia.Eliminar_TipoLaminacion(idtipolaminacion); }

    }
}
