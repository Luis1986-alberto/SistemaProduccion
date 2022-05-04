using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aEmpaquetado_CN
    {
        public static readonly PR_aEmpaquetado_CN _Instancia = new PR_aEmpaquetado_CN();

        public static PR_aEmpaquetado_CN Instancia
        { get { return PR_aEmpaquetado_CN._Instancia; } }

        public List<PR_aEmpaquetado> Lista_Empaquetado()
        { return PR_aEmpaquetado_CD._Instancia.Lista_Empaquetado().ToList(); }

        public IEnumerable<PR_aEmpaquetado> TraerPorID(byte id)
        { return PR_aEmpaquetado_CD._Instancia.Traer_EmpaquetadoPorId(id); }

        public IEnumerable<PR_aEmpaquetado> Buscar_Descripcion(string descripcion)
        {
            var lst = PR_aEmpaquetado_CD._Instancia.Lista_Empaquetado().ToList();
            return from AD in lst where AD.Descripcion == descripcion select AD;
        }

        public string Agregar_Empaquetado(PR_aEmpaquetado empaquetado)
        {
            if (Buscar_Descripcion(empaquetado.Descripcion).Count() > 0) return "Existe un Empaquetado Registrado";
            return PR_aEmpaquetado_CD._Instancia.Agregar_Empaquetado(empaquetado);
        }

        public string Actualizar_Empaquetado(PR_aEmpaquetado empaquetado)
        {
            if (Buscar_Descripcion(empaquetado.Descripcion).Count() > 0) return "Existe Empaquetado Registrado";
            return PR_aEmpaquetado_CD._Instancia.Actualizar_Empaquetado(empaquetado);
        }

        public string Eliminar_Empaquetado(Int32 idDerivadocolor)
        { return PR_aEmpaquetado_CD._Instancia.Eliminar_Empaquetador(idDerivadocolor); }
    }
}
