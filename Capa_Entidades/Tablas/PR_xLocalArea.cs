using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xLocalArea
    {
        public byte IdLocal { get; set; }
        public string Nombre_Local { get; set; }
        public byte IdArea { get; set; }
        public string Nombre_Area { get; set; }
        public short IdLocalArea { get; set; }

        public virtual PR_aArea PR_aArea { get; set; }
        public virtual PR_aLocal PR_aLocal { get; set; }

    }

}
