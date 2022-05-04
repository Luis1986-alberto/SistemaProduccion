using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aTipoMaterialExtruir
    {
        private byte _IdTipoMaterialExtruir;
        private string _Descripcion_MaterialExtruir;
        private string _Abreviatura;

        public byte IdTipoMaterialExtruir { get => _IdTipoMaterialExtruir; set => _IdTipoMaterialExtruir = value; }
        public string Descripcion_MaterialExtruir { get => _Descripcion_MaterialExtruir; set => _Descripcion_MaterialExtruir = value; }
        public string Abreviatura { get => _Abreviatura; set => _Abreviatura = value; }

        public PR_aTipoMaterialExtruir()
        {   }

        public PR_aTipoMaterialExtruir(byte idTipoMaterialExtruir, string descripcion_MaterialExtruir, string abreviatura)
        {
            _IdTipoMaterialExtruir = idTipoMaterialExtruir;
            _Descripcion_MaterialExtruir = descripcion_MaterialExtruir;
            _Abreviatura = abreviatura;
        }

    }
}
