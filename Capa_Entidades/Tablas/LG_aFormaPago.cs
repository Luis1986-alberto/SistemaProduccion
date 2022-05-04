using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class LG_aFormaPago
    {
        public byte IdFormaPago { get; set; }
        public string Nombre_FormaPago { get; set; }
        public Int16 Dias { get; set; }

        public LG_aFormaPago()
        {  }

        public LG_aFormaPago(byte idformapago, string nombre_formapago, Int16 dias )
        {
            this.IdFormaPago = idformapago;
            this.Nombre_FormaPago = nombre_formapago;
            this.Dias = dias;
        }

    }
}
