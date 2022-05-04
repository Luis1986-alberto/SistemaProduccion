using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class LG_aTipoSalida_CN
    {
        public static readonly LG_aTipoSalida_CN _Instancia = new LG_aTipoSalida_CN();

        public static LG_aTipoSalida_CN Instancia
        { get { return LG_aTipoSalida_CN._Instancia; } }

        public List<LG_aTipoSalida> Lista_TipoSalida()
        { return LG_aTipoSalida_CD._Instancia.Lista_TipoSalida().ToList(); }

        public IEnumerable<LG_aTipoSalida> TraerPorID(Int32 id)
        { return LG_aTipoSalida_CD._Instancia.Traer_TipoSalidaPorId(id); }

        public IEnumerable<LG_aTipoSalida> Buscar_TipoSalida(string tiposalidapt)
        {
            var lista = LG_aTipoSalida_CD._Instancia.Lista_TipoSalida().ToList();
            return from buscar in lista where buscar.Nombre_TipoSalida == tiposalidapt select buscar;
        }

        public string Agregar_TipoSalida(LG_aTipoSalida tiposalidapt)
        {
            if (Buscar_TipoSalida(tiposalidapt.Nombre_TipoSalida).Count() > 0) return "EXISTE TIPO SALIDA";
            return LG_aTipoSalida_CD._Instancia.Agregar_TipoSalida(tiposalidapt);
        }

        public string Actualizar_TipoSalida(LG_aTipoSalida tiposalidapt)
        {
            if (Buscar_TipoSalida(tiposalidapt.Nombre_TipoSalida).Count() > 0) return "EXISTE TIPO LAMINACION";
            return LG_aTipoSalida_CD._Instancia.Actualizar_TipoSalida(tiposalidapt);
        }

        public string Eliminar_TipoSalida(Int32 idtiposalidapt)
        { return LG_aTipoSalida_CD._Instancia.Eliminar_TipoSalidaPT(idtiposalidapt); }
    }
}
