using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mAlmacenProdTerminados
    {
        public decimal IdAlmacenProdTerminados { get; set; }
        public string Flag_IngresoProdTerm { get; set; }
        public string Flag_SalidaProdTerm { get; set; }
        public string Flag_ReingresoProdTerm { get; set; }
        public string Flag_ResalidaProdTerm { get; set; }
        public string Flag_IndustrialComercial { get; set; }
        public string IdOrdenProduccion { get; set; }
        public Nullable<decimal> Numero_Bobina_FardoCajaPqte { get; set; }
        public string Flag_Producto_Observado { get; set; }
        public string Nota_Producto_Observado { get; set; }
        public Nullable<byte> IdSectorAlmacenPT { get; set; }
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        public Nullable<System.DateTime> Fecha_Salida { get; set; }
        public string Flag_Bolsas_Mangas { get; set; }
        public Nullable<decimal> Cantidad_Kilos_Ingreso { get; set; }
        public Nullable<decimal> Cantidad_Millares_Ingreso { get; set; }
        public Nullable<decimal> Cantidad_Kilos_Salida { get; set; }
        public Nullable<decimal> Cantidad_Millares_Salida { get; set; }
        public string Nota_Ingreso { get; set; }
        public string Nota_Salida { get; set; }
        public Nullable<System.DateTime> Hora_Ingreso { get; set; }
        public Nullable<System.DateTime> Hora_Salida { get; set; }
        public string IdOrdenProduccionInd { get; set; }
        public string IdUsuario { get; set; }

        public virtual PR_aSectorAlmacenPT PR_aSectorAlmacenPT { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }

    }
}
