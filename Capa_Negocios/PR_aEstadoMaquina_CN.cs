using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aEstadoMaquina_CN
    {
        public static readonly PR_aEstadoMaquina_CN _Instancia = new PR_aEstadoMaquina_CN();

        public static PR_aEstadoMaquina_CN Instancia
        { get { return PR_aEstadoMaquina_CN._Instancia; } }

        public List<PR_aEstadoMaquina> Lista_EstadoMaquina()
        { return PR_aEstadoMaquina_CD._Instancia.Lista_EstadoMaquina().ToList(); }

        public IEnumerable<PR_aEstadoMaquina> TraerPorID(byte id)
        { return PR_aEstadoMaquina_CD._Instancia.Traer_EstadoMaquinaPorId(id); }

        public IEnumerable<PR_aEstadoMaquina> Buscar_NombreEstado(string nombreestado)
        {
            var lst = PR_aEstadoMaquina_CD._Instancia.Lista_EstadoMaquina().ToList();
            return from AD in lst where AD.Nombre_Estado == nombreestado select AD;
        }

        public string Agregar_EstadoMaquina(PR_aEstadoMaquina estadomaquina)
        {
            if (Buscar_NombreEstado(estadomaquina.Nombre_Estado).Count() > 0) return "Existe un Estado Maquina Registrado";
            return PR_aEstadoMaquina_CD._Instancia.Agregar_EstadoMaquina(estadomaquina);
        }

        public string Actualizar_EstadoMaquina(PR_aEstadoMaquina estadomaquina)
        {
            if (Buscar_NombreEstado(estadomaquina.Nombre_Estado).Count() > 0) return "Existe un Estado Maquina Registrado";
            return PR_aEstadoMaquina_CD._Instancia.Actualizar_EstadoMaquina(estadomaquina);
        }

        public string Eliminar_EstadoMaquina(Int32 idestadomaq)
        { return PR_aEstadoMaquina_CD._Instancia.Eliminar_EstadoMaquina(idestadomaq); }
    }
}
