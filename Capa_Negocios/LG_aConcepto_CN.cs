using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aConcepto_CN
    {
        public static readonly LG_aConcepto_CN Instancia = new LG_aConcepto_CN();

        public static LG_aConcepto_CN _Instancia
        { get { return LG_aConcepto_CN.Instancia; } }

        public List<LG_aConcepto> Lista_Concepto()
        { return LG_aConcepto_CD._Instancia.Lista_Concepto().ToList(); }

        public LG_aConcepto traerPorID(int idaidconcepto)
        { return LG_aConcepto_CD._Instancia.TraerPorIdConcepto(idaidconcepto); }

        public IEnumerable<LG_aConcepto> Buscar_TipoConcepto(string tipoconcepto)
        {
            var lst = LG_aConcepto_CD._Instancia.Lista_Concepto().ToList();
            return from CON in lst where CON.Tipo_Concepto == tipoconcepto select CON;
        }

        public string Agregar(LG_aConcepto concepto)
        {
            if (Buscar_TipoConcepto(concepto.Tipo_Concepto).ToList().Count > 0) return "YA EXISTE EL CONCEPTO";
            return LG_aConcepto_CD._Instancia.Agregar_Concepto(concepto);
        }

        public String Actualizar(LG_aConcepto concepto)
        {
            if (Buscar_TipoConcepto(concepto.Tipo_Concepto).ToList().Count > 0) return "YA EXISTE EL CONCEPTO";
            return LG_aConcepto_CD._Instancia.Actualizar_Concepto(concepto);
        }

        public string Eliminar(Int32 idconcepto)
        {
            return LG_aConcepto_CD._Instancia.Eliminar_Concepto(idconcepto);
        }

    }
}
