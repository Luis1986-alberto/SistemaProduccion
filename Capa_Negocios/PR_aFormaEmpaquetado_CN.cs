using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aFormaEmpaquetado_CN
    {
        public static readonly PR_aFormaEmpaquetado_CN _Instancia = new PR_aFormaEmpaquetado_CN();

        public static PR_aFormaEmpaquetado_CN Instancia
        { get { return PR_aFormaEmpaquetado_CN._Instancia; } }

        public List<PR_aFormaEmpaquetado> Lista_FormaEmpaquetado()
        { return PR_aFormaEmpaquetado_CD._Instancia.Lista_FormaEmpaquetado().ToList(); }

        public IEnumerable<PR_aFormaEmpaquetado> TraerPorID(Int32 id)
        { return PR_aFormaEmpaquetado_CD._Instancia.Traer_FormaEmpaquetadoPorId(id); }
        public IEnumerable<PR_aFormaEmpaquetado> Buscar_DetalleEmpaquetado(string detalleempaquetado)
        {
            var lista = PR_aFormaEmpaquetado_CD._Instancia.Lista_FormaEmpaquetado().ToList();
            return from buscar in lista where buscar.Detalle_Empaquetado == detalleempaquetado select buscar;
        }

        public string Agregar_FormaEmpaquetado(PR_aFormaEmpaquetado formaempaquetado)
        {
            if (Buscar_DetalleEmpaquetado(formaempaquetado.Detalle_Empaquetado).Count() > 0) return "Existe una forma Empaquetado Registrado";
            return PR_aFormaEmpaquetado_CD._Instancia.Agregar_FormaEmpaquetado(formaempaquetado);
        }

        public string Actualizar_EstadoOP(PR_aFormaEmpaquetado formaempaquetado)
        {
            if (Buscar_DetalleEmpaquetado(formaempaquetado.Detalle_Empaquetado).Count() > 0) return "Existe una forma Empaquetado Registrado";
            return PR_aFormaEmpaquetado_CD._Instancia.Actualizar_FormaEmpaquetado(formaempaquetado);
        }

        public string Eliminar_Estado(Int32 idempaquetado)
        { return PR_aFormaEmpaquetado_CD._Instancia.Eliminar_FormaEmpaquetado(idempaquetado); }


    }
}
