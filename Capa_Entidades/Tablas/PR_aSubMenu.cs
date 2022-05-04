using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aSubMenu
    {
        private Int32 _IdSubMenu;
        private string _Detalle_SubMenu;
        private string _SubMenu;
        private string _Orden_SubMenu;

        public int IdSubMenu { get => _IdSubMenu; set => _IdSubMenu = value; }
        public string Detalle_SubMenu { get => _Detalle_SubMenu; set => _Detalle_SubMenu = value; }
        public string SubMenu { get => _SubMenu; set => _SubMenu = value; }
        public string Orden_SubMenu { get => _Orden_SubMenu; set => _Orden_SubMenu = value; }

        public PR_aSubMenu()
        {   }

        public PR_aSubMenu(int idSubMenu, string detalle_SubMenu, string subMenu, string orden_SubMenu)
        {
            _IdSubMenu = idSubMenu;
            _Detalle_SubMenu = detalle_SubMenu;
            _SubMenu = subMenu;
            _Orden_SubMenu = orden_SubMenu;
        }

    }
}
