using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aAdhesivo
    {
        private byte _IdAdhesivo;
        private string _Descripcion_Adhesivo;

        public byte IdAdhesivo { get => _IdAdhesivo; set => _IdAdhesivo = value; }
        public string Descripcion_Adhesivo { get => _Descripcion_Adhesivo; set => _Descripcion_Adhesivo = value; }

        public PR_aAdhesivo()
        { }

        public PR_aAdhesivo(byte idAdhesivo, string descripcion_Adhesivo)
        {
            _IdAdhesivo = idAdhesivo;
            _Descripcion_Adhesivo = descripcion_Adhesivo;
        }

    }
}
