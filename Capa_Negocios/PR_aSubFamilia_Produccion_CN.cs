using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aSubFamilia_Produccion_CN
    {
        public static readonly PR_aSubFamilia_Produccion_CN _Instancia = new PR_aSubFamilia_Produccion_CN();

        public static PR_aSubFamilia_Produccion_CN Instancia
        { get { return PR_aSubFamilia_Produccion_CN._Instancia; } }

        public List<PR_aSubFamilia_Produccion> Lista_subfamiliaProd()
        { return PR_aSubFamilia_Produccion_CD._Instancia.Lista_SubFamiliaProduccion().ToList(); }

        public IEnumerable<PR_aSubFamilia_Produccion> TraerPorID(Int32 id)
        { return PR_aSubFamilia_Produccion_CD._Instancia.Traer_subfamiliaproduccionPorId(id); }

        public IEnumerable<PR_aSubFamilia_Produccion> Buscar_Descripcionsubfamilia(string subfamilia)
        {
            var lista = PR_aSubFamilia_Produccion_CD._Instancia.Lista_SubFamiliaProduccion().ToList();
            return from buscar in lista where buscar.Descripcion_SubFamiliaProd == subfamilia select buscar;
        }

        public string Agregar_SubFamiliaProduccion(PR_aSubFamilia_Produccion subfamiliaproduccion)
        {
            if (Buscar_Descripcionsubfamilia(subfamiliaproduccion.Descripcion_SubFamiliaProd).Count() > 0) return "Existe una subfamilia Registrado";
            return PR_aSubFamilia_Produccion_CD._Instancia.Agregar_SubFamiliaProduccion(subfamiliaproduccion);
        }

        public string Actualizar_SubFamiliaProduccion(PR_aSubFamilia_Produccion subfamiliaproduccion)
        {
            if (Buscar_Descripcionsubfamilia(subfamiliaproduccion.Descripcion_SubFamiliaProd).Count() > 0) return "Existe una subfamilia Registrado";
            return PR_aSubFamilia_Produccion_CD._Instancia.Actualizar_SubFamiliaProduccion(subfamiliaproduccion);
        }

        public string Eliminar_SubFamiliaProduccion(Int32 idsubfamilia)
        { return PR_aSubFamilia_Produccion_CD._Instancia.Eliminar_SubFamiliaProduccion(idsubfamilia); }

    }
}
