using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aColor_CN
    {
        public static readonly PR_aColor_CN _Instancia = new PR_aColor_CN();

        public static PR_aColor_CN Instancia
        { get { return PR_aColor_CN._Instancia; } }

        public List<PR_aColor> Lista_Color()
        { return PR_aColor_CD._Instancia.Lista_Color().ToList(); }

        public IEnumerable<PR_aColor> TraerID(Int32 idcolor)
        { return PR_aColor_CD._Instancia.Traer_ColorPorId(idcolor); }

        public IEnumerable<PR_aColor> Buscar_NombreColor(string nombrecolor)
        {
            var lst = PR_aColor_CD._Instancia.Lista_Color().ToList();
            return from C in lst where C.Nombre_Color == nombrecolor select C;
        }

        public string Agregar_Color(PR_aColor acolor)
        {
            if (Buscar_NombreColor(acolor.Nombre_Color).Count() > 0) return "Existe Nombre Color Registrado";
            return PR_aColor_CD._Instancia.Agregar_Color(acolor);
        }

        public string Actualizar_Color(PR_aColor acolor)
        {
            if (Buscar_NombreColor(acolor.Nombre_Color).Count() > 0) return "Existe Adhesivo Registrado";
            return PR_aColor_CD._Instancia.Actualizar_Color(acolor);
        }

        public string Eliminar_Color(Int32 idcolor)
        { return PR_aColor_CD._Instancia.Eliminar_Color(idcolor); }
    }
}
