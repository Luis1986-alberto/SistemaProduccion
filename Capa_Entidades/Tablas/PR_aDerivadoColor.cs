using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aDerivadoColor
    {
        private Int32 _IdDerivadoColor;
        private string _Nombre_DerivadoColor;
        private string _Codigo_DerivadoColor;

        public int IdDerivadoColor { get => _IdDerivadoColor; set => _IdDerivadoColor = value; }
        public string Nombre_DerivadoColor { get => _Nombre_DerivadoColor; set => _Nombre_DerivadoColor = value; }
        public string Codigo_DerivadoColor { get => _Codigo_DerivadoColor; set => _Codigo_DerivadoColor = value; }

        public PR_aDerivadoColor()
        { }

        public PR_aDerivadoColor(int idDerivadoColor, string nombre_DerivadoColor, string codigo_DerivadoColor)
        {
            _IdDerivadoColor = idDerivadoColor;
            _Nombre_DerivadoColor = nombre_DerivadoColor;
            _Codigo_DerivadoColor = codigo_DerivadoColor;
        }

    }
}
