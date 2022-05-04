using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aLineaColor
    {
        private byte _IdLineaColor;
        private string _Nombre_LineaColor;

        public byte IdLineaColor { get => _IdLineaColor; set => _IdLineaColor = value; }
        public string Nombre_LineaColor { get => _Nombre_LineaColor; set => _Nombre_LineaColor = value; }
        
        public PR_aLineaColor()
        { }

        public PR_aLineaColor(byte idLineaColor, string nombre_LineaColor)
        {
            _IdLineaColor = idLineaColor;
            _Nombre_LineaColor = nombre_LineaColor;
        }

    }
}
