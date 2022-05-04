using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoFuelle_CN
    {
        public static readonly PR_aTipoFuelle_CN _Instancia = new PR_aTipoFuelle_CN();

        public static PR_aTipoFuelle_CN Instancia
        { get { return PR_aTipoFuelle_CN._Instancia; } }

        public List<PR_aTipoFuelle> Lista_TipoFuelle()
        { return PR_aTipoFuelle_CD._Instancia.Lista_TipoFuelle().ToList(); }

        public IEnumerable<PR_aTipoFuelle> TraerPorID(Int32 id)
        { return PR_aTipoFuelle_CD._Instancia.Traer_TipoFuellePorId(id); }

        public IEnumerable<PR_aTipoFuelle> Buscar_DescripcionTipoFuelle(string descripciontipofuelle)
        {
            var LST = PR_aTipoFuelle_CD._Instancia.Lista_TipoFuelle().ToList();
            return from DR in LST where DR.Descripcion_TipoFuelle == descripciontipofuelle select DR;
        }

        public string Agregar_TipoFuelle(PR_aTipoFuelle tipofuelle)
        {
            if (Buscar_DescripcionTipoFuelle(tipofuelle.Descripcion_TipoFuelle).Count() > 0) return "YA EXISTE TIPO FUELLE REGISTRADO";
            return PR_aTipoFuelle_CD._Instancia.Agregar_TipoFuelle(tipofuelle);
        }

        public string Actualizar_TipoFuelle(PR_aTipoFuelle tipofuelle)
        {
            if (Buscar_DescripcionTipoFuelle(tipofuelle.Descripcion_TipoFuelle).Count() > 0) return "YA EXISTE TIPO FUELLE REGISTRADO";
            return PR_aTipoFuelle_CD._Instancia.Actualizar_TipoFuelle(tipofuelle);
        }

        public string Eliminar_TipoFuelle(Int32 idtipofuelle)
        { return PR_aTipoFuelle_CD._Instancia.Eliminar_TipoFuelle(idtipofuelle); }

    }
}
