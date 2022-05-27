using Capa_Entidades.Tablas;
using Capa_Negocios;
using Capa_Presentacion.Clases;
using Capa_Presentacion.Framework.ComponetModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios.Produccion
{
    public partial class Frm_RegistroEstandar : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo, bln_Editar = false;
        private string str_Campo;
        private Int32 idextrusion, idsellado, idimpresion, idlaminado, idcorte = 0;
        private List<PR_mEstandar> Lst_Estandares = new List<PR_mEstandar>();
        private PR_mEstandarExtrusion mestextrusion = null;
        private PR_mEstandarImpresion mestimpresion = null;
        private PR_mEstandarSellado mestsellado = null;
        private PR_mEstandarLaminado mestlaminado = null;
        private PR_mEstandarCorte mestcorte = null;

        public Frm_RegistroEstandar()
        {
            InitializeComponent();
        }

        private void Frm_RegistroEstandar_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            tc_procesos.TabPages["Tbp_Extrusion"].Enabled = false;
            tc_procesos.TabPages["Tbp_Impresion"].Enabled = false;
            tc_procesos.TabPages["Tbp_Sellado"].Enabled = false;
            tc_procesos.TabPages["Tbp_Laminado"].Enabled = false;
            tc_procesos.TabPages["Tbp_Doblado"].Enabled = false;
            tc_procesos.TabPages["Tbp_Corte"].Enabled = false;
            Cargar_Combos();
            Cargar_Datos();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void cmd_Procesos_Click(object sender, EventArgs e)
        {
            Frm_ProcesosProduccion procesos = new Frm_ProcesosProduccion();
            procesos.ShowDialog();
            Cbo_Procesos.DataSource = PR_aProcesos_CN._Instancia.Lista_Procesos();
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;
            tbc_Mnt.SelectTab(0);
            tc_procesos.SelectTab(0);
            Estado_Toolbar(bln_Nuevo);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            HabilitarControles(true);
            Limpiar_Controles();
            txt_IdEstandar.Text = "0";
        }

        private void Cargar_Combos()
        {
            cbo_FiltroCliente.DataSource = PR_mClientes_CN._Instancia.Lista_Clientes();
            Cbo_Cliente.DataSource = PR_mClientes_CN._Instancia.Lista_Clientes();
            Cbo_CondicionProcesos.DataSource = PR_aCondicionProceso_CN._Instancia.Lista_CondicionProceso();
            Cbo_Procesos.DataSource = PR_aProcesos_CN._Instancia.Lista_Procesos();
            Cbo_TipoProduccion.DataSource = PR_aTipoProduccion_CN._Instancia.Lista_TipoProduccion();
            Cbo_FiltroTipoProduccion.DataSource = PR_aTipoProduccion_CN._Instancia.Lista_TipoProduccion();
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

            //// standart Laminado//

            //// standart Doblado//

            //// standart Corte//

        }

        private void Cargar_Datos()
        {
            var datos = new PR_mEstandar
            {
                IdCliente = Int32.Parse(cbo_FiltroCliente.SelectedValue.ToString()),
                IdTipoProduccion = byte.Parse(Cbo_FiltroTipoProduccion.SelectedValue.ToString()),
            };
            Lst_Estandares = PR_mEstandar_CN._Instancia.Lista_Estandares(datos, (chk_FiltroTipoEstandar.Checked == true) ? "1" : "0", (chk_FiltroCliente.Checked == true) ? "1" : "0",
                                                                                            (Chk_FiltroRango.Checked == true) ? "1" : "0", Dtp_FechaInicial.Value, Dtp_FechaFinal.Value);
            SortableBindingList<PR_mEstandar> lista = new SortableBindingList<PR_mEstandar>(Lst_Estandares);
            dgv_Mnt.AutoGenerateColumns = false;
            dgv_Mnt.DataSource = lista;
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["idestandar"].Value.ToString())); }
        }

        private void Entrada_Datos(Int32 idestandar)
        {
            Limpiar_Controles();
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

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay registro para modificar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datos = PR_mEstandar_CN._Instancia.TraerIdEstandar(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["idestandar"].Value.ToString()));

            if (datos.Flag_GeneradoOP == "1")
            {
                MessageBox.Show("Existe Ordenes de Produccion", "Error al Modificar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bln_Editar = true;
            bln_Nuevo = false;

            Estado_Toolbar(bln_Editar);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            tbc_Mnt.SelectTab(0);
            HabilitarControles(true);
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay registro para Eliminar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datos = PR_mEstandar_CN._Instancia.TraerIdEstandar(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["idestandar"].Value.ToString()));

            if (datos.Flag_GeneradoOP == "1")
            {
                MessageBox.Show(" No se Puede Eliminar Existe Ordenes de Produccion", "Error al Eliminar  ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Esta Seguro de Eliminar el Registro", "ELIMINAR ESTANDART N°   " + dgv_Mnt.SelectedRows[0].Cells["IdEstandar"].Value.ToString(),
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string rpta = PR_mEstandar_CN._Instancia.Eliminar_Estandar(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEstandar"].Value.ToString()));

                Cargar_Datos();
                tbc_Mnt.SelectTab(1);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            }
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";

            var estadart = new PR_mEstandar
            {
                IdEstandar = Int32.Parse(txt_IdEstandar.Text),
                IdCliente = Int32.Parse(Cbo_Cliente.SelectedValue.ToString()),
                Descripcion = txt_DescripcionEstandar.Text,
                IdProcesos = byte.Parse(Cbo_Procesos.SelectedValue.ToString()),
                Flag_NuevoRepetido = "0",
                Diseño = txt_diseño.Text,
                IdUsuario = "Lquiroz",
                Fecha_Creado = DateTime.Parse(Dtp_FechaCreacion.Value.ToShortDateString()),
                Usuario_Creador = "Lquiroz",
                Fecha_Modificado = DateTime.Now,
                Flag_GeneradoOP = "0",
                Codigo_Estandar = txt_CodigoEstandar.Text,
                Estructura_CodBar = txt_CodigoBarrasEstandar.Text,
                Flag_EspecificacionesCC = 0,
                OrdenTrabajo_Clisses = " ",
                Ruta_Producto = Txt_RutaProducto.Text,
                IdEstandarExtrusion_CC = 0,
                IdEstandarImpresion_CC = 0,
                Flag_Embobinado1 = byte.Parse((rb_sentido1.Checked == true) ? "1" : "0"),
                Flag_Embobinado2 = byte.Parse((rb_sentido2.Checked == true) ? "1" : "0"),
                Flag_Embobinado3 = byte.Parse((rb_sentido3.Checked == true) ? "1" : "0"),
                Flag_Embobinado4 = byte.Parse((rb_sentido4.Checked == true) ? "1" : "0"),
                Flag_Embobinado5 = byte.Parse((rb_sentido5.Checked == true) ? "1" : "0"),
                Flag_Embobinado6 = byte.Parse((rb_sentido6.Checked == true) ? "1" : "0"),
                Flag_Embobinado7 = byte.Parse((rb_sentido7.Checked == true) ? "1" : "0"),
                Flag_Embobinado8 = byte.Parse((rb_sentido8.Checked == true) ? "1" : "0"),
                IdTipoProduccion = byte.Parse(Cbo_TipoProduccion.SelectedValue.ToString()),
                Diametro_Solicitado = decimal.Parse(nud_diametroSolicitado.Value.ToString()),
                IdUnidadDiametroSolicitado = byte.Parse(cbo_umdiametroSolicitado.SelectedValue.ToString()),
                IdTipoProducto = byte.Parse(Cbo_tipoproducto.SelectedValue.ToString()),
                IdCondicionProceso = byte.Parse(Cbo_CondicionProcesos.SelectedValue.ToString())
            };

            if (tc_procesos.TabPages["Tbp_Extrusion"].Enabled == true)
            {
                mestextrusion = new PR_mEstandarExtrusion
                {
                    IdEstandarExtrusion = short.Parse(idextrusion.ToString()),
                    IdUsoProducto = byte.Parse(Cbo_UsoProducto.SelectedValue.ToString()),
                    Color = Txt_ColorSustrato.Text,
                    Flag_AditivoUV = (Chk_FlagAditivoUV.Checked == true) ? "1" : "0",
                    Flag_Apilar = (Chk_FlagApilar.Checked == true) ? "1" : "0",
                    Flag_Biodegradable = (Chk_FlagBiodegradable.Checked == true) ? "1" : "0",
                    Flag_Congelado = (Chk_FlagCongelado.Checked == true) ? "1" : "0",
                    Flag_Impresion = (Chk_DynasTratado.Checked == true) ? "1" : "0",
                    Dynas_Extrusion = decimal.Parse(nud_Dynas.Value.ToString()),
                    Flag_Refile = (Chk_FlagRefile.Checked == true) ? "1" : "0",
                    Medida_Refile = decimal.Parse(nud_medidarefile.Value.ToString()),
                    IdUnidadRefile = byte.Parse(Cbo_UnidadMedidaRefile.SelectedValue.ToString()),
                    Flag_MasLineal = (Chk_FlagMasLineal.Checked == true) ? "1" : "0",
                    Flag_Termocontraible = (Chk_FlagTermocontraible.Checked == true) ? "1" : "0",
                    Flag_Gofrado = (Chk_FlagGofrado.Checked == true) ? "1" : "0",
                    Flag_UsoPesado = (Chk_FlagUsoPesado.Checked == true) ? "1" : "0",
                    Flag_Otros = (Chk_Otros.Checked == true) ? "1" : "0",
                    Nota_Otros = txt_Otrosaplicativos.Text,
                    Medida_Manga = decimal.Parse(nud_medidaanchobobina.Value.ToString()),
                    IdUnidadManga = byte.Parse(Cbo_UnidadMedidaAnchoBob.SelectedValue.ToString()),
                    Flag_Fuelle = (Chk_Fuelle.Checked == true) ? "1" : "0",
                    Medida_Fuelle = decimal.Parse(nud_medidafuelle.Value.ToString()),
                    IdUnidadFuelle = byte.Parse(Cbo_unidadMedidaFuelle.SelectedValue.ToString()),
                    Flag_FuelleIncluido = (Chk_FuelleIncluido.Checked == true) ? "1" : "0",
                    Medida_Espesor = decimal.Parse(nud_medidaespesor.Value.ToString()),
                    IdUnidadEspesor = byte.Parse(Cbo_UMEspesorBob.SelectedValue.ToString()),
                    Nota_Tratado = Txt_DiseñoTratado.Text,
                    Nota_Extrusion = Txt_NotaExtrusion.Text,
                    Gramaje_Total = decimal.Parse(txt_GramajeTotal.Text),
                    Gramaje_Lineal = decimal.Parse(txt_GramajeLineal.Text),
                    Relacion_Soplado = decimal.Parse(nud_RelacionSoplado.Value.ToString()),
                    Ruta_FotoPlanoMecanicoExtr = txt_direccionPlanoExtrusion.Text,
                    Medida_Tuco_Extrusion = decimal.Parse(nud_medidaTuco.Value.ToString()),
                    IdUnidadMedidaTuco = byte.Parse(cbo_UnidadmedidaTuco.SelectedValue.ToString()),
                    Diametro_Tuco_Extrusion = decimal.Parse(nud_DiametroTuco.Value.ToString()),
                    IdUnidadMedidaDiametroTuco = byte.Parse(cbo_umdiametrotuco.SelectedValue.ToString()),
                    Peso_Tuco_Extrusion = decimal.Parse(nud_PesoTuco.Value.ToString()),
                    IdUnidadMedidaPesoTuco = byte.Parse(cbo_UMPesoTuco.SelectedValue.ToString()),
                    Diametro_Cabezal = decimal.Parse(nud_Diametrocabezal.Value.ToString()),
                    Gap_Extrusion = decimal.Parse(nud_Gapextrusion.Value.ToString()),
                    IdTipoTratado = byte.Parse(Cbo_tratado.SelectedValue.ToString()),
                    IdTipoMaterialExtruir = byte.Parse(Cbo_MaterialExtruir.SelectedValue.ToString()),
                    IdFormaSustrato = byte.Parse(cbo_FormaSustrato.SelectedValue.ToString())
                };
            }

            if (tc_procesos.TabPages["Tbp_Impresion"].Enabled == true)
            {
                mestimpresion = new PR_mEstandarImpresion
                {
                    IdEstandarImpresion = idimpresion,
                    Numero_Repeticiones = byte.Parse(nud_numerorepiticiones.Value.ToString()),
                    Medida_Repeticiones = decimal.Parse(txt_medidarepeticion.Text.ToString()),
                    IdUnidadRepeticiones = byte.Parse(Cbo_unidadmedidarepeticiones.SelectedValue.ToString()),
                    Numero_Bandas = byte.Parse(nud_numerobandas.Value.ToString()),
                    Medida_Bandas = decimal.Parse(txt_medidabandas.Text),
                    IdUnidadBandas = byte.Parse(Cbo_unidadmedidabandas.SelectedValue.ToString()),
                    Numero_Pistas = byte.Parse(nud_numeropistas.Value.ToString()),
                    Flag_CodigoBarra = (chk_codigobarras.Checked == true) ? "1" : "0",
                    Flag_PieImprenta = (chk_flagPieImprenta.Checked == true) ? "1" : "0",
                    IdPieImprenta = byte.Parse(cbo_pieimprenta.SelectedValue.ToString()),
                    IdTipoTinta = byte.Parse(cbo_tipotinta.SelectedValue.ToString()),
                    Flag_Agua = (chk_flagagua.Checked == true) ? "1" : "0",
                    Flag_Calor = (chk_flagcalor.Checked == true) ? "1" : "0",
                    Calor_C = decimal.Parse(txt_GradosCalor.Text.ToString()),
                    Flag_Congelamiento = (chk_flagcongelamiento.Checked == true) ? "1" : "0",
                    Congelamiento_C = decimal.Parse(txt_GradosCongelamiento.Text),
                    Flag_Detergente = (chk_flagdetergente.Checked == true) ? "1" : "0",
                    Flag_Frote = (chk_flagfrote.Checked == true) ? "1" : "0",
                    Flag_Grasa = (chk_flaggrasa.Checked == true) ? "1" : "0",
                    Flag_UV = (chk_flaguv.Checked == true) ? "1" : "0",
                    Flag_Otros = (chk_flagotros.Checked == true) ? "1" : "0",
                    Nota_Otros = txt_otrostintasresistentes.Text,
                    Numero_Clisse = int.Parse(nud_numeroclises.Value.ToString()),
                    Flag_ColorMuestraPantone = (rb_colorpantone.Checked == true) ? "1" : "0",
                    Flag_ImpresionInternaExterna = (Rb_ImpresionInterna.Checked == true) ? "0" : "1",
                    Numero_Negativos = byte.Parse(nud_numeronegativo.Value.ToString()),
                    Flag_TiraRetira = (chk_Retira.Checked == true) ? "1" : "0",
                    Numero_Colores = byte.Parse(nud_cantcolortira.Value.ToString()),
                    Nota_NombreColores = txt_colorestira.Text,
                    Numero_Colores2 = byte.Parse(nud_cantcolorretira.Value.ToString()),
                    Nota_NombreColores2 = txt_coloresretira.Text,
                    Flag_Taca = (chk_FlagTaca.Checked == true) ? "1" : "0",
                    IdPosicionTaca = byte.Parse(cbo_posiciontaca.SelectedValue.ToString()),
                    Medida_LargoTaca = decimal.Parse(nud_largotaca.Value.ToString()),
                    Medida_AnchoTaca = decimal.Parse(nud_anchotaca.Value.ToString()),
                    IdUnidadTaca = byte.Parse(cbo_unidadmedidataca.SelectedValue.ToString()),
                    Medida_EspesorClisse = decimal.Parse(txt_EspesorClisse.Text),
                    IdUnidadEspesorClisse = byte.Parse(cbo_IdUMespesorclisse.SelectedValue.ToString()),
                    Flag_Embobinado1 = (rb_sentido1.Checked == true) ? "1" : "0",
                    Flag_Embobinado2 = (rb_sentido2.Checked == true) ? "1" : "0",
                    Flag_Embobinado3 = (rb_sentido3.Checked == true) ? "1" : "0",
                    Flag_Embobinado4 = (rb_sentido4.Checked == true) ? "1" : "0",
                    Flag_Embobinado5 = (rb_sentido5.Checked == true) ? "1" : "0",
                    Flag_Embobinado6 = (rb_sentido6.Checked == true) ? "1" : "0",
                    Flag_Embobinado7 = (rb_sentido7.Checked == true) ? "1" : "0",
                    Flag_Embobinado8 = (rb_sentido8.Checked == true) ? "1" : "0",
                    IdImpresora = byte.Parse(cbm_Impresora.SelectedValue.ToString()),
                    Flag_DueñoClisseEmpresaCliente = (rb_empresa.Checked == true) ? "E" : "C",
                    Nota_Negativos = txt_obsnegativos.Text,
                    Flag_DevolucionClisse = "0",
                    Nota_DevolucionClisse = " ",
                    Nota_Impresion = txt_notaimpresion.Text,
                    Ruta_FotoPlanoMecanicoIMP = txt_direccionarte.Text,
                };
            }

            if (tc_procesos.TabPages["Tbp_Sellado"].Enabled == true)
            {
                mestsellado = new PR_mEstandarSellado()
                {
                    IdEstandarSellado = idsellado,
                    IdEstandar = Int32.Parse(txt_IdEstandar.Text),
                    IdAsa = byte.Parse(cbo_tipoasa.SelectedValue.ToString()),
                    IdTroquel = byte.Parse(cbo_tipotroquel.SelectedValue.ToString()),
                    IdTipoSello = byte.Parse(cbo_tiposello.SelectedValue.ToString()),
                    Ancho = decimal.Parse(nud_Ancho.Value.ToString()),
                    Largo = decimal.Parse(nud_largo.Value.ToString()),
                    IdUnidadLargo = byte.Parse(cbo_unidadmedidabolsa.SelectedValue.ToString()),
                    Flag_Posicion_Sello = (rb_InicioPosicionSello.Checked == true) ? "1" : "0",
                    Numero_Pistas = byte.Parse(txt_cantidadPistas.Text.ToString()),
                    IdEmpaquetado = byte.Parse(cbo_Empaquetado.SelectedValue.ToString()),
                    UnidadxPaquete = short.Parse(txt_Unidadporpaquete.Text.ToString()),
                    PaquetexCaja = byte.Parse(nud_PaquetesXCaja.Value.ToString()),
                    MillarxCaja = decimal.Parse(txt_cantmillaresXcajafardo.Text.ToString()),
                    Flag_Etiqueta = (chk_Etiquetado.Checked == true) ? "1" : "0",
                    Flag_Etiqueta_Paquete = (chk_etiquetapaquete.Checked == true) ? "1" : "0",
                    Flag_Etiqueta_Caja = (chk_etiquetacaja.Checked == true) ? "1" : "0",
                    Flag_Etiqueta_Fardo = (chk_Etiquetado.Checked == true) ? "1" : "0",
                    IdEtiqueta = byte.Parse(cbo_etiquetaempresa.SelectedValue.ToString()),
                    Flag_DetalleEtiqueta = (rb_AxLxE.Checked == true) ? "1" : "0",
                    IdTipoFuelle = byte.Parse(Cbo_Fuellesellado.SelectedValue.ToString()),
                    Medida_Fuelle = decimal.Parse(nud_medidafuellesell.Value.ToString()),
                    IdUnidadFuelle = byte.Parse(cbo_UMfuellesellado.SelectedValue.ToString()),
                    Flag_Perforaciones = (Chk_Perforaciones.Checked == true) ? "1" : "0",
                    Numero_Perforaciones = byte.Parse(nud_cantperforaciones.Value.ToString()),
                    Medida_Perforaciones = decimal.Parse(nud_diametroperforacion.Value.ToString()),
                    IdUnidadPerforaciones = byte.Parse(cbo_umperforaciones.SelectedValue.ToString()),
                    Flag_Pestaña = (chk_Pestaña.Checked == true) ? "1" : "0",
                    Medida_Pestaña = decimal.Parse(nud_medidapestaña.Value.ToString()),
                    IdUnidadPestaña = byte.Parse(cbo_umpestaña.SelectedValue.ToString()),
                    Flag_Solapa = (chk_solapa.Checked == true) ? "1" : "0",
                    Medida_Solapa = decimal.Parse(nud_medidasolapa.Value.ToString()),
                    IdUnidadSolapa = byte.Parse(cbo_umsolapa.SelectedValue.ToString()),
                    Flag_Refile = (chk_refilesellado.Checked == true) ? "1" : "0",
                    Medida_Refile = decimal.Parse(nud_medidarefile.Value.ToString()),
                    IdUnidadRefile = byte.Parse(cbo_umrefilesellado.SelectedValue.ToString()),
                    Peso_Tuco = decimal.Parse(txt_pesotuco.Text),
                    Peso_Envase = decimal.Parse(txt_pesoenvase.Text),
                    Peso_Promedio_Fardo = decimal.Parse(txt_pesocajafardo.Text),
                    Peso_Promedio_Millar = decimal.Parse(txt_pesomillar.Text),
                    Peso_Promedio_Paquete = decimal.Parse(txt_pesopaquete.Text),
                    Nota_Sellado = txt_notasellado.Text,
                    Ruta_FotoPlanoMecanicoSell = txt_DireccionubicacionPlanosellado.Text,
                };
            }

            if (tc_procesos.TabPages["Tbp_Laminado"].Enabled == true)
            {

            }

            if (tc_procesos.TabPages["Tbp_Doblado"].Enabled == true)
            {

            }
            if (tc_procesos.TabPages["Tbp_Corte"].Enabled == true)
            {

            }

            if (bln_Nuevo) rpta = PR_mEstandar_CN._Instancia.Agregar_Estandar(estadart, Img_Producto, mestextrusion, Img_PlanoExtrusion, mestimpresion, Img_Arte,
                                                                               mestsellado, img_PlanoMecanicoSellado);
            if (bln_Editar) rpta = PR_mEstandar_CN._Instancia.Actualizar_estandar(estadart, Img_Producto, mestextrusion, Img_PlanoExtrusion, mestimpresion, Img_Arte,
                                                                                mestsellado, img_PlanoMecanicoSellado);
            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo)
                { MessageBox.Show("Se Agrego un nuevo Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el registro", "Actualizar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                bln_Editar = false;
                bln_Nuevo = false;

                Estado_Toolbar(bln_Editar);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                HabilitarControles(false);

                tc_procesos.TabPages["Tbp_Extrusion"].Enabled = false;
                tc_procesos.TabPages["Tbp_Impresion"].Enabled = false;
                tc_procesos.TabPages["Tbp_Sellado"].Enabled = false;
                tc_procesos.TabPages["Tbp_Laminado"].Enabled = false;
                tc_procesos.TabPages["Tbp_Doblado"].Enabled = false;
                tc_procesos.TabPages["Tbp_Corte"].Enabled = false;
                tbc_Mnt.SelectTab(1);
            }
            else { MessageBox.Show(rpta, "error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            Cargar_Datos();

        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            bln_Nuevo = false;
            bln_Editar = false;
            txt_IdEstandar.Text = "0";
            tbc_Mnt.SelectTab(1);
            Estado_Toolbar(bln_Nuevo);

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            HabilitarControles(false);
            Limpiar_Controles();

            tc_procesos.TabPages["Tbp_Extrusion"].Enabled = false;
            tc_procesos.TabPages["Tbp_Impresion"].Enabled = false;
            tc_procesos.TabPages["Tbp_Sellado"].Enabled = false;
            tc_procesos.TabPages["Tbp_Laminado"].Enabled = false;
            tc_procesos.TabPages["Tbp_Doblado"].Enabled = false;
            tc_procesos.TabPages["Tbp_Corte"].Enabled = false;
        }

        private void Estado_Toolbar(Boolean vEditarForm, Boolean vUnloadForm = true)
        {
            tls_Agregar.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Modificar.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Eliminar.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Grabar.Enabled = (vUnloadForm) ? vEditarForm : false;
            tls_Deshacer.Enabled = (vUnloadForm) ? vEditarForm : false;
            tls_Imprimir.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Previo.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Buscar.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_OrdenASC.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_OrdenDsc.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Refrescar.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Primero.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Anterior.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Siguiente.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Ultimo.Enabled = (vUnloadForm) ? !vEditarForm : false;
        }

        public void HabilitarControles(Boolean vEstado)
        {
            Cbo_Cliente.Enabled = vEstado;
            Cbo_CondicionProcesos.Enabled = vEstado;
            Cbo_Procesos.Enabled = vEstado;
            Cbo_TipoProduccion.Enabled = vEstado;
            Cbo_tipoproducto.Enabled = vEstado;
            txt_DescripcionEstandar.Enabled = vEstado;
            txt_CodigoEstandar.Enabled = vEstado;
            txt_CodigoBarrasEstandar.Enabled = vEstado;
            Txt_RutaProducto.Enabled = vEstado;
            Cmd_BuscarArte.Enabled = vEstado;
            Cmd_EliminarArte.Enabled = vEstado;
            Dtp_FechaCreacion.Enabled = vEstado;
            nud_diametroSolicitado.Enabled = vEstado;
            cbo_umdiametroSolicitado.Enabled = vEstado;
        }

        public void Limpiar_Controles()
        {
            Chk_MostrarImagen.Checked = false;
            txt_DescripcionEstandar.Text = "";
            txt_CodigoEstandar.Text = "";
            txt_CodigoBarrasEstandar.Text = "";
            Txt_RutaProducto.Text = "";
            Dtp_FechaCreacion.Value = DateTime.Now;
            nud_diametroSolicitado.Value = decimal.Parse("0.00");

            //EXTRUSION
            Txt_ColorSustrato.Text = "";
            Txt_DiseñoTratado.Text = "";
            Txt_NotaExtrusion.Text = "";
            nud_medidafuelle.Value = 0;
            nud_medidarefile.Value = 0;
            nud_medidaanchobobina.Value = 0;
            nud_medidaTuco.Value = 0;
            nud_PesoTuco.Value = 0;
            nud_medidaespesor.Value = 0;
            nud_DiametroTuco.Value = 0;
            nud_RelacionSoplado.Value = 0;
            nud_Dynas.Value = 0;
            txt_Otrosaplicativos.Text = "";
            txt_GramajeLineal.Text = "0.00";
            txt_GramajeTotal.Text = "0.00";
            nud_Diametrocabezal.Value = 0;
            nud_Gapextrusion.Value = 0;
            txt_direccionPlanoExtrusion.Text = "";
            Chk_Fuelle.Checked = false;
            Chk_FlagRefile.Checked = false;
            Chk_FlagGofrado.Checked = false;
            Chk_FuelleIncluido.Checked = false;
            Chk_FlagAditivoUV.Checked = false;
            Chk_FlagTermocontraible.Checked = false;
            Chk_FlagApilar.Checked = false;
            Chk_FlagBiodegradable.Checked = false;
            Chk_FlagMasLineal.Checked = false;
            Chk_FlagCongelado.Checked = false;
            Chk_FlagUsoPesado.Checked = false;
            Chk_DynasTratado.Checked = false;
            Chk_Otros.Checked = false;

            //IMPRESION
            nud_numerorepiticiones.Value = 0;
            txt_medidarepeticion.Text = "0.00";
            nud_numerobandas.Value = 0;
            txt_medidabandas.Text = "0.00";
            nud_numeronegativo.Value = 0;
            nud_numeropistas.Value = 0;
            nud_numeroclises.Value = 0;
            nud_cantcolortira.Value = 0;
            nud_cantcolorretira.Value = 0;
            txt_colorestira.Text = "";
            txt_coloresretira.Text = "";
            rb_sentido1.Checked = false;
            rb_sentido2.Checked = false;
            rb_sentido3.Checked = false;
            rb_sentido4.Checked = false;
            rb_sentido5.Checked = false;
            rb_sentido6.Checked = false;
            rb_sentido7.Checked = false;
            rb_sentido8.Checked = false;
            txt_diseño.Text = "";
            chk_codigobarras.Checked = false;
            rb_empresa.Checked = false;
            rb_cliente.Checked = false;
            txt_EspesorClisse.Text = "0.00";
            txt_obsnegativos.Text = "";
            chk_flagdetergente.Checked = false;
            chk_flagagua.Checked = false;
            chk_flagcalor.Checked = false;
            chk_flagfrote.Checked = false;
            chk_flagcongelamiento.Checked = false;
            chk_flaggrasa.Checked = false;
            chk_flaguv.Checked = false;
            chk_flagotros.Checked = false;
            txt_GradosCalor.Text = "0.00";
            txt_GradosCongelamiento.Text = "0.00";
            txt_otrostintasresistentes.Text = "";
            nud_largotaca.Value = 0;
            nud_anchotaca.Value = 0;
            txt_notaimpresion.Text = "";
            txt_direccionarte.Text = "";

            //SELLADO
            nud_Ancho.Value = 0;
            nud_largo.Value = 0;
            txt_cantidadPistas.Text = "0";
            txt_Unidadporpaquete.Text = "0";
            nud_PaquetesXCaja.Text = "0";
            txt_cantmillaresXcajafardo.Text = "0.00";
            chk_Etiquetado.Checked = false;
            chk_EtiquetaFardo.Checked = false;
            chk_etiquetacaja.Checked = false;
            chk_etiquetapaquete.Checked = false;
            Chk_Perforaciones.Checked = false;
            chk_Pestaña.Checked = false;
            chk_solapa.Checked = false;
            chk_refilesellado.Checked = false;
            nud_medidafuellesell.Value = 0;
            nud_cantperforaciones.Value = 0;
            nud_diametroperforacion.Value = 0;
            nud_medidapestaña.Value = 0;
            nud_medidasolapa.Value = 0;
            nud_medrefilesellado.Value = 0;
            txt_pesotuco.Text = "0.00";
            txt_pesoenvase.Text = "0.00";
            txt_pesocajafardo.Text = "0.00";
            txt_pesopaquete.Text = "0.00";
            txt_pesomillar.Text = "0.00";
            txt_notasellado.Text = "";
            txt_DireccionubicacionPlanosellado.Text = "";
            Img_Producto.Image = null;
            Img_PlanoExtrusion.Image = null;
            Img_Arte.Image = null;
            img_PlanoMecanicoSellado.Image = null;
        }

        private void Cbo_Procesos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bln_Editar == true || bln_Nuevo == true)
            {
                var datos = PR_aProcesos_CN._Instancia.TraerPorID(Int32.Parse(Cbo_Procesos.SelectedValue.ToString()));
                foreach (var i in datos)
                {
                    tc_procesos.TabPages["Tbp_Extrusion"].Enabled = i.Flag_Extrusion == 1 ? true : false;
                    tc_procesos.TabPages["Tbp_Impresion"].Enabled = i.Flag_Impresion == 1 ? true : false;
                    tc_procesos.TabPages["Tbp_Sellado"].Enabled = i.Flag_Sellado == 1 ? true : false;
                    tc_procesos.TabPages["Tbp_Laminado"].Enabled = i.Flag_Laminado == 1 ? true : false;
                    tc_procesos.TabPages["Tbp_Doblado"].Enabled = i.Flag_Doblado == 1 ? true : false;
                    tc_procesos.TabPages["Tbp_Corte"].Enabled = i.Flag_Corte == 1 ? true : false;
                }
            }
        }

        private void cmd_Clientes_Click(object sender, EventArgs e)
        {
            Frm_Cliente clientes = new Frm_Cliente();
            clientes.ShowDialog();
            Cbo_Cliente.DataSource = PR_mClientes_CN._Instancia.Lista_Clientes();
        }

        private void cmd_Tipoproduccion_Click(object sender, EventArgs e)
        {
            Frm_TipoProduccion tipoproduccion = new Frm_TipoProduccion();
            tipoproduccion.ShowDialog();
            Cbo_TipoProduccion.DataSource = PR_aTipoProduccion_CN._Instancia.Lista_TipoProduccion();
        }

        private void cmd_CondicionProceso_Click(object sender, EventArgs e)
        {
            Frm_CondicionProceso condicionproceso = new Frm_CondicionProceso();
            condicionproceso.ShowDialog();
            Cbo_CondicionProcesos.DataSource = PR_aCondicionProceso_CN._Instancia.Lista_CondicionProceso();
        }

        private void cmd_tipoproducto_Click(object sender, EventArgs e)
        {
            Frm_TipoProducto tipoproducto = new Frm_TipoProducto();
            tipoproducto.ShowDialog();
            Cbo_tipoproducto.DataSource = PR_aTipoProducto_CN._Instancia.Lista_TipoProducto();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog getImagen = new OpenFileDialog();
            getImagen.InitialDirectory = "C:\\";
            getImagen.Filter = "Archivos de imagenes(*.jpg)(*.jpeg)|*.jpg;jpeg";

            if (getImagen.ShowDialog() == DialogResult.OK)
            {
                Img_Producto.ImageLocation = getImagen.FileName;
                Txt_RutaProducto.Text = getImagen.FileName;
            }
            else { MessageBox.Show("No se selecciono ninguna imagen", "Sin Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnLimpiarImagen_Click(object sender, EventArgs e)
        {
            Img_Producto.Image = null;
            Txt_RutaProducto.Text = "";
        }

        private void cmd_formasustrato_Click(object sender, EventArgs e)
        {
            Frm_FormaSustrato formasustrato = new Frm_FormaSustrato();
            formasustrato.ShowDialog();
            cbo_FormaSustrato.DataSource = PR_aFormaSustrato_CN._Instancia.Lista_FormaSustrato();
        }

        private void cmd_tiposustrato_Click(object sender, EventArgs e)
        {
            Frm_TipoMaterialExtruir materialextruir = new Frm_TipoMaterialExtruir();
            materialextruir.ShowDialog();
            Cbo_MaterialExtruir.DataSource = PR_aTipoMaterialExtruir_CN._Instancia.Lista_TipoMaterialExtruir();
        }

        private void cmd_tratado_Click(object sender, EventArgs e)
        {
            Frm_TipoTratado tipotratado = new Frm_TipoTratado();
            tipotratado.ShowDialog();
            Cbo_tratado.DataSource = PR_aTipoTratado_CN._Instancia.Lista_TipoTratado();
        }

        private void cmd_unidadmedidafuelle_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            Cbo_unidadMedidaFuelle.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_unidadmedidarefile_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            Cbo_UnidadMedidaRefile.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_umrepeticiones_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            Cbo_unidadmedidarepeticiones.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_unidadmedidabandas_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            Cbo_unidadmedidabandas.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_tipotinta_Click(object sender, EventArgs e)
        {
            Frm_TipoTinta tipotinta = new Frm_TipoTinta();
            tipotinta.ShowDialog();
            cbo_tipotinta.DataSource = PR_aTipoTinta_CN._Instancia.Lista_TipoTinta();
        }

        private void cmd_impresorarodillo_Click(object sender, EventArgs e)
        {
            Frm_ImpresoraVSRodillo impresora = new Frm_ImpresoraVSRodillo();
            impresora.ShowDialog();
            cbm_Impresora.DataSource = PR_mImpresora_CN._Instancia.Lista_Impresora();
        }

        private void cmd_pieimprenta_Click(object sender, EventArgs e)
        {
            Frm_PieImprenta pieimprenta = new Frm_PieImprenta();
            pieimprenta.ShowDialog();
            cbo_pieimprenta.DataSource = PR_aPieImprenta_CN._Instancia.Lista_PieImprenta();
        }

        private void cmd_posiciontaca_Click(object sender, EventArgs e)
        {
            Frm_PosicionTaca posiciontaca = new Frm_PosicionTaca();
            posiciontaca.ShowDialog();
            cbo_posiciontaca.DataSource = PR_aPosicionTaca_CN._Instancia.Lista_PosicionTaca();
        }

        private void cmd_umtaca_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            cbo_unidadmedidataca.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_TipoFuelle_Click(object sender, EventArgs e)
        {
            Frm_TipoFuelle tipofuelle = new Frm_TipoFuelle();
            tipofuelle.ShowDialog();
            Cbo_TipoFuelle.DataSource = PR_aTipoFuelle_CN._Instancia.Lista_TipoFuelle();
        }

        private void cmd_unidadmedidabolsa_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            cbo_unidadmedidabolsa.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_tiposello_Click(object sender, EventArgs e)
        {
            Frm_TipoSello tiposello = new Frm_TipoSello();
            tiposello.ShowDialog();
            cbo_tiposello.DataSource = PR_aTipoSello_CN._Instancia.Lista_TipoSello();
        }

        private void cmd_tipotroquel_Click(object sender, EventArgs e)
        {
            Frm_TipoTroquel tipotroquel = new Frm_TipoTroquel();
            tipotroquel.ShowDialog();
            cbo_tipotroquel.DataSource = PR_aTipoTroquel_CN._Instancia.Lista_TipoTroquel();
        }

        private void cmd_tipoasa_Click(object sender, EventArgs e)
        {
            Frm_TipoAsa tipoasa = new Frm_TipoAsa();
            tipoasa.ShowDialog();
            cbo_tipoasa.DataSource = PR_aAsa_CN._Instancia.Lista_Asas();
        }

        private void cmd_empaquetado_Click(object sender, EventArgs e)
        {
            Frm_Empaquetado empaquetado = new Frm_Empaquetado();
            empaquetado.ShowDialog();
            cbo_Empaquetado.DataSource = PR_aEmpaquetado_CN._Instancia.Lista_Empaquetado();
        }

        private void cmd_etiquetaempresa_Click(object sender, EventArgs e)
        {
            Frm_Etiqueta etiqueta = new Frm_Etiqueta();
            etiqueta.ShowDialog();
            cbo_etiquetaempresa.DataSource = PR_aEtiqueta_CN._Instancia.Lista_Etiqueta();
        }

        private void cmd_unidadfuellesellado_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            cbo_UMfuellesellado.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_umperforaciones_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            cbo_umperforaciones.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_pestaña_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            cbo_umpestaña.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_solapa_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            cbo_umsolapa.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void Chk_MostrarImagen_CheckedChanged(object sender, EventArgs e)
        {
            Img_Producto.Image = null;
            Img_PlanoExtrusion.Image = null;
            Img_Arte.Image = null;
            img_PlanoMecanicoSellado.Image = null;

            if (bln_Nuevo == false)
            {
                if (Chk_MostrarImagen.Checked == true)
                {
                    PR_mEstandar_CN._Instancia.Descargar_ImagenProducto(Img_Producto, Int32.Parse(txt_IdEstandar.Text));
                    if (idextrusion > 0) PR_mEstandarExtrusion_CN._Instancia.Descargar_ImagenProducto(Img_PlanoExtrusion, idextrusion);
                    if (idimpresion > 0) PR_mEstandarImpresion_CN._Instancia.Descargar_ImagenProducto(Img_Arte, idimpresion);
                    if (idsellado > 0) PR_mEstandarSellado_CN._Instancia.Descargar_ImagenProducto(img_PlanoMecanicoSellado, idsellado);
                }
            }
        }

        private void Chk_Fuelle_CheckedChanged(object sender, EventArgs e)
        {
            Cbo_TipoFuelle.Enabled = Chk_Fuelle.Checked;
            cmd_TipoFuelle.Enabled = Chk_Fuelle.Checked;
            nud_medidafuelle.Enabled = Chk_Fuelle.Checked;
            Cbo_unidadMedidaFuelle.Enabled = Chk_Fuelle.Checked;
            cmd_unidadmedidafuelle.Enabled = Chk_Fuelle.Checked;
            Chk_FuelleIncluido.Enabled = Chk_Fuelle.Checked;
        }

        private void Chk_Refile_CheckedChanged(object sender, EventArgs e)
        {
            nud_medidarefile.Enabled = Chk_FlagRefile.Checked;
            Cbo_UnidadMedidaRefile.Enabled = Chk_FlagRefile.Checked;
            cmd_unidadmedidarefile.Enabled = Chk_FlagRefile.Checked;
        }

        private void Chk_Otros_CheckedChanged(object sender, EventArgs e)
        {
            txt_Otrosaplicativos.Enabled = Chk_Otros.Checked;
        }

        private void Chk_DynasTratado_CheckedChanged(object sender, EventArgs e)
        {
            nud_Dynas.Enabled = Chk_DynasTratado.Checked;
        }

        private void cmd_unidadmedidaanchobobina_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            Cbo_UnidadMedidaAnchoBob.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_UnidadMedidaTuco_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            cbo_UnidadmedidaTuco.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_UnidadMedidaDiametro_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            cbo_umdiametrotuco.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_UnidadMedidaPesoTuco_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            cbo_UMPesoTuco.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void cmd_unidadmedidaespesorbobina_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            Cbo_UMEspesorBob.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void chk_flagcongelamiento_CheckedChanged(object sender, EventArgs e)
        { txt_GradosCongelamiento.Enabled = chk_flagcongelamiento.Checked; }

        private void chk_flagotros_CheckedChanged(object sender, EventArgs e)
        { txt_otrostintasresistentes.Enabled = chk_flagotros.Checked; }

        private void cmd_UsoProducto_Click(object sender, EventArgs e)
        {
            Frm_UsoProducto usoproducto = new Frm_UsoProducto();
            usoproducto.ShowDialog();
            Cbo_UsoProducto.DataSource = PR_aUsoProducto_CN.Instancia.Lista_UsoProducto();
        }

        private void chk_flagcalor_CheckedChanged(object sender, EventArgs e)
        { txt_GradosCalor.Enabled = chk_flagcalor.Checked; }

        private void cmd_diametroSolicitado_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            cbo_umdiametroSolicitado.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void btn_agregarimgextr_Click(object sender, EventArgs e)
        {
            OpenFileDialog getImagen = new OpenFileDialog();
            getImagen.InitialDirectory = "C:\\";
            getImagen.Filter = "Archivos de imagenes(*.jpg)(*.jpeg)|*.jpg;jpeg";

            if (getImagen.ShowDialog() == DialogResult.OK)
            {
                Img_PlanoExtrusion.ImageLocation = getImagen.FileName;
                txt_direccionPlanoExtrusion.Text = getImagen.FileName;
            }
            else { MessageBox.Show("No se selecciono ninguna imagen", "Sin Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btn_Eliminarimgextr_Click(object sender, EventArgs e)
        {
            Img_PlanoExtrusion.Image = null;
            txt_direccionPlanoExtrusion.Text = "";
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) => Cargar_Datos();

        private void cbm_Impresora_SelectedIndexChanged(object sender, EventArgs e)
        { txt_rodillo.Text = ((Capa_Entidades.Tablas.PR_mImpresora)cbm_Impresora.SelectedItem).Descripcion; }

        private void chk_Retira_CheckedChanged(object sender, EventArgs e)
        {
            nud_cantcolorretira.Enabled = chk_Retira.Checked;
            txt_coloresretira.Enabled = chk_Retira.Checked;
        }

        private void chk_flagPieImprenta_CheckedChanged(object sender, EventArgs e)
        { cbo_pieimprenta.Enabled = chk_flagPieImprenta.Checked; }

        private void chk_FlagTaca_CheckedChanged(object sender, EventArgs e)
        {
            cbo_posiciontaca.Enabled = chk_FlagTaca.Checked;
            nud_largotaca.Enabled = chk_FlagTaca.Checked;
            nud_anchotaca.Enabled = chk_FlagTaca.Checked;
            cbo_unidadmedidataca.Enabled = chk_FlagTaca.Checked;
        }

        private void Cmd_BuscarArte_Click(object sender, EventArgs e)
        {
            OpenFileDialog getImagen = new OpenFileDialog();
            getImagen.InitialDirectory = "C:\\";
            getImagen.Filter = "Archivos de imagenes(*.jpg)(*.jpeg)|*.jpg;jpeg";

            if (getImagen.ShowDialog() == DialogResult.OK)
            {
                Img_Arte.ImageLocation = getImagen.FileName;
                txt_direccionarte.Text = getImagen.FileName;
            }
            else { MessageBox.Show("No se selecciono ninguna imagen", "Sin Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void Cmd_EliminarArte_Click(object sender, EventArgs e)
        {
            Img_Arte.Image = null;
            txt_direccionarte.Text = "";
        }

        private void Chk_Perforaciones_CheckedChanged(object sender, EventArgs e)
        {
            nud_cantperforaciones.Enabled = Chk_Perforaciones.Checked;
            nud_diametroperforacion.Enabled = Chk_Perforaciones.Checked;
            cbo_umperforaciones.Enabled = Chk_Perforaciones.Checked;
            cmd_umperforaciones.Enabled = Chk_Perforaciones.Checked;
        }

        private void chk_Pestaña_CheckedChanged(object sender, EventArgs e)
        {
            nud_medidapestaña.Enabled = chk_Pestaña.Checked;
            cbo_umpestaña.Enabled = chk_Pestaña.Checked;
            cmd_pestaña.Enabled = chk_Pestaña.Checked;
        }

        private void chk_solapa_CheckedChanged(object sender, EventArgs e)
        {
            nud_medidasolapa.Enabled = chk_solapa.Checked;
            cbo_umsolapa.Enabled = chk_solapa.Checked;
            cmd_solapa.Enabled = chk_solapa.Checked;
        }

        private void chk_refilesellado_CheckedChanged(object sender, EventArgs e)
        {
            nud_medrefilesellado.Enabled = chk_refilesellado.Checked;
            cbo_umrefilesellado.Enabled = chk_refilesellado.Checked;
            cmd_refile.Enabled = chk_refilesellado.Checked;
        }

        private void Btn_AgregarPlanoSellado_Click(object sender, EventArgs e)
        {
            OpenFileDialog getImagen = new OpenFileDialog();
            getImagen.InitialDirectory = "C:\\";
            getImagen.Filter = "Archivos de imagenes(*.jpg)(*.jpeg)|*.jpg;jpeg";

            if (getImagen.ShowDialog() == DialogResult.OK)
            {
                img_PlanoMecanicoSellado.ImageLocation = getImagen.FileName;
                txt_DireccionubicacionPlanosellado.Text = getImagen.FileName;
            }
            else { MessageBox.Show("No se selecciono ninguna imagen", "Sin Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void Btn_EliminarPlanoSellado_Click(object sender, EventArgs e)
        {
            img_PlanoMecanicoSellado.Image = null;
            txt_DireccionubicacionPlanosellado.Text = "";
        }

        private void nud_PaquetesXCaja_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.SoloNumeros(e);
        private void txt_Unidadporpaquete_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.SoloNumeros(e);
        private void txt_cantmillaresXcajafardo_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_Ancho_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_largo_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_medidafuellesell_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_cantperforaciones_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.SoloNumeros(e);
        private void nud_diametroperforacion_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_medidapestaña_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_medidasolapa_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_medrefilesellado_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void txt_pesotuco_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void txt_pesoenvase_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void txt_pesocajafardo_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void txt_pesopaquete_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void txt_pesomillar_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_numerorepiticiones_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.SoloNumeros(e);
        private void nud_numerobandas_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.SoloNumeros(e);
        private void nud_numeronegativo_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.SoloNumeros(e);
        private void nud_numeropistas_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.SoloNumeros(e);
        private void nud_cantcolortira_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.SoloNumeros(e);
        private void nud_cantcolorretira_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.SoloNumeros(e);
        private void txt_medidarepeticion_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void txt_medidabandas_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_numeroclises_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.SoloNumeros(e);
        private void txt_EspesorClisse_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void txt_GradosCalor_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void txt_GradosCongelamiento_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_largotaca_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_anchotaca_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_medidafuelle_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_medidarefile_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_medidaanchobobina_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_medidaTuco_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_DiametroTuco_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_PesoTuco_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_RelacionSoplado_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_medidaespesor_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_Dynas_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_Diametrocabezal_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_Gapextrusion_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void nud_diametroSolicitado_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.NumerosDecimales(e);
        private void txt_cantidadPistas_KeyPress(object sender, KeyPressEventArgs e) => Validar_Campos.SoloNumeros(e);

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;
            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["Idestandar"].Value.ToString()));
            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void tls_Anterior_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (SelectIndex == 0) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex - 1].Selected = true;
            SelectIndex = SelectIndex - 1;

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["Idestandar"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;
            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;
            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["Idestandar"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;
            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["Idestandar"].Value.ToString()));
            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void tls_Previo_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = PrintDocument;
                (MyPrintPreviewDialog as Form).WindowState = FormWindowState.Maximized;
                MyPrintPreviewDialog.ShowDialog();
            }
        }

        private void cmd_refile_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            cbo_umrefilesellado.DataSource = PR_aUnidadMedidas_CN._Instancia.Lista_UnidadMedida();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool more = dgr_Visor_Grilla.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void tls_Buscar_Click(object sender, EventArgs e)
        {
            Frm_Buscar fBuscar = new Frm_Buscar();
            fBuscar.Configurar(ref dgv_Mnt, dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name);
            fBuscar.ShowDialog();
        }

        private void tls_OrdenASC_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var Listado_Ordenado = (from ordenar in Lst_Estandares.OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var Listado_Ordenado = (from ordenar in Lst_Estandares.OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void Cbo_FiltroTipoProduccion_SelectedIndexChanged(object sender, EventArgs e) => Cargar_Datos();
        private void Dtp_FechaInicial_ValueChanged(object sender, EventArgs e) => Cargar_Datos();

        private void chk_FiltroCliente_CheckedChanged(object sender, EventArgs e)
        {
            cbo_FiltroCliente.Enabled = chk_FiltroCliente.Checked;
            Cargar_Datos();
        }

        private void cbo_FiltroCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chk_FiltroCliente.Checked == true) Cargar_Datos();
        }

        private void tls_Imprimir_Click(object sender, EventArgs e)
        {

        }

        private void Dtp_FechaFinal_ValueChanged(object sender, EventArgs e) => Cargar_Datos();
        
        private void chk_FiltroTipoEstandar_CheckedChanged(object sender, EventArgs e)
        {
            Cbo_FiltroTipoProduccion.Enabled = chk_FiltroTipoEstandar.Checked;
            Cargar_Datos();
        }

        private void Chk_FiltroRango_CheckedChanged(object sender, EventArgs e)
        {
            Dtp_FechaInicial.Enabled = Chk_FiltroRango.Checked;
            Dtp_FechaFinal.Enabled = Chk_FiltroRango.Checked;
            Cargar_Datos();
        }

        private void cmd_fuellesellado_Click(object sender, EventArgs e)
        {
            Frm_TipoFuelle tipofuelle = new Frm_TipoFuelle();
            tipofuelle.ShowDialog();
            Cbo_Fuellesellado.DataSource = PR_aTipoFuelle_CN._Instancia.Lista_TipoFuelle();
        }

        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            PrintDocument.DocumentName = "Lista de Estandares";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            
            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Estandares", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Estandares", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            return true;
        }


    }
}
