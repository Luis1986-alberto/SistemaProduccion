namespace Capa_Entidades.Tablas
{
    public class PR_aTipoMaterialMezclar
    {
        private byte _IdTipoMaterialMezclar;
        private string _Descripcion_MaterialMezclar;
        private string _Abreviatura;
        private byte _Orden_Gerencia;
        private string _Codigo_Sustrato;
        private int _IdClaseMaterial;

        public byte IdTipoMaterialMezclar { get => _IdTipoMaterialMezclar; set => _IdTipoMaterialMezclar = value; }
        public string Descripcion_MaterialMezclar { get => _Descripcion_MaterialMezclar; set => _Descripcion_MaterialMezclar = value; }
        public string Abreviatura { get => _Abreviatura; set => _Abreviatura = value; }
        public byte Orden_Gerencia { get => _Orden_Gerencia; set => _Orden_Gerencia = value; }
        public string Codigo_Sustrato { get => _Codigo_Sustrato; set => _Codigo_Sustrato = value; }
        public int IdClaseMaterial { get => _IdClaseMaterial; set => _IdClaseMaterial = value; }
        public virtual string Clase_Material { get; set; }

        public PR_aTipoMaterialMezclar()
        { }

        public PR_aTipoMaterialMezclar(byte idTipoMaterialMezclar, string descripcion_MaterialMezclar, string abreviatura, byte orden_Gerencia, string codigo_Sustrato, int idClaseMaterial)
        {
            _IdTipoMaterialMezclar = idTipoMaterialMezclar;
            _Descripcion_MaterialMezclar = descripcion_MaterialMezclar;
            _Abreviatura = abreviatura;
            _Orden_Gerencia = orden_Gerencia;
            _Codigo_Sustrato = codigo_Sustrato;
            _IdClaseMaterial = idClaseMaterial;
        }

    }
}
