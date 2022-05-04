using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoMaquina_CN
    {
        public static readonly PR_aTipoMaquina_CN _Instancia = new PR_aTipoMaquina_CN();

        public static PR_aTipoMaquina_CN Instancia
        { get { return PR_aTipoMaquina_CN._Instancia; } }

        public List<PR_aTipoMaquina> Lista_TipoMaquina()
        { return PR_aTipoMaquina_CD._Instancia.Lista_TipoMaquina().ToList(); }

        public IEnumerable<PR_aTipoMaquina> TraerPorID(Int32 id)
        { return PR_aTipoMaquina_CD._Instancia.Traer_TipoMaquinaPorId(id); }

        public IEnumerable<PR_aTipoMaquina> Buscar_TipoMaquina(string nombretipomaquina)
        {
            var lista = PR_aTipoMaquina_CD._Instancia.Lista_TipoMaquina().ToList();
            return from buscar in lista where buscar.Nombre_TipoMaquina == nombretipomaquina select buscar;
        }

        public string Agregar_TipoMaquina(PR_aTipoMaquina tipomaquina)
        {
            if (Buscar_TipoMaquina(tipomaquina.Nombre_TipoMaquina).Count() > 0) return "EXISTE TIPO MAQUINA";
            return PR_aTipoMaquina_CD._Instancia.Agregar_TipoMaquina(tipomaquina);
        }

        public string Actualizar_TipoMaquina(PR_aTipoMaquina tipomaquina)
        {
            if (Buscar_TipoMaquina(tipomaquina.Nombre_TipoMaquina).Count() > 0) return "EXISTE TIPO MAQUINA";
            return PR_aTipoMaquina_CD._Instancia.Actualizar_TipoMaquina(tipomaquina);
        }

        public string Eliminar_TipoMaquina(Int32 idtipomaaquina)
        { return PR_aTipoMaquina_CD._Instancia.Eliminar_TipoMaquina(idtipomaaquina); }
    }
}
