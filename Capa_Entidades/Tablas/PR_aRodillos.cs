using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aRodillos
    {
        public byte IdRodillo { get;  set; }
        public string   Descripcion { get; set; }

        public PR_aRodillos()
        { }

        public PR_aRodillos(byte idrodillo, string descripcion)
        {
            IdRodillo = idrodillo;
            Descripcion = descripcion;
        }

    }
}
