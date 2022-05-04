using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aFabricanteMaterial
    {
        private Int32 _IdFabricanteMaterial;
        private string _Razon_Social;
        private string _Direccion;
        private string _Numero_RUC;
        private string _Numero_Telefono;
        private string _Pais;

        public int IdFabricanteMaterial { get => _IdFabricanteMaterial; set => _IdFabricanteMaterial = value; }
        public string Razon_Social { get => _Razon_Social; set => _Razon_Social = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Numero_RUC { get => _Numero_RUC; set => _Numero_RUC = value; }
        public string Numero_Telefono { get => _Numero_Telefono; set => _Numero_Telefono = value; }
        public string Pais { get => _Pais; set => _Pais = value; }

        public PR_aFabricanteMaterial()
        {  }

        public PR_aFabricanteMaterial(int idFabricanteMaterial, string razon_Social, string direccion, string numero_RUC, string numero_Telefono, string pais)
        {
            _IdFabricanteMaterial = idFabricanteMaterial;
            _Razon_Social = razon_Social;
            _Direccion = direccion;
            _Numero_RUC = numero_RUC;
            _Numero_Telefono = numero_Telefono;
            _Pais = pais;
        }


    }
}
