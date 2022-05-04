using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aFormaEmpaquetado
    {
        private byte _IdFormaEmpaquetado;
        private string _Detalle_Empaquetado;

        public byte IdFormaEmpaquetado { get => _IdFormaEmpaquetado; set => _IdFormaEmpaquetado = value; }
        public string Detalle_Empaquetado { get => _Detalle_Empaquetado; set => _Detalle_Empaquetado = value; }

        public PR_aFormaEmpaquetado()
        { }

        public PR_aFormaEmpaquetado(byte idFormaEmpaquetado, string detalle_Empaquetado)
        {
            _IdFormaEmpaquetado = idFormaEmpaquetado;
            _Detalle_Empaquetado = detalle_Empaquetado;
        }

    }
}
