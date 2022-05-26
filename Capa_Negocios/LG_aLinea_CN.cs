using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class LG_aLinea_CN
    {
        public static readonly LG_aLinea_CN _Instancia = new LG_aLinea_CN();

        public static LG_aLinea_CN Instancia
        { get { return LG_aLinea_CN._Instancia; } }

        public List<LG_aLinea> Lista_Inmueble()
        { return LG_aLinea_CD._Instancia.Lista_linea().ToList(); }

        public LG_aLinea traerPorID(int idinmueble)
        { return LG_aLinea_CD._Instancia.TraerporIdLinea(idinmueble); }

        public IEnumerable<LG_aLinea> Buscar_NombreLinea(string nombrelinea)
        {
            var predicado = Predicates.Field<LG_aLinea>(x => x.Nombre_Linea, Operator.Eq, nombrelinea);
            return LG_aLinea_CD._Instancia.FiltroPorunCampo(predicado);
        }

        public IEnumerable<LG_aLinea> Buscar_CodigoLinea(string codigolinea)
        {
            var predicado = Predicates.Field<LG_aLinea>(x => x.Codigo_Linea, Operator.Eq, codigolinea);
            return LG_aLinea_CD._Instancia.FiltroPorunCampo(predicado);
        }

        public string Agregar(LG_aLinea linea)
        {
            if (Buscar_NombreLinea(linea.Nombre_Linea).ToList().Count > 0) return "YA EXISTE LALINEA ";
            return LG_aLinea_CD._Instancia.Agregar_Linea(linea);
        }

        public String Actualizar(LG_aLinea linea)
        {
            if (Buscar_NombreLinea(linea.Nombre_Linea).ToList().Count > 0) return "YA EXISTE LA LINEA ";
            return LG_aLinea_CD._Instancia.Actualizar_Linea(linea);
        }

        public string Eliminar(Int32 idlinea)
        {
            return LG_aLinea_CD._Instancia.Eliminar_Linea(idlinea);
        }

    }
}
