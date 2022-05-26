using System;

namespace Capa_Entidades.Tablas
{
    public class PR_aEstandarColor
    {
        private Int32 _IdEstandarColor;
        private string _Descripcion_EstandarColor;
        private string _Nota_EstandarColor;
        private byte[] _Foto_EstandarColor;
        private string _Ruta_EstandarColor;
        private string _IdUsuario;
        private string _IdUsuario_PC;
        private DateTime _Fecha_Servidor;
        private byte _IdColor;
        private Int32 _IdDerivadoColor;
        private byte _IdLineaColor;
        private Int32 _IdMaterial;

        public int IdEstandarColor { get => _IdEstandarColor; set => _IdEstandarColor = value; }
        public string Descripcion_EstandarColor { get => _Descripcion_EstandarColor; set => _Descripcion_EstandarColor = value; }
        public string Nota_EstandarColor { get => _Nota_EstandarColor; set => _Nota_EstandarColor = value; }
        public byte[] Foto_EstandarColor { get => _Foto_EstandarColor; set => _Foto_EstandarColor = value; }
        public string Ruta_EstandarColor { get => _Ruta_EstandarColor; set => _Ruta_EstandarColor = value; }
        public string IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string IdUsuario_PC { get => _IdUsuario_PC; set => _IdUsuario_PC = value; }
        public DateTime Fecha_Servidor { get => _Fecha_Servidor; set => _Fecha_Servidor = value; }
        public byte IdColor { get => _IdColor; set => _IdColor = value; }
        public int IdDerivadoColor { get => _IdDerivadoColor; set => _IdDerivadoColor = value; }
        public byte IdLineaColor { get => _IdLineaColor; set => _IdLineaColor = value; }
        public int IdMaterial { get => _IdMaterial; set => _IdMaterial = value; }

        public PR_aEstandarColor()
        { }

        public PR_aEstandarColor(int idEstandarColor, string descripcion_EstandarColor, string nota_EstandarColor, byte[] foto_EstandarColor,
            string ruta_EstandarColor, string idUsuario, string idUsuario_PC, DateTime fecha_Servidor, byte idColor, int idDerivadoColor,
            byte idLineaColor, int idMaterial)
        {
            _IdEstandarColor = idEstandarColor;
            _Descripcion_EstandarColor = descripcion_EstandarColor;
            _Nota_EstandarColor = nota_EstandarColor;
            _Foto_EstandarColor = foto_EstandarColor;
            _Ruta_EstandarColor = ruta_EstandarColor;
            _IdUsuario = idUsuario;
            _IdUsuario_PC = idUsuario_PC;
            _Fecha_Servidor = fecha_Servidor;
            _IdColor = idColor;
            _IdDerivadoColor = idDerivadoColor;
            _IdLineaColor = idLineaColor;
            _IdMaterial = idMaterial;
        }

    }
}
