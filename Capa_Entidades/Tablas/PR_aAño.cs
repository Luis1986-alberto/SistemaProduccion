using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aAño
    {
        private byte _IdAño;
        private int _Año;

       
        public byte IdAño { get => _IdAño; set => _IdAño = value; }
        public int Año { get => _Año; set => _Año = value; }

        public PR_aAño()
        { }

        public PR_aAño(byte idAño, int año)
        {
            _IdAño = idAño;
            _Año = año;
        }
    }
}
