using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aPrecisionBalanza
    {
        private byte _IdPrecisionBalanza;
        private decimal _Precision_Balanza;

        public byte IdPrecisionBalanza { get => _IdPrecisionBalanza; set => _IdPrecisionBalanza = value; }
        public decimal Precision_Balanza { get => _Precision_Balanza; set => _Precision_Balanza = value; }

        public PR_aPrecisionBalanza()
        { }

        public PR_aPrecisionBalanza(byte idPrecisionBalanza, decimal precision_Balanza)
        {
            _IdPrecisionBalanza = idPrecisionBalanza;
            _Precision_Balanza = precision_Balanza;
        }

    }
}
