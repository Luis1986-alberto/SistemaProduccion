﻿
namespace Capa_Presentacion.Formularios.Produccion
{
    partial class Frm_RegistroMaquina
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RegistroMaquina));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tls_Formulario = new System.Windows.Forms.ToolStrip();
            this.tls_Agregar = new System.Windows.Forms.ToolStripButton();
            this.tls_Modificar = new System.Windows.Forms.ToolStripButton();
            this.tls_Eliminar = new System.Windows.Forms.ToolStripButton();
            this.tls_Separador1 = new System.Windows.Forms.ToolStripSeparator();
            this.tls_Grabar = new System.Windows.Forms.ToolStripButton();
            this.tls_Deshacer = new System.Windows.Forms.ToolStripButton();
            this.tls_Separador2 = new System.Windows.Forms.ToolStripSeparator();
            this.tls_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.tls_Previo = new System.Windows.Forms.ToolStripButton();
            this.tls_Separador3 = new System.Windows.Forms.ToolStripSeparator();
            this.tls_Buscar = new System.Windows.Forms.ToolStripButton();
            this.tls_OrdenASC = new System.Windows.Forms.ToolStripButton();
            this.tls_OrdenDsc = new System.Windows.Forms.ToolStripButton();
            this.tls_Separador4 = new System.Windows.Forms.ToolStripSeparator();
            this.tls_Refrescar = new System.Windows.Forms.ToolStripButton();
            this.tls_Primero = new System.Windows.Forms.ToolStripButton();
            this.tls_Anterior = new System.Windows.Forms.ToolStripButton();
            this.tls_Siguiente = new System.Windows.Forms.ToolStripButton();
            this.tls_Ultimo = new System.Windows.Forms.ToolStripButton();
            this.tbc_Mnt = new System.Windows.Forms.TabControl();
            this.tbp_Ingreso = new System.Windows.Forms.TabPage();
            this.cbo_EmpresaCompra = new System.Windows.Forms.ComboBox();
            this.cmd_EstadoMaquina = new System.Windows.Forms.Button();
            this.cbo_EstadoMaquina = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_horastrabajo = new System.Windows.Forms.TextBox();
            this.txt_produccionmetros = new System.Windows.Forms.TextBox();
            this.txt_ProduccionKg = new System.Windows.Forms.TextBox();
            this.Chk_Baja = new System.Windows.Forms.CheckBox();
            this.Chk_FlagOperativo = new System.Windows.Forms.CheckBox();
            this.txt_PaisProcedencia = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.Cmd_AñoFabricacion = new System.Windows.Forms.Button();
            this.Cbo_AñoFabricacion = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.Txt_CodigoMaquina = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.NUD_CantidadMaxOP = new System.Windows.Forms.NumericUpDown();
            this.Cmd_ProveedorMaquina = new System.Windows.Forms.Button();
            this.Cbo_ProveedorMaquina = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmd_EmpresasCompra = new System.Windows.Forms.Button();
            this.cnd_MarcaMaquina = new System.Windows.Forms.Button();
            this.cmd_TipoMaquina = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Compra = new System.Windows.Forms.DateTimePicker();
            this.btnLimpiarImagen = new System.Windows.Forms.Button();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_aliasmaquina = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_seriemaquina = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_modelomaquina = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_marcamaquina = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_tipomaquina = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_DireccionImagen = new System.Windows.Forms.TextBox();
            this.Chk_MostrarImagen = new System.Windows.Forms.CheckBox();
            this.Img_Producto = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_IdMaquina = new System.Windows.Forms.TextBox();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.tbp_Listado = new System.Windows.Forms.TabPage();
            this.dgv_Mnt = new System.Windows.Forms.DataGridView();
            this.IdMaquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Procedencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoMaquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alias_Maquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca_Maquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo_Maquina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_FiltroEmpresa = new System.Windows.Forms.CheckBox();
            this.cbo_FiltroEmpresa = new System.Windows.Forms.ComboBox();
            this.cbo_FiltroTipoMaquina = new System.Windows.Forms.ComboBox();
            this.chk_TipoMaquina = new System.Windows.Forms.CheckBox();
            this.PrintDocument = new System.Drawing.Printing.PrintDocument();
            this.tls_Formulario.SuspendLayout();
            this.tbc_Mnt.SuspendLayout();
            this.tbp_Ingreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CantidadMaxOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img_Producto)).BeginInit();
            this.tbp_Listado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mnt)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tls_Formulario
            // 
            this.tls_Formulario.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tls_Formulario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tls_Agregar,
            this.tls_Modificar,
            this.tls_Eliminar,
            this.tls_Separador1,
            this.tls_Grabar,
            this.tls_Deshacer,
            this.tls_Separador2,
            this.tls_Imprimir,
            this.tls_Previo,
            this.tls_Separador3,
            this.tls_Buscar,
            this.tls_OrdenASC,
            this.tls_OrdenDsc,
            this.tls_Separador4,
            this.tls_Refrescar,
            this.tls_Primero,
            this.tls_Anterior,
            this.tls_Siguiente,
            this.tls_Ultimo});
            this.tls_Formulario.Location = new System.Drawing.Point(0, 0);
            this.tls_Formulario.Name = "tls_Formulario";
            this.tls_Formulario.Size = new System.Drawing.Size(1093, 70);
            this.tls_Formulario.Stretch = true;
            this.tls_Formulario.TabIndex = 20;
            // 
            // tls_Agregar
            // 
            this.tls_Agregar.Image = ((System.Drawing.Image)(resources.GetObject("tls_Agregar.Image")));
            this.tls_Agregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Agregar.Name = "tls_Agregar";
            this.tls_Agregar.Size = new System.Drawing.Size(53, 67);
            this.tls_Agregar.Text = "&Agregar";
            this.tls_Agregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Agregar.ToolTipText = "Agregar datos";
            this.tls_Agregar.Click += new System.EventHandler(this.tls_Agregar_Click);
            // 
            // tls_Modificar
            // 
            this.tls_Modificar.Image = ((System.Drawing.Image)(resources.GetObject("tls_Modificar.Image")));
            this.tls_Modificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Modificar.Name = "tls_Modificar";
            this.tls_Modificar.Size = new System.Drawing.Size(62, 67);
            this.tls_Modificar.Text = "&Modificar";
            this.tls_Modificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Modificar.ToolTipText = "Modificar datos";
            this.tls_Modificar.Click += new System.EventHandler(this.tls_Modificar_Click);
            // 
            // tls_Eliminar
            // 
            this.tls_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("tls_Eliminar.Image")));
            this.tls_Eliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Eliminar.Name = "tls_Eliminar";
            this.tls_Eliminar.Size = new System.Drawing.Size(54, 67);
            this.tls_Eliminar.Text = "&Eliminar";
            this.tls_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Eliminar.ToolTipText = "Eliminar datos";
            this.tls_Eliminar.Click += new System.EventHandler(this.tls_Eliminar_Click);
            // 
            // tls_Separador1
            // 
            this.tls_Separador1.Name = "tls_Separador1";
            this.tls_Separador1.Size = new System.Drawing.Size(6, 70);
            // 
            // tls_Grabar
            // 
            this.tls_Grabar.Enabled = false;
            this.tls_Grabar.Image = ((System.Drawing.Image)(resources.GetObject("tls_Grabar.Image")));
            this.tls_Grabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Grabar.Name = "tls_Grabar";
            this.tls_Grabar.Size = new System.Drawing.Size(52, 67);
            this.tls_Grabar.Text = "&Grabar";
            this.tls_Grabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Grabar.ToolTipText = "Grabar datos";
            this.tls_Grabar.Click += new System.EventHandler(this.tls_Grabar_Click);
            // 
            // tls_Deshacer
            // 
            this.tls_Deshacer.Enabled = false;
            this.tls_Deshacer.Image = ((System.Drawing.Image)(resources.GetObject("tls_Deshacer.Image")));
            this.tls_Deshacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Deshacer.Name = "tls_Deshacer";
            this.tls_Deshacer.Size = new System.Drawing.Size(59, 67);
            this.tls_Deshacer.Text = "Deshacer";
            this.tls_Deshacer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Deshacer.Click += new System.EventHandler(this.tls_Deshacer_Click);
            // 
            // tls_Separador2
            // 
            this.tls_Separador2.Name = "tls_Separador2";
            this.tls_Separador2.Size = new System.Drawing.Size(6, 70);
            // 
            // tls_Imprimir
            // 
            this.tls_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("tls_Imprimir.Image")));
            this.tls_Imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Imprimir.Name = "tls_Imprimir";
            this.tls_Imprimir.Size = new System.Drawing.Size(57, 67);
            this.tls_Imprimir.Text = "&Imprimir";
            this.tls_Imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Imprimir.ToolTipText = "Imprimir datos";
            this.tls_Imprimir.Click += new System.EventHandler(this.tls_Imprimir_Click);
            // 
            // tls_Previo
            // 
            this.tls_Previo.Image = ((System.Drawing.Image)(resources.GetObject("tls_Previo.Image")));
            this.tls_Previo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Previo.Name = "tls_Previo";
            this.tls_Previo.Size = new System.Drawing.Size(52, 67);
            this.tls_Previo.Text = "&Previo";
            this.tls_Previo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Previo.ToolTipText = "Previo de datos antes de imprimir";
            this.tls_Previo.Click += new System.EventHandler(this.tls_Previo_Click);
            // 
            // tls_Separador3
            // 
            this.tls_Separador3.Name = "tls_Separador3";
            this.tls_Separador3.Size = new System.Drawing.Size(6, 70);
            // 
            // tls_Buscar
            // 
            this.tls_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("tls_Buscar.Image")));
            this.tls_Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Buscar.Name = "tls_Buscar";
            this.tls_Buscar.Size = new System.Drawing.Size(52, 67);
            this.tls_Buscar.Text = "&Buscar";
            this.tls_Buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Buscar.ToolTipText = "Buscar datos";
            this.tls_Buscar.Click += new System.EventHandler(this.tls_Buscar_Click);
            // 
            // tls_OrdenASC
            // 
            this.tls_OrdenASC.Image = ((System.Drawing.Image)(resources.GetObject("tls_OrdenASC.Image")));
            this.tls_OrdenASC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_OrdenASC.Name = "tls_OrdenASC";
            this.tls_OrdenASC.Size = new System.Drawing.Size(52, 67);
            this.tls_OrdenASC.Text = "A&sc";
            this.tls_OrdenASC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_OrdenASC.ToolTipText = "Ordenar Ascendente";
            this.tls_OrdenASC.Click += new System.EventHandler(this.tls_OrdenASC_Click);
            // 
            // tls_OrdenDsc
            // 
            this.tls_OrdenDsc.Image = ((System.Drawing.Image)(resources.GetObject("tls_OrdenDsc.Image")));
            this.tls_OrdenDsc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_OrdenDsc.Name = "tls_OrdenDsc";
            this.tls_OrdenDsc.Size = new System.Drawing.Size(52, 67);
            this.tls_OrdenDsc.Text = "D&esc";
            this.tls_OrdenDsc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_OrdenDsc.ToolTipText = "Ordenar Descendente";
            this.tls_OrdenDsc.Click += new System.EventHandler(this.tls_OrdenDsc_Click);
            // 
            // tls_Separador4
            // 
            this.tls_Separador4.Name = "tls_Separador4";
            this.tls_Separador4.Size = new System.Drawing.Size(6, 70);
            // 
            // tls_Refrescar
            // 
            this.tls_Refrescar.Image = ((System.Drawing.Image)(resources.GetObject("tls_Refrescar.Image")));
            this.tls_Refrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Refrescar.Name = "tls_Refrescar";
            this.tls_Refrescar.Size = new System.Drawing.Size(59, 67);
            this.tls_Refrescar.Text = "&Refrescar";
            this.tls_Refrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Refrescar.ToolTipText = "Refrescar datos";
            this.tls_Refrescar.Click += new System.EventHandler(this.tls_Refrescar_Click);
            // 
            // tls_Primero
            // 
            this.tls_Primero.Image = ((System.Drawing.Image)(resources.GetObject("tls_Primero.Image")));
            this.tls_Primero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Primero.Name = "tls_Primero";
            this.tls_Primero.Size = new System.Drawing.Size(53, 67);
            this.tls_Primero.Text = "Pri&mero";
            this.tls_Primero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Primero.ToolTipText = "Primer registro";
            this.tls_Primero.Click += new System.EventHandler(this.tls_Primero_Click);
            // 
            // tls_Anterior
            // 
            this.tls_Anterior.Image = ((System.Drawing.Image)(resources.GetObject("tls_Anterior.Image")));
            this.tls_Anterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Anterior.Name = "tls_Anterior";
            this.tls_Anterior.Size = new System.Drawing.Size(54, 67);
            this.tls_Anterior.Text = "An&terior";
            this.tls_Anterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Anterior.ToolTipText = "Anterior registro";
            this.tls_Anterior.Click += new System.EventHandler(this.tls_Anterior_Click);
            // 
            // tls_Siguiente
            // 
            this.tls_Siguiente.Image = ((System.Drawing.Image)(resources.GetObject("tls_Siguiente.Image")));
            this.tls_Siguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Siguiente.Name = "tls_Siguiente";
            this.tls_Siguiente.Size = new System.Drawing.Size(60, 67);
            this.tls_Siguiente.Text = "&Siguiente";
            this.tls_Siguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Siguiente.ToolTipText = "Siguiente registro";
            this.tls_Siguiente.Click += new System.EventHandler(this.tls_Siguiente_Click);
            // 
            // tls_Ultimo
            // 
            this.tls_Ultimo.Image = ((System.Drawing.Image)(resources.GetObject("tls_Ultimo.Image")));
            this.tls_Ultimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Ultimo.Name = "tls_Ultimo";
            this.tls_Ultimo.Size = new System.Drawing.Size(52, 67);
            this.tls_Ultimo.Text = "&Ultimo";
            this.tls_Ultimo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Ultimo.ToolTipText = "Ultimo registro";
            this.tls_Ultimo.Click += new System.EventHandler(this.tls_Ultimo_Click);
            // 
            // tbc_Mnt
            // 
            this.tbc_Mnt.Controls.Add(this.tbp_Ingreso);
            this.tbc_Mnt.Controls.Add(this.tbp_Listado);
            this.tbc_Mnt.Location = new System.Drawing.Point(0, 73);
            this.tbc_Mnt.Name = "tbc_Mnt";
            this.tbc_Mnt.SelectedIndex = 0;
            this.tbc_Mnt.ShowToolTips = true;
            this.tbc_Mnt.Size = new System.Drawing.Size(1096, 446);
            this.tbc_Mnt.TabIndex = 21;
            // 
            // tbp_Ingreso
            // 
            this.tbp_Ingreso.BackColor = System.Drawing.Color.SkyBlue;
            this.tbp_Ingreso.Controls.Add(this.cbo_EmpresaCompra);
            this.tbp_Ingreso.Controls.Add(this.cmd_EstadoMaquina);
            this.tbp_Ingreso.Controls.Add(this.cbo_EstadoMaquina);
            this.tbp_Ingreso.Controls.Add(this.label2);
            this.tbp_Ingreso.Controls.Add(this.txt_horastrabajo);
            this.tbp_Ingreso.Controls.Add(this.txt_produccionmetros);
            this.tbp_Ingreso.Controls.Add(this.txt_ProduccionKg);
            this.tbp_Ingreso.Controls.Add(this.Chk_Baja);
            this.tbp_Ingreso.Controls.Add(this.Chk_FlagOperativo);
            this.tbp_Ingreso.Controls.Add(this.txt_PaisProcedencia);
            this.tbp_Ingreso.Controls.Add(this.label17);
            this.tbp_Ingreso.Controls.Add(this.Cmd_AñoFabricacion);
            this.tbp_Ingreso.Controls.Add(this.Cbo_AñoFabricacion);
            this.tbp_Ingreso.Controls.Add(this.label16);
            this.tbp_Ingreso.Controls.Add(this.Txt_CodigoMaquina);
            this.tbp_Ingreso.Controls.Add(this.label15);
            this.tbp_Ingreso.Controls.Add(this.label7);
            this.tbp_Ingreso.Controls.Add(this.label14);
            this.tbp_Ingreso.Controls.Add(this.label13);
            this.tbp_Ingreso.Controls.Add(this.NUD_CantidadMaxOP);
            this.tbp_Ingreso.Controls.Add(this.Cmd_ProveedorMaquina);
            this.tbp_Ingreso.Controls.Add(this.Cbo_ProveedorMaquina);
            this.tbp_Ingreso.Controls.Add(this.label12);
            this.tbp_Ingreso.Controls.Add(this.label11);
            this.tbp_Ingreso.Controls.Add(this.cmd_EmpresasCompra);
            this.tbp_Ingreso.Controls.Add(this.cnd_MarcaMaquina);
            this.tbp_Ingreso.Controls.Add(this.cmd_TipoMaquina);
            this.tbp_Ingreso.Controls.Add(this.label10);
            this.tbp_Ingreso.Controls.Add(this.Dtp_Fecha_Compra);
            this.tbp_Ingreso.Controls.Add(this.btnLimpiarImagen);
            this.tbp_Ingreso.Controls.Add(this.btnCargarImagen);
            this.tbp_Ingreso.Controls.Add(this.label9);
            this.tbp_Ingreso.Controls.Add(this.txt_aliasmaquina);
            this.tbp_Ingreso.Controls.Add(this.label8);
            this.tbp_Ingreso.Controls.Add(this.txt_seriemaquina);
            this.tbp_Ingreso.Controls.Add(this.label6);
            this.tbp_Ingreso.Controls.Add(this.txt_modelomaquina);
            this.tbp_Ingreso.Controls.Add(this.label5);
            this.tbp_Ingreso.Controls.Add(this.cbo_marcamaquina);
            this.tbp_Ingreso.Controls.Add(this.label4);
            this.tbp_Ingreso.Controls.Add(this.cbo_tipomaquina);
            this.tbp_Ingreso.Controls.Add(this.label3);
            this.tbp_Ingreso.Controls.Add(this.Txt_DireccionImagen);
            this.tbp_Ingreso.Controls.Add(this.Chk_MostrarImagen);
            this.tbp_Ingreso.Controls.Add(this.Img_Producto);
            this.tbp_Ingreso.Controls.Add(this.label1);
            this.tbp_Ingreso.Controls.Add(this.txt_IdMaquina);
            this.tbp_Ingreso.Controls.Add(this.lbl_Titulo);
            this.tbp_Ingreso.Location = new System.Drawing.Point(4, 22);
            this.tbp_Ingreso.Name = "tbp_Ingreso";
            this.tbp_Ingreso.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Ingreso.Size = new System.Drawing.Size(1088, 420);
            this.tbp_Ingreso.TabIndex = 0;
            this.tbp_Ingreso.Text = "Ingreso";
            this.tbp_Ingreso.ToolTipText = "Ingreso de datos";
            // 
            // cbo_EmpresaCompra
            // 
            this.cbo_EmpresaCompra.DisplayMember = "Nombre_Empresa";
            this.cbo_EmpresaCompra.Enabled = false;
            this.cbo_EmpresaCompra.FormattingEnabled = true;
            this.cbo_EmpresaCompra.Location = new System.Drawing.Point(500, 153);
            this.cbo_EmpresaCompra.Name = "cbo_EmpresaCompra";
            this.cbo_EmpresaCompra.Size = new System.Drawing.Size(221, 21);
            this.cbo_EmpresaCompra.TabIndex = 93;
            this.cbo_EmpresaCompra.ValueMember = "IdEmpresa";
            // 
            // cmd_EstadoMaquina
            // 
            this.cmd_EstadoMaquina.BackColor = System.Drawing.Color.Transparent;
            this.cmd_EstadoMaquina.ForeColor = System.Drawing.Color.Black;
            this.cmd_EstadoMaquina.Location = new System.Drawing.Point(721, 291);
            this.cmd_EstadoMaquina.Name = "cmd_EstadoMaquina";
            this.cmd_EstadoMaquina.Size = new System.Drawing.Size(25, 23);
            this.cmd_EstadoMaquina.TabIndex = 92;
            this.cmd_EstadoMaquina.Text = "...";
            this.cmd_EstadoMaquina.UseVisualStyleBackColor = false;
            this.cmd_EstadoMaquina.Click += new System.EventHandler(this.cmd_EstadoMaquina_Click);
            // 
            // cbo_EstadoMaquina
            // 
            this.cbo_EstadoMaquina.DisplayMember = "Nombre_Estado";
            this.cbo_EstadoMaquina.Enabled = false;
            this.cbo_EstadoMaquina.FormattingEnabled = true;
            this.cbo_EstadoMaquina.Location = new System.Drawing.Point(500, 293);
            this.cbo_EstadoMaquina.Name = "cbo_EstadoMaquina";
            this.cbo_EstadoMaquina.Size = new System.Drawing.Size(221, 21);
            this.cbo_EstadoMaquina.TabIndex = 91;
            this.cbo_EstadoMaquina.ValueMember = "IdEstadoMaquina";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "Estado Maquina";
            // 
            // txt_horastrabajo
            // 
            this.txt_horastrabajo.Enabled = false;
            this.txt_horastrabajo.Location = new System.Drawing.Point(677, 338);
            this.txt_horastrabajo.Name = "txt_horastrabajo";
            this.txt_horastrabajo.Size = new System.Drawing.Size(69, 20);
            this.txt_horastrabajo.TabIndex = 89;
            this.txt_horastrabajo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_horastrabajo_KeyPress);
            // 
            // txt_produccionmetros
            // 
            this.txt_produccionmetros.Enabled = false;
            this.txt_produccionmetros.Location = new System.Drawing.Point(500, 338);
            this.txt_produccionmetros.Name = "txt_produccionmetros";
            this.txt_produccionmetros.Size = new System.Drawing.Size(69, 20);
            this.txt_produccionmetros.TabIndex = 88;
            this.txt_produccionmetros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_produccionmetros_KeyPress);
            // 
            // txt_ProduccionKg
            // 
            this.txt_ProduccionKg.Enabled = false;
            this.txt_ProduccionKg.Location = new System.Drawing.Point(282, 342);
            this.txt_ProduccionKg.Name = "txt_ProduccionKg";
            this.txt_ProduccionKg.Size = new System.Drawing.Size(69, 20);
            this.txt_ProduccionKg.TabIndex = 87;
            this.txt_ProduccionKg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ProduccionKg_KeyPress);
            // 
            // Chk_Baja
            // 
            this.Chk_Baja.AutoSize = true;
            this.Chk_Baja.Enabled = false;
            this.Chk_Baja.Location = new System.Drawing.Point(109, 381);
            this.Chk_Baja.Name = "Chk_Baja";
            this.Chk_Baja.Size = new System.Drawing.Size(82, 17);
            this.Chk_Baja.TabIndex = 86;
            this.Chk_Baja.Text = "Dar de Baja";
            this.Chk_Baja.UseVisualStyleBackColor = true;
            // 
            // Chk_FlagOperativo
            // 
            this.Chk_FlagOperativo.AutoSize = true;
            this.Chk_FlagOperativo.Enabled = false;
            this.Chk_FlagOperativo.Location = new System.Drawing.Point(11, 381);
            this.Chk_FlagOperativo.Name = "Chk_FlagOperativo";
            this.Chk_FlagOperativo.Size = new System.Drawing.Size(72, 17);
            this.Chk_FlagOperativo.TabIndex = 85;
            this.Chk_FlagOperativo.Text = "Operativo";
            this.Chk_FlagOperativo.UseVisualStyleBackColor = true;
            // 
            // txt_PaisProcedencia
            // 
            this.txt_PaisProcedencia.Enabled = false;
            this.txt_PaisProcedencia.Location = new System.Drawing.Point(109, 245);
            this.txt_PaisProcedencia.Name = "txt_PaisProcedencia";
            this.txt_PaisProcedencia.Size = new System.Drawing.Size(242, 20);
            this.txt_PaisProcedencia.TabIndex = 84;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(591, 345);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 13);
            this.label17.TabIndex = 82;
            this.label17.Text = "Horas Trabajo";
            // 
            // Cmd_AñoFabricacion
            // 
            this.Cmd_AñoFabricacion.BackColor = System.Drawing.Color.Transparent;
            this.Cmd_AñoFabricacion.ForeColor = System.Drawing.Color.Black;
            this.Cmd_AñoFabricacion.Location = new System.Drawing.Point(721, 243);
            this.Cmd_AñoFabricacion.Name = "Cmd_AñoFabricacion";
            this.Cmd_AñoFabricacion.Size = new System.Drawing.Size(25, 23);
            this.Cmd_AñoFabricacion.TabIndex = 81;
            this.Cmd_AñoFabricacion.Text = "...";
            this.Cmd_AñoFabricacion.UseVisualStyleBackColor = false;
            this.Cmd_AñoFabricacion.Click += new System.EventHandler(this.Cmd_AñoFabricacion_Click);
            // 
            // Cbo_AñoFabricacion
            // 
            this.Cbo_AñoFabricacion.DisplayMember = "Año";
            this.Cbo_AñoFabricacion.Enabled = false;
            this.Cbo_AñoFabricacion.FormattingEnabled = true;
            this.Cbo_AñoFabricacion.Location = new System.Drawing.Point(500, 245);
            this.Cbo_AñoFabricacion.Name = "Cbo_AñoFabricacion";
            this.Cbo_AñoFabricacion.Size = new System.Drawing.Size(221, 21);
            this.Cbo_AñoFabricacion.TabIndex = 80;
            this.Cbo_AñoFabricacion.ValueMember = "IdAño";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(392, 248);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 13);
            this.label16.TabIndex = 79;
            this.label16.Text = "Año Fabricacion";
            // 
            // Txt_CodigoMaquina
            // 
            this.Txt_CodigoMaquina.Enabled = false;
            this.Txt_CodigoMaquina.Location = new System.Drawing.Point(500, 197);
            this.Txt_CodigoMaquina.Name = "Txt_CodigoMaquina";
            this.Txt_CodigoMaquina.Size = new System.Drawing.Size(246, 20);
            this.Txt_CodigoMaquina.TabIndex = 78;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(392, 197);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 77;
            this.label15.Text = "Codigo Maquina";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 75;
            this.label7.Text = "Procedencia";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(395, 345);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 13);
            this.label14.TabIndex = 73;
            this.label14.Text = "Produccion Mts";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(190, 345);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 71;
            this.label13.Text = "Produccion KG";
            // 
            // NUD_CantidadMaxOP
            // 
            this.NUD_CantidadMaxOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NUD_CantidadMaxOP.Enabled = false;
            this.NUD_CantidadMaxOP.Location = new System.Drawing.Point(109, 343);
            this.NUD_CantidadMaxOP.Name = "NUD_CantidadMaxOP";
            this.NUD_CantidadMaxOP.Size = new System.Drawing.Size(54, 20);
            this.NUD_CantidadMaxOP.TabIndex = 70;
            // 
            // Cmd_ProveedorMaquina
            // 
            this.Cmd_ProveedorMaquina.BackColor = System.Drawing.Color.Transparent;
            this.Cmd_ProveedorMaquina.ForeColor = System.Drawing.Color.Black;
            this.Cmd_ProveedorMaquina.Location = new System.Drawing.Point(326, 201);
            this.Cmd_ProveedorMaquina.Name = "Cmd_ProveedorMaquina";
            this.Cmd_ProveedorMaquina.Size = new System.Drawing.Size(25, 22);
            this.Cmd_ProveedorMaquina.TabIndex = 69;
            this.Cmd_ProveedorMaquina.Text = "...";
            this.Cmd_ProveedorMaquina.UseVisualStyleBackColor = false;
            this.Cmd_ProveedorMaquina.Click += new System.EventHandler(this.Cmd_ProveedorMaquina_Click);
            // 
            // Cbo_ProveedorMaquina
            // 
            this.Cbo_ProveedorMaquina.DisplayMember = "Razon_Social_Proveedor";
            this.Cbo_ProveedorMaquina.Enabled = false;
            this.Cbo_ProveedorMaquina.FormattingEnabled = true;
            this.Cbo_ProveedorMaquina.Location = new System.Drawing.Point(109, 201);
            this.Cbo_ProveedorMaquina.Name = "Cbo_ProveedorMaquina";
            this.Cbo_ProveedorMaquina.Size = new System.Drawing.Size(221, 21);
            this.Cbo_ProveedorMaquina.TabIndex = 68;
            this.Cbo_ProveedorMaquina.ValueMember = "IdProveedor";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 201);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Proveedor";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 345);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 65;
            this.label11.Text = "N° Ordenes Prod";
            // 
            // cmd_EmpresasCompra
            // 
            this.cmd_EmpresasCompra.BackColor = System.Drawing.Color.Transparent;
            this.cmd_EmpresasCompra.ForeColor = System.Drawing.Color.Black;
            this.cmd_EmpresasCompra.Location = new System.Drawing.Point(721, 151);
            this.cmd_EmpresasCompra.Name = "cmd_EmpresasCompra";
            this.cmd_EmpresasCompra.Size = new System.Drawing.Size(25, 23);
            this.cmd_EmpresasCompra.TabIndex = 63;
            this.cmd_EmpresasCompra.Text = "...";
            this.cmd_EmpresasCompra.UseVisualStyleBackColor = false;
            this.cmd_EmpresasCompra.Click += new System.EventHandler(this.cmd_EmpresasCompra_Click);
            // 
            // cnd_MarcaMaquina
            // 
            this.cnd_MarcaMaquina.BackColor = System.Drawing.Color.Transparent;
            this.cnd_MarcaMaquina.ForeColor = System.Drawing.Color.Black;
            this.cnd_MarcaMaquina.Location = new System.Drawing.Point(326, 107);
            this.cnd_MarcaMaquina.Name = "cnd_MarcaMaquina";
            this.cnd_MarcaMaquina.Size = new System.Drawing.Size(25, 22);
            this.cnd_MarcaMaquina.TabIndex = 62;
            this.cnd_MarcaMaquina.Text = "...";
            this.cnd_MarcaMaquina.UseVisualStyleBackColor = false;
            this.cnd_MarcaMaquina.Click += new System.EventHandler(this.cnd_MarcaMaquina_Click);
            // 
            // cmd_TipoMaquina
            // 
            this.cmd_TipoMaquina.BackColor = System.Drawing.Color.Transparent;
            this.cmd_TipoMaquina.ForeColor = System.Drawing.Color.Black;
            this.cmd_TipoMaquina.Location = new System.Drawing.Point(721, 62);
            this.cmd_TipoMaquina.Name = "cmd_TipoMaquina";
            this.cmd_TipoMaquina.Size = new System.Drawing.Size(25, 22);
            this.cmd_TipoMaquina.TabIndex = 61;
            this.cmd_TipoMaquina.Text = "...";
            this.cmd_TipoMaquina.UseVisualStyleBackColor = false;
            this.cmd_TipoMaquina.Click += new System.EventHandler(this.cmd_TipoMaquina_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 296);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "Fecha Compra";
            // 
            // Dtp_Fecha_Compra
            // 
            this.Dtp_Fecha_Compra.Enabled = false;
            this.Dtp_Fecha_Compra.Location = new System.Drawing.Point(109, 293);
            this.Dtp_Fecha_Compra.Name = "Dtp_Fecha_Compra";
            this.Dtp_Fecha_Compra.Size = new System.Drawing.Size(242, 20);
            this.Dtp_Fecha_Compra.TabIndex = 59;
            // 
            // btnLimpiarImagen
            // 
            this.btnLimpiarImagen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiarImagen.BackgroundImage")));
            this.btnLimpiarImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiarImagen.Location = new System.Drawing.Point(799, 365);
            this.btnLimpiarImagen.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiarImagen.Name = "btnLimpiarImagen";
            this.btnLimpiarImagen.Size = new System.Drawing.Size(45, 46);
            this.btnLimpiarImagen.TabIndex = 58;
            this.btnLimpiarImagen.UseVisualStyleBackColor = true;
            this.btnLimpiarImagen.Click += new System.EventHandler(this.btnLimpiarImagen_Click);
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCargarImagen.BackgroundImage")));
            this.btnCargarImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargarImagen.Location = new System.Drawing.Point(750, 365);
            this.btnCargarImagen.Margin = new System.Windows.Forms.Padding(2);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(45, 46);
            this.btnCargarImagen.TabIndex = 57;
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(392, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "Empresa";
            // 
            // txt_aliasmaquina
            // 
            this.txt_aliasmaquina.Enabled = false;
            this.txt_aliasmaquina.Location = new System.Drawing.Point(109, 64);
            this.txt_aliasmaquina.Name = "txt_aliasmaquina";
            this.txt_aliasmaquina.Size = new System.Drawing.Size(242, 20);
            this.txt_aliasmaquina.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Alias";
            // 
            // txt_seriemaquina
            // 
            this.txt_seriemaquina.Enabled = false;
            this.txt_seriemaquina.Location = new System.Drawing.Point(109, 153);
            this.txt_seriemaquina.Name = "txt_seriemaquina";
            this.txt_seriemaquina.Size = new System.Drawing.Size(242, 20);
            this.txt_seriemaquina.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Serie";
            // 
            // txt_modelomaquina
            // 
            this.txt_modelomaquina.Enabled = false;
            this.txt_modelomaquina.Location = new System.Drawing.Point(500, 109);
            this.txt_modelomaquina.Name = "txt_modelomaquina";
            this.txt_modelomaquina.Size = new System.Drawing.Size(246, 20);
            this.txt_modelomaquina.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Modelo ";
            // 
            // cbo_marcamaquina
            // 
            this.cbo_marcamaquina.DisplayMember = "Descripcion_MarcaMaquina";
            this.cbo_marcamaquina.Enabled = false;
            this.cbo_marcamaquina.FormattingEnabled = true;
            this.cbo_marcamaquina.Location = new System.Drawing.Point(109, 108);
            this.cbo_marcamaquina.Name = "cbo_marcamaquina";
            this.cbo_marcamaquina.Size = new System.Drawing.Size(221, 21);
            this.cbo_marcamaquina.TabIndex = 46;
            this.cbo_marcamaquina.ValueMember = "IdMarcaMaquina";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Marca";
            // 
            // cbo_tipomaquina
            // 
            this.cbo_tipomaquina.DisplayMember = "Nombre_TipoMaquina";
            this.cbo_tipomaquina.Enabled = false;
            this.cbo_tipomaquina.FormattingEnabled = true;
            this.cbo_tipomaquina.Location = new System.Drawing.Point(500, 63);
            this.cbo_tipomaquina.Name = "cbo_tipomaquina";
            this.cbo_tipomaquina.Size = new System.Drawing.Size(221, 21);
            this.cbo_tipomaquina.TabIndex = 44;
            this.cbo_tipomaquina.ValueMember = "IdTipoMaquina";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Tipo ";
            // 
            // Txt_DireccionImagen
            // 
            this.Txt_DireccionImagen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_DireccionImagen.Enabled = false;
            this.Txt_DireccionImagen.Location = new System.Drawing.Point(841, 368);
            this.Txt_DireccionImagen.Multiline = true;
            this.Txt_DireccionImagen.Name = "Txt_DireccionImagen";
            this.Txt_DireccionImagen.ReadOnly = true;
            this.Txt_DireccionImagen.Size = new System.Drawing.Size(241, 41);
            this.Txt_DireccionImagen.TabIndex = 40;
            // 
            // Chk_MostrarImagen
            // 
            this.Chk_MostrarImagen.AutoSize = true;
            this.Chk_MostrarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_MostrarImagen.ForeColor = System.Drawing.Color.Black;
            this.Chk_MostrarImagen.Location = new System.Drawing.Point(804, 36);
            this.Chk_MostrarImagen.Name = "Chk_MostrarImagen";
            this.Chk_MostrarImagen.Size = new System.Drawing.Size(229, 20);
            this.Chk_MostrarImagen.TabIndex = 38;
            this.Chk_MostrarImagen.Text = "Mostrar Imagen del  producto";
            this.Chk_MostrarImagen.UseVisualStyleBackColor = true;
            this.Chk_MostrarImagen.CheckedChanged += new System.EventHandler(this.Chk_MostrarImagen_CheckedChanged);
            // 
            // Img_Producto
            // 
            this.Img_Producto.InitialImage = null;
            this.Img_Producto.Location = new System.Drawing.Point(752, 62);
            this.Img_Producto.Name = "Img_Producto";
            this.Img_Producto.Size = new System.Drawing.Size(330, 300);
            this.Img_Producto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img_Producto.TabIndex = 36;
            this.Img_Producto.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(919, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "IdMaquina";
            // 
            // txt_IdMaquina
            // 
            this.txt_IdMaquina.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_IdMaquina.ForeColor = System.Drawing.Color.Black;
            this.txt_IdMaquina.Location = new System.Drawing.Point(1011, 7);
            this.txt_IdMaquina.Name = "txt_IdMaquina";
            this.txt_IdMaquina.ReadOnly = true;
            this.txt_IdMaquina.Size = new System.Drawing.Size(71, 20);
            this.txt_IdMaquina.TabIndex = 13;
            this.txt_IdMaquina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Titulo.BackColor = System.Drawing.Color.DimGray;
            this.lbl_Titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.ForeColor = System.Drawing.Color.White;
            this.lbl_Titulo.Location = new System.Drawing.Point(0, 0);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(1088, 33);
            this.lbl_Titulo.TabIndex = 8;
            this.lbl_Titulo.Text = "INGRESO DE MAQUINA";
            this.lbl_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbp_Listado
            // 
            this.tbp_Listado.BackColor = System.Drawing.Color.SkyBlue;
            this.tbp_Listado.Controls.Add(this.dgv_Mnt);
            this.tbp_Listado.Controls.Add(this.panel1);
            this.tbp_Listado.Location = new System.Drawing.Point(4, 22);
            this.tbp_Listado.Name = "tbp_Listado";
            this.tbp_Listado.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Listado.Size = new System.Drawing.Size(1088, 420);
            this.tbp_Listado.TabIndex = 1;
            this.tbp_Listado.Text = "Listado";
            this.tbp_Listado.ToolTipText = "Listado de datos";
            // 
            // dgv_Mnt
            // 
            this.dgv_Mnt.AllowUserToAddRows = false;
            this.dgv_Mnt.AllowUserToOrderColumns = true;
            this.dgv_Mnt.BackgroundColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Mnt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Mnt.ColumnHeadersHeight = 35;
            this.dgv_Mnt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMaquina,
            this.Procedencia,
            this.TipoMaquina,
            this.Alias_Maquina,
            this.Marca_Maquina,
            this.Modelo_Maquina});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Mnt.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Mnt.Location = new System.Drawing.Point(3, 42);
            this.dgv_Mnt.Name = "dgv_Mnt";
            this.dgv_Mnt.ReadOnly = true;
            this.dgv_Mnt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Mnt.Size = new System.Drawing.Size(1082, 375);
            this.dgv_Mnt.TabIndex = 3;
            // 
            // IdMaquina
            // 
            this.IdMaquina.DataPropertyName = "IdMaquina";
            this.IdMaquina.HeaderText = "Codigo";
            this.IdMaquina.Name = "IdMaquina";
            this.IdMaquina.ReadOnly = true;
            this.IdMaquina.Width = 50;
            // 
            // Procedencia
            // 
            this.Procedencia.DataPropertyName = "Procedencia";
            this.Procedencia.HeaderText = "Procedencia";
            this.Procedencia.Name = "Procedencia";
            this.Procedencia.ReadOnly = true;
            this.Procedencia.Width = 150;
            // 
            // TipoMaquina
            // 
            this.TipoMaquina.DataPropertyName = "Nombre_TipoMaquina";
            this.TipoMaquina.HeaderText = "Tipo Maquina";
            this.TipoMaquina.Name = "TipoMaquina";
            this.TipoMaquina.ReadOnly = true;
            this.TipoMaquina.Width = 200;
            // 
            // Alias_Maquina
            // 
            this.Alias_Maquina.DataPropertyName = "Alias_Maquina";
            this.Alias_Maquina.HeaderText = "Alias Maquina";
            this.Alias_Maquina.Name = "Alias_Maquina";
            this.Alias_Maquina.ReadOnly = true;
            this.Alias_Maquina.Width = 200;
            // 
            // Marca_Maquina
            // 
            this.Marca_Maquina.DataPropertyName = "Descripcion_MarcaMaquina";
            this.Marca_Maquina.HeaderText = "Marca Maquina";
            this.Marca_Maquina.Name = "Marca_Maquina";
            this.Marca_Maquina.ReadOnly = true;
            this.Marca_Maquina.Width = 200;
            // 
            // Modelo_Maquina
            // 
            this.Modelo_Maquina.DataPropertyName = "Modelo_Maquina";
            this.Modelo_Maquina.HeaderText = "Modelo Maquina";
            this.Modelo_Maquina.Name = "Modelo_Maquina";
            this.Modelo_Maquina.ReadOnly = true;
            this.Modelo_Maquina.Width = 200;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Ivory;
            this.panel1.Controls.Add(this.chk_FiltroEmpresa);
            this.panel1.Controls.Add(this.cbo_FiltroEmpresa);
            this.panel1.Controls.Add(this.cbo_FiltroTipoMaquina);
            this.panel1.Controls.Add(this.chk_TipoMaquina);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 33);
            this.panel1.TabIndex = 2;
            // 
            // chk_FiltroEmpresa
            // 
            this.chk_FiltroEmpresa.AutoSize = true;
            this.chk_FiltroEmpresa.Location = new System.Drawing.Point(275, 9);
            this.chk_FiltroEmpresa.Name = "chk_FiltroEmpresa";
            this.chk_FiltroEmpresa.Size = new System.Drawing.Size(106, 17);
            this.chk_FiltroEmpresa.TabIndex = 59;
            this.chk_FiltroEmpresa.Text = "Empresa Compra";
            this.chk_FiltroEmpresa.UseVisualStyleBackColor = true;
            this.chk_FiltroEmpresa.CheckedChanged += new System.EventHandler(this.chk_FiltroEmpresa_CheckedChanged);
            // 
            // cbo_FiltroEmpresa
            // 
            this.cbo_FiltroEmpresa.DisplayMember = "Nombre_Empresa";
            this.cbo_FiltroEmpresa.Enabled = false;
            this.cbo_FiltroEmpresa.FormattingEnabled = true;
            this.cbo_FiltroEmpresa.Location = new System.Drawing.Point(387, 7);
            this.cbo_FiltroEmpresa.Name = "cbo_FiltroEmpresa";
            this.cbo_FiltroEmpresa.Size = new System.Drawing.Size(250, 21);
            this.cbo_FiltroEmpresa.TabIndex = 58;
            this.cbo_FiltroEmpresa.ValueMember = "IdEmpresa";
            this.cbo_FiltroEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbo_FiltroEmpresa_SelectedIndexChanged);
            // 
            // cbo_FiltroTipoMaquina
            // 
            this.cbo_FiltroTipoMaquina.DisplayMember = "Nombre_TipoMaquina";
            this.cbo_FiltroTipoMaquina.Enabled = false;
            this.cbo_FiltroTipoMaquina.FormattingEnabled = true;
            this.cbo_FiltroTipoMaquina.Location = new System.Drawing.Point(102, 7);
            this.cbo_FiltroTipoMaquina.Name = "cbo_FiltroTipoMaquina";
            this.cbo_FiltroTipoMaquina.Size = new System.Drawing.Size(153, 21);
            this.cbo_FiltroTipoMaquina.TabIndex = 12;
            this.cbo_FiltroTipoMaquina.ValueMember = "IdTipoMaquina";
            this.cbo_FiltroTipoMaquina.SelectedIndexChanged += new System.EventHandler(this.cbo_FiltroTipoMaquina_SelectedIndexChanged);
            // 
            // chk_TipoMaquina
            // 
            this.chk_TipoMaquina.AutoSize = true;
            this.chk_TipoMaquina.Location = new System.Drawing.Point(5, 9);
            this.chk_TipoMaquina.Name = "chk_TipoMaquina";
            this.chk_TipoMaquina.Size = new System.Drawing.Size(91, 17);
            this.chk_TipoMaquina.TabIndex = 0;
            this.chk_TipoMaquina.Text = "Tipo Maquina";
            this.chk_TipoMaquina.UseVisualStyleBackColor = true;
            this.chk_TipoMaquina.CheckedChanged += new System.EventHandler(this.chk_TipoMaquina_CheckedChanged);
            // 
            // PrintDocument
            // 
            this.PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
            // 
            // Frm_RegistroMaquina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 516);
            this.Controls.Add(this.tbc_Mnt);
            this.Controls.Add(this.tls_Formulario);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_RegistroMaquina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Maquina";
            this.Load += new System.EventHandler(this.Frm_RegistroMaquina_Load);
            this.tls_Formulario.ResumeLayout(false);
            this.tls_Formulario.PerformLayout();
            this.tbc_Mnt.ResumeLayout(false);
            this.tbp_Ingreso.ResumeLayout(false);
            this.tbp_Ingreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CantidadMaxOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img_Producto)).EndInit();
            this.tbp_Listado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mnt)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tls_Formulario;
        private System.Windows.Forms.ToolStripButton tls_Agregar;
        private System.Windows.Forms.ToolStripButton tls_Modificar;
        private System.Windows.Forms.ToolStripButton tls_Eliminar;
        private System.Windows.Forms.ToolStripSeparator tls_Separador1;
        private System.Windows.Forms.ToolStripButton tls_Grabar;
        private System.Windows.Forms.ToolStripButton tls_Deshacer;
        private System.Windows.Forms.ToolStripSeparator tls_Separador2;
        private System.Windows.Forms.ToolStripButton tls_Imprimir;
        private System.Windows.Forms.ToolStripButton tls_Previo;
        private System.Windows.Forms.ToolStripSeparator tls_Separador3;
        private System.Windows.Forms.ToolStripButton tls_Buscar;
        private System.Windows.Forms.ToolStripButton tls_OrdenASC;
        private System.Windows.Forms.ToolStripButton tls_OrdenDsc;
        private System.Windows.Forms.ToolStripSeparator tls_Separador4;
        private System.Windows.Forms.ToolStripButton tls_Refrescar;
        private System.Windows.Forms.ToolStripButton tls_Primero;
        private System.Windows.Forms.ToolStripButton tls_Anterior;
        private System.Windows.Forms.ToolStripButton tls_Siguiente;
        private System.Windows.Forms.ToolStripButton tls_Ultimo;
        private System.Windows.Forms.TabControl tbc_Mnt;
        private System.Windows.Forms.TabPage tbp_Ingreso;
        private System.Windows.Forms.Button cmd_EmpresasCompra;
        private System.Windows.Forms.Button cnd_MarcaMaquina;
        private System.Windows.Forms.Button cmd_TipoMaquina;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Compra;
        private System.Windows.Forms.Button btnLimpiarImagen;
        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_aliasmaquina;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_seriemaquina;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_modelomaquina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_marcamaquina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_tipomaquina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_DireccionImagen;
        private System.Windows.Forms.CheckBox Chk_MostrarImagen;
        private System.Windows.Forms.PictureBox Img_Producto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_IdMaquina;
        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.TabPage tbp_Listado;
        private System.Windows.Forms.DataGridView dgv_Mnt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbo_FiltroTipoMaquina;
        private System.Windows.Forms.CheckBox chk_TipoMaquina;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown NUD_CantidadMaxOP;
        private System.Windows.Forms.Button Cmd_ProveedorMaquina;
        private System.Windows.Forms.ComboBox Cbo_ProveedorMaquina;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Txt_CodigoMaquina;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button Cmd_AñoFabricacion;
        private System.Windows.Forms.ComboBox Cbo_AñoFabricacion;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_PaisProcedencia;
        private System.Drawing.Printing.PrintDocument PrintDocument;
        private System.Windows.Forms.CheckBox Chk_Baja;
        private System.Windows.Forms.CheckBox Chk_FlagOperativo;
        private System.Windows.Forms.TextBox txt_produccionmetros;
        private System.Windows.Forms.TextBox txt_ProduccionKg;
        private System.Windows.Forms.TextBox txt_horastrabajo;
        private System.Windows.Forms.Button cmd_EstadoMaquina;
        private System.Windows.Forms.ComboBox cbo_EstadoMaquina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_FiltroEmpresa;
        private System.Windows.Forms.CheckBox chk_FiltroEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMaquina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Procedencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoMaquina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alias_Maquina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca_Maquina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo_Maquina;
        private System.Windows.Forms.ComboBox cbo_EmpresaCompra;
    }
}