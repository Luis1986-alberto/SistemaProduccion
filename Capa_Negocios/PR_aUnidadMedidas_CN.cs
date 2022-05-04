using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aUnidadMedidas_CN
    {
        public static readonly PR_aUnidadMedidas_CN _Instancia = new PR_aUnidadMedidas_CN();

        public static PR_aUnidadMedidas_CN Instancia
        { get { return PR_aUnidadMedidas_CN._Instancia; } }

        public List<PR_aUnidadMedidas> Lista_UnidadMedida()
        { return PR_aUnidadMedidas_CD._Instancia.Lista_UnidadMedida().ToList(); }

        public IEnumerable<PR_aUnidadMedidas> TraerPorID(Int32 id)
        { return PR_aUnidadMedidas_CD._Instancia.Traer_UnidadMedidaPorId(id); }

        public IEnumerable<PR_aUnidadMedidas> Buscar_NombreUnidad(string nombreunidad)
        {
            var lista = PR_aUnidadMedidas_CD._Instancia.Lista_UnidadMedida().ToList();
            return from buscar in lista where buscar.Nombre_Unidad == nombreunidad select buscar;
        }

        public string Agregar_UnidadMedida(PR_aUnidadMedidas unidadmedida)
        {
            if (Buscar_NombreUnidad(unidadmedida.Nombre_Unidad).Count() > 0) return "EXISTE UNIDAD MEDIDA";
            return PR_aUnidadMedidas_CD._Instancia.Agregar_UnidadMedida(unidadmedida);
        }

        public string Actualizar_UnidadMedida(PR_aUnidadMedidas unidadmedida)
        {
            if (Buscar_NombreUnidad(unidadmedida.Nombre_Unidad).Count() > 0) return "EXISTE UNIDAD MEDIDA ";
            return PR_aUnidadMedidas_CD._Instancia.Actualizar_UnidadMedida(unidadmedida);
        }

        public string Eliminar_UnidadMedida(Int32 idtipolaminacion)
        { return PR_aUnidadMedidas_CD._Instancia.Eliminar_UnidadMedida(idtipolaminacion); }
    }
}
