namespace Capa_Entidades.Tablas
{
    public class PR_aProcesos
    {
        private byte _IdProcesos;
        private string _Secuencia_Procesos;
        private byte _Flag_Extrusion;
        private byte _Flag_Impresion;
        private byte _Flag_Sellado;
        private byte _Flag_Corte;
        private byte _Flag_Laminado;
        private byte _Flag_Doblado;

        public byte IdProcesos { get => _IdProcesos; set => _IdProcesos = value; }
        public string Secuencia_Procesos { get => _Secuencia_Procesos; set => _Secuencia_Procesos = value; }
        public byte Flag_Extrusion { get => _Flag_Extrusion; set => _Flag_Extrusion = value; }
        public byte Flag_Impresion { get => _Flag_Impresion; set => _Flag_Impresion = value; }
        public byte Flag_Sellado { get => _Flag_Sellado; set => _Flag_Sellado = value; }
        public byte Flag_Corte { get => _Flag_Corte; set => _Flag_Corte = value; }
        public byte Flag_Laminado { get => _Flag_Laminado; set => _Flag_Laminado = value; }
        public byte Flag_Doblado { get => _Flag_Doblado; set => _Flag_Doblado = value; }

        public PR_aProcesos()
        { }

        public PR_aProcesos(byte idProcesos, string secuencia_Procesos, byte flag_Extrusion, byte flag_Impresion, byte flag_Sellado, byte flag_Corte,
                            byte flag_Laminado, byte flag_Doblado)
        {
            _IdProcesos = idProcesos;
            _Secuencia_Procesos = secuencia_Procesos;
            _Flag_Extrusion = flag_Extrusion;
            _Flag_Impresion = flag_Impresion;
            _Flag_Sellado = flag_Sellado;
            _Flag_Corte = flag_Corte;
            _Flag_Laminado = flag_Laminado;
            _Flag_Doblado = flag_Doblado;
        }
    }
}
