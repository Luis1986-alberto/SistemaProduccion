using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Capa_Negocios
{
    public class PR_aEmpresa_CN
    {
        public static readonly PR_aEmpresa_CN _Instancia = new PR_aEmpresa_CN();

        public static PR_aEmpresa_CN Instancia
        { get { return PR_aEmpresa_CN._Instancia; } }

        public List<PR_aEmpresa> Lista_Empresas()
        { return PR_aEmpresa_CD._Instancia.Listar_Empresas().ToList(); }

        public IEnumerable<PR_aEmpresa> TraerPorID(byte id)
        { return PR_aEmpresa_CD._Instancia.Traer_EmpresaPorId(id); }

        public IEnumerable<PR_aEmpresa> Buscar_NombreEmpresa(string nombreempresa)
        {
            var lst = PR_aEmpresa_CD._Instancia.Listar_Empresas().ToList();
            return from AD in lst where AD.Nombre_Empresa == nombreempresa select AD;
        }

        public string Agregar_Empresa(PR_aEmpresa empresa, PictureBox fotoempresa)
        {
            if (Buscar_NombreEmpresa(empresa.Nombre_Empresa).Count() > 0) return "Existe una Empresa Registrado";
            return PR_aEmpresa_CD._Instancia.Agregar_Empresa(empresa, fotoempresa);
        }

        public string Actualizar_Empresa(PR_aEmpresa empresa, PictureBox fotoempresa)
        {
            if (Buscar_NombreEmpresa(empresa.Nombre_Empresa).Count() > 0) return "Existe una Empresa Registrado";
            return PR_aEmpresa_CD._Instancia.Actualizar_Empresa(empresa, fotoempresa);
        }

        public string Eliminar_Empresa(Int32 idempresa)
        {
            var lista = LG_aAlmacen_CN._Instancia.Buscar_AlmacenPorEmpresa(idempresa);
            if (lista.Count() > 0) return "EXISTE ALMACENES REGISTRADOS EN ESTA EMPRESA";

            return PR_aEmpresa_CD._Instancia.Eliminar_Empresa(idempresa);
        }

        public void Descargar_Imagen(PictureBox fotoempresa, Int32 idempresa)
        { PR_aEmpresa_CD._Instancia.Descargar_Imagen(fotoempresa, idempresa); }

    }
}
