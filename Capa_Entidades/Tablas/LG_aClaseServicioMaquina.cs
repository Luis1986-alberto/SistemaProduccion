using System;

namespace Capa_Entidades.Tablas
{
    public class LG_aClaseServicioMaquina
    {
        public Int32 IdClaseServicioMaquina { get; set; }
        public string Descripcion_ClaseServicio { get; set; }

        public LG_aClaseServicioMaquina()
        { }

        public LG_aClaseServicioMaquina(Int32 idclaseserviciomaquina, string descripcion_claseservicio)
        {
            this.IdClaseServicioMaquina = idclaseserviciomaquina;
            this.Descripcion_ClaseServicio = descripcion_claseservicio;
        }

    }
}
