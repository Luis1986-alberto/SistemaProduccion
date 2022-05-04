using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class LG_aMes
    {
        public byte IdMes { get; set; }
        public string Mes { get; set; }

        public LG_aMes()
        {  }

        public LG_aMes(byte idmes, string mes)
        {
            this.IdMes = idmes;
            this.Mes = mes;
        }


    }
}
