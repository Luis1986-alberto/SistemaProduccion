using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aCargoTrabajador
    {
        private byte _IdCargoTrabajador;
        private string _Nombre_CargoTrabajador;

        public byte IdCargoTrabajador { get => _IdCargoTrabajador; set => _IdCargoTrabajador = value; }
        public string Nombre_CargoTrabajador { get => _Nombre_CargoTrabajador; set => _Nombre_CargoTrabajador = value; }

        public PR_aCargoTrabajador()
        { }

        public PR_aCargoTrabajador(byte idCargoTrabajador, string nombre_CargoTrabajador)
        {
            _IdCargoTrabajador = idCargoTrabajador;
            _Nombre_CargoTrabajador = nombre_CargoTrabajador;
        }

    }
}
