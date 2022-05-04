using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoTinta_CN
    {
        public static readonly PR_aTipoTinta_CN _Instancia = new PR_aTipoTinta_CN();

        public static PR_aTipoTinta_CN Instancia
        { get { return PR_aTipoTinta_CN._Instancia; } }

        public List<PR_aTipoTinta> Lista_TipoTinta()
        { return PR_aTipoTinta_CD._Instancia.Lista_TipoTinta().ToList(); }

        public IEnumerable<PR_aTipoTinta> TraerPorID(Int32 id)
        { return PR_aTipoTinta_CD._Instancia.Traer_TipoTintaPorId(id); }

        public IEnumerable<PR_aTipoTinta> Buscar_DescTipoTinta(string desctipotinta)
        {
            var lista = PR_aTipoTinta_CD._Instancia.Lista_TipoTinta().ToList();
            return from buscar in lista where buscar.Descripcion_TipoTinta == desctipotinta select buscar;
        }

        public string Agregar_TipoTinta(PR_aTipoTinta tipotinta)
        {
            if (Buscar_DescTipoTinta(tipotinta.Descripcion_TipoTinta).Count() > 0) return "EXISTE TIPO TINTA";
            return PR_aTipoTinta_CD._Instancia.Agregar_TipoTinta(tipotinta);
        }

        public string Actualizar_TipoTinta(PR_aTipoTinta tipotinta)
        {
            if (Buscar_DescTipoTinta(tipotinta.Descripcion_TipoTinta).Count() > 0) return "EXISTE TIPO tinta";
            return PR_aTipoTinta_CD._Instancia.Actualizar_TipoTinta(tipotinta);
        }

        public string Eliminar_TipoTinta(Int32 idtipotinta)
        { return PR_aTipoTinta_CD._Instancia.Eliminar_TipoTinta(idtipotinta); }
    }
}
