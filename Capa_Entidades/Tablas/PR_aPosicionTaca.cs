namespace Capa_Entidades.Tablas
{
    public class PR_aPosicionTaca
    {
        public byte IdPosicionTaca { get; set; }
        public string Posicion_Taca { get; set; }

        public PR_aPosicionTaca()
        { }

        public PR_aPosicionTaca(byte idposiciontaca, string posiciontaca)
        {
            IdPosicionTaca = idposiciontaca;
            Posicion_Taca = posiciontaca;
        }

    }
}
