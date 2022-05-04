
namespace Capa_Presentacion.Formularios
{
    partial class Frm_CodigoEvento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.png_Ingreso = new System.Windows.Forms.Panel();
            this.RB_EventoMaterial = new System.Windows.Forms.RadioButton();
            this.RB_EventoColaborador = new System.Windows.Forms.RadioButton();
            this.Rb_EventoMaquina = new System.Windows.Forms.RadioButton();
            this.cbo_area = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_local = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_codigoevento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Puntos = new System.Windows.Forms.Label();
            this.txt_descripcionevento = new System.Windows.Forms.TextBox();
            this.lbl_Color = new System.Windows.Forms.Label();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.txt_IdCodigoEvento = new System.Windows.Forms.TextBox();
            this.lbl_IdAño_ = new System.Windows.Forms.Label();
            this.tbp_Listado = new System.Windows.Forms.TabPage();
            this.dgv_Mnt = new System.Windows.Forms.DataGridView();
            this.PrintDocument = new System.Drawing.Printing.PrintDocument();
            this.IdCodigoEvento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo_Evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag_EventoMaquina = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Flag_EventoColaborador = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Flag_EventoMaterial = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Nombre_Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_Local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tls_Formulario.SuspendLayout();
            this.tbc_Mnt.SuspendLayout();
            this.tbp_Ingreso.SuspendLayout();
            this.png_Ingreso.SuspendLayout();
            this.tbp_Listado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mnt)).BeginInit();
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
            this.tls_Formulario.Size = new System.Drawing.Size(880, 70);
            this.tls_Formulario.Stretch = true;
            this.tls_Formulario.TabIndex = 16;
            // 
            // tls_Agregar
            // 
            this.tls_Agregar.Image = global::Capa_Presentacion.Properties.Resources.Ajouter;
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
            this.tls_Modificar.Image = global::Capa_Presentacion.Properties.Resources.Edit;
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
            this.tls_Grabar.Image = global::Capa_Presentacion.Properties.Resources.Usbstick;
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
            this.tls_Deshacer.Image = global::Capa_Presentacion.Properties.Resources.Refresh;
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
            this.tls_Imprimir.Image = global::Capa_Presentacion.Properties.Resources.impresora;
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
            this.tls_Previo.Image = global::Capa_Presentacion.Properties.Resources.notepad;
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
            this.tls_Buscar.Image = global::Capa_Presentacion.Properties.Resources.search_hdd;
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
            this.tls_OrdenASC.Image = global::Capa_Presentacion.Properties.Resources.Fleche_Bas_2;
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
            this.tls_OrdenDsc.Image = global::Capa_Presentacion.Properties.Resources.Fleche_Haut_2;
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
            this.tls_Refrescar.Image = global::Capa_Presentacion.Properties.Resources.calls;
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
            this.tls_Primero.Image = global::Capa_Presentacion.Properties.Resources.Media_prev_Mejorado;
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
            this.tls_Anterior.Image = global::Capa_Presentacion.Properties.Resources.Media_backwards_Mejorado;
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
            this.tls_Siguiente.Image = global::Capa_Presentacion.Properties.Resources.Media_fastforward___Mejorado;
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
            this.tls_Ultimo.Image = global::Capa_Presentacion.Properties.Resources.Media_next_Mejorado;
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
            this.tbc_Mnt.Size = new System.Drawing.Size(881, 377);
            this.tbc_Mnt.TabIndex = 17;
            // 
            // tbp_Ingreso
            // 
            this.tbp_Ingreso.BackColor = System.Drawing.Color.White;
            this.tbp_Ingreso.Controls.Add(this.png_Ingreso);
            this.tbp_Ingreso.Controls.Add(this.lbl_Titulo);
            this.tbp_Ingreso.Controls.Add(this.txt_IdCodigoEvento);
            this.tbp_Ingreso.Controls.Add(this.lbl_IdAño_);
            this.tbp_Ingreso.Location = new System.Drawing.Point(4, 22);
            this.tbp_Ingreso.Name = "tbp_Ingreso";
            this.tbp_Ingreso.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Ingreso.Size = new System.Drawing.Size(873, 351);
            this.tbp_Ingreso.TabIndex = 0;
            this.tbp_Ingreso.Text = "Ingreso";
            this.tbp_Ingreso.ToolTipText = "Ingreso de datos";
            // 
            // png_Ingreso
            // 
            this.png_Ingreso.BackColor = System.Drawing.Color.SkyBlue;
            this.png_Ingreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.png_Ingreso.Controls.Add(this.RB_EventoMaterial);
            this.png_Ingreso.Controls.Add(this.RB_EventoColaborador);
            this.png_Ingreso.Controls.Add(this.Rb_EventoMaquina);
            this.png_Ingreso.Controls.Add(this.cbo_area);
            this.png_Ingreso.Controls.Add(this.label5);
            this.png_Ingreso.Controls.Add(this.label6);
            this.png_Ingreso.Controls.Add(this.cbo_local);
            this.png_Ingreso.Controls.Add(this.label3);
            this.png_Ingreso.Controls.Add(this.label4);
            this.png_Ingreso.Controls.Add(this.label1);
            this.png_Ingreso.Controls.Add(this.txt_codigoevento);
            this.png_Ingreso.Controls.Add(this.label2);
            this.png_Ingreso.Controls.Add(this.lbl_Puntos);
            this.png_Ingreso.Controls.Add(this.txt_descripcionevento);
            this.png_Ingreso.Controls.Add(this.lbl_Color);
            this.png_Ingreso.Location = new System.Drawing.Point(35, 75);
            this.png_Ingreso.Name = "png_Ingreso";
            this.png_Ingreso.Size = new System.Drawing.Size(803, 236);
            this.png_Ingreso.TabIndex = 10;
            // 
            // RB_EventoMaterial
            // 
            this.RB_EventoMaterial.AutoSize = true;
            this.RB_EventoMaterial.Enabled = false;
            this.RB_EventoMaterial.Location = new System.Drawing.Point(610, 108);
            this.RB_EventoMaterial.Name = "RB_EventoMaterial";
            this.RB_EventoMaterial.Size = new System.Drawing.Size(99, 17);
            this.RB_EventoMaterial.TabIndex = 25;
            this.RB_EventoMaterial.TabStop = true;
            this.RB_EventoMaterial.Text = "Evento Material";
            this.RB_EventoMaterial.UseVisualStyleBackColor = true;
            // 
            // RB_EventoColaborador
            // 
            this.RB_EventoColaborador.AutoSize = true;
            this.RB_EventoColaborador.Enabled = false;
            this.RB_EventoColaborador.Location = new System.Drawing.Point(393, 108);
            this.RB_EventoColaborador.Name = "RB_EventoColaborador";
            this.RB_EventoColaborador.Size = new System.Drawing.Size(119, 17);
            this.RB_EventoColaborador.TabIndex = 24;
            this.RB_EventoColaborador.TabStop = true;
            this.RB_EventoColaborador.Text = "Evento Colaborador";
            this.RB_EventoColaborador.UseVisualStyleBackColor = true;
            // 
            // Rb_EventoMaquina
            // 
            this.Rb_EventoMaquina.AutoSize = true;
            this.Rb_EventoMaquina.Enabled = false;
            this.Rb_EventoMaquina.Location = new System.Drawing.Point(183, 108);
            this.Rb_EventoMaquina.Name = "Rb_EventoMaquina";
            this.Rb_EventoMaquina.Size = new System.Drawing.Size(103, 17);
            this.Rb_EventoMaquina.TabIndex = 23;
            this.Rb_EventoMaquina.TabStop = true;
            this.Rb_EventoMaquina.Text = "Evento Maquina";
            this.Rb_EventoMaquina.UseVisualStyleBackColor = true;
            // 
            // cbo_area
            // 
            this.cbo_area.DisplayMember = "Nombre_Area";
            this.cbo_area.Enabled = false;
            this.cbo_area.FormattingEnabled = true;
            this.cbo_area.Location = new System.Drawing.Point(183, 192);
            this.cbo_area.Name = "cbo_area";
            this.cbo_area.Size = new System.Drawing.Size(147, 21);
            this.cbo_area.TabIndex = 22;
            this.cbo_area.ValueMember = "IdArea";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(145, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Area";
            // 
            // cbo_local
            // 
            this.cbo_local.DisplayMember = "Nombre_Local";
            this.cbo_local.Enabled = false;
            this.cbo_local.FormattingEnabled = true;
            this.cbo_local.Location = new System.Drawing.Point(183, 148);
            this.cbo_local.Name = "cbo_local";
            this.cbo_local.Size = new System.Drawing.Size(147, 21);
            this.cbo_local.TabIndex = 19;
            this.cbo_local.ValueMember = "IdLocal";
            this.cbo_local.SelectedIndexChanged += new System.EventHandler(this.cbo_local_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(145, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Local";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = ":";
            // 
            // txt_codigoevento
            // 
            this.txt_codigoevento.AcceptsReturn = true;
            this.txt_codigoevento.AcceptsTab = true;
            this.txt_codigoevento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_codigoevento.Enabled = false;
            this.txt_codigoevento.Location = new System.Drawing.Point(183, 59);
            this.txt_codigoevento.MaxLength = 4;
            this.txt_codigoevento.Name = "txt_codigoevento";
            this.txt_codigoevento.Size = new System.Drawing.Size(147, 20);
            this.txt_codigoevento.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Codigo Evento";
            // 
            // lbl_Puntos
            // 
            this.lbl_Puntos.AutoSize = true;
            this.lbl_Puntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Puntos.Location = new System.Drawing.Point(145, 24);
            this.lbl_Puntos.Name = "lbl_Puntos";
            this.lbl_Puntos.Size = new System.Drawing.Size(10, 13);
            this.lbl_Puntos.TabIndex = 10;
            this.lbl_Puntos.Text = ":";
            // 
            // txt_descripcionevento
            // 
            this.txt_descripcionevento.AcceptsReturn = true;
            this.txt_descripcionevento.AcceptsTab = true;
            this.txt_descripcionevento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_descripcionevento.Enabled = false;
            this.txt_descripcionevento.Location = new System.Drawing.Point(183, 21);
            this.txt_descripcionevento.MaxLength = 0;
            this.txt_descripcionevento.Name = "txt_descripcionevento";
            this.txt_descripcionevento.Size = new System.Drawing.Size(295, 20);
            this.txt_descripcionevento.TabIndex = 2;
            // 
            // lbl_Color
            // 
            this.lbl_Color.AutoSize = true;
            this.lbl_Color.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Color.Location = new System.Drawing.Point(37, 24);
            this.lbl_Color.Name = "lbl_Color";
            this.lbl_Color.Size = new System.Drawing.Size(100, 13);
            this.lbl_Color.TabIndex = 9;
            this.lbl_Color.Text = "Descripcion Evento";
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
            this.lbl_Titulo.Location = new System.Drawing.Point(35, 46);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(803, 26);
            this.lbl_Titulo.TabIndex = 8;
            this.lbl_Titulo.Text = "INGRESO CODIGO DE EVENTO";
            this.lbl_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_IdCodigoEvento
            // 
            this.txt_IdCodigoEvento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(225)))));
            this.txt_IdCodigoEvento.Location = new System.Drawing.Point(767, 23);
            this.txt_IdCodigoEvento.Name = "txt_IdCodigoEvento";
            this.txt_IdCodigoEvento.ReadOnly = true;
            this.txt_IdCodigoEvento.Size = new System.Drawing.Size(71, 20);
            this.txt_IdCodigoEvento.TabIndex = 1;
            this.txt_IdCodigoEvento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_IdAño_
            // 
            this.lbl_IdAño_.AutoSize = true;
            this.lbl_IdAño_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IdAño_.ForeColor = System.Drawing.Color.Black;
            this.lbl_IdAño_.Location = new System.Drawing.Point(692, 26);
            this.lbl_IdAño_.Name = "lbl_IdAño_";
            this.lbl_IdAño_.Size = new System.Drawing.Size(58, 13);
            this.lbl_IdAño_.TabIndex = 0;
            this.lbl_IdAño_.Text = "Código : ";
            // 
            // tbp_Listado
            // 
            this.tbp_Listado.Controls.Add(this.dgv_Mnt);
            this.tbp_Listado.Location = new System.Drawing.Point(4, 22);
            this.tbp_Listado.Name = "tbp_Listado";
            this.tbp_Listado.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_Listado.Size = new System.Drawing.Size(873, 351);
            this.tbp_Listado.TabIndex = 1;
            this.tbp_Listado.Text = "Listado";
            this.tbp_Listado.ToolTipText = "Listado de datos";
            this.tbp_Listado.UseVisualStyleBackColor = true;
            // 
            // dgv_Mnt
            // 
            this.dgv_Mnt.AllowUserToAddRows = false;
            this.dgv_Mnt.AllowUserToOrderColumns = true;
            this.dgv_Mnt.BackgroundColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Mnt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_Mnt.ColumnHeadersHeight = 35;
            this.dgv_Mnt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCodigoEvento,
            this.Codigo_Evento,
            this.Descripcion,
            this.Flag_EventoMaquina,
            this.Flag_EventoColaborador,
            this.Flag_EventoMaterial,
            this.Nombre_Area,
            this.Nombre_Local});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Mnt.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_Mnt.Location = new System.Drawing.Point(0, 4);
            this.dgv_Mnt.Name = "dgv_Mnt";
            this.dgv_Mnt.ReadOnly = true;
            this.dgv_Mnt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Mnt.Size = new System.Drawing.Size(867, 347);
            this.dgv_Mnt.TabIndex = 0;
            // 
            // PrintDocument
            // 
            this.PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
            // 
            // IdCodigoEvento
            // 
            this.IdCodigoEvento.DataPropertyName = "IdCodigoEvento";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IdCodigoEvento.DefaultCellStyle = dataGridViewCellStyle8;
            this.IdCodigoEvento.HeaderText = "Código";
            this.IdCodigoEvento.Name = "IdCodigoEvento";
            this.IdCodigoEvento.ReadOnly = true;
            // 
            // Codigo_Evento
            // 
            this.Codigo_Evento.DataPropertyName = "Codigo_Evento";
            this.Codigo_Evento.HeaderText = "Codigo Evento";
            this.Codigo_Evento.Name = "Codigo_Evento";
            this.Codigo_Evento.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Flag_EventoMaquina
            // 
            this.Flag_EventoMaquina.DataPropertyName = "Flag_EventoMaquina";
            this.Flag_EventoMaquina.FalseValue = "0";
            this.Flag_EventoMaquina.HeaderText = "Evento Maquina";
            this.Flag_EventoMaquina.Name = "Flag_EventoMaquina";
            this.Flag_EventoMaquina.ReadOnly = true;
            this.Flag_EventoMaquina.TrueValue = "1";
            // 
            // Flag_EventoColaborador
            // 
            this.Flag_EventoColaborador.DataPropertyName = "Flag_EventoColaborador";
            this.Flag_EventoColaborador.FalseValue = "0";
            this.Flag_EventoColaborador.HeaderText = "Evento Colaborador";
            this.Flag_EventoColaborador.Name = "Flag_EventoColaborador";
            this.Flag_EventoColaborador.ReadOnly = true;
            this.Flag_EventoColaborador.TrueValue = "1";
            // 
            // Flag_EventoMaterial
            // 
            this.Flag_EventoMaterial.DataPropertyName = "Flag_EventoMaterial";
            this.Flag_EventoMaterial.FalseValue = "0";
            this.Flag_EventoMaterial.HeaderText = "Evento Material";
            this.Flag_EventoMaterial.Name = "Flag_EventoMaterial";
            this.Flag_EventoMaterial.ReadOnly = true;
            this.Flag_EventoMaterial.TrueValue = "1";
            // 
            // Nombre_Area
            // 
            this.Nombre_Area.DataPropertyName = "Nombre_Area";
            this.Nombre_Area.HeaderText = "Nombre Area";
            this.Nombre_Area.Name = "Nombre_Area";
            this.Nombre_Area.ReadOnly = true;
            this.Nombre_Area.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Nombre_Area.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Nombre_Local
            // 
            this.Nombre_Local.DataPropertyName = "Nombre_Local";
            this.Nombre_Local.HeaderText = "Nombre Local";
            this.Nombre_Local.Name = "Nombre_Local";
            this.Nombre_Local.ReadOnly = true;
            this.Nombre_Local.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Nombre_Local.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Frm_CodigoEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 450);
            this.Controls.Add(this.tbc_Mnt);
            this.Controls.Add(this.tls_Formulario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_CodigoEvento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Codigo Evento";
            this.Load += new System.EventHandler(this.Frm_CodigoEvento_Load);
            this.tls_Formulario.ResumeLayout(false);
            this.tls_Formulario.PerformLayout();
            this.tbc_Mnt.ResumeLayout(false);
            this.tbp_Ingreso.ResumeLayout(false);
            this.tbp_Ingreso.PerformLayout();
            this.png_Ingreso.ResumeLayout(false);
            this.png_Ingreso.PerformLayout();
            this.tbp_Listado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mnt)).EndInit();
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
        private System.Windows.Forms.Panel png_Ingreso;
        private System.Windows.Forms.Label lbl_Puntos;
        private System.Windows.Forms.TextBox txt_descripcionevento;
        private System.Windows.Forms.Label lbl_Color;
        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.TextBox txt_IdCodigoEvento;
        private System.Windows.Forms.Label lbl_IdAño_;
        private System.Windows.Forms.TabPage tbp_Listado;
        private System.Windows.Forms.DataGridView dgv_Mnt;
        private System.Windows.Forms.ComboBox cbo_area;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbo_local;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_codigoevento;
        private System.Windows.Forms.Label label2;
        private System.Drawing.Printing.PrintDocument PrintDocument;
        private System.Windows.Forms.RadioButton RB_EventoMaterial;
        private System.Windows.Forms.RadioButton RB_EventoColaborador;
        private System.Windows.Forms.RadioButton Rb_EventoMaquina;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCodigoEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_Evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Flag_EventoMaquina;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Flag_EventoColaborador;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Flag_EventoMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Local;
    }
}