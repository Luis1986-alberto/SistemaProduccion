using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aCargoTrabajador_CN
    {
        public static readonly PR_aCargoTrabajador_CN _Instancia = new PR_aCargoTrabajador_CN();

        public static PR_aCargoTrabajador_CN Instancia
        { get { return PR_aCargoTrabajador_CN._Instancia; } }

        public List<PR_aCargoTrabajador> Lista_CargoTrabajador()
        { return PR_aCargoTrabajador_CD._Instancia.Lista_cargotrabajador().ToList(); }

        public IEnumerable<PR_aCargoTrabajador> TraerID(byte idcargotrabajador)
        { return PR_aCargoTrabajador_CD._Instancia.Traer_CargotrabajadorPorId(idcargotrabajador); }

        public IEnumerable<PR_aCargoTrabajador> Buscar_Nombre(string descripcion)
        {
            var lst = PR_aCargoTrabajador_CD._Instancia.Lista_cargotrabajador().ToList();
            return from AD in lst where AD.Nombre_CargoTrabajador == descripcion select AD;
        }

        public string Agregar(PR_aCargoTrabajador cargotrabajador)
        {
            if (Buscar_Nombre(cargotrabajador.Nombre_CargoTrabajador).Count() > 0) return "Existe cargo trabajador Registrado";
            return PR_aCargoTrabajador_CD._Instancia.Agregar_CargoTrabajador(cargotrabajador);
        }

        public string Actualizar(PR_aCargoTrabajador cargotrabajador)
        {
            if (Buscar_Nombre(cargotrabajador.Nombre_CargoTrabajador).Count() > 0) return "Existe cargo trabajador Registrado";
            return PR_aCargoTrabajador_CD._Instancia.Actualizar_CargoTrabajador(cargotrabajador);
        }

        public string Eliminar(Int32 idcargotrabajador)
        { return PR_aCargoTrabajador_CD._Instancia.Eliminar_CargoTrabajador(idcargotrabajador); }
    }
}
