using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aMarcaMaquina
    {
        private byte _IdMarcaMaquina;
        private string _Descripcion_MarcaMaquina;
        private string _Abreviatura_MarcaMaquina;

        public byte IdMarcaMaquina { get => _IdMarcaMaquina; set => _IdMarcaMaquina = value; }
        public string Descripcion_MarcaMaquina { get => _Descripcion_MarcaMaquina; set => _Descripcion_MarcaMaquina = value; }
        public string Abreviatura_MarcaMaquina { get => _Abreviatura_MarcaMaquina; set => _Abreviatura_MarcaMaquina = value; }

        public PR_aMarcaMaquina()
        { }

        public PR_aMarcaMaquina(byte idMarcaMaquina, string descripcion_MarcaMaquina, string abreviatura_MarcaMaquina)
        {
            _IdMarcaMaquina = idMarcaMaquina;
            _Descripcion_MarcaMaquina = descripcion_MarcaMaquina;
            _Abreviatura_MarcaMaquina = abreviatura_MarcaMaquina;
        }
    }
}
