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
    public class LG_aTipoDocumento_CN
    {
        public static readonly LG_aTipoDocumento_CN _Instancia = new LG_aTipoDocumento_CN();

        public static LG_aTipoDocumento_CN Instancia
        { get { return LG_aTipoDocumento_CN._Instancia; } }

        public IEnumerable<LG_aTipoDocumento> Lista_TipoDocumento()
        { return LG_aTipoDocumento_CD._Instancia.Lista_TipoDocumento(); }

        public LG_aTipoDocumento traerPorID(int idtipodocumento)
        { return LG_aTipoDocumento_CD._Instancia.traerPorIdTipoDocumento(idtipodocumento); }

        public IEnumerable<LG_aTipoDocumento> Buscar_TipoDocumento(string tipodocumento)
        {
            var predicado = Predicates.Field<LG_aTipoDocumento>(x => x.Nombre_TipoDocumento, Operator.Eq, tipodocumento);
            return LG_aTipoDocumento_CD._Instancia.FiltroPorunCampo(predicado);
        }

        public string Agregar(LG_aTipoDocumento tipodocumento)
        {
            if (Buscar_TipoDocumento(tipodocumento.Nombre_TipoDocumento).ToList().Count > 0) return "YA EXISTE TIPO DOCUMENTO ";
            return LG_aTipoDocumento_CD._Instancia.Agregar_TipoDocumento(tipodocumento);
        }

        public String Actualizar(LG_aTipoDocumento tipodocumento)
        {
            if (Buscar_TipoDocumento(tipodocumento.Nombre_TipoDocumento).ToList().Count > 0) return "YA EXISTE TIPO COSTO ";
            return LG_aTipoDocumento_CD._Instancia.Actualizar_TipoDocumento(tipodocumento);
        }

        public string Eliminar(Int32 idtipodocumento)
        {
            return LG_aTipoDocumento_CD._Instancia.Eliminar_TipoDocumento(idtipodocumento);
        }

    }
}
