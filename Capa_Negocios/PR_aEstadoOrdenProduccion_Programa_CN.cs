using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aEstadoOrdenProduccion_Programa_CN
    {
        public static readonly PR_aEstadoOrdenProduccion_Programa_CN _Instancia = new PR_aEstadoOrdenProduccion_Programa_CN();

        public static PR_aEstadoOrdenProduccion_Programa_CN Instancia
        { get { return PR_aEstadoOrdenProduccion_Programa_CN._Instancia; } }

        public List<PR_aEstadoOrdenProduccion_Programa> Lista_Estado_OP()
        { return PR_aEstadoOrdenProduccion_Programa_CD._Instancia.Lista_EstadoOrenProduccion_Programa().ToList(); }

        public IEnumerable<PR_aEstadoOrdenProduccion_Programa> TraerPorID(byte id)
        { return PR_aEstadoOrdenProduccion_Programa_CD._Instancia.Traer_EstadoOrdenProduccionPorId(id); }

        public IEnumerable<PR_aEstadoOrdenProduccion_Programa> Buscar_EstadoOPproframa(string descripcionop)
        {
            var lst = PR_aEstadoOrdenProduccion_Programa_CD._Instancia.Lista_EstadoOrenProduccion_Programa().ToList();
            return from AD in lst where AD.EstadoOrdenProduccion_Programa == descripcionop select AD;
        }

        public string Agregar_EstadoOPPrograma(PR_aEstadoOrdenProduccion_Programa estadoOPprograma)
        {
            if (Buscar_EstadoOPproframa(estadoOPprograma.EstadoOrdenProduccion_Programa).Count() > 0) return "Existe un Estado OP Programa Registrado";
            return PR_aEstadoOrdenProduccion_Programa_CD._Instancia.Agregar_EstadoOrdenProduccion_Programa(estadoOPprograma);
        }

        public string Actualizar_EstadoOPPrograma(PR_aEstadoOrdenProduccion_Programa estadoOPprograma)
        {
            if (Buscar_EstadoOPproframa(estadoOPprograma.EstadoOrdenProduccion_Programa).Count() > 0) return "Existe un Estado OP Programa Registrado";
            return PR_aEstadoOrdenProduccion_Programa_CD._Instancia.Actualizar_EstadoOrdenProduccion_Programa(estadoOPprograma);
        }

        public string Eliminar_EstadoOPPrograma(Int32 idestadoopPrograma)
        { return PR_aEstadoOrdenProduccion_Programa_CD._Instancia.Eliminar_EstadoOrdenProduccion_Programa(idestadoopPrograma); }
    }
}
