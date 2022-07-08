using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aSeVendePor
    {   
        private byte IdSeVendePor { get; set; }
        private string SeVende_Por { get; set; }

        public PR_aSeVendePor()
        {  }

        public PR_aSeVendePor(byte idSeVendePor, string seVende_Por)
        {
            IdSeVendePor = idSeVendePor;
            SeVende_Por = seVende_Por;
        }


    }
}
