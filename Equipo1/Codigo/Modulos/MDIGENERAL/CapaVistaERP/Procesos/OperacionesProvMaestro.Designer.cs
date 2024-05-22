﻿namespace CapaVistaERP.Procesos
{
    partial class OperacionesProvMaestro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperacionesProvMaestro));
            this.dg_facturasprove = new System.Windows.Forms.DataGridView();
            this.cb_año = new System.Windows.Forms.ComboBox();
            this.cb_filtrado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btn_ayudas = new System.Windows.Forms.Button();
            this.btn_reporte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_facturasprove)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_facturasprove
            // 
            this.dg_facturasprove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_facturasprove.Location = new System.Drawing.Point(35, 183);
            this.dg_facturasprove.Name = "dg_facturasprove";
            this.dg_facturasprove.RowHeadersWidth = 51;
            this.dg_facturasprove.RowTemplate.Height = 24;
            this.dg_facturasprove.Size = new System.Drawing.Size(809, 285);
            this.dg_facturasprove.TabIndex = 0;
            // 
            // cb_año
            // 
            this.cb_año.FormattingEnabled = true;
            this.cb_año.Location = new System.Drawing.Point(112, 145);
            this.cb_año.Name = "cb_año";
            this.cb_año.Size = new System.Drawing.Size(121, 24);
            this.cb_año.TabIndex = 1;
            // 
            // cb_filtrado
            // 
            this.cb_filtrado.FormattingEnabled = true;
            this.cb_filtrado.Location = new System.Drawing.Point(331, 145);
            this.cb_filtrado.Name = "cb_filtrado";
            this.cb_filtrado.Size = new System.Drawing.Size(121, 24);
            this.cb_filtrado.TabIndex = 2;
            this.cb_filtrado.SelectedIndexChanged += new System.EventHandler(this.cb_filtrado_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Año:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(253, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Filtrar por:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(3)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.btn_salir);
            this.panel1.Controls.Add(this.btn_ayudas);
            this.panel1.Controls.Add(this.btn_reporte);
            this.panel1.Location = new System.Drawing.Point(35, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 101);
            this.panel1.TabIndex = 15;
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(113)))));
            this.btn_salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salir.ForeColor = System.Drawing.Color.Snow;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_salir.Location = new System.Drawing.Point(221, 13);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(84, 71);
            this.btn_salir.TabIndex = 6;
            this.btn_salir.Text = "Salir";
            this.btn_salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_salir.UseVisualStyleBackColor = false;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_ayudas
            // 
            this.btn_ayudas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(113)))));
            this.btn_ayudas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ayudas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ayudas.ForeColor = System.Drawing.Color.Snow;
            this.btn_ayudas.Image = ((System.Drawing.Image)(resources.GetObject("btn_ayudas.Image")));
            this.btn_ayudas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ayudas.Location = new System.Drawing.Point(114, 13);
            this.btn_ayudas.Name = "btn_ayudas";
            this.btn_ayudas.Size = new System.Drawing.Size(84, 71);
            this.btn_ayudas.TabIndex = 5;
            this.btn_ayudas.Text = "Ayuda";
            this.btn_ayudas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ayudas.UseVisualStyleBackColor = false;
            this.btn_ayudas.Click += new System.EventHandler(this.btn_ayudas_Click);
            // 
            // btn_reporte
            // 
            this.btn_reporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(113)))));
            this.btn_reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reporte.ForeColor = System.Drawing.Color.Snow;
            this.btn_reporte.Image = ((System.Drawing.Image)(resources.GetObject("btn_reporte.Image")));
            this.btn_reporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_reporte.Location = new System.Drawing.Point(14, 13);
            this.btn_reporte.Name = "btn_reporte";
            this.btn_reporte.Size = new System.Drawing.Size(84, 71);
            this.btn_reporte.TabIndex = 4;
            this.btn_reporte.Text = "Reporte";
            this.btn_reporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_reporte.UseVisualStyleBackColor = false;
            // 
            // OperacionesProvMaestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 491);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_filtrado);
            this.Controls.Add(this.cb_año);
            this.Controls.Add(this.dg_facturasprove);
            this.Name = "OperacionesProvMaestro";
            this.Text = "OperacionesProvMaestro";
            ((System.ComponentModel.ISupportInitialize)(this.dg_facturasprove)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_facturasprove;
        private System.Windows.Forms.ComboBox cb_año;
        private System.Windows.Forms.ComboBox cb_filtrado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btn_ayudas;
        private System.Windows.Forms.Button btn_reporte;
    }
}