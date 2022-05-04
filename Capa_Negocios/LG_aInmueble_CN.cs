using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aInmueble_CN
    {
        public static readonly LG_aInmueble_CN _Instancia = new LG_aInmueble_CN();

        public static LG_aInmueble_CN Instancia
        { get { return LG_aInmueble_CN._Instancia; } }

        public List<LG_aInmueble> Lista_Inmueble()
        { return LG_aInmueble_CD._Instancia.Lista_Inmuebles().ToList(); }

        public LG_aInmueble traerPorID(int idinmueble)
        { return LG_aInmueble_CD._Instancia.TraerIdInmueble(idinmueble); }

        public IEnumerable<LG_aInmueble> Buscar_CodigoPredial(string codigopredial)
        {
            var lst = LG_aInmueble_CD._Instancia.Lista_Inmuebles();
            return from INM in lst where INM.Codigo_Predio == codigopredial select INM;
        }

        public string Agregar(LG_aInmueble inmueble)
        {
            if (Buscar_CodigoPredial(inmueble.Codigo_Predio).ToList().Count > 0) return "YA EXISTE CODIGO PREDIAL";
            return LG_aInmueble_CD._Instancia.Agregar_Inmueble(inmueble);
        }

        public String Actualizar(LG_aInmueble inmueble)
        {
            if (Buscar_CodigoPredial(inmueble.Codigo_Predio).ToList().Count > 0) return "YA EXISTE EL CODIGO PREDIAL";
            return LG_aInmueble_CD._Instancia.Actualizar_Inmueble(inmueble);
        }

        public string Eliminar(Int32 idinmueble)
        {
            return LG_aInmueble_CD._Instancia.Eliminar_Inmueble(idinmueble);
        }



    }
}
