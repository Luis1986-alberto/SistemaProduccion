using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aFamilia_Produccion_CN
    {
        public static readonly PR_aFamilia_Produccion_CN _Instancia = new PR_aFamilia_Produccion_CN();

        public static PR_aFamilia_Produccion_CN Instancia
        { get { return PR_aFamilia_Produccion_CN._Instancia; } }

        public List<PR_aFamilia_Produccion> Lista_FamiliaProduccion()
        { return PR_aFamilia_Produccion_CD._Instancia.Lista_FamiliasProduccion().ToList(); }

        public IEnumerable<PR_aFamilia_Produccion> TraerPorID(Int32 id)
        { return PR_aFamilia_Produccion_CD._Instancia.Traer_FamiliaProdPorId(id); }

        public IEnumerable<PR_aFamilia_Produccion> Buscar_FamiliaProduccion(string familiaproduccion)
        {
            var lista = PR_aFamilia_Produccion_CD._Instancia.Lista_FamiliasProduccion().ToList();
            return from buscar in lista where buscar.Descripcion_Familia == familiaproduccion select buscar;
        }

        public string Agregar(PR_aFamilia_Produccion familiaproduccion)
        {
            if (Buscar_FamiliaProduccion(familiaproduccion.Descripcion_Familia).Count() > 0) return "Existe una familia produccion Registrado";
            return PR_aFamilia_Produccion_CD._Instancia.Agregar_FamiliaProduccion(familiaproduccion);
        }

        public string Actualizar(PR_aFamilia_Produccion familiaproduccion)
        {
            if (Buscar_FamiliaProduccion(familiaproduccion.Descripcion_Familia).Count() > 0) return "Existe una familia produccion Registrado";
            return PR_aFamilia_Produccion_CD._Instancia.Actualizar_FamiliaProduccion(familiaproduccion);
        }

        public string Eliminar(Int32 idfamproduccion)
        { return PR_aFamilia_Produccion_CD._Instancia.Eliminar_FamiliaProduccion(idfamproduccion); }
    }
}
