using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aModeloMaquina
    {
        private byte _IdModeloMaquina;
        private string _Descripcion_ModeloMaquina;

       
        public byte IdModeloMaquina { get => _IdModeloMaquina; set => _IdModeloMaquina = value; }
        public string Descripcion_ModeloMaquina { get => _Descripcion_ModeloMaquina; set => _Descripcion_ModeloMaquina = value; }

        public PR_aModeloMaquina()
        {   }

        public PR_aModeloMaquina(byte idModeloMaquina, string descripcion_ModeloMaquina)
        {
            _IdModeloMaquina = idModeloMaquina;
            _Descripcion_ModeloMaquina = descripcion_ModeloMaquina;
        }

    }
}
