using System;

namespace Capa_Entidades.Tablas
{
    public class LG_xPeriodo
    {
        private Int32 _IdPeriodo;
        private int _IdAño;
        private byte _IdMes;
        private byte _Flag_Cerrado;
        private string _Nombre_Periodo;
        private DateTime _Fecha_Inicio;
        private DateTime _Fecha_Final;

        public Int32 IdPeriodo { get => _IdPeriodo; set => _IdPeriodo = value; }
        public int IdAño { get => _IdAño; set => _IdAño = value; }
        public byte IdMes { get => _IdMes; set => _IdMes = value; }
        public byte Flag_Cerrado { get => _Flag_Cerrado; set => _Flag_Cerrado = value; }
        public string Nombre_Periodo { get => _Nombre_Periodo; set => _Nombre_Periodo = value; }
        public DateTime Fecha_Inicio { get => _Fecha_Inicio; set => _Fecha_Inicio = value; }
        public DateTime Fecha_Final { get => _Fecha_Final; set => _Fecha_Final = value; }
        public int Año { get; set; }
        public string Mes { get; set; }

        public LG_xPeriodo()
        { }

        public LG_xPeriodo(Int32 idperiodo)
        {
            IdPeriodo = idperiodo;
        }
        public LG_xPeriodo(int idPeriodo, int idAño, byte idMes, byte flag_Cerrado, string nombre_Periodo, DateTime fecha_Inicio, DateTime fecha_Final)
        {
            IdPeriodo = idPeriodo;
            IdAño = idAño;
            IdMes = idMes;
            Flag_Cerrado = flag_Cerrado;
            Nombre_Periodo = nombre_Periodo;
            Fecha_Inicio = fecha_Inicio;
            Fecha_Final = fecha_Final;
        }


    }
}
