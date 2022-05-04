using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoTroquel_CN
    {
        public static readonly PR_aTipoTroquel_CN _Instancia = new PR_aTipoTroquel_CN();

        public static PR_aTipoTroquel_CN Instancia
        { get { return PR_aTipoTroquel_CN._Instancia; } }

        public List<PR_aTipoTroquel> Lista_TipoTroquel()
        { return PR_aTipoTroquel_CD._Instancia.Lista_TipoTroquel().ToList(); }

        public IEnumerable<PR_aTipoTroquel> TraerPorID(Int32 id)
        { return PR_aTipoTroquel_CD._Instancia.Traer_TipoTroquelId(id); }

        public IEnumerable<PR_aTipoTroquel> Buscar_TipoTroquel(string desctipotroquel)
        {
            var lista = PR_aTipoTroquel_CD._Instancia.Lista_TipoTroquel().ToList();
            return from buscar in lista where buscar.Descripcion_TipoTroquel == desctipotroquel select buscar;
        }

        public string Agregar_Tipotroquel(PR_aTipoTroquel tipotroquel)
        {
            if (Buscar_TipoTroquel(tipotroquel.Descripcion_TipoTroquel).Count() > 0) return "EXISTE TIPO TROQUEL";
            return PR_aTipoTroquel_CD._Instancia.Agregar_TipoTroquel(tipotroquel);
        }

        public string Actualizar_TipoTroquel(PR_aTipoTroquel tipotroquel)
        {
            if (Buscar_TipoTroquel(tipotroquel.Descripcion_TipoTroquel).Count() > 0) return "EXISTE TIPO TROQUEL";
            return PR_aTipoTroquel_CD._Instancia.Actualizar_TipoTroquel(tipotroquel);
        }

        public string Eliminar_TipoTroquel(Int32 idtipotroquel)
        { return PR_aTipoTroquel_CD._Instancia.Eliminar_TipoTroquel(idtipotroquel); }


    }
}
