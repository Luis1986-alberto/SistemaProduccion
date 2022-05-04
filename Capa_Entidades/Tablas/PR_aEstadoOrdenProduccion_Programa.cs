using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aEstadoOrdenProduccion_Programa
    {
        private byte _IdEstadoOrdenProduccion_Programa;
        private string _EstadoOrdenProduccion_Programa;
        private string _Sigla_EstadoOP_Programa;

        public byte IdEstadoOrdenProduccion_Programa { get => _IdEstadoOrdenProduccion_Programa; set => _IdEstadoOrdenProduccion_Programa = value; }
        public string EstadoOrdenProduccion_Programa { get => _EstadoOrdenProduccion_Programa; set => _EstadoOrdenProduccion_Programa = value; }
        public string Sigla_EstadoOP_Programa { get => _Sigla_EstadoOP_Programa; set => _Sigla_EstadoOP_Programa = value; }

        public PR_aEstadoOrdenProduccion_Programa()
        {  }

        public PR_aEstadoOrdenProduccion_Programa(byte idEstadoOrdenProduccion_Programa, string estadoOrdenProduccion_Programa, string sigla_EstadoOP_Programa)
        {
            _IdEstadoOrdenProduccion_Programa = idEstadoOrdenProduccion_Programa;
            _EstadoOrdenProduccion_Programa = estadoOrdenProduccion_Programa;
            _Sigla_EstadoOP_Programa = sigla_EstadoOP_Programa;
        }

    }
}
