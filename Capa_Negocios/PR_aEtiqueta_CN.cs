using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aEtiqueta_CN
    {
        public static readonly PR_aEtiqueta_CN _Instancia = new PR_aEtiqueta_CN();

        public static PR_aEtiqueta_CN Instancia
        { get { return PR_aEtiqueta_CN._Instancia; } }

        public List<PR_aEtiqueta> Lista_Etiqueta()
        { return PR_aEtiqueta_CD._Instancia.Lista_Etiquetas().ToList(); }

        public IEnumerable<PR_aEtiqueta> TraerPorID(byte id)
        { return PR_aEtiqueta_CD._Instancia.Traer_EtiquetaPorId(id); }

        public IEnumerable<PR_aEtiqueta> Buscar_Descripcion(string descripcion)
        {
            var lst = PR_aEtiqueta_CD._Instancia.Lista_Etiquetas().ToList();
            return from AD in lst where AD.Descripcion == descripcion select AD;
        }

        public string Agregar_Etiqueta(PR_aEtiqueta etiqueta)
        {
            if (Buscar_Descripcion(etiqueta.Descripcion).Count() > 0) return "Existe una etiqueta Registrado";
            return PR_aEtiqueta_CD._Instancia.Agregar_Etiqueta(etiqueta);
        }

        public string Actualizar_Etiqueta(PR_aEtiqueta etiqueta)
        {
            if (Buscar_Descripcion(etiqueta.Descripcion).Count() > 0) return "Existe una etiqueta Registrado";
            return PR_aEtiqueta_CD._Instancia.Actualizar_Etiqueta(etiqueta);
        }

        public string Eliminar_Etiqueta(Int32 idetiqueta)
        { return PR_aEtiqueta_CD._Instancia.Eliminar_Etiqueta(idetiqueta); }


    }
}
