using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class LG_aCondicionCobranza_CN
    {
        public static readonly LG_aCondicionCobranza_CN _Instancia = new LG_aCondicionCobranza_CN();

        public static LG_aCondicionCobranza_CN Instancia
        { get { return LG_aCondicionCobranza_CN._Instancia; } }

        public List<LG_aCondicionCobranza> Lista_CondicionCobranza()
        { return LG_aCondicionCobranza_CD._Instancia.Listar().ToList(); }

        public LG_aCondicionCobranza TraerID(byte idcondicionpago)
        { return LG_aCondicionCobranza_CD._Instancia.TraerPorId(idcondicionpago); }

        public IEnumerable<LG_aCondicionCobranza> Buscar_CondicionCobranza(string condicioncobranza)
        {
            var lista = LG_aCondicionCobranza_CD._Instancia.Listar();
            return from Buscar in lista where Buscar.Condicion_Cobranza == condicioncobranza select Buscar;
        }

        public string Agregar_CondicionCobranza(LG_aCondicionCobranza condicioncobranza)
        {
            if (Buscar_CondicionCobranza(condicioncobranza.Condicion_Cobranza).Count() > 0) return "Existe Adhesivo Registrado";
            return LG_aCondicionCobranza_CD._Instancia.Agregar(condicioncobranza);
        }

        public string Actualizar_CondicionCobranza(LG_aCondicionCobranza condicioncobranza)
        {
            if (Buscar_CondicionCobranza(condicioncobranza.Condicion_Cobranza).Count() > 0) return "Existe Adhesivo Registrado";
            return LG_aCondicionCobranza_CD._Instancia.Actualizar(condicioncobranza);
        }

        public string Eliminar_CondicionCobranza(Int32 idcondicioncobranza)
        { return LG_aCondicionCobranza_CD._Instancia.Eliminar(idcondicioncobranza); }
    }
}
