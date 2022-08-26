using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class Pr_mVendedores_CN
    {
        public static readonly Pr_mVendedores_CN _Instancia = new Pr_mVendedores_CN();

        public static Pr_mVendedores_CN Instancia
        { get { return Pr_mVendedores_CN._Instancia; } }

        public List<PR_mVendedores>Lista_vendedores()
        { return PR_mVendedores_CD.Instancia.Lista_Vendedores().ToList(); }

        public PR_mVendedores Traer_PorId(Int32 idvendedores)
        { return PR_mVendedores_CD.Instancia.TraerPorId(idvendedores); }

        public IEnumerable<PR_mVendedores> Buscar_Nombre(string nombre)
        {
            var lst = PR_mVendedores_CD._Instancia.Lista_Vendedores();
            return from vendedor in lst where vendedor.Nombre_Vendedor == nombre select vendedor;
        }

        public string Agregar_Vendedor(PR_mVendedores vendedores )
        {           
            if(Buscar_Nombre(vendedores.Nombre_Vendedor).Count()>0) return "EXISTEN ESTE VENDEDOR"; 
            return PR_mVendedores_CD._Instancia.Agregar_Vendedores(vendedores);             
        }

        public string Actualizar_Vendedor(PR_mVendedores vendedores)
        {
            if (Buscar_Nombre(vendedores.Nombre_Vendedor).Count() > 0) return "EXISTEN ESTE VENDEDOR";
            return PR_mVendedores_CD._Instancia.Actualizar_Vendedores(vendedores);
        }

        public string Eliminar_Vendedor(Int32 idvendedor)
        {
            return PR_mVendedores_CD._Instancia.Eliminar_Vendedores(idvendedor);
        }



    }
}
