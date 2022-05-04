using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aUsoProducto_CN
    {
        public static readonly PR_aUsoProducto_CN _Instancia = new PR_aUsoProducto_CN();

        public static PR_aUsoProducto_CN Instancia
        { get { return PR_aUsoProducto_CN._Instancia; } }

        public List<PR_aUsoProducto> Lista_UsoProducto()
        { return PR_aUsoProducto_CD._Instancia.Lista_UsoProductos().ToList(); }

        public IEnumerable<PR_aUsoProducto> TraerPorID(Int32 id)
        { return PR_aUsoProducto_CD._Instancia.Traer_UsoProductoPorId(id); }

        public IEnumerable<PR_aUsoProducto> Buscar_Descripcion(string usoproducto)
        {
            var lista = PR_aUsoProducto_CD._Instancia.Lista_UsoProductos().ToList();
            return from buscar in lista where buscar.Descripcion_UsoProducto == usoproducto select buscar;
        }

        public string Agregar_UsoProducto(PR_aUsoProducto usoproducto)
        {
            if (Buscar_Descripcion(usoproducto.Descripcion_UsoProducto).Count() > 0) return "EXISTE USO PRODUCTO";
            return PR_aUsoProducto_CD._Instancia.Agregar_UsoProducto(usoproducto);
        }

        public string Actualizar_UsoProducto(PR_aUsoProducto usoproducto)
        {
            if (Buscar_Descripcion(usoproducto.Descripcion_UsoProducto).Count() > 0) return "EXISTE USO PRODUCTO";
            return PR_aUsoProducto_CD._Instancia.Actualizar_UsoProducto(usoproducto);
        }

        public string Eliminar_UsoProducto(Int32 idusoproducto)
        { return PR_aUsoProducto_CD._Instancia.Eliminar_UsoProducto(idusoproducto); }
    }
}
