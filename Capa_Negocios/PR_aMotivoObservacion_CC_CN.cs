using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aMotivoObservacion_CC_CN
    {
        public static readonly PR_aMotivoObservacion_CC_CN _Instancia = new PR_aMotivoObservacion_CC_CN();

        public static PR_aMotivoObservacion_CC_CN Instancia
        { get { return PR_aMotivoObservacion_CC_CN._Instancia; } }

        public List<PR_aMotivoObservacion_CC> Lista_MotivoObservacion()
        { return PR_aMotivoObservacion_CC_CD._Instancia.Lista_MotivoObservacion().ToList(); }

        public IEnumerable<PR_aMotivoObservacion_CC> TraerPorID(Int32 id)
        { return PR_aMotivoObservacion_CC_CD._Instancia.Traer_MotivoObservacionPorId(id); }

        public IEnumerable<PR_aMotivoObservacion_CC> Buscar_Motivoobs(string motivoobs)
        {
            var lista = PR_aMotivoObservacion_CC_CD._Instancia.Lista_MotivoObservacion().ToList();
            return from buscar in lista where buscar.Motivo_Observacion_CC == motivoobs select buscar;
        }

        public string Agregar_MotivoObservacion(PR_aMotivoObservacion_CC motivoobservacion)
        {
            if (Buscar_Motivoobs(motivoobservacion.Motivo_Observacion_CC).Count() > 0) return "Existe una Motivo Registrado";
            return PR_aMotivoObservacion_CC_CD._Instancia.Agregar_MotivoObservacion_CC(motivoobservacion);
        }

        public string Actualizar_MotivoObservacion(PR_aMotivoObservacion_CC motivoobservacion)
        {
            if (Buscar_Motivoobs(motivoobservacion.Motivo_Observacion_CC).Count() > 0) return "Existe una Motivo Registrado";
            return PR_aMotivoObservacion_CC_CD._Instancia.Actualizar_MotivoObservacion_CC(motivoobservacion);
        }

        public string Eliminar_MotivoObservacion(Int32 idmotivoobs)
        { return PR_aMotivoObservacion_CC_CD._Instancia.Eliminar_MotivoObservacion_CC(idmotivoobs); }

    }
}
