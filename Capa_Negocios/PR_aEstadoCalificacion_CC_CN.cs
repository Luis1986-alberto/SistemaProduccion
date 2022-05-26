using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aEstadoCalificacion_CC_CN
    {
        public static readonly PR_aEstadoCalificacion_CC_CN _Instancia = new PR_aEstadoCalificacion_CC_CN();

        public static PR_aEstadoCalificacion_CC_CN Instancia
        { get { return PR_aEstadoCalificacion_CC_CN._Instancia; } }

        public List<PR_aEstadoCalificacion_CC> Lista_EstadoCalificacion_CC()
        { return PR_aEstadoCalificacion_CC_CD._Instancia.Lista_EstadoCalñificacion_CC().ToList(); }

        public IEnumerable<PR_aEstadoCalificacion_CC> TraerPorID(byte id)
        { return PR_aEstadoCalificacion_CC_CD._Instancia.Traer_EstadoCalificacionPorId(id); }

        public IEnumerable<PR_aEstadoCalificacion_CC> Buscar_nombreestado(string nombreestadocalif)
        {
            var lst = PR_aEstadoCalificacion_CC_CD._Instancia.Lista_EstadoCalñificacion_CC().ToList();
            return from AD in lst where AD.Nombre_EstadoCaficacion_CC == nombreestadocalif select AD;
        }

        public string Agregar_EstadoCalificacionCC(PR_aEstadoCalificacion_CC estadocalificacioncc)
        {
            if (Buscar_nombreestado(estadocalificacioncc.Nombre_EstadoCaficacion_CC).Count() > 0) return "Existe un estado calificacion Registrado";
            return PR_aEstadoCalificacion_CC_CD._Instancia.Agregar_EstadoCalificacion(estadocalificacioncc);
        }

        public string Actualizar_EstadoCalificacionCC(PR_aEstadoCalificacion_CC estadocalificacioncc)
        {
            if (Buscar_nombreestado(estadocalificacioncc.Nombre_EstadoCaficacion_CC).Count() > 0) return "Existe un  estado calificacion Registrado";
            return PR_aEstadoCalificacion_CC_CD._Instancia.Actualizar_EstadoCalificacion(estadocalificacioncc);
        }

        public string Eliminar_EstadoCalificacionCC(Int32 IestadoCal)
        { return PR_aEstadoCalificacion_CC_CD._Instancia.Eliminar_EstadoCalificacion(IestadoCal); }


    }
}
