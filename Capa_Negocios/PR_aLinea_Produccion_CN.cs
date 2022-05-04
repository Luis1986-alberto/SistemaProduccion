using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aLinea_Produccion_CN
    {
        public static readonly PR_aLinea_Produccion_CN _Instancia = new PR_aLinea_Produccion_CN();

        public static PR_aLinea_Produccion_CN Instancia
        { get { return PR_aLinea_Produccion_CN._Instancia; } }

        public List<PR_aLinea_Produccion> Lista_LineaProduccion()
        { return PR_aLinea_Produccion_CD._Instancia.Lista_LineaProduccion().ToList(); }

        public IEnumerable<PR_aLinea_Produccion> TraerPorID(Int32 id)
        { return PR_aLinea_Produccion_CD._Instancia.Traer_LineaProduccionPorId(id); }

        public IEnumerable<PR_aLinea_Produccion> Buscar_Descripcionlinea(string descripcionlinea)
        {
            var lista = PR_aLinea_Produccion_CD._Instancia.Lista_LineaProduccion().ToList();
            return from buscar in lista where buscar.Descripcion_Linea == descripcionlinea select buscar;
        }

        public string Agregar_LineaProduccion(PR_aLinea_Produccion lineaproduccion)
        {
            if (Buscar_Descripcionlinea(lineaproduccion.Descripcion_Linea).Count() > 0) return "Existe una Linea Produccion Registrado";
            return PR_aLinea_Produccion_CD._Instancia.Agregar_LineaProduccion(lineaproduccion);
        }

        public string Actualizar_LineaProduccion(PR_aLinea_Produccion lineaproduccion)
        {
            if (Buscar_Descripcionlinea(lineaproduccion.Descripcion_Linea).Count() > 0) return "Existe una Linea Produccion Registrado";
            return PR_aLinea_Produccion_CD._Instancia.Actualizar_LineaProduccion(lineaproduccion);
        }

        public string Eliminar_LineaProduccion(Int32 idlineaprod)
        { return PR_aLinea_Produccion_CD._Instancia.Eliminar_LineaProduccion(idlineaprod); }

    }
}
