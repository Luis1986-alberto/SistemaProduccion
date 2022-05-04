using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aMedidas_Produccion
    {
        private Int32 _IdMedidaProd;
        private string _Descripcion_Medida;
        private short _Orden_Medida;

        public int IdMedidaProd { get => _IdMedidaProd; set => _IdMedidaProd = value; }
        public string Descripcion_Medida { get => _Descripcion_Medida; set => _Descripcion_Medida = value; }
        public short Orden_Medida { get => _Orden_Medida; set => _Orden_Medida = value; }

        public PR_aMedidas_Produccion()
        { }

        public PR_aMedidas_Produccion(int idMedidaProd, string descripcion_Medida, short orden_Medida)
        {
            _IdMedidaProd = idMedidaProd;
            _Descripcion_Medida = descripcion_Medida;
            _Orden_Medida = orden_Medida;
        }

    }
}
