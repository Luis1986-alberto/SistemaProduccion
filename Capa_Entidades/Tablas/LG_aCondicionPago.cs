namespace Capa_Entidades.Tablas
{
    public class LG_aCondicionPago
    {
        private byte _IdCondicionPago;
        private string _Nombre_Condicion_Pago;

        public byte IdCondicionPago { get => _IdCondicionPago; set => _IdCondicionPago = value; }
        public string Nombre_Condicion_Pago { get => _Nombre_Condicion_Pago; set => _Nombre_Condicion_Pago = value; }

        public LG_aCondicionPago()
        { }

        public LG_aCondicionPago(byte idcondicionpago, string nombre_condicion_pago)
        {
            _IdCondicionPago = idcondicionpago;
            _Nombre_Condicion_Pago = nombre_condicion_pago;
        }

    }
}
