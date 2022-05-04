using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aEtiqueta
    {
        private byte _IdEtiqueta;
        private string _Descripcion;
        private byte _Orden_Sistemas;

        public byte IdEtiqueta { get => _IdEtiqueta; set => _IdEtiqueta = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public byte Orden_Sistemas { get => _Orden_Sistemas; set => _Orden_Sistemas = value; }

        public PR_aEtiqueta()
        { }

        public PR_aEtiqueta(byte idEtiqueta, string descripcion, byte orden_Sistemas)
        {
            _IdEtiqueta = idEtiqueta;
            _Descripcion = descripcion;
            _Orden_Sistemas = orden_Sistemas;
        }

    }
}
