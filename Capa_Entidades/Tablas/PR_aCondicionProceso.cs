using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aCondicionProceso
    {
        private byte _IdCondicionProceso;
        private string _Nombre_CondicionProceso;

        public byte IdCondicionProceso { get => _IdCondicionProceso; set => _IdCondicionProceso = value; }
        public string Nombre_CondicionProceso { get => _Nombre_CondicionProceso; set => _Nombre_CondicionProceso = value; }

        public PR_aCondicionProceso()
        { }

        public PR_aCondicionProceso(byte idCondicionProceso, string nombre_CondicionProceso)
        {
            _IdCondicionProceso = idCondicionProceso;
            _Nombre_CondicionProceso = nombre_CondicionProceso;
        }

    }
}
