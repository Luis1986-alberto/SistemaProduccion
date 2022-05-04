using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aMedidas_Produccion_CN
    {
        public static readonly PR_aMedidas_Produccion_CN _Instancia = new PR_aMedidas_Produccion_CN();

        public static PR_aMedidas_Produccion_CN Instancia
        { get { return PR_aMedidas_Produccion_CN._Instancia; } }

        public List<PR_aMedidas_Produccion> Lista_MedidasProduccion()
        { return PR_aMedidas_Produccion_CD._Instancia.Lista_MedidasProduccion().ToList(); }

        public IEnumerable<PR_aMedidas_Produccion> TraerPorID(Int32 id)
        { return PR_aMedidas_Produccion_CD._Instancia.Traer_MedidaProduccionPorId(id); }

        public IEnumerable<PR_aMedidas_Produccion> Buscar_DescripcionMedida(string descripcionmedida)
        {
            var lista = PR_aMedidas_Produccion_CD._Instancia.Lista_MedidasProduccion().ToList();
            return from buscar in lista where buscar.Descripcion_Medida == descripcionmedida select buscar;
        }

        public string Agregar_MedidasProduccion(PR_aMedidas_Produccion medidasproduccion)
        {
            if (Buscar_DescripcionMedida(medidasproduccion.Descripcion_Medida).Count() > 0) return "Existe una Medida Produccion Registrado";
            return PR_aMedidas_Produccion_CD._Instancia.Agregar_MedidasProduccion(medidasproduccion);
        }

        public string Actualizar_MedidasProduccion(PR_aMedidas_Produccion medidasproduccion)
        {
            if (Buscar_DescripcionMedida(medidasproduccion.Descripcion_Medida).Count() > 0) return "Existe una Medida Produccion Registrado";
            return PR_aMedidas_Produccion_CD._Instancia.Actualizar_MedidaProduccion(medidasproduccion);
        }

        public string Eliminar_MedidasProduccion(Int32 idmedidaproduccion)
        { return PR_aMedidas_Produccion_CD._Instancia.Eliminar_MedidaProduccion(idmedidaproduccion); }

    }
}
