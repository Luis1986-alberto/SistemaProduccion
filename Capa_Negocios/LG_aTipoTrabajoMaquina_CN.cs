using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aTipoTrabajoMaquina_CN
    {
        public static readonly LG_aTipoTrabajoMaquina_CN _Instancia = new LG_aTipoTrabajoMaquina_CN();

        public static LG_aTipoTrabajoMaquina_CN Instancia
        { get { return LG_aTipoTrabajoMaquina_CN._Instancia; } }

        public IEnumerable<LG_aTipoTrabajoMaquina> Lista_TipoTrabajoMaquina()
        { return LG_aTipoTrabajoMaquina_CD._Instancia.Lista_TipotrabajoMaquina(); }

        public LG_aTipoTrabajoMaquina traerPorID(int idtrabajomaquina)
        { return LG_aTipoTrabajoMaquina_CD._Instancia.TraerPorIdtrabajoMaquina(idtrabajomaquina); }

        public IEnumerable<LG_aTipoTrabajoMaquina> Buscar_TrabajoMaquina(string trabajomaquina)
        {
            var predicado = Predicates.Field<LG_aTipoTrabajoMaquina>(x => x.Descripcion_TrabajoMaquina, Operator.Eq, trabajomaquina);
            return LG_aTipoTrabajoMaquina_CD._Instancia.FiltroPorunCampo(predicado);
        }

        public string Agregar(LG_aTipoTrabajoMaquina tipotrabajomaquina)
        {
            if (Buscar_TrabajoMaquina(tipotrabajomaquina.Descripcion_TrabajoMaquina).ToList().Count > 0) return "YA EXISTE TIPO TRABAJO MAQUINA ";
            return LG_aTipoTrabajoMaquina_CD._Instancia.Agregar_TipoTrabajoMaquina(tipotrabajomaquina);
        }

        public String Actualizar(LG_aTipoTrabajoMaquina tipotrabajomaquina)
        {
            if (Buscar_TrabajoMaquina(tipotrabajomaquina.Descripcion_TrabajoMaquina).ToList().Count > 0) return "YA EXISTE TIPO TRABAJO MAQUINA ";
            return LG_aTipoTrabajoMaquina_CD._Instancia.Actualizar_TipoTrabajoMaquina(tipotrabajomaquina);
        }

        public string Eliminar(Int32 idtrabajomaquina)
        {
            return LG_aTipoTrabajoMaquina_CD._Instancia.Eliminar_TipoTrabajoMaquina(idtrabajomaquina);
        }

    }
}
