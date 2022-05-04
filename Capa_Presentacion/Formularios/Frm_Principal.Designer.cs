
namespace Capa_Presentacion.Formularios
{
    partial class Frm_Principal
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
            this.cmd_Extrusion = new System.Windows.Forms.Button();
            this.cmd_impresion = new System.Windows.Forms.Button();
            this.Cmd_Sellado = new System.Windows.Forms.Button();
            this.cmd_CorePrincipal = new System.Windows.Forms.Button();
            this.Cmd_ProductosTerminados = new System.Windows.Forms.Button();
            this.Cmd_Laminado = new System.Windows.Forms.Button();
            this.Cmd_Corte = new System.Windows.Forms.Button();
            this.cmd_ConsultasReportes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmd_Extrusion
            // 
            this.cmd_Extrusion.Location = new System.Drawing.Point(14, 106);
            this.cmd_Extrusion.Name = "cmd_Extrusion";
            this.cmd_Extrusion.Size = new System.Drawing.Size(216, 112);
            this.cmd_Extrusion.TabIndex = 0;
            this.cmd_Extrusion.Text = "Extrusion";
            this.cmd_Extrusion.UseVisualStyleBackColor = true;
            this.cmd_Extrusion.Click += new System.EventHandler(this.cmd_Produccion_Click);
            // 
            // cmd_impresion
            // 
            this.cmd_impresion.Location = new System.Drawing.Point(246, 106);
            this.cmd_impresion.Name = "cmd_impresion";
            this.cmd_impresion.Size = new System.Drawing.Size(216, 112);
            this.cmd_impresion.TabIndex = 1;
            this.cmd_impresion.Text = "Impresion";
            this.cmd_impresion.UseVisualStyleBackColor = true;
            // 
            // Cmd_Sellado
            // 
            this.Cmd_Sellado.Location = new System.Drawing.Point(479, 106);
            this.Cmd_Sellado.Name = "Cmd_Sellado";
            this.Cmd_Sellado.Size = new System.Drawing.Size(216, 112);
            this.Cmd_Sellado.TabIndex = 2;
            this.Cmd_Sellado.Text = "Sellado";
            this.Cmd_Sellado.UseVisualStyleBackColor = true;
            // 
            // cmd_CorePrincipal
            // 
            this.cmd_CorePrincipal.Location = new System.Drawing.Point(14, 24);
            this.cmd_CorePrincipal.Name = "cmd_CorePrincipal";
            this.cmd_CorePrincipal.Size = new System.Drawing.Size(681, 65);
            this.cmd_CorePrincipal.TabIndex = 3;
            this.cmd_CorePrincipal.Text = "Core Principal";
            this.cmd_CorePrincipal.UseVisualStyleBackColor = true;
            this.cmd_CorePrincipal.Click += new System.EventHandler(this.cmd_CorePrincipal_Click);
            // 
            // Cmd_ProductosTerminados
            // 
            this.Cmd_ProductosTerminados.Location = new System.Drawing.Point(479, 224);
            this.Cmd_ProductosTerminados.Name = "Cmd_ProductosTerminados";
            this.Cmd_ProductosTerminados.Size = new System.Drawing.Size(216, 112);
            this.Cmd_ProductosTerminados.TabIndex = 6;
            this.Cmd_ProductosTerminados.Text = "Productos Terminado";
            this.Cmd_ProductosTerminados.UseVisualStyleBackColor = true;
            // 
            // Cmd_Laminado
            // 
            this.Cmd_Laminado.Location = new System.Drawing.Point(246, 224);
            this.Cmd_Laminado.Name = "Cmd_Laminado";
            this.Cmd_Laminado.Size = new System.Drawing.Size(216, 112);
            this.Cmd_Laminado.TabIndex = 5;
            this.Cmd_Laminado.Text = "Laminado";
            this.Cmd_Laminado.UseVisualStyleBackColor = true;
            // 
            // Cmd_Corte
            // 
            this.Cmd_Corte.Location = new System.Drawing.Point(14, 224);
            this.Cmd_Corte.Name = "Cmd_Corte";
            this.Cmd_Corte.Size = new System.Drawing.Size(216, 112);
            this.Cmd_Corte.TabIndex = 4;
            this.Cmd_Corte.Text = "Corte";
            this.Cmd_Corte.UseVisualStyleBackColor = true;
            // 
            // cmd_ConsultasReportes
            // 
            this.cmd_ConsultasReportes.Location = new System.Drawing.Point(14, 350);
            this.cmd_ConsultasReportes.Name = "cmd_ConsultasReportes";
            this.cmd_ConsultasReportes.Size = new System.Drawing.Size(681, 65);
            this.cmd_ConsultasReportes.TabIndex = 7;
            this.cmd_ConsultasReportes.Text = "Consultas Reportes";
            this.cmd_ConsultasReportes.UseVisualStyleBackColor = true;
            // 
            // Frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(707, 436);
            this.Controls.Add(this.cmd_ConsultasReportes);
            this.Controls.Add(this.Cmd_ProductosTerminados);
            this.Controls.Add(this.Cmd_Laminado);
            this.Controls.Add(this.Cmd_Corte);
            this.Controls.Add(this.cmd_CorePrincipal);
            this.Controls.Add(this.Cmd_Sellado);
            this.Controls.Add(this.cmd_impresion);
            this.Controls.Add(this.cmd_Extrusion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SISTEMA DE PRODUCCION";
            this.Load += new System.EventHandler(this.Frm_Principal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmd_Extrusion;
        private System.Windows.Forms.Button cmd_impresion;
        private System.Windows.Forms.Button Cmd_Sellado;
        private System.Windows.Forms.Button cmd_CorePrincipal;
        private System.Windows.Forms.Button Cmd_ProductosTerminados;
        private System.Windows.Forms.Button Cmd_Laminado;
        private System.Windows.Forms.Button Cmd_Corte;
        private System.Windows.Forms.Button cmd_ConsultasReportes;
    }
}