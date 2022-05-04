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
    public class LG_aTipoInmueble_CN
    {
        public static readonly LG_aTipoInmueble_CN _Instancia = new LG_aTipoInmueble_CN();

        public static LG_aTipoInmueble_CN Instancia
        { get { return LG_aTipoInmueble_CN._Instancia; } }

        public IEnumerable<LG_aTipoInmueble> Lista_TipoInmueble()
        { return LG_aTipoInmueble_CD._Instancia.Listar_TipoInmueble(); }

        public LG_aTipoInmueble traerPorID(int idinmueble)
        { return LG_aTipoInmueble_CD._Instancia.TraerPorIdInmueble(idinmueble); }

        public IEnumerable<LG_aTipoInmueble> Buscar_TipoInmueble(string tipoinmueble)
        {
            var predicado = Predicates.Field<LG_aTipoInmueble>(x => x.Tipo_Inmueble, Operator.Eq, tipoinmueble);
            return LG_aTipoInmueble_CD._Instancia.FiltroPorunCampo(predicado);
        }

        public string Agregar(LG_aTipoInmueble tipoinmueble)
        {
            if (Buscar_TipoInmueble(tipoinmueble.Tipo_Inmueble).ToList().Count > 0) return "YA EXISTE TIPO INMUEBLE ";
            return LG_aTipoInmueble_CD._Instancia.Agregar_TipoInmueble(tipoinmueble);
        }

        public String Actualizar(LG_aTipoInmueble tipoinmueble)
        {
            if (Buscar_TipoInmueble(tipoinmueble.Tipo_Inmueble).ToList().Count > 0) return "YA EXISTE TIPO INMUEBLE ";
            return LG_aTipoInmueble_CD._Instancia.Actualizar_TipoInmueble(tipoinmueble);
        }

        public string Eliminar(Int32 idtipoinmueble)
        {
            return LG_aTipoInmueble_CD._Instancia.Eliminar_TipoInmueble(idtipoinmueble);
        }
    }
}
