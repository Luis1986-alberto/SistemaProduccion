using System;

namespace Capa_Entidades.Tablas
{
    public class PR_mAlmacenProdTermCom_Sal
    {
        public decimal IdAlmacenProdTermCom_Sal { get; set; }
        public Nullable<decimal> IdGProdProplast { get; set; }
        public Nullable<decimal> IdProductosProplast { get; set; }
        public Nullable<decimal> IdListaProdProplast { get; set; }
        public Nullable<byte> IdFormaEmpaquetado { get; set; }
        public string Flag_BolsasLaminas { get; set; }
        public string Flag_MangasLaminas { get; set; }
        public Nullable<decimal> Numero_Bobina_FardoCajaPqte { get; set; }
        public Nullable<decimal> Cantidad_Kilos_Salida { get; set; }
        public Nullable<decimal> Cantidad_Millares_Salida { get; set; }
        public Nullable<System.DateTime> Fecha_Salida { get; set; }
        public string Nota_Salida { get; set; }
        public string Flag_Salida { get; set; }

        public virtual PR_aFormaEmpaquetado PR_aFormaEmpaquetado { get; set; }



    }
}
