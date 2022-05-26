using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xAvanceCalidad
    {
        public string Observacion_Ext { get; set; }
        public string Observacion_Sel { get; set; }
        public string Observacion_Imp { get; set; }
        public string Observacion_Cor { get; set; }
        public string Observacion_Lam { get; set; }
        public string Observacion_Alm { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuario_PC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }

    }
}
