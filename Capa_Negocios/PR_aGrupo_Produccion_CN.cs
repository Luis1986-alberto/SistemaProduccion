using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aGrupo_Produccion_CN
    {
        public static readonly PR_aGrupo_Produccion_CN _Instancia = new PR_aGrupo_Produccion_CN();

        public static PR_aGrupo_Produccion_CN Instancia
        { get { return PR_aGrupo_Produccion_CN._Instancia; } }

        public List<PR_aGrupo_Produccion> Lista_GrupoProduccion()
        { return PR_aGrupo_Produccion_CD.Instancia.Lista_GrupoProduccion().ToList(); }

        public IEnumerable<PR_aGrupo_Produccion> TraerPorID(Int32 id)
        { return PR_aGrupo_Produccion_CD.Instancia.Traer_GrupoProduccionPorId(id); }
        public IEnumerable<PR_aGrupo_Produccion> Buscar_DescripcionGrupoProd(string descGrupoprod)
        {
           var lista = PR_aGrupo_Produccion_CD.Instancia.Lista_GrupoProduccion().ToList();
            return from buscar in lista where buscar.Descripcion_GrupoProd == descGrupoprod select buscar;
        }

        public string Agregar_GrupoProduccion(PR_aGrupo_Produccion grupoproduccion)
        {
            if (Buscar_DescripcionGrupoProd(grupoproduccion.Descripcion_GrupoProd).Count() > 0) return "Existe una forma Empaquetado Registrado";
            return PR_aGrupo_Produccion_CD._Instancia.Agregar_GrupoProduccion(grupoproduccion);
        }

        public string Actualizar_GrupoProduccion(PR_aGrupo_Produccion grupoproduccion)
        {
            if (Buscar_DescripcionGrupoProd(grupoproduccion.Descripcion_GrupoProd).Count() > 0) return "Existe una forma Empaquetado Registrado";
            return PR_aGrupo_Produccion_CD._Instancia.Actualizar_GrupoProduccion(grupoproduccion);
        }

        public string Eliminar_GrupoProduccion(Int32 idgrupoprod)
        { return PR_aGrupo_Produccion_CD._Instancia.Eliminar_GrupoProduccion(idgrupoprod); }

    }
}
