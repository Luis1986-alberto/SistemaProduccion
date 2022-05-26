using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aCarreta_CN
    {
        public static readonly PR_aCarreta_CN _Instancia = new PR_aCarreta_CN();

        public static PR_aCarreta_CN Instancia
        { get { return PR_aCarreta_CN._Instancia; } }

        public List<PR_aCarreta> Lista_Carretas()
        { return PR_aCarreta_CD._Instancia.Lista_carretas().ToList(); }

        public IEnumerable<PR_aCarreta> TraerID(byte idcarreta)
        { return PR_aCarreta_CD._Instancia.Traer_CarretaPorId(idcarreta); }

        public IEnumerable<PR_aCarreta> Buscar_Nombre(decimal descripcion)
        {
            var lst = PR_aCarreta_CD._Instancia.Lista_carretas().ToList();
            return from AD in lst where AD.Pesos_Kilos == descripcion select AD;
        }

        public string Agregar_Carreta(PR_aCarreta carreta)
        {
            if (Buscar_Nombre(carreta.Pesos_Kilos).Count() > 0) return "Existe Peso Registrado";
            return PR_aCarreta_CD._Instancia.Agregar_Carretas(carreta);
        }

        public string Actualizar_Carreta(PR_aCarreta carreta)
        {
            if (Buscar_Nombre(carreta.Pesos_Kilos).Count() > 0) return "Existe Peso Registrado";
            return PR_aCarreta_CD._Instancia.Actualizar_Carretas(carreta);
        }

        public string Eliminar_Carreta(Int32 idcarreta)
        { return PR_aCarreta_CD._Instancia.Eliminar_Carretas(idcarreta); }
    }
}
