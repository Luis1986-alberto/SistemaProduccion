using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aEstadoMaquina
    {
        private byte _IdEstadoMaquina;
        private string _Nombre_Estado;

        public byte IdEstadoMaquina { get => _IdEstadoMaquina; set => _IdEstadoMaquina = value; }
        public string Nombre_Estado { get => _Nombre_Estado; set => _Nombre_Estado = value; }

        public PR_aEstadoMaquina()
        { }

        public PR_aEstadoMaquina(byte idEstadoMaquina, string nombre_Estado)
        {
            _IdEstadoMaquina = idEstadoMaquina;
            _Nombre_Estado = nombre_Estado;
        }
    }
}
