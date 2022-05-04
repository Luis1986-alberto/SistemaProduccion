using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aAsa
    {
        private byte _IdAsa;
        private string _Descripcion_Asa;

        public byte IdAsa { get => _IdAsa; set => _IdAsa = value; }
        public string Descripcion_Asa { get => _Descripcion_Asa; set => _Descripcion_Asa = value; }

        public PR_aAsa()
        { }

        public PR_aAsa(byte idAsa, string descripcion_Asa)
        {
            IdAsa = idAsa;
            Descripcion_Asa = descripcion_Asa;
        }
    }
}
