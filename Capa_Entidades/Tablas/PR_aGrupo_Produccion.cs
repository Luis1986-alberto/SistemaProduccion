namespace Capa_Entidades.Tablas
{
    public class PR_aGrupo_Produccion
    {
        private byte _IdGrupoProd;
        private string _Descripcion_GrupoProd;

        public byte IdGrupoProd { get => _IdGrupoProd; set => _IdGrupoProd = value; }
        public string Descripcion_GrupoProd { get => _Descripcion_GrupoProd; set => _Descripcion_GrupoProd = value; }

        public PR_aGrupo_Produccion()
        { }

        public PR_aGrupo_Produccion(byte idGrupoProd, string descripcion_GrupoProd)
        {
            _IdGrupoProd = idGrupoProd;
            _Descripcion_GrupoProd = descripcion_GrupoProd;
        }
    }
}
