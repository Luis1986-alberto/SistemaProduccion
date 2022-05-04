using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aSubFamilia_Produccion
    {
        private Int32 _IdSubFamiliaProd;
        private string _Descripcion_SubFamiliaProd;
        private string _Observacion;

        public int IdSubFamiliaProd { get => _IdSubFamiliaProd; set => _IdSubFamiliaProd = value; }
        public string Descripcion_SubFamiliaProd { get => _Descripcion_SubFamiliaProd; set => _Descripcion_SubFamiliaProd = value; }
        public string Observacion { get => _Observacion; set => _Observacion = value; }

        public PR_aSubFamilia_Produccion()
        { }

        public PR_aSubFamilia_Produccion(int idSubFamiliaProd, string descripcion_SubFamiliaProd, string observacion)
        {
            _IdSubFamiliaProd = idSubFamiliaProd;
            _Descripcion_SubFamiliaProd = descripcion_SubFamiliaProd;
            _Observacion = observacion;
        }

    }
}
