using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class MP_aBanco
    {
        public byte IdBanco { get; set; }
        public string Nombre_Banco { get; set; }
        public string Abreviatura_Banco { get; set; }

        public MP_aBanco()
        {   }

        public MP_aBanco(byte idBanco, string nombre_Banco, string abreviatura_Banco)
        {
            IdBanco = idBanco;
            Nombre_Banco = nombre_Banco;
            Abreviatura_Banco = abreviatura_Banco;
        }
    }
}
