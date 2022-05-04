using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aEtiquetadoras_CN
    {
        public static readonly PR_aEtiquetadoras_CN _Instancia = new PR_aEtiquetadoras_CN();

        public static PR_aEtiquetadoras_CN Instancia
        { get { return PR_aEtiquetadoras_CN._Instancia; }  }

        public List<PR_aEtiquetadoras> Lista_Etiquetadoras()
        {return PR_aEtiquetadoras_CD.Intancia.Lista_Etiquetadoras().ToList();}

        public IEnumerable<PR_aEtiquetadoras> traerPorId(byte idetiquetadora)
        { return PR_aEtiquetadoras_CD.Intancia.Traer_EtiquetadoraPorId(idetiquetadora); }

        public IEnumerable<PR_aEtiquetadoras> Buscar_Codigo( string codigo)
        {
            var lista = PR_aEtiquetadoras_CD.Intancia.Lista_Etiquetadoras();
            return from lstet in lista where lstet.Codigo_Etiquetadora == codigo select lstet;
        }
        public IEnumerable<PR_aEtiquetadoras> Buscar_Modelo(string modelo)
        {
            var lista = PR_aEtiquetadoras_CD.Intancia.Lista_Etiquetadoras();
            return from lstet in lista where lstet.Modelo_Etiquetadora == modelo select lstet;
        }

        public string Agregar_Etiquetadora(PR_aEtiquetadoras etiquetadoras)
        {
            if (Buscar_Codigo(etiquetadoras.Codigo_Etiquetadora).Count() > 0) { return "EXISTE ESTE CODIGO REGISTRADO "; }
            if (Buscar_Modelo(etiquetadoras.Marca_Etiquetadora).Count() > 0) { return "EXISTE ESTE MODELO REGISTRADO "; }
            return PR_aEtiquetadoras_CD._Intancia.Agregar_Etiquetadoras(etiquetadoras);
        }

        public string Actualizar_Etiquetadora(PR_aEtiquetadoras etiquetadoras)
        {
            if (Buscar_Codigo(etiquetadoras.Codigo_Etiquetadora).Count() > 0) { return "EXISTE ESTE CODIGO REGISTRADO "; }
            if (Buscar_Modelo(etiquetadoras.Marca_Etiquetadora).Count() > 0) { return "EXISTE ESTE MODELO REGISTRADO "; }
            return PR_aEtiquetadoras_CD._Intancia.Actualizar_Etiquetadoras(etiquetadoras);
        }

        public string Eliminar_Etiquetadora(Int32 idetiquetadora)
        {
            // *****EVRIFICAR SI EXISTE EATA ETIQUETORA CONECTADA CON UN AVANCE
            return PR_aEtiquetadoras_CD._Intancia.Eliminar_Etiquetadora(idetiquetadora);
        }
    }
}
