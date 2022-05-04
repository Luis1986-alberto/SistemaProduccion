using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aFormaPago_CN
    {
        public static readonly LG_aFormaPago_CN _Instancia = new LG_aFormaPago_CN();

        public static LG_aFormaPago_CN Instancia
        { get { return LG_aFormaPago_CN._Instancia; } }

        public List<LG_aFormaPago> Lista_FormaPago()
        { return LG_aFormaPago_CD._Instancia.Lista_FormaPgo().ToList(); }

        public LG_aFormaPago TraerPorID(int idformapago)
        { return LG_aFormaPago_CD._Instancia.TraerPorIdFormaPgo(idformapago); }

        public IEnumerable<LG_aFormaPago> Buscar_FormaPago(string formapago)
        {
            var lst = LG_aFormaPago_CD._Instancia.Lista_FormaPgo();
            return from FP in lst where FP.Nombre_FormaPago == formapago select FP;
        }

        public string Agregar(LG_aFormaPago formapago)
        {
            if (Buscar_FormaPago(formapago.Nombre_FormaPago).ToList().Count > 0) return "YA EXISTE FORMA PAGO ";
            return LG_aFormaPago_CD._Instancia.Agregar_FormaPago(formapago);
        }

        public String Actualizar(LG_aFormaPago formapago)
        {
            if (Buscar_FormaPago(formapago.Nombre_FormaPago).ToList().Count > 0) return "YA EXISTE FORMA PAGO ";
            return LG_aFormaPago_CD._Instancia.Actualizar_FormaPago(formapago);
        }

        public string Eliminar(Int32 idformapago)
        {
            return LG_aFormaPago_CD._Instancia.Eliminar_FormaPago(idformapago);
        }


    }
}
