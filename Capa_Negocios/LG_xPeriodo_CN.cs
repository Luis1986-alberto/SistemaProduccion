using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class LG_xPeriodo_CN
    {
        public static readonly LG_xPeriodo_CN _Instancia = new LG_xPeriodo_CN();

        public static LG_xPeriodo_CN Instancia
        { get { return LG_xPeriodo_CN._Instancia; } }

        public List<LG_xPeriodo> Lista_Periodo()
        {
            return LG_xPeriodo_CD._Instacia.Lista_Periodo().ToList();
        }

        public LG_xPeriodo TraerPorID(Int32 idperiodo)
        {
            return LG_xPeriodo_CD._Instacia.TraerPorIdPeriodo(idperiodo);
        }

        public LG_xPeriodo TraerPorPeriodo(string periodo)
        {
            var lista = LG_xPeriodo_CD._Instacia.Lista_Periodo();
            return lista.FirstOrDefault(x => x.Nombre_Periodo == periodo);
        }
        public string Agregar_Periodo(LG_xPeriodo periodo)
        {
            if (TraerPorPeriodo(periodo.Nombre_Periodo) != null) return "Existe el Periodo Registrado";
            else return LG_xPeriodo_CD._Instacia.Agregar_Periodo(periodo);
        }

        public string Actualizar_Periodo(LG_xPeriodo periodo)
        {
            if (TraerPorPeriodo(periodo.Nombre_Periodo) != null) return "Existe el Periodo Registrado";
            else return LG_xPeriodo_CD._Instacia.Actualizar_Periodo(periodo);
        }

        public string Eliminar_Periodo(Int32 idperiodo)
        {
            return LG_xPeriodo_CD._Instacia.Eliminar_Periodo(idperiodo);
        }



    }
}
