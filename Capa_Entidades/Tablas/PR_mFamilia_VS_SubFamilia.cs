using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mFamilia_VS_SubFamilia
    {
        public decimal IdFamiliaProd { get; set; }
        public decimal IdSubFamiliaProd { get; set; }
        public string Observacion { get; set; }

        public virtual PR_aFamilia_Produccion PR_aFamilia_Produccion { get; set; }
        public virtual PR_aSubFamilia_Produccion PR_aSubFamilia_Produccion { get; set; }
    }
}
