using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mStockProdComercial
    {
        public decimal IdStockProdComercial { get; set; }
        public Nullable<decimal> IdGProdProplast { get; set; }
        public Nullable<decimal> Numero_Bobina_FardoCajaPqte { get; set; }
        public Nullable<decimal> Cantidad_Kilos_Saldo { get; set; }
        public Nullable<decimal> Cantidad_Millares_Saldo { get; set; }
        public Nullable<byte> IdFormaEmpaquetado { get; set; }

        public virtual PR_aFormaEmpaquetado PR_aFormaEmpaquetado { get; set; }
    }
}
