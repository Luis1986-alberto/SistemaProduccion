using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aEstadoSolicitud_CN
    {
        public static readonly LG_aEstadoSolicitud_CN _Instancia = new LG_aEstadoSolicitud_CN();

        public static LG_aEstadoSolicitud_CN Instancia
        { get { return LG_aEstadoSolicitud_CN._Instancia; } }

        public List<LG_aEstadoSolicitud> Lista_EstadoSolicitud()
        { return LG_aEstadoSolicitud_CD._Instancia.Lista_EstadoSolicitud().ToList(); }

        public LG_aEstadoSolicitud traerPorID(int idestadosolicitud)
        { return LG_aEstadoSolicitud_CD._Instancia.TraerporIDEstadoSolicitud(idestadosolicitud); }

        public IEnumerable<LG_aEstadoSolicitud> Buscar_EstadoSolicitud(string estadosolicitud)
        {
            var lst = LG_aEstadoSolicitud_CD._Instancia.Lista_EstadoSolicitud();
            return from ESS in lst where ESS.Descripcion_EstadoSolicitud == estadosolicitud select ESS;
        }

        public string Agregar(LG_aEstadoSolicitud estadosolicitud)
        {
            if (Buscar_EstadoSolicitud(estadosolicitud.Descripcion_EstadoSolicitud).ToList().Count > 0) return "YA EXISTE ESTADO SOLICITUD";
            return LG_aEstadoSolicitud_CD._Instancia.Agregar_EstadoSolicitud(estadosolicitud);
        }

        public String Actualizar(LG_aEstadoSolicitud estadosolicitud)
        {
            if (Buscar_EstadoSolicitud(estadosolicitud.Descripcion_EstadoSolicitud).ToList().Count > 0) return "YA EXISTE EL ESTADO INMUEBLE";
            return LG_aEstadoSolicitud_CD._Instancia.Actualizar_EstadoSolicitud(estadosolicitud);
        }

        public string Eliminar(Int32 idestadosolicitud)
        {
            return LG_aEstadoSolicitud_CD._Instancia.Eliminar_EstadoSolicitud(idestadosolicitud);
        }



    }
}
