using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoMoneda_CN
    {
        public static readonly PR_aTipoMoneda_CN _Instancia = new PR_aTipoMoneda_CN();

        public static PR_aTipoMoneda_CN Instancia
        { get { return PR_aTipoMoneda_CN._Instancia; } }

        public List<PR_aTipoMoneda> Lista_TipoMoneda()
        { return PR_aTipoMoneda_CD._Instancia.Lista_TipoMoneda().ToList(); }

        public IEnumerable<PR_aTipoMoneda> TraerPorID(Int32 id)
        { return PR_aTipoMoneda_CD._Instancia.Traer_TipoMOnedaPorId(id); }

        public IEnumerable<PR_aTipoMoneda> Buscar_TipoMoneda(string tipomoneda)
        {
            var lista = PR_aTipoMoneda_CD._Instancia.Lista_TipoMoneda().ToList();
            return from buscar in lista where buscar.Tipo_Moneda == tipomoneda select buscar;
        }

        public string Agregar_TipoMoneda(PR_aTipoMoneda tipomoneda)
        {
            if (Buscar_TipoMoneda(tipomoneda.Tipo_Moneda).Count() > 0) return "EXISTE TIPO MONEDA";
            return PR_aTipoMoneda_CD._Instancia.Agregar_TipoMoneda(tipomoneda);
        }

        public string Actualizar_TipoMoneda(PR_aTipoMoneda tipomoneda)
        {
            if (Buscar_TipoMoneda(tipomoneda.Tipo_Moneda).Count() > 0) return "EXISTE TIPO MONEDA";
            return PR_aTipoMoneda_CD._Instancia.Actualizar_TipoMoneda(tipomoneda);
        }

        public string Eliminar_TipoMoneda(Int32 idtipomoneda)
        { return PR_aTipoMoneda_CD._Instancia.Eliminar_TipoMoneda(idtipomoneda); }
    }
}
