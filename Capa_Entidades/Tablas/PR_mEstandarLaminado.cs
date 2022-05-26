using System;

namespace Capa_Entidades.Tablas
{
    public class PR_mEstandarLaminado
    {
        public short IdEstandarLaminado { get; set; }
        public Int32 IdEstandar { get; set; }
        public Nullable<byte> IdTipoLaminado { get; set; }
        public Nullable<byte> IdUsoProducto { get; set; }
        public Nullable<short> Flag_Solvente { get; set; }
        public Nullable<decimal> Total_Gramaje { get; set; }
        public string Nota_Laminado { get; set; }
        public string Ruta_Foto { get; set; }
        public byte[] Foto_Bolsa { get; set; }
        public Nullable<decimal> AnchoUtil_Laminacion { get; set; }
        public Nullable<decimal> Gramaje_Adhesivo { get; set; }
        public Nullable<byte> IdAdhesivo { get; set; }


        public PR_mEstandarLaminado()
        { }

    }
}
