using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aArea_CN
    {
        public static readonly PR_aArea_CN _Instancia = new PR_aArea_CN();

        public static PR_aArea_CN Instancia
        { get { return PR_aArea_CN._Instancia; } }

        public List<PR_aArea> Lista_Areas()
        { return PR_aArea_CD._Intancia.Lista_Areas().ToList(); }

        public IEnumerable<PR_aArea> TraerID(byte idarea)
        { return PR_aArea_CD._Intancia.Traer_AreaPorId(idarea); }

        public IEnumerable<PR_aArea> Buscar_Nombre(string nombre_area)
        {
            var lst = PR_aArea_CD._Intancia.Lista_Areas().ToList();
            return from AD in lst where AD.Nombre_Area == nombre_area select AD;
        }

        public string Agregar(PR_aArea area)
        {
            if (Buscar_Nombre(area.Nombre_Area).Count() > 0) return "Existe un Area Registrado";
            return PR_aArea_CD._Intancia.Agregar_Area(area);
        }

        public string Actualizar(PR_aArea area)
        {
            if (Buscar_Nombre(area.Nombre_Area).Count() > 0) return "Existe Adhesivo Registrado";
            return PR_aArea_CD._Intancia.Actualizar_Area(area);
        }

        public string Eliminar(Int32 idarea)
        { return PR_aArea_CD._Intancia.Eliminar_Area(idarea); }
    }
}
