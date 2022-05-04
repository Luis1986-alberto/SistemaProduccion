using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aEstado_OP
    {
        private byte _IdEstado_OP;
        private string _Descripcion_EstadoOP;

        public byte IdEstado_OP { get => _IdEstado_OP; set => _IdEstado_OP = value; }
        public string Descripcion_EstadoOP { get => _Descripcion_EstadoOP; set => _Descripcion_EstadoOP = value; }

        public PR_aEstado_OP()
        { }

        public PR_aEstado_OP(byte idEstado_OP, string descripcion_EstadoOP)
        {
            _IdEstado_OP = idEstado_OP;
            _Descripcion_EstadoOP = descripcion_EstadoOP;
        }

    }
}
