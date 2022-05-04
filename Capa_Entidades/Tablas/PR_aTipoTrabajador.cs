using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aTipoTrabajador
    {
        private byte _IdTipoTrabajador;
        private string _Nombre_TipoTrabajador;

        public byte IdTipoTrabajador { get => _IdTipoTrabajador; set => _IdTipoTrabajador = value; }
        public string Nombre_TipoTrabajador { get => _Nombre_TipoTrabajador; set => _Nombre_TipoTrabajador = value; }

        public PR_aTipoTrabajador()
        { }

        public PR_aTipoTrabajador(byte idTipoTrabajador, string nombre_TipoTrabajador)
        {
            _IdTipoTrabajador = idTipoTrabajador;
            _Nombre_TipoTrabajador = nombre_TipoTrabajador;
        }

    }
}
