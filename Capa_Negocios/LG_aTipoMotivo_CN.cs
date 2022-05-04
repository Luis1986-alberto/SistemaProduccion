using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aTipoMotivo_CN
    {
        public static readonly LG_aTipoMotivo_CN _Instancia = new LG_aTipoMotivo_CN();

        public static LG_aTipoMotivo_CN Instancia
        { get { return LG_aTipoMotivo_CN._Instancia; } }

        public IEnumerable<LG_aTipoMotivo> Lista_TipoMotivo()
        { return LG_aTipoMotivo_CD._Instancia.Listar_TipoMotivo(); }

        public LG_aTipoMotivo traerPorID(int idmotivo)
        { return LG_aTipoMotivo_CD._Instancia.TraerPorIdMotivo(idmotivo); }

        public IEnumerable<LG_aTipoMotivo> Buscar_TipoMotivo(string tipomotivo)
        {
            var predicado = Predicates.Field<LG_aTipoMotivo>(x => x.TipoMotivo, Operator.Eq, tipomotivo);
            return LG_aTipoMotivo_CD._Instancia.FiltroPorunCampo(predicado);
        }

        public string Agregar(LG_aTipoMotivo tipomotivo)
        {
            if (Buscar_TipoMotivo(tipomotivo.TipoMotivo).ToList().Count > 0) return "YA EXISTE TIPO MOTIVO ";
            return LG_aTipoMotivo_CD._Instancia.Agregar_TipoMotivo(tipomotivo);
        }

        public String Actualizar(LG_aTipoMotivo tipomotivo)
        {
            if (Buscar_TipoMotivo(tipomotivo.TipoMotivo).ToList().Count > 0) return "YA EXISTE TIPO MOTIVO ";
            return LG_aTipoMotivo_CD._Instancia.Actualizar_TipoMotivo(tipomotivo);
        }

        public string Eliminar(Int32 idtipomotivo)
        {
            return LG_aTipoMotivo_CD._Instancia.Eliminar_TipoMotivo(idtipomotivo);
        }


    }
}
