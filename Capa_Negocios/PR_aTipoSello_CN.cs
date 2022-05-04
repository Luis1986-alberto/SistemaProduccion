using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoSello_CN
    {
        public static readonly PR_aTipoSello_CN _Instancia = new PR_aTipoSello_CN();

        public static PR_aTipoSello_CN Instancia
        { get { return PR_aTipoSello_CN._Instancia; } }

        public List<PR_aTipoSello> Lista_TipoSello()
        { return PR_aTipoSello_CD._Instancia.Lista_TipoSello().ToList(); }

        public IEnumerable<PR_aTipoSello> TraerPorID(Int32 id)
        { return PR_aTipoSello_CD._Instancia.Traer_TipoSelloPorId(id); }

        public IEnumerable<PR_aTipoSello> Buscar_TipoSello(string tiposello)
        {
           var lista = PR_aTipoSello_CD._Instancia.Lista_TipoSello().ToList();
            return from buscar in lista where buscar.Descripcion_TipoSello == tiposello select buscar;
        }

        public string Agregar_TipoSello(PR_aTipoSello tiposello)
        {
            if (Buscar_TipoSello(tiposello.Descripcion_TipoSello).Count() > 0) return "EXISTE TIPO SELLO";
            return PR_aTipoSello_CD._Instancia.Agregar_TipoSello(tiposello);
        }

        public string Actualizar_TipoSello(PR_aTipoSello tiposello)
        {
            if (Buscar_TipoSello(tiposello.Descripcion_TipoSello).Count() > 0) return "EXISTE TIPO SELLO";
            return PR_aTipoSello_CD._Instancia.Actualizar_TipoSello(tiposello);
        }

        public string Eliminar_TipoSello(Int32 idtiposello)
        { return PR_aTipoSello_CD._Instancia.Eliminar_TipoSello(idtiposello); }
    }
}
