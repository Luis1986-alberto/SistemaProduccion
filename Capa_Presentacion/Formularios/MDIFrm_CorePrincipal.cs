using Capa_Presentacion.Formularios.Logistica;
using Capa_Presentacion.Formularios.Produccion;
using System;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios
{
    public partial class MDIFrm_CorePrincipal : Form
    {
        public string IdUsuario { get; set; }
        public string Contraseña { get; set; }
        public string BasedeDatos { get; set; }
        public string Servidor { get; set; }
        public string PC_Usuario { get; set; }

        public MDIFrm_CorePrincipal()
        {
            InitializeComponent();
            tim_Reloj.Enabled = true;
        }

        public void TraerDatosIniciales()
        {
            stb_Usuario.Text = IdUsuario;
            stb_Modulo.Text = "Sistema de Producción";
            stb_BaseDeDatos.Text = BasedeDatos;
            stb_Servidor.Text = Servidor;
            stb_PC_Usuario.Text = PC_Usuario;
        }

        private void tim_Reloj_Tick(object sender, EventArgs e)
        {
            this.Text = "Sistema de Producción - " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void MDIFrm_Principal_Load(object sender, EventArgs e)
        {

        }

        #region Configuracion
        private void mnu_Año_Click(object sender, EventArgs e)
        {
            this.mnu_Año.Enabled = false;

            Frm_Año fAño = new Frm_Año();
            fAño.MdiParent = this;

            fAño.FormClosing += new FormClosingEventHandler(Frm_Año_FormClosing);
            fAño.Show();
        }

        private void Frm_Año_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_Año.Enabled = true;
        }

        private void mnu_Usuarios_Click(object sender, EventArgs e)
        {
            this.mnu_Usuarios.Enabled = false;

            Frm_Usuario fUsuario = new Frm_Usuario();
            fUsuario.MdiParent = this;
            fUsuario.FormClosing += new FormClosingEventHandler(Frm_Usuario_FormClosing);
            fUsuario.Show();
        }
        private void Frm_Usuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_Usuarios.Enabled = true;
        }

        private void mnu_Mes_Click(object sender, EventArgs e)
        {
            this.mnu_Mes.Enabled = false;
            Frm_Mes mes = new Frm_Mes();
            mes.MdiParent = this;
            mes.FormClosing += new FormClosingEventHandler(Frm_Mes_FormClosing);
            mes.Show();
        }

        private void Frm_Mes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_Mes.Enabled = true;
        }
        #endregion


        #region Produccion
        private void mnu_TipoAsa_Click(object sender, EventArgs e)
        {
            this.mnu_TipoAsa.Enabled = false;
            Frm_TipoAsa tipoAsa = new Frm_TipoAsa();
            tipoAsa.MdiParent = this;

            tipoAsa.FormClosing += new FormClosingEventHandler(Frm_TipoAsa_FormClosing);
            tipoAsa.Show();
        }

        private void Frm_TipoAsa_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_TipoAsa.Enabled = true;
        }

        private void mnu_Carreta_Click(object sender, EventArgs e)
        {
            this.mnu_Carreta.Enabled = false;
            Frm_Carreta carreta = new Frm_Carreta();
            carreta.MdiParent = this;

            carreta.FormClosing += new FormClosingEventHandler(Frm_Carreta_FormClosing);
            carreta.Show();
        }

        private void Frm_Carreta_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_Carreta.Enabled = true;
        }

        private void mnu_Color_Click(object sender, EventArgs e)
        {
            this.mnu_Color.Enabled = false;
            Frm_Color color = new Frm_Color();
            color.MdiParent = this;

            color.FormClosing += new FormClosingEventHandler(Frm_Color_FormClosing);
            color.Show();
        }

        private void Frm_Color_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_Color.Enabled = true;
        }

        private void mnu_FormaSustrato_Click(object sender, EventArgs e)
        {
            this.mnu_FormaSustrato.Enabled = false;
            Frm_FormaSustrato forma = new Frm_FormaSustrato();
            forma.MdiParent = this;

            forma.FormClosing += new FormClosingEventHandler(Frm_FormaSustrato_FormClosing);
            forma.Show();
        }

        private void Frm_FormaSustrato_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_FormaSustrato.Enabled = true;
        }

        private void mnu_Fuelle_Click(object sender, EventArgs e)
        {
            this.mnu_Fuelle.Enabled = false;
            Frm_TipoFuelle fuelle = new Frm_TipoFuelle();
            fuelle.MdiParent = this;

            fuelle.FormClosing += new FormClosingEventHandler(Frm_Fuelle_FormClosing);
            fuelle.Show();
        }

        private void Frm_Fuelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_Fuelle.Enabled = true;
        }

        private void mnu_Empaquetado_Click(object sender, EventArgs e)
        {
            this.mnu_Empaquetado.Enabled = false;
            Frm_Empaquetado empaquetado = new Frm_Empaquetado();
            empaquetado.MdiParent = this;

            empaquetado.FormClosing += new FormClosingEventHandler(Frm_Empaquetado_FormClosing);
            empaquetado.Show();
        }

        private void Frm_Empaquetado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_Empaquetado.Enabled = true;
        }



        private void mnu_EmpresaEtiqueta_Click(object sender, EventArgs e)
        {
            this.mnu_EmpresaEtiqueta.Enabled = false;
            Frm_Etiqueta empetiqueta = new Frm_Etiqueta();
            empetiqueta.MdiParent = this;

            empetiqueta.FormClosing += new FormClosingEventHandler(Frm_EmpresaEtiqueta_FormClosing);
            empetiqueta.Show();
        }

        private void Frm_EmpresaEtiqueta_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_EmpresaEtiqueta.Enabled = true;
        }

        private void mnu_EstadoProcesoOrdenProd_Click(object sender, EventArgs e)
        {
            this.mnu_EstadoProcesoOrdenProd.Enabled = false;
            Frm_EstadoOrdenProduccion_Programa estadoproop = new Frm_EstadoOrdenProduccion_Programa();
            estadoproop.MdiParent = this;

            estadoproop.FormClosing += new FormClosingEventHandler(Frm_EstadoProcesoOrdenProduccion_FormClosing);
            estadoproop.Show();
        }

        private void Frm_EstadoProcesoOrdenProduccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_EstadoProcesoOrdenProd.Enabled = true;
        }

        private void mnu_CondicionProceso_Click(object sender, EventArgs e)
        {
            this.mnu_CondicionProceso.Enabled = false;
            Frm_CondicionProceso condicionproc = new Frm_CondicionProceso();
            condicionproc.MdiParent = this;

            condicionproc.FormClosing += new FormClosingEventHandler(Frm_CondicionProceso_FormClosing);
            condicionproc.Show();
        }

        private void Frm_CondicionProceso_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_CondicionProceso.Enabled = true;
        }

        private void mnu_PieImprenta_Click(object sender, EventArgs e)
        {
            this.mnu_PieImprenta.Enabled = false;
            Frm_PieImprenta oieimprenta = new Frm_PieImprenta();
            oieimprenta.MdiParent = this;

            oieimprenta.FormClosing += new FormClosingEventHandler(Frm_PieImprenta_FormClosing);
            oieimprenta.Show();
        }

        private void Frm_PieImprenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_PieImprenta.Enabled = true;
        }

        private void mnu_PosicionTaca_Click(object sender, EventArgs e)
        {
            this.mnu_PosicionTaca.Enabled = false;
            Frm_PosicionTaca posiciontaca = new Frm_PosicionTaca();
            posiciontaca.MdiParent = this;

            posiciontaca.FormClosing += new FormClosingEventHandler(Frm_PosicionTaca_FormClosing);
            posiciontaca.Show();
        }

        private void Frm_PosicionTaca_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_PosicionTaca.Enabled = true;
        }

        private void mnu_Procesos_Click(object sender, EventArgs e)
        {
            this.mnu_Procesos.Enabled = false;
            Frm_ProcesosProduccion procesosprod = new Frm_ProcesosProduccion();
            procesosprod.MdiParent = this;

            procesosprod.FormClosing += new FormClosingEventHandler(Frm_ProcesosProduccion_FormClosing);
            procesosprod.Show();
        }

        private void Frm_ProcesosProduccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_Procesos.Enabled = true;
        }

        private void mnu_Rodillos_Click(object sender, EventArgs e)
        {
            this.mnu_Rodillos.Enabled = false;
            Frm_Rodillo rodillo = new Frm_Rodillo();
            rodillo.MdiParent = this;

            rodillo.FormClosing += new FormClosingEventHandler(Frm_Rodillo_FormClosing);
            rodillo.Show();
        }

        private void Frm_Rodillo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_Rodillos.Enabled = true;
        }



        private void mnu_TipoProduccion_Click(object sender, EventArgs e)
        {
            this.mnu_TipoProduccion.Enabled = false;
            Frm_TipoProduccion tipoproduccion = new Frm_TipoProduccion();
            tipoproduccion.MdiParent = this;

            tipoproduccion.FormClosing += new FormClosingEventHandler(Frm_TipoProduccion_FormClosing);
            tipoproduccion.Show();
        }

        private void Frm_TipoProduccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_TipoProduccion.Enabled = true;
        }

        private void mnu_TipoProducto_Click(object sender, EventArgs e)
        {
            this.mnu_TipoProducto.Enabled = false;
            Frm_TipoProducto tipoproducto = new Frm_TipoProducto();
            tipoproducto.MdiParent = this;

            tipoproducto.FormClosing += new FormClosingEventHandler(Frm_TipoProducto_FormClosing);
            tipoproducto.Show();
        }

        private void Frm_TipoProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_TipoProducto.Enabled = true;
        }

        private void mnu_TipoRubro_Click(object sender, EventArgs e)
        {
            this.mnu_TipoRubro.Enabled = false;
            Frm_TipoRubro tiporubro = new Frm_TipoRubro();
            tiporubro.MdiParent = this;

            tiporubro.FormClosing += new FormClosingEventHandler(Frm_TipoRubro_FormClosing);
            tiporubro.Show();
        }

        private void Frm_TipoRubro_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_TipoRubro.Enabled = true;
        }

        private void mnu_TipoSello_Click(object sender, EventArgs e)
        {
            this.mnu_TipoSello.Enabled = false;
            Frm_TipoSello tiposello = new Frm_TipoSello();
            tiposello.MdiParent = this;

            tiposello.FormClosing += new FormClosingEventHandler(Frm_TipoSello_FormClosing);
            tiposello.Show();
        }

        private void Frm_TipoSello_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_TipoSello.Enabled = true;
        }

        private void mnu_TipoTinta_Click(object sender, EventArgs e)
        {
            this.mnu_TipoTinta.Enabled = false;
            Frm_TipoTinta tipotinta = new Frm_TipoTinta();
            tipotinta.MdiParent = this;

            tipotinta.FormClosing += new FormClosingEventHandler(Frm_TipoTinta_FormClosing);
            tipotinta.Show();
        }

        private void Frm_TipoTinta_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_TipoTinta.Enabled = true;
        }


        private void mnu_TipoTrabajador_Click(object sender, EventArgs e)
        {
            this.mnu_TipoTrabajador.Enabled = false;
            Frm_TipoTrabajador tipotrabajador = new Frm_TipoTrabajador();
            tipotrabajador.MdiParent = this;

            tipotrabajador.FormClosing += new FormClosingEventHandler(Frm_TipoTrabajador_FormClosing);
            tipotrabajador.Show();
        }

        private void Frm_TipoTrabajador_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_TipoTrabajador.Enabled = true;
        }

        private void mnu_Tratado_Click(object sender, EventArgs e)
        {
            this.mnu_Tratado.Enabled = false;
            Frm_TipoTratado tratado = new Frm_TipoTratado();
            tratado.MdiParent = this;

            tratado.FormClosing += new FormClosingEventHandler(Frm_Tratado_FormClosing);
            tratado.Show();
        }

        private void Frm_Tratado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_Tratado.Enabled = true;
        }

        private void mnu_TipoTroquel_Click(object sender, EventArgs e)
        {
            this.mnu_TipoTroquel.Enabled = false;
            Frm_TipoTroquel troquel = new Frm_TipoTroquel();
            troquel.MdiParent = this;

            troquel.FormClosing += new FormClosingEventHandler(Frm_Troquel_FormClosing);
            troquel.Show();
        }

        private void Frm_Troquel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_TipoTroquel.Enabled = true;
        }

        private void mnu_UnidadMedida_Click(object sender, EventArgs e)
        {
            this.mnu_UnidadMedida.Enabled = false;
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.MdiParent = this;

            unidadmedida.FormClosing += new FormClosingEventHandler(Frm_UnidadMedida_FormClosing);
            unidadmedida.Show();
        }

        private void Frm_UnidadMedida_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_UnidadMedida.Enabled = true;
        }

        private void mnu_registroClientes_Click(object sender, EventArgs e)
        {
            this.mnu_registroClientes.Enabled = false;
            Frm_Cliente cliente = new Frm_Cliente();
            cliente.MdiParent = this;

            cliente.FormClosing += new FormClosingEventHandler(Frm_Clientes_FormClosing);
            cliente.Show();
        }

        private void Frm_Clientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_registroClientes.Enabled = true;
        }

        private void mnu_RegistroEstandar_Click(object sender, EventArgs e)
        {
            this.mnu_RegistroEstandar.Enabled = false;
            Frm_RegistroEstandar estandar = new Frm_RegistroEstandar();
            estandar.MdiParent = this;
            estandar.FormClosing += new FormClosingEventHandler(Frm_Estandar_FormClosing);
            estandar.Show();
        }

        private void Frm_Estandar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_RegistroEstandar.Enabled = true;
        }

        private void mnu_RegistroMaquina_Click(object sender, EventArgs e)
        {
            this.mnu_RegistroMaquina.Enabled = false;
            Frm_RegistroMaquina maquina = new Frm_RegistroMaquina();
            maquina.MdiParent = this;

            maquina.FormClosing += new FormClosingEventHandler(Frm_RegistroMaquina_FormClosing);
            maquina.Show();
        }

        private void Frm_RegistroMaquina_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_RegistroMaquina.Enabled = true;
        }

        private void mnu_PaisProcedencia_Click(object sender, EventArgs e)
        {
            this.mnu_PaisProcedencia.Enabled = false;
            Frm_PaisProcedencia paisprocedencia = new Frm_PaisProcedencia();
            paisprocedencia.MdiParent = this;

            paisprocedencia.FormClosing += new FormClosingEventHandler(Frm_PaisProcedencia_FormClosing);
            paisprocedencia.Show();
        }

        private void Frm_PaisProcedencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_PaisProcedencia.Enabled = true;
        }

        private void mnu_RegistroTrabajadores_Click(object sender, EventArgs e)
        {
            //this.mnu_RegistroTrabajadores.Enabled = false;
            //Frm_RegistroTrabajadores regtrabajadores = new Frm_RegistroTrabajadores();
            //regtrabajadores.MdiParent = this;

            //regtrabajadores.FormClosing += new FormClosingEventHandler(Frm_RegistroTrabajadores_FormClosing);
            //regtrabajadores.Show();
        }

        private void Frm_RegistroTrabajadores_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_RegistroTrabajadores.Enabled = true;
        }

        private void mnu_AdhesivoLaminacion_Click(object sender, EventArgs e)
        {
            this.mnu_AdhesivoLaminacion.Enabled = false;
            Frm_Adhesivo adhesivo = new Frm_Adhesivo();
            adhesivo.MdiParent = this;
            adhesivo.FormClosing += new FormClosingEventHandler(Frm_AdhesivoLaminacion_FormClosing);
            adhesivo.Show();
        }

        private void Frm_AdhesivoLaminacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_AdhesivoLaminacion.Enabled = true;
        }

        private void mnu_Salir_Click(object sender, EventArgs e)
        { }

        private void mnu_TipoLaminacion_Click(object sender, EventArgs e)
        {
            this.mnu_TipoLaminacion.Enabled = false;
            Frm_TipoLaminacion laminacion = new Frm_TipoLaminacion();
            laminacion.MdiParent = this;
            laminacion.FormClosing += new FormClosingEventHandler(Frm_TipoLaminacion_FormClosing);
            laminacion.Show();
        }
        private void Frm_TipoLaminacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_TipoLaminacion.Enabled = true;
        }

        private void mnu_TipoMaterialLaminado_Click(object sender, EventArgs e)
        {
            this.mnu_TipoMaterialLaminado.Enabled = false;
            Frm_TipoMaterialLaminado tmlaminado = new Frm_TipoMaterialLaminado();
            tmlaminado.MdiParent = this;
            tmlaminado.FormClosing += new FormClosingEventHandler(Frm_TipoMaterialLaminado_FormClosing);
            tmlaminado.Show();
        }

        private void Frm_TipoMaterialLaminado_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_TipoMaterialLaminado.Enabled = true;
        }

        private void mnu_TipoMaterialExtruir_Click(object sender, EventArgs e)
        {
            this.mnu_TipoMaterialExtruir.Enabled = false;
            Frm_TipoMaterialExtruir tmextruir = new Frm_TipoMaterialExtruir();
            tmextruir.MdiParent = this;
            tmextruir.FormClosing += new FormClosingEventHandler(Frm_TipoMaterialExtruir_FormClosing);
            tmextruir.Show();
        }

        private void Frm_TipoMaterialExtruir_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mnu_TipoMaterialExtruir.Enabled = true;
        }


        private void mnu_EstadoOrdenProduccion_Click(object sender, EventArgs e)
        {
            this.mnu_EstadoOrdenProduccion.Enabled = false;
            Frm_EstadoOrdenProduccion estadoop = new Frm_EstadoOrdenProduccion();
            estadoop.MdiParent = this;
            estadoop.FormClosing += new FormClosingEventHandler(Frm_EstadoOrdenProduccion_FormClosing);
            estadoop.Show();
        }

        private void Frm_EstadoOrdenProduccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            mnu_EstadoOrdenProduccion.Enabled = true;
        }
        #endregion


        #region Logistica
        private void mnu_TipoIngreso_Click_1(object sender, EventArgs e)
        {
            this.mnu_TipoIngreso.Enabled = false;
            Frm_TipoIngreso tipoingreso = new Frm_TipoIngreso();
            tipoingreso.MdiParent = this;
            tipoingreso.FormClosing += new FormClosingEventHandler(Frm_TipoIngreso_FormClosing);
            tipoingreso.Show();
        }

        private void Frm_TipoIngreso_FormClosing(object sender, FormClosingEventArgs e)
        { this.mnu_TipoIngreso.Enabled = true; }

        private void mnu_TipoSalida_Click(object sender, EventArgs e)
        {
            this.mnu_TipoSalida.Enabled = false;
            Frm_TipoSalida tiposalida = new Frm_TipoSalida();
            tiposalida.MdiParent = this;
            tiposalida.FormClosing += new FormClosingEventHandler(Frm_TipoSalida_FormClosing);
            tiposalida.Show();
        }

        private void Frm_TipoSalida_FormClosing(object sender, FormClosingEventArgs e)
        { this.mnu_TipoSalida.Enabled = true; }


        #endregion

        #region Materia_Prima

        #endregion

        private void mnu_Empresas_Click(object sender, EventArgs e)
        {
            this.mnu_Empresas.Enabled = false;
            Frm_Empresa empresa = new Frm_Empresa();
            empresa.MdiParent = this;
            empresa.FormClosing += new FormClosingEventHandler(Frm_Empresa_FormClosing);
            empresa.Show();
        }

        private void Frm_Empresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            mnu_Empresas.Enabled = true;
        }

        private void mnu_Almacen_Click(object sender, EventArgs e)
        {
            this.mnu_Almacen.Enabled = false;
            Frm_Almacen almacen = new Frm_Almacen();
            almacen.MdiParent = this;
            almacen.FormClosing += new FormClosingEventHandler(Frm_Almacen_FormClosing);
            almacen.Show();
        }

        private void Frm_Almacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            mnu_Almacen.Enabled = true;
        }

        private void mnu_Area_Click(object sender, EventArgs e)
        {
            this.mnu_Area.Enabled = false;
            Frm_Area area = new Frm_Area();
            area.MdiParent = this;
            area.FormClosing += new FormClosingEventHandler(Frm_Area_FormClosing);
            area.Show();
        }
        private void Frm_Area_FormClosing(object sender, FormClosingEventArgs e)
        {
            mnu_Area.Enabled = true;
        }

        private void mnu_Local_Click(object sender, EventArgs e)
        {
            this.mnu_Local.Enabled = false;
            Frm_Local local = new Frm_Local();
            local.MdiParent = this;
            local.FormClosing += new FormClosingEventHandler(Frm_Local_FormClosing);
            local.Show();
        }

        private void Frm_Local_FormClosing(object sender, FormClosingEventArgs e)
        {
            mnu_Local.Enabled = true;
        }

        private void mnu_CargoTrabajador_Click(object sender, EventArgs e)
        {
            this.mnu_CargoTrabajador.Enabled = false;
            Frm_Cargotrabajador cargotrabajador = new Frm_Cargotrabajador();
            cargotrabajador.MdiParent = this;
            cargotrabajador.FormClosing += new FormClosingEventHandler(Frm_Cargotrabajador_FormClosing);
            cargotrabajador.Show();
        }
        private void Frm_Cargotrabajador_FormClosing(object sender, FormClosingEventArgs e)
        {
            mnu_CargoTrabajador.Enabled = true;
        }

        private void mnu_CondicionCobranza_Click(object sender, EventArgs e)
        {
            this.mnu_CondicionCobranza.Enabled = false;
            Frm_CondicionCobranza condcobranza = new Frm_CondicionCobranza();
            condcobranza.MdiParent = this;
            condcobranza.FormClosing += new FormClosingEventHandler(Frm_CondicionCobranza_FormClosing);
            condcobranza.Show();
        }
        private void Frm_CondicionCobranza_FormClosing(object sender, FormClosingEventArgs e)
        {
            mnu_CondicionCobranza.Enabled = true;
        }

        private void mnu_EspesorTuco_Click(object sender, EventArgs e)
        {
            this.mnu_EspesorTuco.Enabled = false;
            Frm_EspesorTuco espesortuco = new Frm_EspesorTuco();
            espesortuco.MdiParent = this;
            espesortuco.FormClosing += new FormClosingEventHandler(Frm_EspesorTuco_FormClosing);
            espesortuco.Show();
        }
        private void Frm_EspesorTuco_FormClosing(object sender, FormClosingEventArgs e)
        {
            mnu_EspesorTuco.Enabled = true;
        }

        private void mnu_General_Click(object sender, EventArgs e)
        {
            this.mnu_General.Enabled = false;
            Frm_Estado estado = new Frm_Estado();
            estado.MdiParent = this;
            estado.FormClosing += new FormClosingEventHandler(Frm_Estado_FormClosing);
            estado.Show();
        }
        private void Frm_Estado_FormClosing(object sender, FormClosingEventArgs e)
        {
            mnu_General.Enabled = true;
        }

        private void mnu_EstadoCalificacion_Click(object sender, EventArgs e)
        {
            this.mnu_EstadoCalificacion.Enabled = false;
            Frm_EstadoCalificacionCC estadocalificacioncc = new Frm_EstadoCalificacionCC();
            estadocalificacioncc.MdiParent = this;
            estadocalificacioncc.FormClosing += new FormClosingEventHandler(Frm_EstadoCalificacion_FormClosing);
            estadocalificacioncc.Show();
        }

        private void Frm_EstadoCalificacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            mnu_EstadoCalificacion.Enabled = true;
        }

        private void mnu_LocalvsArea_Click(object sender, EventArgs e)
        {
            this.mnu_LocalvsArea.Enabled = false;
            Frm_LocalvsArea localvsarea = new Frm_LocalvsArea();
            localvsarea.MdiParent = this;
            localvsarea.FormClosing += new FormClosingEventHandler(Frm_LocalvsArea_FormClosing);
            localvsarea.Show();
        }
        private void Frm_LocalvsArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            mnu_LocalvsArea.Enabled = true;
        }

        private void mnu_CodigoEvento_Click(object sender, EventArgs e)
        {
            this.mnu_CodigoEvento.Enabled = false;
            Frm_CodigoEvento codigoevento = new Frm_CodigoEvento();
            codigoevento.MdiParent = this;
            codigoevento.FormClosing += new FormClosingEventHandler(Frm_CodigoEvento_FormClosing);
            codigoevento.Show();
        }

        private void Frm_CodigoEvento_FormClosing(object sender, EventArgs e)
        { mnu_CodigoEvento.Enabled = true; }

        private void mnu_EstadoMaquina_Click(object sender, EventArgs e)
        {
            this.mnu_EstadoMaquina.Enabled = false;
            Frm_EstadoMaquina estadomaquina = new Frm_EstadoMaquina();
            estadomaquina.MdiParent = this;
            estadomaquina.FormClosing += new FormClosingEventHandler(Frm_EstadoMaquina_FormClosing);
            estadomaquina.Show();
        }

        private void Frm_EstadoMaquina_FormClosing(object sender, EventArgs e)
        {
            mnu_EstadoMaquina.Enabled = true;
        }

        private void mnu_TipoMaquina_Click(object sender, EventArgs e)
        {
            this.mnu_TipoMaquina.Enabled = false;
            Frm_TipoMaquina tipomaquina = new Frm_TipoMaquina();
            tipomaquina.MdiParent = this;
            tipomaquina.FormClosing += new FormClosingEventHandler(Frm_TipoMaquina_FormClosing);
            tipomaquina.Show();
        }

        private void Frm_TipoMaquina_FormClosing(object sender, EventArgs e)
        {
            mnu_TipoMaquina.Enabled = true;
        }

        private void mnu_MarcaMaquina_Click(object sender, EventArgs e)
        {
            this.mnu_MarcaMaquina.Enabled = false;
            Frm_MarcaMaquina marcamaq = new Frm_MarcaMaquina();
            marcamaq.MdiParent = this;

            marcamaq.FormClosing += new FormClosingEventHandler(Frm_MarcaMaquina_FormClosing);
            marcamaq.Show();
        }

        private void Frm_MarcaMaquina_FormClosing(object sender, EventArgs e)
        {
            mnu_MarcaMaquina.Enabled = true;
        }

        private void mnu_Etiquetadoras_Click(object sender, EventArgs e)
        {
            this.mnu_Etiquetadoras.Enabled = false;
            Frm_Etiquetadoras etiquetadoras = new Frm_Etiquetadoras();
            etiquetadoras.MdiParent = this;
            etiquetadoras.FormClosing += new FormClosingEventHandler(Frm_Etiquetadoras_FormClosing);
            etiquetadoras.Show();
        }

        private void Frm_Etiquetadoras_FormClosing(object sender, EventArgs e)
        { mnu_Etiquetadoras.Enabled = true; }

        private void mnu_EstadoFormulacion_Click(object sender, EventArgs e)
        {
            this.mnu_EstadoFormulacion.Enabled = false;
            Frm_EstadoFormulacion estadoFormulacion = new Frm_EstadoFormulacion();
            estadoFormulacion.MdiParent = this;
            estadoFormulacion.FormClosing += new FormClosingEventHandler(Frm_EstadoFormulacion_FormClosing);
            estadoFormulacion.Show();
        }

        private void Frm_EstadoFormulacion_FormClosing(object sender, EventArgs e)
        { this.mnu_EstadoFormulacion.Enabled = true; }

        private void mnu_TipoMoneda_Click(object sender, EventArgs e)
        {
            this.mnu_TipoMoneda.Enabled = false;
            Frm_TipoMoneda tipomoneda = new Frm_TipoMoneda();
            tipomoneda.MdiParent = this;
            tipomoneda.FormClosing += new FormClosingEventHandler(Frm_TipoMoneda_FormClosing);
            tipomoneda.Show();
        }

        private void Frm_TipoMoneda_FormClosing(object sender, EventArgs e)
        { this.mnu_TipoMoneda.Enabled = true; }

        private void mnu_IGV_Click(object sender, EventArgs e)
        {
            this.mnu_IGV.Enabled = false;
            Frm_IGV igv = new Frm_IGV();
            igv.MdiParent = this;
            igv.FormClosing += new FormClosingEventHandler(Frm_IGV_FormClosing);
            igv.Show();
        }

        private void Frm_IGV_FormClosing(object sender, EventArgs e)
        { this.mnu_IGV.Enabled = true; }

        private void mnu_TipoProcesoCorte_Click(object sender, EventArgs e)
        {
            this.mnu_TipoProcesoCorte.Enabled = false;
            Frm_TipoProcesoCorte tipoprocesocorte = new Frm_TipoProcesoCorte();
            tipoprocesocorte.MdiParent = this;
            tipoprocesocorte.FormClosing += new FormClosingEventHandler(Frm_TipoProcesoCorte_FormClosing);
            tipoprocesocorte.Show();
        }

        private void Frm_TipoProcesoCorte_FormClosing(object sender, EventArgs e)
        { this.mnu_TipoProcesoCorte.Enabled = true; }



        private void mnu_grupoProduccion_Click(object sender, EventArgs e)
        {
            this.mnu_grupoProduccion.Enabled = false;
            Frm_GrupoProduccion grupoproduccion = new Frm_GrupoProduccion();
            grupoproduccion.MdiParent = this;
            grupoproduccion.FormClosing += new FormClosingEventHandler(Frm_GrupoProduccion_FormClosing);
            grupoproduccion.Show();
        }

        private void Frm_GrupoProduccion_FormClosing(object sender, EventArgs e)
        { this.mnu_grupoProduccion.Enabled = true; }

        private void mnu_FamiliaProduccion_Click(object sender, EventArgs e)
        {
            this.mnu_FamiliaProduccion.Enabled = false;
            Frm_FamiliaProduccion familiaproduccion = new Frm_FamiliaProduccion();
            familiaproduccion.MdiParent = this;
            familiaproduccion.FormClosing += new FormClosingEventHandler(Frm_FamiliaProduccion_FormClosing);
            familiaproduccion.Show();
        }

        private void Frm_FamiliaProduccion_FormClosing(object sender, EventArgs e)
        { this.mnu_FamiliaProduccion.Enabled = true; }

        private void mnu_SubFamiliaProduccion_Click(object sender, EventArgs e)
        {
            this.mnu_SubFamiliaProduccion.Enabled = false;
            Frm_SubFamiliaProduccion subfamiliaproduccion = new Frm_SubFamiliaProduccion();
            subfamiliaproduccion.MdiParent = this;
            subfamiliaproduccion.FormClosing += new FormClosingEventHandler(Frm_SubFamiliaProduccion_FormClosing);
            subfamiliaproduccion.Show();
        }

        private void Frm_SubFamiliaProduccion_FormClosing(object sender, EventArgs e)
        { this.mnu_SubFamiliaProduccion.Enabled = true; }

        private void mnu_LineaProduccion_Click(object sender, EventArgs e)
        {
            this.mnu_LineaProduccion.Enabled = false;
            Frm_LineaProduccion lineaproduccion = new Frm_LineaProduccion();
            lineaproduccion.MdiParent = this;
            lineaproduccion.FormClosing += new FormClosingEventHandler(Frm_LineaProduccion_FormClosing);
            lineaproduccion.Show();
        }

        private void Frm_LineaProduccion_FormClosing(object sender, EventArgs e)
        { this.mnu_LineaProduccion.Enabled = true; }

        private void mnu_MediaProduccion_Click(object sender, EventArgs e)
        {
            this.mnu_MediaProduccion.Enabled = false;
            Frm_MedidaProduccion medidaproduccion = new Frm_MedidaProduccion();
            medidaproduccion.MdiParent = this;
            medidaproduccion.FormClosing += new FormClosingEventHandler(Frm_MedidaProduccion_FormClosing);
            medidaproduccion.Show();
        }
        private void Frm_MedidaProduccion_FormClosing(object sender, EventArgs e)
        { this.mnu_MediaProduccion.Enabled = true; }

        private void mnu_Mezcladora_Click(object sender, EventArgs e)
        {
            this.mnu_Mezcladora.Enabled = false;
            Frm_MaquinaMezcladora maquinamezcladora = new Frm_MaquinaMezcladora();
            maquinamezcladora.MdiParent = this;
            maquinamezcladora.FormClosing += new FormClosingEventHandler(Frm_MaquinaMezcladora_FormClosing);
            maquinamezcladora.Show();
        }

        private void Frm_MaquinaMezcladora_FormClosing(object sender, EventArgs e)
        { this.mnu_Mezcladora.Enabled = true; }

        private void mnu_MotivoObservacion_Click(object sender, EventArgs e)
        {
            this.mnu_MotivoObservacion.Enabled = false;
            Frm_MotivoObservacion_CC motivoobservacion = new Frm_MotivoObservacion_CC();
            motivoobservacion.MdiParent = this;
            motivoobservacion.FormClosing += new FormClosingEventHandler(Frm_MotivoObservacion_CC_FormClosing);
            motivoobservacion.Show();
        }

        private void Frm_MotivoObservacion_CC_FormClosing(object sender, EventArgs e)
        { this.mnu_MotivoObservacion.Enabled = true; }

        private void mnu_PresicionBalanza_Click(object sender, EventArgs e)
        {
            this.mnu_PresicionBalanza.Enabled = false;
            Frm_Presicionbalanza presicionbalanza = new Frm_Presicionbalanza();
            presicionbalanza.MdiParent = this;
            presicionbalanza.FormClosing += new FormClosingEventHandler(Frm_Presicionbalanza_FormClosing);
            presicionbalanza.Show();
        }

        private void Frm_Presicionbalanza_FormClosing(object sender, EventArgs e)
        { this.mnu_PresicionBalanza.Enabled = true; }

        private void mnu_Prioridad_Click(object sender, EventArgs e)
        {
            this.mnu_Prioridad.Enabled = false;
            Frm_Prioridad prioridad = new Frm_Prioridad();
            prioridad.MdiParent = this;
            prioridad.FormClosing += new FormClosingEventHandler(Frm_Prioridad_FormClosing);
            prioridad.Show();
        }

        private void Frm_Prioridad_FormClosing(object sender, EventArgs e)
        { this.mnu_Prioridad.Enabled = true; }

        private void mnu_SectorAlmacenPT_Click(object sender, EventArgs e)
        {
            this.mnu_SectorAlmacenPT.Enabled = false;
            Frm_SectorAlmacenPT sectoralmacenpt = new Frm_SectorAlmacenPT();
            sectoralmacenpt.MdiParent = this;
            sectoralmacenpt.FormClosing += new FormClosingEventHandler(Frm_SectorAlmacenPT_FormClosing);
            sectoralmacenpt.Show();
        }

        private void Frm_SectorAlmacenPT_FormClosing(object sender, EventArgs e)
        { this.mnu_SectorAlmacenPT.Enabled = true; }

        private void mnu_RegistroSemana_Click(object sender, EventArgs e)
        {
            this.mnu_RegistroSemana.Enabled = false;
            Frm_Semana semana = new Frm_Semana();
            semana.MdiParent = this;
            semana.FormClosing += new FormClosingEventHandler(Frm_Semana_FormClosing);
            semana.Show();
        }
        private void Frm_Semana_FormClosing(object sender, EventArgs e)
        { this.mnu_RegistroSemana.Enabled = true; }

        private void mnu_TipoDespacho_Click(object sender, EventArgs e)
        {
            this.mnu_TipoDespacho.Enabled = false;
            Frm_TipoDespacho tipodespacho = new Frm_TipoDespacho();
            tipodespacho.MdiParent = this;
            tipodespacho.FormClosing += new FormClosingEventHandler(Frm_TipoDespacho_FormClosing);
            tipodespacho.Show();
        }

        private void Frm_TipoDespacho_FormClosing(object sender, EventArgs e)
        { this.mnu_TipoDespacho.Enabled = true; }

        private void mnu_TipoProcesoLaminacion_Click(object sender, EventArgs e)
        {
            this.mnu_TipoProcesoLaminacion.Enabled = false;
            Frm_TipoProcesoLaminado tipoprocesolaminacion = new Frm_TipoProcesoLaminado();
            tipoprocesolaminacion.MdiParent = this;
            tipoprocesolaminacion.FormClosing += new FormClosingEventHandler(Frm_TipoProcesoLaminado_FormClosing);
            tipoprocesolaminacion.Show();
        }

        private void Frm_TipoProcesoLaminado_FormClosing(object sender, EventArgs e)
        { this.mnu_TipoProcesoLaminacion.Enabled = true; }

        private void mnu_UsoProducto_Click(object sender, EventArgs e)
        {
            this.mnu_UsoProducto.Enabled = false;
            Frm_UsoProducto usoproducto = new Frm_UsoProducto();
            usoproducto.MdiParent = this;
            usoproducto.FormClosing += new FormClosingEventHandler(Frm_UsoProducto_FormClosing);
            usoproducto.Show();
        }

        private void Frm_UsoProducto_FormClosing(object sender, EventArgs e)
        { this.mnu_UsoProducto.Enabled = true; }

        private void mnu_MarcaMaterial_Click(object sender, EventArgs e)
        {
            this.mnu_MarcaMaterial.Enabled = false;
            Frm_MarcaMaterial marcamaterial = new Frm_MarcaMaterial();
            marcamaterial.MdiParent = this;
            marcamaterial.FormClosing += new FormClosingEventHandler(Frm_MarcaMaterial_FormClosing);
            marcamaterial.Show();
        }

        private void Frm_MarcaMaterial_FormClosing(object sender, EventArgs e)
        { this.mnu_MarcaMaterial.Enabled = true; }

        private void mnu_AgenteAduanero_Click(object sender, EventArgs e)
        {
            this.mnu_AgenteAduanero.Enabled = false;
            Frm_AgenteAduanero agenteaduanero = new Frm_AgenteAduanero();
            agenteaduanero.MdiParent = this;
            agenteaduanero.FormClosing += new FormClosingEventHandler(Frm_AgenteAduanero_FormClosing);
            agenteaduanero.Show();
        }

        private void Frm_AgenteAduanero_FormClosing(object sender, EventArgs e)
        { this.mnu_AgenteAduanero.Enabled = true; }

        private void mnu_AlmacenAduanero_Click(object sender, EventArgs e)
        {
            this.mnu_AlmacenAduanero.Enabled = false;
            Frm_AlmacenAduana almacenaduana = new Frm_AlmacenAduana();
            almacenaduana.MdiParent = this;
            almacenaduana.FormClosing += new FormClosingEventHandler(Frm_AlmacenAduana_FormClosing);
            almacenaduana.Show();
        }

        private void Frm_AlmacenAduana_FormClosing(object sender, EventArgs e)
        { this.mnu_AlmacenAduanero.Enabled = true; }

        private void mnu_CategoriaMaterial_Click(object sender, EventArgs e)
        {
            this.mnu_CategoriaMaterial.Enabled = false;
            Frm_CategoriaMaterial categoriamaterial = new Frm_CategoriaMaterial();
            categoriamaterial.MdiParent = this;
            categoriamaterial.FormClosing += new FormClosingEventHandler(Frm_CategoriaMaterial_FormClosing);
            categoriamaterial.Show();
        }

        private void Frm_CategoriaMaterial_FormClosing(object sender, EventArgs e)
        { this.mnu_CategoriaMaterial.Enabled = true; }

        private void mnu_PropiedadMaterial_Click(object sender, EventArgs e)
        {
            this.mnu_PropiedadMaterial.Enabled = false;
            Frm_PropiedadesMaterial propiedadmaterial = new Frm_PropiedadesMaterial();
            propiedadmaterial.MdiParent = this;
            propiedadmaterial.FormClosing += new FormClosingEventHandler(Frm_PropiedadesMaterial_FormClosing);
            propiedadmaterial.Show();
        }

        private void Frm_PropiedadesMaterial_FormClosing(object sender, EventArgs e)
        { this.mnu_PropiedadMaterial.Enabled = true; }

        private void mnu_TipoMaterial_Click(object sender, EventArgs e)
        {
            this.mnu_TipoMaterial.Enabled = false;
            Frm_TipoMaterial tipomaterial = new Frm_TipoMaterial();
            tipomaterial.MdiParent = this;
            tipomaterial.FormClosing += new FormClosingEventHandler(Frm_TipoMaterial_FormClosing);
            tipomaterial.Show();
        }

        private void Frm_TipoMaterial_FormClosing(object sender, EventArgs e)
        { this.mnu_TipoMaterial.Enabled = true; }

        private void mnu_CondicionPago_Click(object sender, EventArgs e)
        {
            this.mnu_CondicionPago.Enabled = false;
            Frm_CondicionPago condicionpago = new Frm_CondicionPago();
            condicionpago.MdiParent = this;
            condicionpago.FormClosing += new FormClosingEventHandler(Frm_CondicionPago_FormClosing);
            condicionpago.Show();
        }

        private void Frm_CondicionPago_FormClosing(object sender, EventArgs e)
        { this.mnu_CondicionPago.Enabled = true; }

        private void mnu_EstadoInmueble_Click(object sender, EventArgs e)
        {
            this.mnu_EstadoInmueble.Enabled = false;
            Frm_EstadoInmueble estadoinmueble = new Frm_EstadoInmueble();
            estadoinmueble.MdiParent = this;
            estadoinmueble.FormClosing += new FormClosingEventHandler(Frm_EstadoInmueble_FormClosing);
            estadoinmueble.Show();
        }

        private void Frm_EstadoInmueble_FormClosing(object sender, EventArgs e)
        { this.mnu_EstadoInmueble.Enabled = true; }

        private void mnu_FormaPago_Click(object sender, EventArgs e)
        {
            this.mnu_FormaPago.Enabled = false;
            Frm_FormaPago formapago = new Frm_FormaPago();
            formapago.MdiParent = this;
            formapago.FormClosing += new FormClosingEventHandler(Frm_FormaPago_FormClosing);
            formapago.Show();
        }

        private void Frm_FormaPago_FormClosing(object sender, EventArgs e)
        { this.mnu_FormaPago.Enabled = true; }

        private void mnu_UbicacionInmueble_Click(object sender, EventArgs e)
        {
            this.mnu_UbicacionInmueble.Enabled = false;
            Frm_UbicacionInmueble ubicacioninmueble = new Frm_UbicacionInmueble();
            ubicacioninmueble.MdiParent = this;
            ubicacioninmueble.FormClosing += new FormClosingEventHandler(Frm_UbicacionInmueble_FormClosing);
            ubicacioninmueble.Show();
        }

        private void Frm_UbicacionInmueble_FormClosing(object sender, EventArgs e)
        { this.mnu_UbicacionInmueble.Enabled = true; }

        private void mnu_Impresora_Click(object sender, EventArgs e)
        {
            this.mnu_Impresora.Enabled = false;
            Frm_ImpresoraVSRodillo impresoraRodillo = new Frm_ImpresoraVSRodillo();
            impresoraRodillo.MdiParent = this;
            impresoraRodillo.FormClosing += new FormClosingEventHandler(Frm_ImpresoraVSRodillo_FormClosing);
            impresoraRodillo.Show();
        }

        private void Frm_ImpresoraVSRodillo_FormClosing(object sender, EventArgs e)
        { this.mnu_Impresora.Enabled = true; }

        private void mnu_TipoProveedor_Click(object sender, EventArgs e)
        {
            this.mnu_TipoProveedor.Enabled = false;
            Frm_TipoProveedor imtipoproveedor = new Frm_TipoProveedor();
            imtipoproveedor.MdiParent = this;
            imtipoproveedor.FormClosing += new FormClosingEventHandler(Frm_TipoProveedor_FormClosing);
            imtipoproveedor.Show();
        }

        private void Frm_TipoProveedor_FormClosing(object sender, EventArgs e)
        { this.mnu_TipoProveedor.Enabled = true; }

        private void mnu_RegistroProveedores_Click(object sender, EventArgs e)
        {
            this.mnu_RegistroProveedores.Enabled = false;
            Frm_Proveedores proveedores = new Frm_Proveedores();
            proveedores.MdiParent = this;
            proveedores.FormClosing += new FormClosingEventHandler(Frm_Proveedores_FormClosing);
            proveedores.Show();
        }

        private void Frm_Proveedores_FormClosing(object sender, EventArgs e)
        { this.mnu_RegistroProveedores.Enabled = true; }

        private void mnu_Periodo_Click(object sender, EventArgs e)
        {
            this.mnu_Periodo.Enabled = false;
            Frm_Periodo Periodo = new Frm_Periodo();
            Periodo.MdiParent = this;
            Periodo.FormClosing += new FormClosingEventHandler(Frm_Periodo_FormClosing);
            Periodo.Show();
        }

        private void Frm_Periodo_FormClosing(object sender, EventArgs e)
        { this.mnu_Periodo.Enabled = true; }

        private void mnu_RegistroPedido_Click(object sender, EventArgs e)
        {
            this.mnu_RegistroPedido.Enabled = false;
            Frm_RegistroPedidos pedidos = new Frm_RegistroPedidos();
            pedidos.MdiParent = this;
            pedidos.FormClosing += new FormClosingEventHandler(Frm_Pedidos_FormClosing);
            pedidos.Show();
        }

        private void Frm_Pedidos_FormClosing(object sender, EventArgs e)
        { this.mnu_RegistroPedido.Enabled = true; }

        private void mnu_TipoVenta_Click(object sender, EventArgs e)
        {
            this.mnu_TipoVenta.Enabled = false;
            Frm_TipoVenta tipoventas = new Frm_TipoVenta();
            tipoventas.MdiParent = this;
            tipoventas.FormClosing += new FormClosingEventHandler(Frm_TipoVenta_FormClosing);
            tipoventas.Show();
        }

        private void Frm_TipoVenta_FormClosing(object sender, EventArgs e)
        { this.mnu_TipoVenta.Enabled = true; }



    }
}
