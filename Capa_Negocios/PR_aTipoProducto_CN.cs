using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoProducto_CN
    {
        public static readonly PR_aTipoProducto_CN _Instancia = new PR_aTipoProducto_CN();

        public static PR_aTipoProducto_CN Instancia
        { get { return PR_aTipoProducto_CN._Instancia; } }

        public List<PR_aTipoProducto> Lista_TipoProducto()
        { return PR_aTipoProducto_CD._Instancia.Lista_TipoProducto().ToList(); }

        public IEnumerable<PR_aTipoProducto> TraerPorID(Int32 id)
        { return PR_aTipoProducto_CD._Instancia.Traer_TipoProductoPorId(id); }

        public IEnumerable<PR_aTipoProducto> Buscar_NombreTipoProducto(string nombretipoproducto)
        {
           var lista = PR_aTipoProducto_CD._Instancia.Lista_TipoProducto().ToList();
            return from buscar in lista where buscar.Nombre_TipoProducto == nombretipoproducto select buscar;
        }

        public string Agregar_TipoProducto(PR_aTipoProducto tipoproducto)
        {
            if (Buscar_NombreTipoProducto(tipoproducto.Nombre_TipoProducto).Count() > 0) return "EXISTE TIPO PRODUCTO";
            return PR_aTipoProducto_CD._Instancia.Agregar_TipoProducto(tipoproducto);
        }

        public string Actualizar_TipoProducto(PR_aTipoProducto tipoproducto)
        {
            if (Buscar_NombreTipoProducto(tipoproducto.Nombre_TipoProducto).Count() > 0) return "EXISTE TIPO PRODUCTO";
            return PR_aTipoProducto_CD._Instancia.Actualizar_TipoProducto(tipoproducto);
        }

        public string Eliminar_TipoProducto(Int32 idtipoproducto)
        { return PR_aTipoProducto_CD._Instancia.Eliminar_TipoProducto(idtipoproducto); }


    }
}
