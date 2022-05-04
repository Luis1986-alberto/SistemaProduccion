using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mAlmacenProdTermCom_Ing
    {
        public decimal IdAlmacenProdTermCom_Ing { get; set; }
        public Nullable<decimal> IdGProdProplast { get; set; }
        public Nullable<decimal> IdProductosProplast { get; set; }
        public Nullable<decimal> IdListaProdProplast { get; set; }
        public Nullable<byte> IdFormaEmpaquetado { get; set; }
        public string Flag_BolsasLaminas { get; set; }
        public string Flag_MangasLaminas { get; set; }
        public Nullable<decimal> Numero_Bobina_FardoCajaPqte { get; set; }
        public Nullable<decimal> Cantidad_Kilos_Ingreso { get; set; }
        public Nullable<decimal> Cantidad_Millares_Ingreso { get; set; }
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        public string Nota_Ingreso { get; set; }
        public string Flag_Ingreso { get; set; }

        public virtual PR_aFormaEmpaquetado PR_aFormaEmpaquetado { get; set; }
       
        

    }
}
