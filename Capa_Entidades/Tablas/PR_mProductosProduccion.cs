using System;

namespace Capa_Entidades.Tablas
{
    public class PR_mProductosProduccion
    {
        public decimal IdProductosProduccion { get; set; }
        public Nullable<int> IdLineaProd { get; set; }
        public string Descripcion_Producto { get; set; }
        public Nullable<decimal> IdGrupoProd { get; set; }
        public Nullable<int> IdMedidaProd { get; set; }
        public Nullable<decimal> IdFamiliaProd { get; set; }
        public Nullable<decimal> IdSubFamiliaProd { get; set; }
        public string Observacion { get; set; }
        public Nullable<short> Flag_Impresion { get; set; }
        public Nullable<short> IdColorProd { get; set; }
        public byte[] Imagen_Produccion { get; set; }
        public string Direccion_Image { get; set; }

        public virtual PR_aColor PR_aColor { get; set; }
        public virtual PR_aFamilia_Produccion PR_aFamilia_Produccion { get; set; }
        public virtual PR_aGrupo_Produccion PR_aGrupo_Produccion { get; set; }
        public virtual PR_aLinea_Produccion PR_aLinea_Produccion { get; set; }
        public virtual PR_aMedidas_Produccion PR_aMedidas_Produccion { get; set; }
        public virtual PR_aSubFamilia_Produccion PR_aSubFamilia_Produccion { get; set; }

    }
}
