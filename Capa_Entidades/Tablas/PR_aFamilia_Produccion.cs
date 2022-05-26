using System;

namespace Capa_Entidades.Tablas
{
    public class PR_aFamilia_Produccion
    {
        private Int32 _IdFamiliaProd;
        private string _Descripcion_Familia;
        private string _Observacion;
        private byte _Orden_Gerencia;

        public int IdFamiliaProd { get => _IdFamiliaProd; set => _IdFamiliaProd = value; }
        public string Descripcion_Familia { get => _Descripcion_Familia; set => _Descripcion_Familia = value; }
        public string Observacion { get => _Observacion; set => _Observacion = value; }
        public byte Orden_Gerencia { get => _Orden_Gerencia; set => _Orden_Gerencia = value; }

        public PR_aFamilia_Produccion()
        { }

        public PR_aFamilia_Produccion(int idFamiliaProd, string descripcion_Familia, string observacion, byte orden_Gerencia)
        {
            _IdFamiliaProd = idFamiliaProd;
            _Descripcion_Familia = descripcion_Familia;
            _Observacion = observacion;
            _Orden_Gerencia = orden_Gerencia;
        }

    }
}
