using System;

namespace Capa_Entidades.Tablas
{
    public class PR_mCapacidadExtrusion
    {
        public string Alias_Maquina { get; set; }
        public string Diseño { get; set; }
        public string Medida { get; set; }
        public Nullable<decimal> Espesor { get; set; }
        public Nullable<decimal> Cabezal_AD { get; set; }
        public Nullable<decimal> Cabezal_BD { get; set; }
        public Nullable<decimal> Kilos_Por_Dia { get; set; }
        public Nullable<decimal> Kilos_Por_Hora { get; set; }
        public Nullable<decimal> Ancho_Manga_AD_Max { get; set; }
        public Nullable<decimal> Ancho_Manga_AD_Min { get; set; }
        public Nullable<decimal> Ancho_Manga_BD_Max { get; set; }
        public Nullable<decimal> Ancho_Manga_BD_Min { get; set; }
        public short IdMaquina { get; set; }

        public virtual PR_mMaquina PR_mMaquina { get; set; }

    }
}
