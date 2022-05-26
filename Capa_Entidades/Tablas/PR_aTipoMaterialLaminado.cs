namespace Capa_Entidades.Tablas
{
    public class PR_aTipoMaterialLaminado
    {
        private byte _IdTipoMaterialLaminado;
        private string _Descripcion;
        private string _Abreviatura;
        private byte _Orden_Gerencia;
        private decimal _Gramaje_Lineal;

        public byte IdTipoMaterialLaminado { get => _IdTipoMaterialLaminado; set => _IdTipoMaterialLaminado = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Abreviatura { get => _Abreviatura; set => _Abreviatura = value; }
        public byte Orden_Gerencia { get => _Orden_Gerencia; set => _Orden_Gerencia = value; }
        public decimal Gramaje_Lineal { get => _Gramaje_Lineal; set => _Gramaje_Lineal = value; }

        public PR_aTipoMaterialLaminado()
        { }

        public PR_aTipoMaterialLaminado(byte idTipoMaterialLaminado, string descripcion, string abreviatura, byte orden_Gerencia, decimal gramaje_Lineal)
        {
            _IdTipoMaterialLaminado = idTipoMaterialLaminado;
            _Descripcion = descripcion;
            _Abreviatura = abreviatura;
            _Orden_Gerencia = orden_Gerencia;
            _Gramaje_Lineal = gramaje_Lineal;
        }

    }
}
