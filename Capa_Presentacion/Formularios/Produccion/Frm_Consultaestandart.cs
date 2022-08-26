using Capa_Entidades.Tablas;
using Capa_Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios.Produccion
{
    public partial class Frm_Consultaestandart : Form
    {
        public Int32 idestandart;
        private Int32 idextrusion, idsellado, idimpresion, idlaminado, idcorte = 0;
        private PR_mEstandarExtrusion mestextrusion = null;
        private PR_mEstandarImpresion mestimpresion = null;
        private PR_mEstandarSellado mestsellado = null;
        private PR_mEstandarLaminado mestlaminado = null;

        private void Chk_MostrarImagen_CheckedChanged(object sender, EventArgs e)
        {
            Img_Producto.Image = null;
            Img_PlanoExtrusion.Image = null;
            Img_Arte.Image = null;
            img_PlanoMecanicoSellado.Image = null;
            if (Chk_MostrarImagen.Checked == true)
            {
                PR_mEstandar_CN._Instancia.Descargar_ImagenProducto(Img_Producto, Int32.Parse(txt_IdEstandar.Text));
                if (idextrusion > 0) PR_mEstandarExtrusion_CN._Instancia.Descargar_ImagenProducto(Img_PlanoExtrusion, idextrusion);
                if (idimpresion > 0) PR_mEstandarImpresion_CN._Instancia.Descargar_ImagenProducto(Img_Arte, idimpresion);
                if (idsellado > 0) PR_mEstandarSellado_CN._Instancia.Descargar_ImagenProducto(img_PlanoMecanicoSellado, idsellado);
            }            
        }

        private PR_mEstandarCorte mestcorte = null;
        public Frm_Consultaestandart()
        {
            InitializeComponent();
        }

        private void Frm_Consultaestandart_Load(object sender, EventArgs e)
        {            
            Cbo_Cliente.DataSource = PR_mClientes_CN._Instancia.Lista_Clientes();
            Cbo_CondicionProcesos.DataSource = PR_aCondicionProceso_CN._Instancia.Lista_CondicionProceso();
            Cbo_Procesos.DataSource = PR_aProcesos_CN._Instancia.Lista_Procesos();
            Cbo_TipoProduccion.DataSource = PR_aTipoProduccion_CN._Instancia.Lista_TipoProduccion();            
            Cbo_tipoproducto.DataSource = PR_aTipoProducto_CN._Instancia.Lista_TipoProducto();
            cbo_umdiametroSolicitado.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();

            //--Extrusion----//
            cbo_FormaSustrato.DataSource = PR_aFormaSustrato_CN._Instancia.Lista_FormaSustrato();
            Cbo_MaterialExtruir.DataSource = PR_aTipoMaterialExtruir_CN._Instancia.Lista_TipoMaterialExtruir();
            Cbo_UsoProducto.DataSource = PR_aUsoProducto_CN._Instancia.Lista_UsoProducto();
            Cbo_tratado.DataSource = PR_aTipoTratado_CN._Instancia.Lista_TipoTratado();
            Cbo_TipoFuelle.DataSource = PR_aTipoFuelle_CN._Instancia.Lista_TipoFuelle();
            Cbo_unidadMedidaFuelle.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
            Cbo_UnidadMedidaRefile.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
            Cbo_UnidadMedidaAnchoBob.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
            Cbo_UMEspesorBob.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
            cbo_UnidadmedidaTuco.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
            cbo_umdiametrotuco.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
            cbo_UMPesoTuco.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();

            ////standart impresion//
            cbo_posiciontaca.DataSource = PR_aPosicionTaca_CN._Instancia.Lista_PosicionTaca();
            cbo_unidadmedidataca.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida(); ;
            cbm_Impresora.DataSource = PR_mImpresora_CN._Instancia.Lista_Impresora();
            cbo_pieimprenta.DataSource = PR_aPieImprenta_CN._Instancia.Lista_PieImprenta();
            Cbo_unidadmedidarepeticiones.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida(); ;
            Cbo_unidadmedidabandas.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida(); ;
            cbo_tipotinta.DataSource = PR_aTipoTinta_CN._Instancia.Lista_TipoTinta();
            cbo_IdUMespesorclisse.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();

            //// standart Sellado//
            cbo_unidadmedidabolsa.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
            cbo_tiposello.DataSource = PR_aTipoSello_CN._Instancia.Lista_TipoSello();
            cbo_tipotroquel.DataSource = PR_aTipoTroquel_CN._Instancia.Lista_TipoTroquel();
            cbo_tipoasa.DataSource = PR_aAsa_CN._Instancia.Lista_Asas();
            cbo_Empaquetado.DataSource = PR_aEmpaquetado_CN._Instancia.Lista_Empaquetado();
            cbo_etiquetaempresa.DataSource = PR_aEtiqueta_CN._Instancia.Lista_Etiqueta();
            Cbo_Fuellesellado.DataSource = PR_aTipoFuelle_CN._Instancia.Lista_TipoFuelle();
            cbo_UMfuellesellado.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
            cbo_umperforaciones.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
            cbo_umpestaña.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
            cbo_umsolapa.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
            cbo_umrefilesellado.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();


            Entrada_Datos(idestandart);

        }
        private void Entrada_Datos(Int32 idestandar)
        {            
            var i = PR_mEstandar_CN._Instancia.TraerIdEstandar(idestandar);
            txt_IdEstandar.Text = i.IdEstandar.ToString();
            Cbo_Cliente.SelectedValue = i.IdCliente;
            txt_DescripcionEstandar.Text = i.Descripcion;
            txt_CodigoEstandar.Text = i.Codigo_Estandar;
            txt_CodigoBarrasEstandar.Text = i.Estructura_CodBar;
            Cbo_Procesos.SelectedValue = i.IdProcesos;
            Cbo_TipoProduccion.SelectedValue = i.IdTipoProduccion;
            Cbo_CondicionProcesos.SelectedValue = i.IdCondicionProceso;
            Dtp_FechaCreacion.Text = i.Fecha_Creado.ToString();
            Cbo_tipoproducto.SelectedValue = i.IdTipoProducto;
            idextrusion = i.IdEstandarExtrusion;
            idimpresion = i.IdEstandarImpresion;
            idsellado = i.IdEstandarSellado;
            idlaminado = i.IdEstandarLaminado;
            idcorte = i.IdEstandarCorte;
            nud_diametroSolicitado.Value = i.Diametro_Solicitado.Value;
            cbo_umdiametroSolicitado.SelectedValue = i.IdUnidadDiametroSolicitado;
            Txt_RutaProducto.Text = i.Ruta_Producto;
            txt_diseño.Text = i.Diseño;

            //Extrusion
            if (idextrusion > 0)
            {
                var extr = PR_mEstandarExtrusion_CN._Instancia.TraerPorID(idextrusion);
                Cbo_UsoProducto.SelectedValue = extr.IdUsoProducto;
                cbo_FormaSustrato.SelectedValue = extr.IdFormaSustrato;
                Cbo_MaterialExtruir.SelectedValue = extr.IdTipoMaterialExtruir;
                Txt_ColorSustrato.Text = extr.Color;
                Cbo_tratado.SelectedValue = extr.IdTipoTratado;
                Txt_DiseñoTratado.Text = extr.Nota_Tratado;
                Txt_NotaExtrusion.Text = extr.Nota_Extrusion;
                Chk_Fuelle.Checked = (extr.Flag_Fuelle == "1") ? true : false;
                Cbo_TipoFuelle.SelectedValue = extr.IdTipoFuelle;
                nud_medidafuelle.Value = extr.Medida_Fuelle.Value;
                Cbo_unidadMedidaFuelle.SelectedValue = extr.IdUnidadFuelle;
                Chk_FuelleIncluido.Checked = (extr.Flag_FuelleIncluido == "1") ? true : false;
                Chk_FlagGofrado.Checked = (extr.Flag_Gofrado == "1") ? true : false;
                Chk_FlagRefile.Checked = (extr.Flag_Refile == "1") ? true : false;
                nud_medidarefile.Value = extr.Medida_Refile.Value;
                Cbo_UnidadMedidaRefile.SelectedValue = extr.IdUnidadRefile;
                nud_medidaanchobobina.Value = extr.Medida_Manga.Value;
                nud_medidaespesor.Value = extr.Medida_Espesor.Value;
                Cbo_UMEspesorBob.SelectedValue = extr.IdUnidadEspesor;
                nud_medidaTuco.Value = extr.Medida_Tuco_Extrusion.Value;
                cbo_UnidadmedidaTuco.SelectedValue = extr.IdUnidadMedidaTuco;
                nud_DiametroTuco.Value = extr.Diametro_Tuco_Extrusion.Value;
                cbo_UnidadmedidaTuco.SelectedValue = extr.IdUnidadMedidaTuco;
                nud_PesoTuco.Value = extr.Peso_Tuco_Extrusion.Value;
                cbo_UMPesoTuco.SelectedValue = extr.IdUnidadMedidaPesoTuco;
                nud_RelacionSoplado.Value = extr.Relacion_Soplado.Value;
                Chk_FlagAditivoUV.Checked = (extr.Flag_AditivoUV == "1") ? true : false;
                Chk_FlagTermocontraible.Checked = (extr.Flag_Termocontraible == "1") ? true : false;
                Chk_FlagApilar.Checked = (extr.Flag_Apilar == "1") ? true : false;
                Chk_FlagBiodegradable.Checked = (extr.Flag_Biodegradable == "1") ? true : false;
                Chk_FlagMasLineal.Checked = (extr.Flag_MasLineal == "1") ? true : false;
                Chk_FlagCongelado.Checked = (extr.Flag_Congelado == "1") ? true : false;
                Chk_FlagUsoPesado.Checked = (extr.Flag_UsoPesado == "1") ? true : false;
                Chk_DynasTratado.Checked = (extr.Flag_Impresion == "1") ? true : false;
                nud_Dynas.Value = extr.Dynas_Extrusion.Value;
                Chk_Otros.Checked = (extr.Flag_Otros == "1") ? true : false;
                txt_Otrosaplicativos.Text = extr.Nota_Otros;
                txt_GramajeLineal.Text = extr.Gramaje_Lineal.ToString();
                txt_GramajeTotal.Text = extr.Gramaje_Total.ToString();
                nud_Diametrocabezal.Value = extr.Diametro_Cabezal.Value;
                nud_Gapextrusion.Value = extr.Gap_Extrusion.Value;
                txt_direccionPlanoExtrusion.Text = extr.Ruta_FotoPlanoMecanicoExtr;
            }

            //Impresion
            if (idimpresion > 0)
            {
                var imp = PR_mEstandarImpresion_CN._Instancia.TraerPorId(idimpresion);
                nud_numerorepiticiones.Value = imp.Numero_Repeticiones;
                txt_medidarepeticion.Text = imp.Medida_Repeticiones.ToString();
                Cbo_unidadmedidarepeticiones.SelectedValue = imp.IdUnidadRepeticiones;
                nud_numerobandas.Value = imp.Numero_Bandas;
                txt_medidabandas.Text = imp.Medida_Bandas.ToString();
                Cbo_unidadmedidabandas.SelectedValue = imp.IdUnidadBandas;
                nud_numeronegativo.Value = imp.Numero_Negativos;
                nud_numeroclises.Value = imp.Numero_Clisse;
                chk_codigobarras.Checked = (imp.Flag_CodigoBarra == "1") ? true : false;
                nud_numeropistas.Value = imp.Numero_Pistas;
                txt_EspesorClisse.Text = imp.Medida_EspesorClisse.ToString();
                cbo_IdUMespesorclisse.SelectedValue = imp.IdUnidadEspesorClisse;
                cbo_tipotinta.SelectedValue = imp.IdTipoTinta;
                rb_colormuestra.Checked = (imp.Flag_ColorMuestraPantone == "0") ? true : false;
                rb_colorpantone.Checked = (imp.Flag_ColorMuestraPantone == "1") ? true : false;
                nud_cantcolortira.Value = imp.Numero_Colores;
                chk_Retira.Checked = (imp.Flag_TiraRetira == "1") ? true : false;
                txt_colorestira.Text = imp.Nota_NombreColores;
                nud_cantcolorretira.Value = imp.Numero_Colores2;
                txt_coloresretira.Text = imp.Nota_NombreColores2;
                rb_sentido1.Checked = (imp.Flag_Embobinado1 == "1") ? true : false;
                rb_sentido2.Checked = (imp.Flag_Embobinado2 == "1") ? true : false;
                rb_sentido3.Checked = (imp.Flag_Embobinado3 == "1") ? true : false;
                rb_sentido4.Checked = (imp.Flag_Embobinado4 == "1") ? true : false;
                rb_sentido5.Checked = (imp.Flag_Embobinado5 == "1") ? true : false;
                rb_sentido6.Checked = (imp.Flag_Embobinado6 == "1") ? true : false;
                rb_sentido7.Checked = (imp.Flag_Embobinado7 == "1") ? true : false;
                rb_sentido8.Checked = (imp.Flag_Embobinado8 == "1") ? true : false;
                cbm_Impresora.SelectedValue = imp.IdImpresora;
                chk_flagPieImprenta.Checked = (imp.Flag_PieImprenta == "1") ? true : false;
                Rb_ImpresionInterna.Checked = (imp.Flag_ImpresionInternaExterna == "0") ? true : false;
                Rb_ImpresionExterna.Checked = (imp.Flag_ImpresionInternaExterna == "1") ? true : false;
                txt_EspesorClisse.Text = imp.Medida_EspesorClisse.ToString();
                rb_empresa.Checked = (imp.Flag_DueñoClisseEmpresaCliente == "E") ? true : false;
                rb_cliente.Checked = (imp.Flag_DueñoClisseEmpresaCliente == "C") ? true : false;
                txt_obsnegativos.Text = imp.Nota_Negativos;
                chk_flagagua.Checked = (imp.Flag_Agua == "1") ? true : false;
                chk_flagdetergente.Checked = (imp.Flag_Detergente == "1") ? true : false;
                chk_flagcalor.Checked = (imp.Flag_Calor == "1") ? true : false;
                txt_GradosCalor.Text = imp.Calor_C.ToString();
                chk_flagfrote.Checked = (imp.Flag_Frote == "1") ? true : false;
                Chk_FlagCongelado.Checked = (imp.Flag_Congelamiento == "1") ? true : false;
                txt_GradosCongelamiento.Text = imp.Congelamiento_C.ToString();
                chk_flaggrasa.Checked = (imp.Flag_Grasa == "1") ? true : false;
                chk_flaguv.Checked = (imp.Flag_UV == "1") ? true : false;
                chk_flagotros.Checked = (imp.Flag_Otros == "1") ? true : false;
                txt_otrostintasresistentes.Text = imp.Nota_Otros;
                chk_FlagTaca.Checked = (imp.Flag_Taca == "1") ? true : false;
                cbo_posiciontaca.SelectedValue = imp.IdPosicionTaca;
                nud_largotaca.Value = imp.Medida_LargoTaca;
                nud_anchotaca.Value = imp.Medida_AnchoTaca;
                txt_notaimpresion.Text = imp.Nota_Impresion;
            }

            // Sellado
            if (idsellado > 0)
            {
                var sell = PR_mEstandarSellado_CN._Instancia.TraerPor_Id(idsellado);
                nud_Ancho.Value = sell.Ancho;
                nud_largo.Value = sell.Largo;
                cbo_unidadmedidabolsa.SelectedValue = sell.IdUnidadLargo;
                txt_cantidadPistas.Text = sell.Numero_Pistas.ToString();
                rb_InicioPosicionSello.Checked = (sell.Flag_Posicion_Sello == "1") ? true : false;
                rb_FinalPosicionSello.Checked = (sell.Flag_Posicion_Sello == "0") ? true : false;
                cbo_tiposello.SelectedValue = sell.IdTipoSello;
                cbo_tipotroquel.SelectedValue = sell.IdTroquel;
                cbo_tipoasa.SelectedValue = sell.IdAsa;
                cbo_Empaquetado.SelectedValue = sell.IdEmpaquetado;
                txt_Unidadporpaquete.Text = sell.UnidadxPaquete.ToString();
                nud_PaquetesXCaja.Value = sell.PaquetexCaja;
                txt_cantmillaresXcajafardo.Text = sell.MillarxCaja.ToString();
                chk_Etiquetado.Checked = (sell.Flag_Etiqueta == "1") ? true : false;
                chk_etiquetacaja.Checked = (sell.Flag_Etiqueta_Caja == "1") ? true : false;
                chk_EtiquetaFardo.Checked = (sell.Flag_Etiqueta_Fardo == "1") ? true : false;
                chk_etiquetapaquete.Checked = (sell.Flag_Etiqueta_Paquete == "1") ? true : false;
                cbo_etiquetaempresa.SelectedValue = sell.IdEtiqueta;
                rb_AxLxE.Checked = (sell.Flag_DetalleEtiqueta == "1") ? true : false;
                rb_AxL.Checked = (sell.Flag_DetalleEtiqueta == "0") ? true : false;
                Cbo_Fuellesellado.SelectedValue = sell.IdTipoFuelle;
                nud_medidafuellesell.Value = sell.Medida_Fuelle;
                cbo_UMfuellesellado.SelectedValue = sell.IdUnidadFuelle;
                Chk_Perforaciones.Checked = (sell.Flag_Perforaciones == "1") ? true : false;
                nud_cantperforaciones.Value = sell.Numero_Perforaciones;
                nud_diametroperforacion.Value = sell.Medida_Perforaciones;
                cbo_umperforaciones.SelectedValue = sell.IdUnidadPerforaciones;
                chk_Pestaña.Checked = (sell.Flag_Pestaña == "1") ? true : false;
                nud_medidapestaña.Value = sell.Medida_Pestaña;
                cbo_umpestaña.SelectedValue = sell.IdUnidadPestaña;
                chk_solapa.Checked = (sell.Flag_Solapa == "1") ? true : false;
                nud_medidasolapa.Value = sell.Medida_Solapa;
                cbo_umsolapa.SelectedValue = sell.IdUnidadSolapa;
                chk_refilesellado.Checked = (sell.Flag_Refile == "1") ? true : false;
                nud_medrefilesellado.Value = sell.Medida_Refile;
                cbo_umrefilesellado.SelectedValue = sell.IdUnidadRefile;
                txt_pesotuco.Text = sell.Peso_Tuco.ToString();
                txt_pesoenvase.Text = sell.Peso_Envase.ToString();
                txt_pesocajafardo.Text = sell.Peso_Promedio_Fardo.ToString();
                txt_pesopaquete.Text = sell.Peso_Promedio_Paquete.ToString();
                txt_pesomillar.Text = sell.Peso_Promedio_Millar.ToString();
                txt_notasellado.Text = sell.Nota_Sellado;
                txt_DireccionubicacionPlanosellado.Text = sell.Ruta_FotoPlanoMecanicoSell;
            }


        }
    }
}
