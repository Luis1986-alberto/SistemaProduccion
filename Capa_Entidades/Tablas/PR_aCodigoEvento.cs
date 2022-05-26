using System;

namespace Capa_Entidades.Tablas
{
    public class PR_aCodigoEvento
    {
        private byte _IdCodigoEvento;
        private string _Codigo_Evento;
        private string _Descripcion;
        private string _Flag_EventoMaquina;
        private string _Flag_EventoColaborador;
        private string _Flag_EventoMaterial;
        private string _IdUsuario;
        private DateTime _Fecha_Servidor;
        private byte _IdArea;
        private byte _IdLocal;
        public virtual string Nombre_Area { get; set; }
        public virtual string Nombre_Local { get; set; }

        public byte IdCodigoEvento { get => _IdCodigoEvento; set => _IdCodigoEvento = value; }
        public string Codigo_Evento { get => _Codigo_Evento; set => _Codigo_Evento = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Flag_EventoMaquina { get => _Flag_EventoMaquina; set => _Flag_EventoMaquina = value; }
        public string Flag_EventoColaborador { get => _Flag_EventoColaborador; set => _Flag_EventoColaborador = value; }
        public string Flag_EventoMaterial { get => _Flag_EventoMaterial; set => _Flag_EventoMaterial = value; }
        public string IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public DateTime Fecha_Servidor { get => _Fecha_Servidor; set => _Fecha_Servidor = value; }
        public byte IdArea { get => _IdArea; set => _IdArea = value; }
        public byte IdLocal { get => _IdLocal; set => _IdLocal = value; }

        public PR_aCodigoEvento()
        { }

        public PR_aCodigoEvento(byte idCodigoEvento, string codigo_Evento, string descripcion, string flag_EventoMaquina, string flag_EventoColaborador,
                                string flag_EventoMaterial, string idUsuario, DateTime fecha_Servidor, byte idArea, byte idLocal)
        {
            _IdCodigoEvento = idCodigoEvento;
            _Codigo_Evento = codigo_Evento;
            _Descripcion = descripcion;
            _Flag_EventoMaquina = flag_EventoMaquina;
            _Flag_EventoColaborador = flag_EventoColaborador;
            _Flag_EventoMaterial = flag_EventoMaterial;
            _IdUsuario = idUsuario;
            _Fecha_Servidor = fecha_Servidor;
            _IdArea = idArea;
            _IdLocal = idLocal;
        }


    }
}
