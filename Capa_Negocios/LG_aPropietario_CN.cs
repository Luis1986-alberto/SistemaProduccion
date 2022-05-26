using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class LG_aPropietario_CN
    {
        public static readonly LG_aPropietario_CN _Instancia = new LG_aPropietario_CN();

        public static LG_aPropietario_CN Instancia
        { get { return LG_aPropietario_CN._Instancia; } }

        public IEnumerable<LG_aPropietario> Lista_Propietario()
        { return LG_aPropietario_CD._Instancia.Lista_Propietarios(); }

        public LG_aPropietario traerPorID(int idpropietario)
        { return LG_aPropietario_CD._Instancia.TraerPorIdPropietario(idpropietario); }

        public IEnumerable<LG_aPropietario> Buscar_nombrecompleto(string nombrecompleto)
        {
            var predicado = Predicates.Field<LG_aPropietario>(x => x.Nombre_Completo, Operator.Eq, nombrecompleto);
            return LG_aPropietario_CD._Instancia.FiltroPorunCampo(predicado);
        }

        public string Agregar(LG_aPropietario propietario)
        {
            if (Buscar_nombrecompleto(propietario.Nombre_Completo).ToList().Count > 0) return "YA EXISTE PROPIETARIO ";
            return LG_aPropietario_CD._Instancia.Agregar_Propietario(propietario);
        }

        public String Actualizar(LG_aPropietario propietario)
        {
            if (Buscar_nombrecompleto(propietario.Nombre_Completo).ToList().Count > 0) return "YA EXISTE PROPIETARIO ";
            return LG_aPropietario_CD._Instancia.Actualizar_Propietario(propietario);
        }

        public string Eliminar(Int32 idpropietario)
        {
            return LG_aPropietario_CD._Instancia.Eliminar_Propietario(idpropietario);
        }

    }
}
