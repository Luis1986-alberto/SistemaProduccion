using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aEstadoCalificacion_CC
    {
        private byte _IdEstadoCalificacion_CC;
        private string _Nombre_EstadoCaficacion_CC;

        public byte IdEstadoCalificacion_CC { get => _IdEstadoCalificacion_CC; set => _IdEstadoCalificacion_CC = value; }
        public string Nombre_EstadoCaficacion_CC { get => _Nombre_EstadoCaficacion_CC; set => _Nombre_EstadoCaficacion_CC = value; }

        public PR_aEstadoCalificacion_CC()
        { }

        public PR_aEstadoCalificacion_CC(byte idEstadoCalificacion_CC, string nombre_EstadoCaficacion_CC)
        {
            _IdEstadoCalificacion_CC = idEstadoCalificacion_CC;
            _Nombre_EstadoCaficacion_CC = nombre_EstadoCaficacion_CC;
        }
    }
}
