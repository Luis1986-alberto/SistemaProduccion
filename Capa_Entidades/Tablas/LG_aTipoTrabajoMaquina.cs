using System;

namespace Capa_Entidades.Tablas
{
    public class LG_aTipoTrabajoMaquina
    {
        public Int32 IdTrabajoMaquina { get; set; }
        public string Descripcion_TrabajoMaquina { get; set; }

        public LG_aTipoTrabajoMaquina()
        { }

        public LG_aTipoTrabajoMaquina(Int32 idtrabajomaquina, string descripcion_trabajomaquina)
        {
            this.IdTrabajoMaquina = idtrabajomaquina;
            this.Descripcion_TrabajoMaquina = descripcion_trabajomaquina;
        }


    }
}
