using System;

namespace Capa_Entidades.Tablas
{
    public class MP_aMarcaMaterial
    {
        private Int32 _IdMarcaMaterial;
        private string _Descripcion;
        private string _Abreviatura_MarcaMaterial;

        public int IdMarcaMaterial { get => _IdMarcaMaterial; set => _IdMarcaMaterial = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Abreviatura_MarcaMaterial { get => _Abreviatura_MarcaMaterial; set => _Abreviatura_MarcaMaterial = value; }

        public MP_aMarcaMaterial()
        { }

        public MP_aMarcaMaterial(int idMarcaMaterial, string descripcion, string abreviatura_MarcaMaterial)
        {
            _IdMarcaMaterial = idMarcaMaterial;
            _Descripcion = descripcion;
            _Abreviatura_MarcaMaterial = abreviatura_MarcaMaterial;
        }

    }
}
