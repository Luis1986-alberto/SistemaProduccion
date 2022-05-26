using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xEstructuraCodBar
    {
        public short IdEstructuraCodBar { get; set; }
        public Nullable<decimal> IdCliente { get; set; }
        public string Estructura_CodBar { get; set; }

        public virtual PR_mClientes PR_mClientes { get; set; }

    }
}
