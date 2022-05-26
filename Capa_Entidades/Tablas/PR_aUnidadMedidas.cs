namespace Capa_Entidades.Tablas
{
    public class PR_aUnidadMedidas
    {
        private byte _IdUnidadMedida;
        private string _Sigla_Unidad;
        private string _Nombre_Unidad;
        private string _Flag_Espesor;

        public byte IdUnidadMedida { get => _IdUnidadMedida; set => _IdUnidadMedida = value; }
        public string Sigla_Unidad { get => _Sigla_Unidad; set => _Sigla_Unidad = value; }
        public string Nombre_Unidad { get => _Nombre_Unidad; set => _Nombre_Unidad = value; }
        public string Flag_Espesor { get => _Flag_Espesor; set => _Flag_Espesor = value; }

        public PR_aUnidadMedidas()
        { }

        public PR_aUnidadMedidas(byte idUnidadMedida, string sigla_Unidad, string nombre_Unidad, string flag_Espesor)
        {
            _IdUnidadMedida = idUnidadMedida;
            _Sigla_Unidad = sigla_Unidad;
            _Nombre_Unidad = nombre_Unidad;
            _Flag_Espesor = flag_Espesor;
        }

    }
}
