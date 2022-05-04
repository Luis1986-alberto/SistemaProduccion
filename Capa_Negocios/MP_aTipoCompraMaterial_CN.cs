using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class MP_aTipoCompraMaterial_CN
    {
        public static readonly MP_aTipoCompraMaterial_CN _Instancia = new MP_aTipoCompraMaterial_CN();

        public static MP_aTipoCompraMaterial_CN Instancia
        { get { return MP_aTipoCompraMaterial_CN._Instancia; } }


        public IEnumerable<MP_aTipoCompraMaterial> Lista_TipoCompraMaterial()
        { return MP_aTipoCompraMaterial_CD._Instancia.Listar_TipoCompraMaterial() ; }


        public MP_aTipoCompraMaterial TraerPorID(Int32 idtipocompramaterial)
        { return MP_aTipoCompraMaterial_CD._Instancia.TraerPorIdTipoCompraMaterial(idtipocompramaterial);}

        public IEnumerable<MP_aTipoCompraMaterial>  Buscar_Tipocompra(string tipocompa)
        {
            var lista = MP_aTipoCompraMaterial_CD._Instancia.Listar_TipoCompraMaterial();
            return lista.Where(x => x.Descripcion_TipoCompra == tipocompa);
        }

        public string Agregar(MP_aTipoCompraMaterial tipoCompramaterial)
        {
            if (Buscar_Tipocompra(tipoCompramaterial.Descripcion_TipoCompra).Count() > 0) return "existe registrado este Tipo Compra";
            return MP_aTipoCompraMaterial_CD._Instancia.Agregar(tipoCompramaterial);
        }

        public string Actualizar(MP_aTipoCompraMaterial tipoCompramaterial)
        {
            if (Buscar_Tipocompra(tipoCompramaterial.Descripcion_TipoCompra).Count() > 0) return "existe registrado este Tipo Compra";
            return MP_aTipoCompraMaterial_CD._Instancia.Actualizar(tipoCompramaterial);
        }

        public string Eliminar(Int32 idtipocompramaterial)
        {
            return MP_aTipoCompraMaterial_CD._Instancia.Eliminar(idtipocompramaterial);
        }



    }
}
