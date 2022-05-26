using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class LG_aMes_CN
    {
        public static readonly LG_aMes_CN _Instancia = new LG_aMes_CN();

        public static LG_aMes_CN Instancia
        { get { return LG_aMes_CN._Instancia; } }

        public IEnumerable<LG_aMes> Lista_Mes()
        { return LG_aMes_CD._Instancia.Lista_Mes(); }

        public LG_aMes traerPorID(int idmes)
        { return LG_aMes_CD._Instancia.TraerporIdMes(idmes); }

        public IEnumerable<LG_aMes> Buscar_Mes(string mes)
        {
            var predicado = Predicates.Field<LG_aMes>(x => x.Mes, Operator.Eq, mes);
            return LG_aMes_CD._Instancia.FiltroPorunCampo(predicado);
        }

        public string Agregar(LG_aMes mes)
        {
            if (Buscar_Mes(mes.Mes).ToList().Count > 0) return "YA EXISTE MES ";
            return LG_aMes_CD._Instancia.Agregar_Mes(mes);
        }

        public String Actualizar(LG_aMes mes)
        {
            if (Buscar_Mes(mes.Mes).ToList().Count > 0) return "YA EXISTE MES ";
            return LG_aMes_CD._Instancia.Actualizar_Mes(mes);
        }

        public string Eliminar(Int32 idmes)
        {
            return LG_aMes_CD._Instancia.Eliminar_mes(idmes);
        }


    }
}
