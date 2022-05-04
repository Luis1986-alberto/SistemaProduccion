using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoTrabajador_CN
    {
        public static readonly PR_aTipoTrabajador_CN _Instancia = new PR_aTipoTrabajador_CN();

        public static PR_aTipoTrabajador_CN Instancia
        { get { return PR_aTipoTrabajador_CN._Instancia; } }

        public List<PR_aTipoTrabajador> Lista_TipoTrabajador()
        { return PR_aTipoTrabajador_CD._Instancia.Lista_TipoTrabajador().ToList(); }

        public IEnumerable<PR_aTipoTrabajador> TraerPorID(Int32 id)
        { return PR_aTipoTrabajador_CD._Instancia.Traer_TipoTrabajadorPorId(id); }

        public IEnumerable<PR_aTipoTrabajador> Buscar_NombreTipoTrabajador(string tipotrabajador)
        {
            var lista = PR_aTipoTrabajador_CD._Instancia.Lista_TipoTrabajador().ToList();
            return from buscar in lista where buscar.Nombre_TipoTrabajador == tipotrabajador select buscar;
        }

        public string Agregar_TipoTrabajador(PR_aTipoTrabajador tipotrabajador)
        {
            if (Buscar_NombreTipoTrabajador(tipotrabajador.Nombre_TipoTrabajador).Count() > 0) return "EXISTE TIPO TRABAJADOR";
            return PR_aTipoTrabajador_CD._Instancia.Agregar_TipoTrabajador(tipotrabajador);
        }

        public string Actualizar_TipoTrabajador(PR_aTipoTrabajador tipotrabajador)
        {
            if (Buscar_NombreTipoTrabajador(tipotrabajador.Nombre_TipoTrabajador).Count() > 0) return "EXISTE TIPO TRABAJADOR";
            return PR_aTipoTrabajador_CD._Instancia.Actualizar_TipoTrabajador(tipotrabajador);
        }

        public string Eliminar_TipoTrabajador(Int32 idtipotrabajador)
        { return PR_aTipoTrabajador_CD._Instancia.Eliminar_TipoTrabajador(idtipotrabajador); }

    }
}
