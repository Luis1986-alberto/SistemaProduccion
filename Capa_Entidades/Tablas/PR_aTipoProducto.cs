using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aTipoProducto
    {
        private byte _IdTipoProducto;
        private string _Nombre_TipoProducto;

        public byte IdTipoProducto { get => _IdTipoProducto; set => _IdTipoProducto = value; }
        public string Nombre_TipoProducto { get => _Nombre_TipoProducto; set => _Nombre_TipoProducto = value; }

        public PR_aTipoProducto()
        { }

        public PR_aTipoProducto(byte idTipoProducto, string nombre_TipoProducto)
        {
            _IdTipoProducto = idTipoProducto;
            _Nombre_TipoProducto = nombre_TipoProducto;
        }


    }
}
