namespace Capa_Entidades.Tablas
{
    public class PR_aIGV
    {
        private byte _IdIGV;
        private decimal _Porcentaje;
        private byte _Flag_Activo;

        public byte IdIGV { get => _IdIGV; set => _IdIGV = value; }
        public decimal Porcentaje { get => _Porcentaje; set => _Porcentaje = value; }
        public byte Flag_Activo { get => _Flag_Activo; set => _Flag_Activo = value; }

        public PR_aIGV()
        { }

        public PR_aIGV(byte idIGV, decimal porcentaje, byte flag_Activo)
        {
            _IdIGV = idIGV;
            _Porcentaje = porcentaje;
            _Flag_Activo = flag_Activo;
        }

    }
}
