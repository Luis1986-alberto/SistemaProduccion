using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aTipoProcesoCorte
    {
        private byte _IdTipoProcesoCorte;
        private string _Nombre_TipoProcesoCorte;

        public byte IdTipoProcesoCorte { get => _IdTipoProcesoCorte; set => _IdTipoProcesoCorte = value; }
        public string Nombre_TipoProcesoCorte { get => _Nombre_TipoProcesoCorte; set => _Nombre_TipoProcesoCorte = value; }

        public PR_aTipoProcesoCorte()
        { }

        public PR_aTipoProcesoCorte(byte idTipoProcesoCorte, string nombre_TipoProcesoCorte)
        {
            _IdTipoProcesoCorte = idTipoProcesoCorte;
            _Nombre_TipoProcesoCorte = nombre_TipoProcesoCorte;
        }
    }
}
