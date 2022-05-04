using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aPrioridad
    {
        private byte _IdPrioridad;
        private string _Descripcion_Prioridad;

        public byte IdPrioridad { get => _IdPrioridad; set => _IdPrioridad = value; }
        public string Descripcion_Prioridad { get => _Descripcion_Prioridad; set => _Descripcion_Prioridad = value; }

        public PR_aPrioridad()
        {   }
        
        public PR_aPrioridad(byte idPrioridad, string descripcion_Prioridad)
        {
            _IdPrioridad = idPrioridad;
            _Descripcion_Prioridad = descripcion_Prioridad;
        }

    }
}
