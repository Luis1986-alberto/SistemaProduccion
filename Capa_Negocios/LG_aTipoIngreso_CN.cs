using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class LG_aTipoIngreso_CN
    {
        public static readonly LG_aTipoIngreso_CN _Instancia = new LG_aTipoIngreso_CN();

        public static LG_aTipoIngreso_CN Instancia
        { get { return LG_aTipoIngreso_CN._Instancia; } }

        public List<LG_aTipoIngreso> Lista_TipoIngreso()
        { return LG_aTipoIngreso_CD._Instancia.Lista_TipoIngresos().ToList(); }

        public IEnumerable<LG_aTipoIngreso> TraerPorID(Int32 id)
        { return LG_aTipoIngreso_CD._Instancia.Traer_TipoIngresoPorId(id); }

        public IEnumerable<LG_aTipoIngreso> Buscar_NombreTipoIngreso(string tipoingreso)
        {
            var lista = LG_aTipoIngreso_CD._Instancia.Lista_TipoIngresos().ToList();
            return from buscar in lista where buscar.Nombre_TipoIngreso == tipoingreso select buscar;
        }

        public string Agregar_TipoIngreso(LG_aTipoIngreso tipoingreso)
        {
            if (Buscar_NombreTipoIngreso(tipoingreso.Nombre_TipoIngreso).Count() > 0) return "TIPO INGRESO YA REGISTRADO ";
            return LG_aTipoIngreso_CD._Instancia.Agregar_TipoIngreso(tipoingreso);
        }

        public string Actualizar_TipoIngreso(LG_aTipoIngreso tipoingreso)
        {
            if (Buscar_NombreTipoIngreso(tipoingreso.Nombre_TipoIngreso).Count() > 0) return "TIPO INGRESO YA REGISTRADO ";
            return LG_aTipoIngreso_CD._Instancia.Actualizar_TipoIngreso(tipoingreso);
        }

        public string Eliminar_TipoIngreso(Int32 idtipoaingreso)
        { return LG_aTipoIngreso_CD._Instancia.Eliminar_TipoIngreso(idtipoaingreso); }


    }
}
