using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aPeriodo
    {
        private byte _IdPeriodo;
        private string _Nombre_Periodo;
        private string _Flag_Activo;

        public byte IdPeriodo { get => _IdPeriodo; set => _IdPeriodo = value; }
        public string Nombre_Periodo { get => _Nombre_Periodo; set => _Nombre_Periodo = value; }
        public string Flag_Activo { get => _Flag_Activo; set => _Flag_Activo = value; }

        public PR_aPeriodo()
        { }

        public PR_aPeriodo(byte idPeriodo, string nombre_Periodo, string flag_Activo)
        {
            _IdPeriodo = idPeriodo;
            _Nombre_Periodo = nombre_Periodo;
            _Flag_Activo = flag_Activo;
        }

    }
}
