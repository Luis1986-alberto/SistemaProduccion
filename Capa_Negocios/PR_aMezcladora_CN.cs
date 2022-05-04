using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aMezcladora_CN
    {
        public static readonly PR_aMezcladora_CN _Instancia = new PR_aMezcladora_CN();

        public static PR_aMezcladora_CN Instancia
        { get { return PR_aMezcladora_CN._Instancia; } }

        public List<PR_aMezcladora> Lista_Mezcladora()
        { return PR_aMezcladora_CD._Instancia.Lista_Mezcladora().ToList(); }

        public IEnumerable<PR_aMezcladora> TraerPorID(Int32 id)
        { return PR_aMezcladora_CD._Instancia.Traer_MezcladoraPorId(id); }

        public IEnumerable<PR_aMezcladora> Buscar_NombreMezcladora(string nombremezclado)
        {
            var lista = PR_aMezcladora_CD._Instancia.Lista_Mezcladora().ToList();
            return from buscar in lista where buscar.Nombre_Mezcladora == nombremezclado select buscar;
        }

        public string Agregar_Mezcladora(PR_aMezcladora mezcladora)
        {
            if (Buscar_NombreMezcladora(mezcladora.Nombre_Mezcladora).Count() > 0) return "Existe la Mezcladora Registrado";
            return PR_aMezcladora_CD._Instancia.Agregar_Mezcladora(mezcladora);
        }

        public string Actualizar_Mezcladora(PR_aMezcladora mezcladora)
        {
            if (Buscar_NombreMezcladora(mezcladora.Nombre_Mezcladora).Count() > 0) return "Existe la Mezcladora Registrado";
            return PR_aMezcladora_CD._Instancia.Actualizar_Mezcladora(mezcladora);
        }

        public string Eliminar_Mezcladora(Int32 idmezcladora)
        { return PR_aMezcladora_CD._Instancia.Eliminar_Mezcladora(idmezcladora); }

    }
}
