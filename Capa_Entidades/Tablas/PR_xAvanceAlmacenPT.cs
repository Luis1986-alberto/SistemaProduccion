using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xAvanceAlmacenPT
    {
        public Nullable<System.DateTime> FechaInicio_APT_CD { get; set; }
        public Nullable<System.DateTime> FechaTermino_APT_CD { get; set; }
        public Nullable<decimal> TotalKilos_APT_CD { get; set; }
        public Nullable<decimal> TotalMillares_APT_CD { get; set; }
        public string Observacion_APT_CD { get; set; }
        public string IdUsuario_APT_CD { get; set; }
        public string IdUsuario_APT_PC_CD { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor_APT_CD { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }

    }
}
