using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xProgramaImpresionInd
    {
        public decimal IdProgImpresionInd { get; set; }
        public Nullable<short> IdMaquina { get; set; }
        public Nullable<byte> Prioridad { get; set; }
        public Nullable<System.DateTime> Fecha_Programada { get; set; }
        public string IdUsuario { get; set; }
        public string Codigo_Maquina { get; set; }
        public Nullable<short> IdPosicionMaquina { get; set; }
        public string Alias_Maquina { get; set; }
        public string Flag_Grabado_Servicio { get; set; }
        public string Flag_Servicio { get; set; }
        public Nullable<byte> IdEmpresa_Imp { get; set; }
        public Nullable<decimal> Numero_Servicio_Imp { get; set; }
        public string IdOrdenProduccionInd_Serv { get; set; }
        public Nullable<short> Flag_AnuladoProceso { get; set; }
        public string IdUsuario_CC { get; set; }
        public string IdUsuario_PC_CC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor_CC { get; set; }
        public Nullable<byte> Prioridad_GE { get; set; }
        public Nullable<decimal> Dias_Procesados { get; set; }
        public Nullable<decimal> IdOrdProd { get; set; }
        public Nullable<byte> IdSemana { get; set; }
        public string IdOrdenProduccionInd { get; set; }
        public Nullable<byte> IdEstadoOrdenProduccion_Programa { get; set; }
        public Nullable<short> Flag_Entrega_OP_PCP { get; set; }
        public Nullable<System.DateTime> Fecha_Entrega_OP_PCP { get; set; }

        public virtual PR_aEstadoOrdenProduccion_Programa PR_aEstadoOrdenProduccion_Programa { get; set; }
        public virtual PR_aSemana PR_aSemana { get; set; }
        public virtual PR_mMaquina PR_mMaquina { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
        public virtual PR_xPosicionMaquina PR_xPosicionMaquina { get; set; }
    }
}
