
namespace Capa_Presentacion.Formularios
{
    partial class Frm_ProcesosProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ProcesosProduccion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.Chk_FlagDoblado = new System.Windows.Forms.CheckBox();
            this.Chk_FlagLaminado = new System.Windows.Forms.CheckBox();
            this.Chk_FlagCorte = new System.Windows.Forms.CheckBox();
            this.Chk_FlagSellado = new System.Windows.Forms.CheckBox();
            this.Chk_FlagImpresion = new System.Windows.Forms.CheckBox();
            this.Chk_FlagExtrusion = new System.Windows.Forms.CheckBox();
            this.lbl_Puntos = new System.Windows.Forms.Label();
            this.txt_Procesos = new System.Windows.Forms.TextBox();
            this.lbl_Mes = new System.Windows.Forms.Label();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.txt_IdProcesos = new System.Windows.Forms.TextBox();
            this.lbl_IdAño_ = new System.Windows.Forms.Label();
            this.tbp_Listado = new System.Windows.Forms.TabPage();
            this.dgv_Mnt = new System.Windows.Forms.DataGridView();
            this.PrintDocument = new System.Drawing.Printing.PrintDocument();
            this.IdProcesos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Secuencia_Procesos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag_Extrusion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Flag_Sellado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Flag_Impresion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Flag_Corte = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Flag_Laminado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Flag_Doblado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.tls_Formulario.Size = new System.Drawing.Size(883, 70);
            this.tls_Formulario.Stretch = true;
            this.tls_Formulario.TabIndex = 19;
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
            this.tbc_Mnt.Size = new System.Drawing.Size(881, 377);
            this.tbc_Mnt.TabIndex = 20;
            // 
            // tbp_Ingreso
            // 
            this.tbp_Ingreso.BackColor = System.Drawing.Color.White;
            this.tbp_Ingreso.Controls.Add(this.png_Ingreso);
            this.tbp_Ingreso.Controls.Add(this.lbl_Titulo);
            this.tbp_Ingreso.Controls.Add(this.txt_IdProcesos);
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
            this.png_Ingreso.Controls.Add(this.Chk_FlagDoblado);
            this.png_Ingreso.Controls.Add(this.Chk_FlagLaminado);
            this.png_Ingreso.Controls.Add(this.Chk_FlagCorte);
            this.png_Ingreso.Controls.Add(this.Chk_FlagSellado);
            this.png_Ingreso.Controls.Add(this.Chk_FlagImpresion);
            this.png_Ingreso.Controls.Add(this.Chk_FlagExtrusion);
            this.png_Ingreso.Controls.Add(this.lbl_Puntos);
            this.png_Ingreso.Controls.Add(this.txt_Procesos);
            this.png_Ingreso.Controls.Add(this.lbl_Mes);
            this.png_Ingreso.Location = new System.Drawing.Point(35, 123);
            this.png_Ingreso.Name = "png_Ingreso";
            this.png_Ingreso.Size = new System.Drawing.Size(790, 181);
            this.png_Ingreso.TabIndex = 10;
            // 
            // Chk_FlagDoblado
            // 
            this.Chk_FlagDoblado.AutoSize = true;
            this.Chk_FlagDoblado.Location = new System.Drawing.Point(467, 135);
            this.Chk_FlagDoblado.Name = "Chk_FlagDoblado";
            this.Chk_FlagDoblado.Size = new System.Drawing.Size(66, 17);
            this.Chk_FlagDoblado.TabIndex = 16;
            this.Chk_FlagDoblado.Text = "Doblado";
            this.Chk_FlagDoblado.UseVisualStyleBackColor = true;
            // 
            // Chk_FlagLaminado
            // 
            this.Chk_FlagLaminado.AutoSize = true;
            this.Chk_FlagLaminado.Location = new System.Drawing.Point(467, 112);
            this.Chk_FlagLaminado.Name = "Chk_FlagLaminado";
            this.Chk_FlagLaminado.Size = new System.Drawing.Size(72, 17);
            this.Chk_FlagLaminado.TabIndex = 15;
            this.Chk_FlagLaminado.Text = "Laminado";
            this.Chk_FlagLaminado.UseVisualStyleBackColor = true;
            // 
            // Chk_FlagCorte
            // 
            this.Chk_FlagCorte.AutoSize = true;
            this.Chk_FlagCorte.Location = new System.Drawing.Point(467, 89);
            this.Chk_FlagCorte.Name = "Chk_FlagCorte";
            this.Chk_FlagCorte.Size = new System.Drawing.Size(51, 17);
            this.Chk_FlagCorte.TabIndex = 14;
            this.Chk_FlagCorte.Text = "Corte";
            this.Chk_FlagCorte.UseVisualStyleBackColor = true;
            // 
            // Chk_FlagSellado
            // 
            this.Chk_FlagSellado.AutoSize = true;
            this.Chk_FlagSellado.Location = new System.Drawing.Point(467, 66);
            this.Chk_FlagSellado.Name = "Chk_FlagSellado";
            this.Chk_FlagSellado.Size = new System.Drawing.Size(61, 17);
            this.Chk_FlagSellado.TabIndex = 13;
            this.Chk_FlagSellado.Text = "Sellado";
            this.Chk_FlagSellado.UseVisualStyleBackColor = true;
            // 
            // Chk_FlagImpresion
            // 
            this.Chk_FlagImpresion.AutoSize = true;
            this.Chk_FlagImpresion.Location = new System.Drawing.Point(467, 43);
            this.Chk_FlagImpresion.Name = "Chk_FlagImpresion";
            this.Chk_FlagImpresion.Size = new System.Drawing.Size(71, 17);
            this.Chk_FlagImpresion.TabIndex = 12;
            this.Chk_FlagImpresion.Text = "Impresion";
            this.Chk_FlagImpresion.UseVisualStyleBackColor = true;
            // 
            // Chk_FlagExtrusion
            // 
            this.Chk_FlagExtrusion.AutoSize = true;
            this.Chk_FlagExtrusion.Location = new System.Drawing.Point(467, 18);
            this.Chk_FlagExtrusion.Name = "Chk_FlagExtrusion";
            this.Chk_FlagExtrusion.Size = new System.Drawing.Size(69, 17);
            this.Chk_FlagExtrusion.TabIndex = 11;
            this.Chk_FlagExtrusion.Text = "Extrusion";
            this.Chk_FlagExtrusion.UseVisualStyleBackColor = true;
            // 
            // lbl_Puntos
            // 
            this.lbl_Puntos.AutoSize = true;
            this.lbl_Puntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Puntos.Location = new System.Drawing.Point(137, 80);
            this.lbl_Puntos.Name = "lbl_Puntos";
            this.lbl_Puntos.Size = new System.Drawing.Size(10, 13);
            this.lbl_Puntos.TabIndex = 10;
            this.lbl_Puntos.Text = ":";
            // 
            // txt_Procesos
            // 
            this.txt_Procesos.AcceptsReturn = true;
            this.txt_Procesos.AcceptsTab = true;
            this.txt_Procesos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Procesos.Enabled = false;
            this.txt_Procesos.Location = new System.Drawing.Point(153, 77);
            this.txt_Procesos.MaxLength = 0;
            this.txt_Procesos.Name = "txt_Procesos";
            this.txt_Procesos.Size = new System.Drawing.Size(175, 20);
            this.txt_Procesos.TabIndex = 2;
            // 
            // lbl_Mes
            // 
            this.lbl_Mes.AutoSize = true;
            this.lbl_Mes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Mes.Location = new System.Drawing.Point(21, 80);
            this.lbl_Mes.Name = "lbl_Mes";
            this.lbl_Mes.Size = new System.Drawing.Size(105, 13);
            this.lbl_Mes.TabIndex = 9;
            this.lbl_Mes.Text = "Secuencia Procesos";
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
            this.lbl_Titulo.Location = new System.Drawing.Point(35, 81);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(790, 26);
            this.lbl_Titulo.TabIndex = 8;
            this.lbl_Titulo.Text = "INGRESOS PROCESOS PRODUCTIVOS";
            this.lbl_Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_IdProcesos
            // 
            this.txt_IdProcesos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_IdProcesos.Location = new System.Drawing.Point(784, 23);
            this.txt_IdProcesos.Name = "txt_IdProcesos";
            this.txt_IdProcesos.ReadOnly = true;
            this.txt_IdProcesos.Size = new System.Drawing.Size(71, 20);
            this.txt_IdProcesos.TabIndex = 1;
            this.txt_IdProcesos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_IdAño_
            // 
            this.lbl_IdAño_.AutoSize = true;
            this.lbl_IdAño_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IdAño_.ForeColor = System.Drawing.Color.Black;
            this.lbl_IdAño_.Location = new System.Drawing.Point(702, 26);
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
            this.IdProcesos,
            this.Secuencia_Procesos,
            this.Flag_Extrusion,
            this.Flag_Sellado,
            this.Flag_Impresion,
            this.Flag_Corte,
            this.Flag_Laminado,
            this.Flag_Doblado});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Mnt.DefaultCellStyle = dataGridViewCellStyle4;
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
            // IdProcesos
            // 
            this.IdProcesos.DataPropertyName = "IdProcesos";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IdProcesos.DefaultCellStyle = dataGridViewCellStyle2;
            this.IdProcesos.HeaderText = "Código";
            this.IdProcesos.Name = "IdProcesos";
            this.IdProcesos.ReadOnly = true;
            this.IdProcesos.Width = 90;
            // 
            // Secuencia_Procesos
            // 
            this.Secuencia_Procesos.DataPropertyName = "Secuencia_Procesos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Secuencia_Procesos.DefaultCellStyle = dataGridViewCellStyle3;
            this.Secuencia_Procesos.HeaderText = "Secuencia Procesos";
            this.Secuencia_Procesos.Name = "Secuencia_Procesos";
            this.Secuencia_Procesos.ReadOnly = true;
            this.Secuencia_Procesos.Width = 250;
            // 
            // Flag_Extrusion
            // 
            this.Flag_Extrusion.DataPropertyName = "Flag_Extrusion";
            this.Flag_Extrusion.HeaderText = "Extrusion";
            this.Flag_Extrusion.Name = "Flag_Extrusion";
            this.Flag_Extrusion.ReadOnly = true;
            this.Flag_Extrusion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Flag_Extrusion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Flag_Extrusion.Width = 80;
            // 
            // Flag_Sellado
            // 
            this.Flag_Sellado.DataPropertyName = "Flag_Sellado";
            this.Flag_Sellado.HeaderText = "Sellado";
            this.Flag_Sellado.Name = "Flag_Sellado";
            this.Flag_Sellado.ReadOnly = true;
            this.Flag_Sellado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Flag_Sellado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Flag_Sellado.Width = 80;
            // 
            // Flag_Impresion
            // 
            this.Flag_Impresion.DataPropertyName = "Flag_Impresion";
            this.Flag_Impresion.HeaderText = "Impresion";
            this.Flag_Impresion.Name = "Flag_Impresion";
            this.Flag_Impresion.ReadOnly = true;
            this.Flag_Impresion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Flag_Impresion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Flag_Impresion.Width = 80;
            // 
            // Flag_Corte
            // 
            this.Flag_Corte.DataPropertyName = "Flag_Corte";
            this.Flag_Corte.HeaderText = "Corte";
            this.Flag_Corte.Name = "Flag_Corte";
            this.Flag_Corte.ReadOnly = true;
            this.Flag_Corte.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Flag_Corte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Flag_Corte.Width = 80;
            // 
            // Flag_Laminado
            // 
            this.Flag_Laminado.DataPropertyName = "Flag_Laminado";
            this.Flag_Laminado.HeaderText = "Laminado";
            this.Flag_Laminado.Name = "Flag_Laminado";
            this.Flag_Laminado.ReadOnly = true;
            this.Flag_Laminado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Flag_Laminado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Flag_Laminado.Width = 80;
            // 
            // Flag_Doblado
            // 
            this.Flag_Doblado.DataPropertyName = "Flag_Doblado";
            this.Flag_Doblado.HeaderText = "Doblado";
            this.Flag_Doblado.Name = "Flag_Doblado";
            this.Flag_Doblado.ReadOnly = true;
            this.Flag_Doblado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Flag_Doblado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Flag_Doblado.Width = 80;
            // 
            // Frm_ProcesosProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 450);
            this.Controls.Add(this.tbc_Mnt);
            this.Controls.Add(this.tls_Formulario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ProcesosProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ProcesosProduccion";
            this.Load += new System.EventHandler(this.Frm_ProcesosProduccion_Load);
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
        private System.Windows.Forms.CheckBox Chk_FlagDoblado;
        private System.Windows.Forms.CheckBox Chk_FlagLaminado;
        private System.Windows.Forms.CheckBox Chk_FlagCorte;
        private System.Windows.Forms.CheckBox Chk_FlagSellado;
        private System.Windows.Forms.CheckBox Chk_FlagImpresion;
        private System.Windows.Forms.CheckBox Chk_FlagExtrusion;
        private System.Windows.Forms.Label lbl_Puntos;
        private System.Windows.Forms.TextBox txt_Procesos;
        private System.Windows.Forms.Label lbl_Mes;
        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.TextBox txt_IdProcesos;
        private System.Windows.Forms.Label lbl_IdAño_;
        private System.Windows.Forms.TabPage tbp_Listado;
        private System.Windows.Forms.DataGridView dgv_Mnt;
        private System.Drawing.Printing.PrintDocument PrintDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProcesos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Secuencia_Procesos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Flag_Extrusion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Flag_Sellado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Flag_Impresion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Flag_Corte;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Flag_Laminado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Flag_Doblado;
    }
}