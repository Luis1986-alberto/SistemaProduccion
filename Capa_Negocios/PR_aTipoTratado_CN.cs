using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoTratado_CN
    {
        public static readonly PR_aTipoTratado_CN _Instancia = new PR_aTipoTratado_CN();

        public static PR_aTipoTratado_CN Instancia
        { get { return PR_aTipoTratado_CN._Instancia; } }

        public List<PR_aTipoTratado> Lista_TipoTratado()
        { return PR_aTipoTratado_CD._Instancia.Lista_TipoTratado().ToList(); }

        public IEnumerable<PR_aTipoTratado> TraerPorID(Int32 id)
        { return PR_aTipoTratado_CD._Instancia.Lista_TipoTratadoPorId(id); }

        public IEnumerable<PR_aTipoTratado> Buscar_TipoTratado(string tipotratado)
        {
            var LST = PR_aTipoTratado_CD._Instancia.Lista_TipoTratado().ToList();
            return from buscar in LST where buscar.Tipo_Tratado == tipotratado select buscar; 
        }

        public string Agregar_TipoTratado(PR_aTipoTratado tipotratado)
        {
            if (Buscar_TipoTratado(tipotratado.Tipo_Tratado).Count() > 0) return "EXISTE TIPO TRATADO";
            return PR_aTipoTratado_CD._Instancia.Agregar_TipoTratado(tipotratado);
        }

        public string Actualizar_TipoTratado(PR_aTipoTratado tipotratado)
        {
            if (Buscar_TipoTratado(tipotratado.Tipo_Tratado).Count() > 0) return "EXISTE TIPO TRATADO";
            return PR_aTipoTratado_CD._Instancia.Actualizar_TipoTratado(tipotratado);
        }

        public string Eliminar_TipoTratado(Int32 idtipotratado)
        { return PR_aTipoTratado_CD._Instancia.Eliminar_TipoTratado(idtipotratado); }


    }
}
