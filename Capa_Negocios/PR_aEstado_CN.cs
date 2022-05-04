using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aEstado_CN
    {
        public static readonly PR_aEstado_CN _Instancia = new PR_aEstado_CN();

        public static PR_aEstado_CN Instancia
        { get { return PR_aEstado_CN._Instancia; } }

        public List<PR_aEstado> Lista_Estado()
        { return PR_aEstado_CD._Instancia.Lista_Estado().ToList(); }

        public IEnumerable<PR_aEstado> TraerPorID(byte id)
        { return PR_aEstado_CD._Instancia.Traer_EstadoPorId(id); }

        public IEnumerable<PR_aEstado> Buscar_NombreEstado(string nombreestado)
        {
            var lst = PR_aEstado_CD._Instancia.Lista_Estado().ToList();
            return from AD in lst where AD.Nombre_Estado == nombreestado select AD;
        }

        public string Agregar(PR_aEstado estado)
        {
            if (Buscar_NombreEstado(estado.Nombre_Estado).Count() > 0) return "Existe un Estado Registrado";
            return PR_aEstado_CD._Instancia.Agregar_Estado(estado);
        }

        public string Actualizar(PR_aEstado estado)
        {
            if (Buscar_NombreEstado(estado.Nombre_Estado).Count() > 0) return "Existe un Estado Registrado";
            return PR_aEstado_CD._Instancia.Actualizar_Estado(estado);
        }

        public string Eliminar(Int32 idestado)
        { return PR_aEstado_CD._Instancia.Eliminar_Estado(idestado); }

    }
}
