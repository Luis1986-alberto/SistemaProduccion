using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aFabricanteMaterial_CN
    {
        public static readonly PR_aFabricanteMaterial_CN _Instancia = new PR_aFabricanteMaterial_CN();

        public static PR_aFabricanteMaterial_CN Instancia
        { get { return PR_aFabricanteMaterial_CN._Instancia; } }

        public List<PR_aFabricanteMaterial> Lista_Estado_OP()
        { return PR_aFabricanteMaterial_CD._Instancia.Lista_FabricanteMaterial().ToList(); }

        public IEnumerable<PR_aFabricanteMaterial> TraerPorID(byte id)
        { return PR_aFabricanteMaterial_CD._Instancia.Traer_FabricanteMaterialPorId(id); }
        public IEnumerable<PR_aFabricanteMaterial> Buscar_RazonSocial(string razonsocial)
        {
            var lista = PR_aFabricanteMaterial_CD._Instancia.Lista_FabricanteMaterial().ToList();
            return from buscar in lista where buscar.Razon_Social == razonsocial select buscar;
        }

        public string Agregar_EstadoOP(PR_aFabricanteMaterial fabricantematerial)
        {
            if (Buscar_RazonSocial(fabricantematerial.Razon_Social).Count() > 0) return "Existe una Razon Social Registrado";
            return PR_aFabricanteMaterial_CD._Instancia.Agregar_FabricanteMaterial(fabricantematerial);
        }

        public string Actualizar_EstadoOP(PR_aFabricanteMaterial fabricantematerial)
        {
            if (Buscar_RazonSocial(fabricantematerial.Razon_Social).Count() > 0) return "Existe una Razon Social Registrado";
            return PR_aFabricanteMaterial_CD._Instancia.Actualizar_FabricanteMaterial(fabricantematerial);
        }

        public string Eliminar_Estado(Int32 idestadoop)
        { return PR_aEstado_OP_CD._Instancia.Eliminar_EstadoOP(idestadoop); }

    }
}
