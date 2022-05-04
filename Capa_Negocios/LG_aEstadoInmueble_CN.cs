using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aEstadoInmueble_CN
    {
        public static readonly LG_aEstadoInmueble_CN _Instancia = new LG_aEstadoInmueble_CN();

        public static LG_aEstadoInmueble_CN Instancia
        { get { return LG_aEstadoInmueble_CN._Instancia; } }

        public List<LG_aEstadoInmueble> Lista_EstadoInmueble()
        { return LG_aEstadoInmueble_CD._Instancia.Lista_estadoInmueble().ToList(); }

        public LG_aEstadoInmueble TraerPorID(int idestadoinmuble)
        { return LG_aEstadoInmueble_CD._Instancia.TraerporIDEstadoInmueble(idestadoinmuble); }

        public IEnumerable<LG_aEstadoInmueble> Buscar_EstadoInmueble(string estadoinmueble)
        {
            var lst = LG_aEstadoInmueble_CD._Instancia.Lista_estadoInmueble();
            return from EST in lst where EST.Estado_Inmueble == estadoinmueble select EST;
        }

        public string Agregar(LG_aEstadoInmueble estadoinmueble)
        {
            if (Buscar_EstadoInmueble(estadoinmueble.Estado_Inmueble).ToList().Count > 0) return "YA EXISTE ESTADO INMUEBLE";
            return LG_aEstadoInmueble_CD._Instancia.Agregar_EstadoInmueble(estadoinmueble);
        }

        public String Actualizar(LG_aEstadoInmueble estadoinmueble)
        {
            if (Buscar_EstadoInmueble(estadoinmueble.Estado_Inmueble).ToList().Count > 0) return "YA EXISTE EL ESTADO INMUEBLE";
            return LG_aEstadoInmueble_CD._Instancia.Actualizar_EstadoInmueble(estadoinmueble);
        }

        public string Eliminar(Int32 idestadoinmueble)
        {
            return LG_aEstadoInmueble_CD._Instancia.Eliminar_Estadoinmueble(idestadoinmueble);
        }

    }
}
