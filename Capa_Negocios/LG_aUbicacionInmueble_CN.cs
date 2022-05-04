using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aUbicacionInmueble_CN
    {
        public static readonly LG_aUbicacionInmueble_CN Instancia = new LG_aUbicacionInmueble_CN();

        public static LG_aUbicacionInmueble_CN _Instancia
        { get { return LG_aUbicacionInmueble_CN.Instancia; } }

        public List<LG_aUbicacionInmueble> Lista_UbicacionInmueble()
        { return LG_aUbicacionInmueble_CD._Instancia.Listar().ToList(); }

        public LG_aUbicacionInmueble traerPorID(int idubicacioninmueble)
        { return LG_aUbicacionInmueble_CD._Instancia.TraerPorId(idubicacioninmueble); }

        public IEnumerable<LG_aUbicacionInmueble> Buscar_Distrito(string distrito)
        {
            var lst = LG_aUbicacionInmueble_CD._Instancia.Listar().ToList();
            return from buscar in lst where buscar.Nombre_Distrito == distrito select buscar;
        }

        public string Agregar(LG_aUbicacionInmueble ubicacion)
        {
            if (Buscar_Distrito(ubicacion.Nombre_Distrito).ToList().Count > 0) return "YA EXISTE EL CONCEPTO";
            return LG_aUbicacionInmueble_CD._Instancia.Agregar(ubicacion);
        }

        public String Actualizar(LG_aUbicacionInmueble ubicacion)
        {
            if (Buscar_Distrito(ubicacion.Nombre_Distrito).ToList().Count > 0) return "YA EXISTE EL CONCEPTO";
            return LG_aUbicacionInmueble_CD._Instancia.Actualizar(ubicacion);
        }

        public string Eliminar(Int32 idubicacion)
        {
            return LG_aUbicacionInmueble_CD._Instancia.Eliminar(idubicacion);
        }
    }
}
