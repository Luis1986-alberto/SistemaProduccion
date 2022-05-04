using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalleProgramacionMezclado
    {
        public decimal IdProgramacionMezclado { get; set; }
        public byte IdItem { get; set; }
        public Nullable<short> Flag_Kilo { get; set; }
        public Nullable<decimal> Formula { get; set; }
        public Nullable<decimal> Kilos_TolvaLlena { get; set; }
        public Nullable<decimal> Porcentaje_TolvaLlena { get; set; }
        public string Lote_Material { get; set; }
        public Nullable<short> IdColor { get; set; }
        public Nullable<short> IdMaterial { get; set; }
        public Nullable<decimal> Cubo1_Kilos { get; set; }
        public Nullable<decimal> Cubo1_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo1_Porcentaje { get; set; }
        public Nullable<decimal> Cubo2_KIlos { get; set; }
        public Nullable<decimal> Cubo2_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo2_Porcentaje { get; set; }
        public Nullable<decimal> Cubo3_Kilos { get; set; }
        public Nullable<decimal> Cubo3_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo3_Porcentaje { get; set; }
        public Nullable<decimal> Cubo4_Kilos { get; set; }
        public Nullable<decimal> Cubo4_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo4_Porcentaje { get; set; }
        public Nullable<decimal> Cubo5_Kilos { get; set; }
        public Nullable<decimal> Cubo5_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo5_Porcentaje { get; set; }
        public Nullable<decimal> Cubo6_Kilos { get; set; }
        public Nullable<decimal> Cubo6_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo6_Porcentaje { get; set; }
        public Nullable<decimal> Cubo7_Kilos { get; set; }
        public Nullable<decimal> Cubo7_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo7_Porcentaje { get; set; }
        public Nullable<decimal> Cubo8_Kilos { get; set; }
        public Nullable<decimal> Cubo8_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo8_Porcentaje { get; set; }
        public Nullable<decimal> Cubo9_Kilos { get; set; }
        public Nullable<decimal> Cubo9_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo9_Porcentaje { get; set; }
        public Nullable<decimal> Cubo10_Kilos { get; set; }
        public Nullable<decimal> Cubo10_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo10_Porcentaje { get; set; }
        public Nullable<decimal> Cubo11_Kilos { get; set; }
        public Nullable<decimal> Cubo11_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo11_Porcentaje { get; set; }
        public Nullable<decimal> Cubo12_Kilos { get; set; }
        public Nullable<decimal> Cubo12_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo12_Porcentaje { get; set; }
        public Nullable<decimal> Cubo13_Kilos { get; set; }
        public Nullable<decimal> Cubo13_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo13_Porcentaje { get; set; }
        public Nullable<decimal> Cubo14_Kilos { get; set; }
        public Nullable<decimal> Cubo14_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo14_Porcentaje { get; set; }
        public Nullable<decimal> Cubo15_Kilos { get; set; }
        public Nullable<decimal> Cubo15_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo15_Porcentaje { get; set; }
        public Nullable<decimal> Cubo16_Kilos { get; set; }
        public Nullable<decimal> Cubo16_Bolsa_Kilos { get; set; }
        public Nullable<decimal> Cubo16_Porcentaje { get; set; }
        public Nullable<decimal> Cubo2_Bolsa_Kilos__15912 { get; set; }
        public Nullable<decimal> Cubo3_Kilos__15916 { get; set; }

        public virtual PR_aColor PR_aColor { get; set; }
        public virtual PR_mMateriales PR_mMateriales { get; set; }
        public virtual PR_xProgramacionMezclado PR_xProgramacionMezclado { get; set; }
    }
}
