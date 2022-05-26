using System;

namespace Capa_Entidades.Tablas
{
    public class LG_aTipoCosto
    {
        public byte IdTipoCosto { get; set; }
        public string Nombre_TipoCosto { get; set; }
        public string Codigo_TipoCosto { get; set; }
        public DateTime Fecha_Servidor { get; set; }
        public string IdUsuario_PC { get; set; }
        public string IdUsuario { get; set; }


        public LG_aTipoCosto()
        { }

        public LG_aTipoCosto(byte idtipocosto, string nombre_tipocosto, string codigo_tipocosto, DateTime fecha_servidor, string idusuario_pc, string idusuario)
        {
            this.IdTipoCosto = idtipocosto;
            this.Nombre_TipoCosto = nombre_tipocosto;
            this.Codigo_TipoCosto = codigo_tipocosto;
            this.Fecha_Servidor = fecha_servidor;
            this.IdUsuario_PC = idusuario_pc;
            this.IdUsuario = idusuario;
        }


    }
}
