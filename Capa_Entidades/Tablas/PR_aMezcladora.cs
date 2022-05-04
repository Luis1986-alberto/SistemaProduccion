using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aMezcladora
    {
        private byte _IdMezcladora;
        private string _Nombre_Mezcladora;
        private decimal _Capacidad_Mezcladora;

        public byte IdMezcladora { get => _IdMezcladora; set => _IdMezcladora = value; }
        public string Nombre_Mezcladora { get => _Nombre_Mezcladora; set => _Nombre_Mezcladora = value; }
        public decimal Capacidad_Mezcladora { get => _Capacidad_Mezcladora; set => _Capacidad_Mezcladora = value; }

        public PR_aMezcladora()
        { }

        public PR_aMezcladora(byte idMezcladora, string nombre_Mezcladora, decimal capacidad_Mezcladora)
        {
            _IdMezcladora = idMezcladora;
            _Nombre_Mezcladora = nombre_Mezcladora;
            _Capacidad_Mezcladora = capacidad_Mezcladora;
        }
    }
}
