using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_aEmpresa
    {
        public byte IdEmpresa { get; set; }
        public string Nombre_Empresa { get; set; }
        public string RUC_Empresa { get; set; }
        public string Abreviatura_Empresa { get; set; }
        public byte Flag_Activo { get; set; }
        public byte[] Foto_Empresa { get; set; }
        public string Ruta_Foto_Empresa { get; set; }
        public string Direccion_Empresa { get; set; }
        public string Telefono1_Empresa { get; set; }
        public string Telefono2_Empresa { get; set; }
        public string Telefono3_Empresa { get; set; }

        public PR_aEmpresa()
        { }

        public PR_aEmpresa(byte idEmpresa, string nombre_Empresa, string rUC_Empresa, string abreviatura_Empresa, byte flag_Activo, //byte[] foto_Empresa, 
                           string ruta_Foto_Empresa, string direccion_Empresa, string telefono1_Empresa, string telefono2_Empresa, string telefono3_Empresa)
        {
            IdEmpresa = idEmpresa;
            Nombre_Empresa = nombre_Empresa;
            RUC_Empresa = rUC_Empresa;
            Abreviatura_Empresa = abreviatura_Empresa;
            Flag_Activo = flag_Activo;
            //Foto_Empresa = foto_Empresa;
            Ruta_Foto_Empresa = ruta_Foto_Empresa;
            Direccion_Empresa = direccion_Empresa;
            Telefono1_Empresa = telefono1_Empresa;
            Telefono2_Empresa = telefono2_Empresa;
            Telefono3_Empresa = telefono3_Empresa;
        }
    }
}
