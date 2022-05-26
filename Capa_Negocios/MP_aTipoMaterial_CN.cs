using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class MP_aTipoMaterial_CN
    {
        public static readonly MP_aTipoMaterial_CN _Instancia = new MP_aTipoMaterial_CN();

        public static MP_aTipoMaterial_CN Instancia
        { get { return MP_aTipoMaterial_CN._Instancia; } }

        public IEnumerable<MP_aTipoMaterial> Lista_TipoMateriales()
        { return MP_aTipoMaterial_CD._Instancia.Lista_TipoMaterial(); }

        public MP_aTipoMaterial traerPorID(Int32 idtipomaterial)
        { return MP_aTipoMaterial_CD._Instancia.TipoMaterialPorId(idtipomaterial); }

        public IEnumerable<MP_aTipoMaterial> FiltrarPorDescripcion(string descripcion)
        {
            var lista = MP_aTipoMaterial_CD._Instancia.Lista_TipoMaterial();
            return from TM in lista where TM.Descripcion == descripcion select TM;
        }

        public string Agregar(MP_aTipoMaterial tipomaterial)
        {
            if (FiltrarPorDescripcion(tipomaterial.Descripcion).Count() > 0) return "EXISTE TIPO MATERIAL REGISTRADO";
            return MP_aTipoMaterial_CD._Instancia.Agregar_TipoMaterial(tipomaterial);
        }

        public string Actualizar(MP_aTipoMaterial tipomaterial)
        {
            if (FiltrarPorDescripcion(tipomaterial.Descripcion).Count() > 0) return "EXISTE ESTE TIPO MATERIAL REGISTRADO";
            return MP_aTipoMaterial_CD._Instancia.Actualizar_TipoMaterial(tipomaterial);
        }

        public string Eliminar(int idtipomaterial)
        {
            return MP_aTipoMaterial_CD._Instancia.Eliminar_TipoMaterial(idtipomaterial);
        }


    }
}
