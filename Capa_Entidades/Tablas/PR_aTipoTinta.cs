using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aTipoTinta
    {
        private byte _IdTipoTinta;
        private string _Descripcion_TipoTinta;

        public byte IdTipoTinta { get => _IdTipoTinta; set => _IdTipoTinta = value; }
        public string Descripcion_TipoTinta { get => _Descripcion_TipoTinta; set => _Descripcion_TipoTinta = value; }

        public PR_aTipoTinta()
        { }

        public PR_aTipoTinta(byte idTipoTinta, string descripcion_TipoTinta)
        {
            _IdTipoTinta = idTipoTinta;
            _Descripcion_TipoTinta = descripcion_TipoTinta;
        }

    }
}
