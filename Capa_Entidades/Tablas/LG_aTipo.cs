using System;

namespace Capa_Entidades.Tablas
{
    public class LG_aTipo
    {
        public Int32 IdTipo { get; set; }
        public string Nombre_Tipo { get; set; }
        public string IdUsuario_PC { get; set; }
        public DateTime Fecha_Servidor { get; set; }
        public string Codigo_Tipo { get; set; }
        public string IdUsuario { get; set; }


        public LG_aTipo()
        { }

        public LG_aTipo(Int32 idtipo, string nombre_tipo, string idusuariopc, DateTime fecha_servidor, string codigo_tipo, string idusuario)
        {
            this.IdTipo = idtipo;
            this.Nombre_Tipo = nombre_tipo;
            this.IdUsuario_PC = idusuariopc;
            this.Codigo_Tipo = codigo_tipo;
            this.IdUsuario = idusuariopc;
        }


    }
}
