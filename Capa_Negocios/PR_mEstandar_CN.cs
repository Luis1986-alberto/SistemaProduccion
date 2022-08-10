using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Capa_Negocios
{
    public class PR_mEstandar_CN
    {
        public static readonly PR_mEstandar_CN _Instancia = new PR_mEstandar_CN();

        public static PR_mEstandar_CN Instancia
        { get { return PR_mEstandar_CN._Instancia; } }

        public List<PR_mEstandar> Lista_Estandares(PR_mEstandar mEstandaresIndustriales, string flag_tipoproduccion, string flag_clientes,
                                                                  string flag_rango, DateTime fecha_inicio, DateTime fecha_final)
        { return PR_mEstandar_CD._Instancia.Listar_Estandar(mEstandaresIndustriales, flag_clientes, flag_tipoproduccion, flag_rango, fecha_inicio, fecha_final).ToList(); }

        public PR_mEstandar TraerIdEstandar(Int32 idestandar)
        {
            return PR_mEstandar_CD._Instancia.TraerPorID(idestandar);
        }

        public string Agregar_Estandar(PR_mEstandar mestandar, PictureBox Foto_Producto, PR_mEstandarExtrusion mextrusion, PictureBox fotoarteextr,
                                       PR_mEstandarImpresion mimpresion, PictureBox fotoarteimp, PR_mEstandarSellado msellado, PictureBox fotoplanosell)
        {
            string rptaextr, rptaimp, rptasell = "";
            Int32 idestandar = PR_mEstandar_CD._Instancia.Procesar_Estandar(mestandar, "I", Foto_Producto);
            if (mextrusion != null) rptaextr = PR_mEstandarExtrusion_CD._Instancia.EstandartExtrusion_Procesar(mextrusion, idestandar, "I", fotoarteextr);
            if (mimpresion != null) rptaimp = PR_mEstandarImpresion_CD._Instancia.EstandarImpresion_Procesar(mimpresion, idestandar, "I", fotoarteimp);
            if (msellado != null) rptasell = PR_mEstandarSellado_CD._Instancia.EstandarSellado_Procesar(msellado, idestandar, "I", fotoplanosell);

            return "PROCESADO";
        }

        public string Actualizar_estandar(PR_mEstandar mestandar, PictureBox Foto_Producto, PR_mEstandarExtrusion mextrusion, PictureBox fotoarteextr,
                                          PR_mEstandarImpresion mimpresion, PictureBox fotoarteimp, PR_mEstandarSellado msellado, PictureBox fotoplanosell)
        {
            string rptaextr, rptaimp, rptasell = "";

            var predicado = Predicates.Field<PR_xPedidosIndustriales>(x => x.IdEstandarIndustrial, Operator.Eq , mestandar.IdEstandar);
            if( PR_xPedidosIndustriales_CD._Instancia.FiltroPorUnCampo(predicado).Count() >0) return "EXiste Pedidos generados con este estandart";

            PR_mEstandar_CD._Instancia.Procesar_Estandar(mestandar, "U", Foto_Producto);
            if (mextrusion != null) rptaextr = PR_mEstandarExtrusion_CD._Instancia.EstandartExtrusion_Procesar(mextrusion, mestandar.IdEstandar, "U", fotoarteextr);
            if (mimpresion != null) rptaimp = PR_mEstandarImpresion_CD._Instancia.EstandarImpresion_Procesar(mimpresion, mestandar.IdEstandar, "U", fotoarteimp);
            if (msellado != null) rptasell = PR_mEstandarSellado_CD._Instancia.EstandarSellado_Procesar(msellado, mestandar.IdEstandar, "U", fotoplanosell);

            return "PROCESADO";
        }

        public String Eliminar_Estandar(Int32 IdEstandar)
        {
            var predicado = Predicates.Field<PR_xPedidosIndustriales>(x => x.IdEstandarIndustrial, Operator.Eq, IdEstandar);
            if (PR_xPedidosIndustriales_CD._Instancia.FiltroPorUnCampo(predicado).Count() > 0) return "EXiste Pedidos generados con este estandart";

            PR_mEstandarExtrusion_CD._Instancia.Eliminar_EstandarExtrusion(IdEstandar);
            PR_mEstandarImpresion_CD._Instancia.Eliminar_EstandarImpresion(IdEstandar);
            PR_mEstandarSellado_CD._Instancia.Eliminar_estandarSellado(IdEstandar);
            PR_mEstandar_CD._Instancia.Eliminar_Estandar(IdEstandar);
            return "PROCESADO";
        }

        public void Descargar_ImagenProducto(PictureBox imagen, long idestandar)
        {
            PR_mEstandar_CD._Instancia.Descargar_Imagen(imagen, idestandar);
        }


    }
}
