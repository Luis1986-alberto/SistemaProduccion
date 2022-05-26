using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class LG_aTipoCosto_CN
    {
        public static readonly LG_aTipoCosto_CN _Instancia = new LG_aTipoCosto_CN();

        public static LG_aTipoCosto_CN Instancia
        { get { return LG_aTipoCosto_CN._Instancia; } }

        public IEnumerable<LG_aTipoCosto> Lista_TipoCosto()
        { return LG_aTipoCosto_CD._Instancia.Lista_TipoCosto(); }

        public LG_aTipoCosto traerPorID(int idtipocosto)
        { return LG_aTipoCosto_CD._Instancia.TraerPorIdTipoCosto(idtipocosto); }

        public IEnumerable<LG_aTipoCosto> Buscar_tipocosto(string nombrecosto)
        {
            var predicado = Predicates.Field<LG_aTipoCosto>(x => x.Nombre_TipoCosto, Operator.Eq, nombrecosto);
            return LG_aTipoCosto_CD._Instancia.FiltroPorunCampo(predicado);
        }

        public string Agregar(LG_aTipoCosto tipocosto)
        {
            if (Buscar_tipocosto(tipocosto.Nombre_TipoCosto).ToList().Count > 0) return "YA EXISTE TIPO COSTO ";
            return LG_aTipoCosto_CD._Instancia.Agregar_TipoCosto(tipocosto);
        }

        public String Actualizar(LG_aTipoCosto tipocosto)
        {
            if (Buscar_tipocosto(tipocosto.Nombre_TipoCosto).ToList().Count > 0) return "YA EXISTE TIPO COSTO ";
            return LG_aTipoCosto_CD._Instancia.Actualizar_TipoCosto(tipocosto);
        }

        public string Eliminar(Int32 idtipocosto)
        {
            return LG_aTipoCosto_CD._Instancia.Eliminar_TipoCosto(idtipocosto);
        }


    }
}
