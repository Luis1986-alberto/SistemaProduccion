using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aUsoProducto
    {
        private byte _IdUsoProducto;
        private string _Descripcion_UsoProducto;

        public byte IdUsoProducto { get => _IdUsoProducto; set => _IdUsoProducto = value; }
        public string Descripcion_UsoProducto { get => _Descripcion_UsoProducto; set => _Descripcion_UsoProducto = value; }

        public PR_aUsoProducto()
        { }

        public PR_aUsoProducto(byte idUsoProducto, string descripcion_UsoProducto)
        {
            _IdUsoProducto = idUsoProducto;
            _Descripcion_UsoProducto = descripcion_UsoProducto;
        }

    }
}