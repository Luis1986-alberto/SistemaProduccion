using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_mTrabajador_CN
    {
        public static readonly PR_mTrabajador_CN _Intancia = new PR_mTrabajador_CN();

        public static PR_mTrabajador_CN Instancia
        { get { return PR_mTrabajador_CN._Intancia; } }

        public IEnumerable<PR_mTrabajador>Lista_Trabajadores(string flag_idempresa, Int32 idempresa, string flag_idtrabajador, Int32 idtipotrabajador)
        {
            return PR_mTrabajador_CD._Instancia.Lista_Trabajadores(flag_idempresa, idempresa, flag_idtrabajador, idtipotrabajador);
        }

        public PR_mTrabajador Traer_PorId(Int32 idtrabajador)
        {
            return PR_mTrabajador_CD._Instancia.Traer_PorId(idtrabajador);
        }

        public IEnumerable<PR_mTrabajador>Buscar_PorDNI(string dni)
        {
            var predicado = Predicates.Field<PR_mTrabajador>(x => x.DNI, Operator.Eq, dni);
            return PR_mTrabajador_CD._Instancia.FiltrarPorunCampo(predicado);
        }

        public IEnumerable<PR_mTrabajador> Buscar_NombreApellidos(string nombres, string apaterno, string apmaterno)
        {
            return (from trabajador in PR_mTrabajador_CD._Instancia.Lista_Trabajadores("0", 0, "0", 0).ToList()
                    where trabajador.Apellido_Paterno == apaterno && trabajador.Apellido_Materno == apmaterno && trabajador.Nombre == nombres
                    select trabajador);
        }


        public string Agregar_Trabajado(PR_mTrabajador trabajador)
        {
            if (Buscar_PorDNI(trabajador.DNI).Count() > 0) return "EXISTE ESTE DNI REGISTRADO";
            if (Buscar_NombreApellidos(trabajador.Nombre, trabajador.Apellido_Paterno, trabajador.Apellido_Materno).Count() > 0) return "EXISTE ESTE TRABAJADOR";
            return PR_mTrabajador_CD._Instancia.Agregar_Trabajador(trabajador);
        }

        public string Actualizar_Trabajador(PR_mTrabajador trabajador)
        {
            return PR_mTrabajador_CD._Instancia.Agregar_Trabajador(trabajador);
        }


    }
}
