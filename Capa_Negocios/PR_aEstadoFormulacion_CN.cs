using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aEstadoFormulacion_CN
    {
        public static readonly PR_aEstadoFormulacion_CN _Instancia = new PR_aEstadoFormulacion_CN();

        public static PR_aEstadoFormulacion_CN Instancia
        { get { return PR_aEstadoFormulacion_CN._Instancia; } }

        public List<PR_aEstadoFormulacion> Lista_EstadoFormulacion()
        { return PR_aEstadoFormulacion_CD._Instancia.Lista_EstadoFormulacion().ToList(); }

        public IEnumerable<PR_aEstadoFormulacion> TraerPorID(byte id)
        { return PR_aEstadoFormulacion_CD._Instancia.Traer_EstadoFormulacionId(id); }

        public IEnumerable<PR_aEstadoFormulacion> Buscar_nombreestadoFormulacion(string nombreestadoform)
        {
            var lst = PR_aEstadoFormulacion_CD._Instancia.Lista_EstadoFormulacion().ToList();
            return from AD in lst where AD.Nombre_EstadoFormulacion == nombreestadoform select AD;
        }

        public string Agregar_EstadoCalificacion(PR_aEstadoFormulacion estadoformulacion)
        {
            if (Buscar_nombreestadoFormulacion(estadoformulacion.Nombre_EstadoFormulacion).Count() > 0) return "Existe un estado Formulacion Registrado";
            return PR_aEstadoFormulacion_CD._Instancia.Agregar_EstadoFormulacion(estadoformulacion);
        }

        public string Actualizar_EstadoFormulacion(PR_aEstadoFormulacion estadoformulacion)
        {
            if (Buscar_nombreestadoFormulacion(estadoformulacion.Nombre_EstadoFormulacion).Count() > 0) return "Existe un  estado calificacion Registrado";
            return PR_aEstadoFormulacion_CD._Instancia.Actualizar_EstadoFormulacion(estadoformulacion);
        }

        public string Eliminar_EstadoFormulacion(Int32 idestadoform)
        { return PR_aEstadoFormulacion_CD._Instancia.Eliminar_EstadoFormulacion(idestadoform); }


    }
}
