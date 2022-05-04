using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_mClientes_CN
    {
        public static readonly PR_mClientes_CN _Instancia = new PR_mClientes_CN();

        public static PR_mClientes_CN Instancia
        { get { return PR_mClientes_CN._Instancia;} }

        public List<PR_mClientes> Lista_Clientes()
        { return PR_mClientes_CD._Instancia.Lista_Clientes().ToList();}

        public IEnumerable<PR_mClientes> TraerIdCliente(int IdCliente)
        //{ return PR_mClientes_CD._Instancia.TraerIdCliente(IdCliente);}
        {
            return (from Clientes in PR_mClientes_CD._Instancia.Lista_Clientes().ToList()
                    where Clientes.IdCliente == IdCliente
                    select Clientes).ToList();
        }

        public IEnumerable<PR_mClientes> Buscar_RazonSocial(string RazonSocial)
        {
            var Listado = PR_mClientes_CD._Instancia.Lista_Clientes().ToList();
            return from CL in Listado where CL.Razon_Social == RazonSocial select CL;
        }

        public int Agregar_Cliente(PR_mClientes oCliente)
        {
            if (Buscar_RazonSocial(oCliente.Razon_Social).Count() > 0) return 0;
            return PR_mClientes_CD._Instancia.Agregar_Cliente(oCliente);
        }

        public int Actualizar_Cliente(PR_mClientes oCliente)
        {
            if (Buscar_RazonSocial(oCliente.Razon_Social).Count() > 0) return 0;
            return PR_mClientes_CD._Instancia.Modificar_Cliente(oCliente);
        }

        public int Eliminar_Cliente(int IdCliente)
        {
            return PR_mClientes_CD._Instancia.Eliminar_Cliente(IdCliente);
        }
    }
}
