using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mUsuarios
    {
        public string IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Contraseña { get; set; }
        public Nullable<short> Flag_Activo { get; set; }
        public Nullable<byte> IdNivelUsuario { get; set; }

        public PR_mUsuarios()
        {   }


    }
    
}
