namespace Capa_Entidades.Tablas
{
    public class PR_aMotivoObservacion_CC
    {
        private byte _IdMotivoObservacion_CC;
        private string _Motivo_Observacion_CC;

        public byte IdMotivoObservacion_CC { get => _IdMotivoObservacion_CC; set => _IdMotivoObservacion_CC = value; }
        public string Motivo_Observacion_CC { get => _Motivo_Observacion_CC; set => _Motivo_Observacion_CC = value; }

        public PR_aMotivoObservacion_CC()
        { }

        public PR_aMotivoObservacion_CC(byte idMotivoObservacion_CC, string motivo_Observacion_CC)
        {
            _IdMotivoObservacion_CC = idMotivoObservacion_CC;
            _Motivo_Observacion_CC = motivo_Observacion_CC;
        }
    }
}
