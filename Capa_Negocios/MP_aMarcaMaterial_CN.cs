using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class MP_aMarcaMaterial_CN
    {
        public static readonly MP_aMarcaMaterial_CN _Instancia = new MP_aMarcaMaterial_CN();

        public static MP_aMarcaMaterial_CN Instancia
        { get { return MP_aMarcaMaterial_CN._Instancia; } }

        public IEnumerable<MP_aMarcaMaterial> Listar_MarcaMaterial()
        { return MP_aMarcaMaterial_CD._Instancia.Lista_MarcaMaterial().ToList(); }

        public IEnumerable<MP_aMarcaMaterial> TraerPorID(Int32 idmarcamaterial)
        { return MP_aMarcaMaterial_CD._Instancia.Traer_MarcaMaterialPorId(idmarcamaterial); }

        public IEnumerable<MP_aMarcaMaterial> Buscar_Descripcion(string descripcion)
        {
            var lista = MP_aMarcaMaterial_CD._Instancia.Lista_MarcaMaterial();
            return from MAR in lista where MAR.Descripcion == descripcion select MAR;
        }

        public string Agregar(MP_aMarcaMaterial marcamaterial)
        {
            if (Buscar_Descripcion(marcamaterial.Descripcion).Count() > 0) return "YA EXISTE ESTA MARCA REGISTRADA";
            return MP_aMarcaMaterial_CD._Instancia.Agregar_MarcaMaterial(marcamaterial);
        }

        public string Actualizar(MP_aMarcaMaterial marcamaterial)
        {
            if (Buscar_Descripcion(marcamaterial.Descripcion).Count() > 0) return "YA EXISTE ESTA MARCA REGISTRADA";
            return MP_aMarcaMaterial_CD._Instancia.Actualizar_MarcaMaterial(marcamaterial);
        }

        public string Eliminar(Int32 idmarcamaterial)
        {
            return MP_aMarcaMaterial_CD._Instancia.Eliminar_MarcaMaterial(idmarcamaterial);
        }


    }
}
