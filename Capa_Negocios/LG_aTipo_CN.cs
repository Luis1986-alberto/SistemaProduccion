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
    public class LG_aTipo_CN
    {
        public static readonly LG_aTipo_CN _Instancia = new LG_aTipo_CN();

        public static LG_aTipo_CN Instancia
        { get { return LG_aTipo_CN._Instancia; } }

        public IEnumerable<LG_aTipo> Lista_Tipos()
        { return LG_aTipo_CD._Instancia.Lista_Tipos(); }

        public LG_aTipo traerPorID(int idtipo)
        { return LG_aTipo_CD._Instancia.TraerPorIdTipo(idtipo); }

        public IEnumerable<LG_aTipo> Buscar_NombreTipo(string nombretipo)
        {
            var predicado = Predicates.Field<LG_aTipo>(x => x.Nombre_Tipo, Operator.Eq, nombretipo);
            return LG_aTipo_CD._Instancia.FiltroPorunCampo(predicado);
        }

        public string Agregar(LG_aTipo tipo)
        {
            if (Buscar_NombreTipo(tipo.Nombre_Tipo).ToList().Count > 0) return "YA EXISTE TIPO ";
            return LG_aTipo_CD._Instancia.Agregar_Tipo(tipo);
        }

        public String Actualizar(LG_aTipo tipo)
        {
            if (Buscar_NombreTipo(tipo.Nombre_Tipo).ToList().Count > 0) return "YA EXISTE TIPO ";
            return LG_aTipo_CD._Instancia.Actualizar_Tipo(tipo);
        }

        public string Eliminar(Int32 idtipo)
        {
            return LG_aTipo_CD._Instancia.Eliminar_Tipo(idtipo);
        }

    }
}
