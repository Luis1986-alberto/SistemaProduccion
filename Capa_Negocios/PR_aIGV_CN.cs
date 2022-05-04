using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aIGV_CN
    {
        public static readonly PR_aIGV_CN _Instancia = new PR_aIGV_CN();

        public static PR_aIGV_CN Instancia
        { get { return PR_aIGV_CN._Instancia; } }

        public List<PR_aIGV> Lista_IGV()
        { return PR_aIGV_CD._Instancia.Lista_Igv().ToList(); }

        public IEnumerable<PR_aIGV> TraerPorID(Int32 id)
        { return PR_aIGV_CD._Instancia.Traer_IGVPorId(id); }

        public IEnumerable<PR_aIGV> Buscar_Porcentaje(decimal porcentaje)
        {
            var lista = PR_aIGV_CD._Instancia.Lista_Igv().ToList();
            return from buscar in lista where buscar.Porcentaje == porcentaje select buscar;
        }

        public string Agregar_IGV(PR_aIGV igv)
        {
            if (Buscar_Porcentaje(igv.Porcentaje).Count() > 0) return "Existe el porcentaje Registrado";
            return PR_aIGV_CD._Instancia.Agregar_Igv(igv);
        }

        public string Actualizar_IGV(PR_aIGV igv)
        {
            return PR_aIGV_CD._Instancia.Actualizar_IGV(igv);
        }

        public string Eliminar_IGV(Int32 igv)
        { return PR_aIGV_CD._Instancia.Eliminar_IGV(igv); }

    }
}
