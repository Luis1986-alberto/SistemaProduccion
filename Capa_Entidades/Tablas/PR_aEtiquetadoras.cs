using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aEtiquetadoras
    {
        private byte _IdEtiquetadora;
        private string _Marca_Etiquetadora;
        private string _Modelo_Etiquetadora;
        private string _Codigo_Etiquetadora;

        public byte IdEtiquetadora { get => _IdEtiquetadora; set => _IdEtiquetadora = value; }
        public string Marca_Etiquetadora { get => _Marca_Etiquetadora; set => _Marca_Etiquetadora = value; }
        public string Modelo_Etiquetadora { get => _Modelo_Etiquetadora; set => _Modelo_Etiquetadora = value; }
        public string Codigo_Etiquetadora { get => _Codigo_Etiquetadora; set => _Codigo_Etiquetadora = value; }

        public PR_aEtiquetadoras()
        {  }

        public PR_aEtiquetadoras(byte idEtiquetadora, string marca_Etiquetadora, string modelo_Etiquetadora, string codigo_Etiquetadora)
        {
            _IdEtiquetadora = idEtiquetadora;
            _Marca_Etiquetadora = marca_Etiquetadora;
            _Modelo_Etiquetadora = modelo_Etiquetadora;
            _Codigo_Etiquetadora = codigo_Etiquetadora;
        }

    }
}
