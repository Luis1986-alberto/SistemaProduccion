using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aTipoLaminacion
    {
        private byte _IdTipoLaminado;
        private string _Detalle_Laminacion;
        private string _Nota_Laminacion;

        public byte IdTipoLaminado { get => _IdTipoLaminado; set => _IdTipoLaminado = value; }
        public string Detalle_Laminacion { get => _Detalle_Laminacion; set => _Detalle_Laminacion = value; }
        public string Nota_Laminacion { get => _Nota_Laminacion; set => _Nota_Laminacion = value; }

        public PR_aTipoLaminacion()
        { }

        public PR_aTipoLaminacion(byte idTipoLaminado, string detalle_Laminacion, string nota_Laminacion)
        {
            _IdTipoLaminado = idTipoLaminado;
            _Detalle_Laminacion = detalle_Laminacion;
            _Nota_Laminacion = nota_Laminacion;
        }

    }
}
