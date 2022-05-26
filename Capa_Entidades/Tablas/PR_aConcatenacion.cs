using System;

namespace Capa_Entidades.Tablas
{
    public class PR_aConcatenacion
    {
        private Int32 _IdConcatenacion;
        private Int32 _IdGProdProplast;
        private string _OrdenConcatenacion;
        private byte _Flag_Concatenacion;
        private Int32 _IdEstandarIndustrial;

        public int IdConcatenacion { get => _IdConcatenacion; set => _IdConcatenacion = value; }
        public int IdGProdProplast { get => _IdGProdProplast; set => _IdGProdProplast = value; }
        public string OrdenConcatenacion { get => _OrdenConcatenacion; set => _OrdenConcatenacion = value; }
        public byte Flag_Concatenacion { get => _Flag_Concatenacion; set => _Flag_Concatenacion = value; }
        public int IdEstandarIndustrial { get => _IdEstandarIndustrial; set => _IdEstandarIndustrial = value; }

        public PR_aConcatenacion()
        { }

        public PR_aConcatenacion(int idConcatenacion, int idGProdProplast, string ordenConcatenacion, byte flag_Concatenacion, int idEstandarIndustrial)
        {
            _IdConcatenacion = idConcatenacion;
            _IdGProdProplast = idGProdProplast;
            _OrdenConcatenacion = ordenConcatenacion;
            _Flag_Concatenacion = flag_Concatenacion;
            _IdEstandarIndustrial = idEstandarIndustrial;
        }


    }

}
