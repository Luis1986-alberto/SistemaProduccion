using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aArea
    {
        private byte _IdArea;
        private string _Nombre_Area;

        public byte IdArea { get => _IdArea; set => _IdArea = value; }
        public string Nombre_Area { get => _Nombre_Area; set => _Nombre_Area = value; }

        public PR_aArea()
        { }

        public PR_aArea(byte idArea, string nombre_Area)
        {
            IdArea = idArea;
            Nombre_Area = nombre_Area;
        }

    }
}
