using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class MP_aAlmacenAduana
    {
        public byte IdAlmacenAduana { get; set; }
        public string Nombre_AlmacenAduana { get; set; }


        public MP_aAlmacenAduana()
        {   }

        public MP_aAlmacenAduana(byte idAlmacenAduana, string nombre_AlmacenAduana)
        {
            IdAlmacenAduana = idAlmacenAduana;
            Nombre_AlmacenAduana = nombre_AlmacenAduana;
        }

    }
}
