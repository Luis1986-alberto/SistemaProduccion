using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoMaterialExtruir_CN
    {
        public static readonly PR_aTipoMaterialExtruir_CN _Instancia = new PR_aTipoMaterialExtruir_CN();

        public static PR_aTipoMaterialExtruir_CN Instancia
        { get { return PR_aTipoMaterialExtruir_CN._Instancia; } }

        public List<PR_aTipoMaterialExtruir> Lista_TipoMaterialExtruir()
        { return PR_aTipoMaterialExtruir_CD._Instancia.Lista_TipoMaterialExtruir().ToList(); }

        public IEnumerable<PR_aTipoMaterialExtruir> TraerPorID(Int32 id)
        { return PR_aTipoMaterialExtruir_CD._Instancia.Traer_TipoMaterialExtruirPorId(id); }

        public IEnumerable<PR_aTipoMaterialExtruir> Buscar_MaterialExtruir(string descripciontipomaterial)
        {
            var lista = PR_aTipoMaterialExtruir_CD._Instancia.Lista_TipoMaterialExtruir().ToList();
            return from buscar in lista where buscar.Descripcion_MaterialExtruir == descripciontipomaterial select buscar;
        }

        public string Agregar_TipoMaterialExtruir(PR_aTipoMaterialExtruir tipomaterialextruir)
        {
            if (Buscar_MaterialExtruir(tipomaterialextruir.Descripcion_MaterialExtruir).Count() > 0) return "EXISTE TIPO LAMINACION";
            return PR_aTipoMaterialExtruir_CD._Instancia.Agregar_TipoMaterialExtruir(tipomaterialextruir);
        }

        public string Actualizar_TipoMaterialExtruir(PR_aTipoMaterialExtruir tipomaterialextruir)
        {
            if (Buscar_MaterialExtruir(tipomaterialextruir.Descripcion_MaterialExtruir).Count() > 0) return "EXISTE TIPO LAMINACION";
            return PR_aTipoMaterialExtruir_CD._Instancia.Actualizar_TipoMaterialExtruir(tipomaterialextruir);
        }

        public string Eliminar_TipoLaminacion(Int32 idtipomaterialextruir)
        { return PR_aTipoMaterialExtruir_CD._Instancia.Eliminar_TipoMaterialExtruir(idtipomaterialextruir); }
    }
}
