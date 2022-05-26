using System;

namespace Capa_Entidades.Tablas
{
    public class LG_aGrupo
    {
        public Int32 IdGrupo { get; set; }
        public string Nombre_Grupo { get; set; }
        public string Codigo_Grupo { get; set; }
        public string IdUsuario_PC { get; set; }
        public DateTime Fecha_Servidor { get; set; }
        public string IdUsuario { get; set; }

        public LG_aGrupo()
        { }



    }
}
