
namespace CapaVista_SisB
{
    partial class frmNotas
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
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_Cuenta = new System.Windows.Forms.TextBox();
            this.cmb_facturas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_cheque = new System.Windows.Forms.Label();
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ch_debito = new System.Windows.Forms.CheckBox();
            this.ch_credito = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupB_debito = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_aumento = new System.Windows.Forms.TextBox();
            this.groupB_credito = new System.Windows.Forms.GroupBox();
            this.txt_descuento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_monto = new System.Windows.Forms.Label();
            this.pnl_titulo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupB_debito.SuspendLayout();
            this.groupB_credito.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.SlateGray;
            this.btn_buscar.FlatAppearance.BorderSize = 0;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_buscar.Location = new System.Drawing.Point(144, 297);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(126, 28);
            this.btn_buscar.TabIndex = 94;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_Cuenta
            // 
            this.txt_Cuenta.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_Cuenta.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Cuenta.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Cuenta.Location = new System.Drawing.Point(100, 247);
            this.txt_Cuenta.Multiline = true;
            this.txt_Cuenta.Name = "txt_Cuenta";
            this.txt_Cuenta.Size = new System.Drawing.Size(211, 24);
            this.txt_Cuenta.TabIndex = 93;
            this.txt_Cuenta.Tag = "Cantidad_a_retirar";
            this.txt_Cuenta.Text = "10000";
            this.txt_Cuenta.Click += new System.EventHandler(this.txt_Cuenta_Click);
            // 
            // cmb_facturas
            // 
            this.cmb_facturas.FormattingEnabled = true;
            this.cmb_facturas.Location = new System.Drawing.Point(115, 370);
            this.cmb_facturas.Name = "cmb_facturas";
            this.cmb_facturas.Size = new System.Drawing.Size(174, 21);
            this.cmb_facturas.TabIndex = 92;
            this.cmb_facturas.SelectedIndexChanged += new System.EventHandler(this.cmb_facturas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(41)))), ((int)(((byte)(57)))));
            this.label2.Location = new System.Drawing.Point(152, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Seleccione factura";
            // 
            // lbl_cheque
            // 
            this.lbl_cheque.AutoSize = true;
            this.lbl_cheque.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(41)))), ((int)(((byte)(57)))));
            this.lbl_cheque.Location = new System.Drawing.Point(133, 228);
            this.lbl_cheque.Name = "lbl_cheque";
            this.lbl_cheque.Size = new System.Drawing.Size(156, 13);
            this.lbl_cheque.TabIndex = 90;
            this.lbl_cheque.Text = "Ingrese numero de Cuenta";
            // 
            // pnl_titulo
            // 
            this.pnl_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(57)))));
            this.pnl_titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_titulo.Controls.Add(this.label1);
            this.pnl_titulo.Controls.Add(this.ch_debito);
            this.pnl_titulo.Controls.Add(this.ch_credito);
            this.pnl_titulo.Controls.Add(this.panel4);
            this.pnl_titulo.Controls.Add(this.label6);
            this.pnl_titulo.Location = new System.Drawing.Point(27, 22);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(358, 176);
            this.pnl_titulo.TabIndex = 89;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(124, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Seleccione tipo de Nota";
            // 
            // ch_debito
            // 
            this.ch_debito.AutoSize = true;
            this.ch_debito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_debito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ch_debito.Location = new System.Drawing.Point(198, 127);
            this.ch_debito.Name = "ch_debito";
            this.ch_debito.Size = new System.Drawing.Size(63, 17);
            this.ch_debito.TabIndex = 69;
            this.ch_debito.Text = "Débito";
            this.ch_debito.UseVisualStyleBackColor = true;
            this.ch_debito.CheckedChanged += new System.EventHandler(this.ch_debito_CheckedChanged);
            // 
            // ch_credito
            // 
            this.ch_credito.AutoSize = true;
            this.ch_credito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_credito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ch_credito.Location = new System.Drawing.Point(110, 127);
            this.ch_credito.Name = "ch_credito";
            this.ch_credito.Size = new System.Drawing.Size(66, 17);
            this.ch_credito.TabIndex = 68;
            this.ch_credito.Text = "Crédito";
            this.ch_credito.UseVisualStyleBackColor = true;
            this.ch_credito.CheckedChanged += new System.EventHandler(this.ch_credito_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel4.ForeColor = System.Drawing.Color.Transparent;
            this.panel4.Location = new System.Drawing.Point(63, 43);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(220, 4);
            this.panel4.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(48, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Gestión de Notas";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(57)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.groupB_debito);
            this.panel2.Controls.Add(this.groupB_credito);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(402, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 402);
            this.panel2.TabIndex = 88;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateGray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(117, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 28);
            this.button1.TabIndex = 77;
            this.button1.Text = "Realizar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SlateGray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Location = new System.Drawing.Point(117, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 28);
            this.button2.TabIndex = 78;
            this.button2.Text = "Imprimir";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupB_debito
            // 
            this.groupB_debito.Controls.Add(this.label7);
            this.groupB_debito.Controls.Add(this.txt_aumento);
            this.groupB_debito.ForeColor = System.Drawing.Color.White;
            this.groupB_debito.Location = new System.Drawing.Point(52, 169);
            this.groupB_debito.Name = "groupB_debito";
            this.groupB_debito.Size = new System.Drawing.Size(263, 107);
            this.groupB_debito.TabIndex = 75;
            this.groupB_debito.TabStop = false;
            this.groupB_debito.Text = "Débito";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(31, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 73;
            this.label7.Text = "Monto a aumentar:";
            // 
            // txt_aumento
            // 
            this.txt_aumento.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_aumento.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_aumento.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_aumento.Location = new System.Drawing.Point(34, 50);
            this.txt_aumento.Multiline = true;
            this.txt_aumento.Name = "txt_aumento";
            this.txt_aumento.Size = new System.Drawing.Size(211, 24);
            this.txt_aumento.TabIndex = 60;
            this.txt_aumento.Tag = "Cantidad_a_retirar";
            this.txt_aumento.Text = "10000";
            this.txt_aumento.Click += new System.EventHandler(this.txt_aumento_Click);
            this.txt_aumento.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.txt_aumento_ChangeUICues);
            // 
            // groupB_credito
            // 
            this.groupB_credito.Controls.Add(this.txt_descuento);
            this.groupB_credito.Controls.Add(this.label8);
            this.groupB_credito.ForeColor = System.Drawing.Color.White;
            this.groupB_credito.Location = new System.Drawing.Point(52, 54);
            this.groupB_credito.Name = "groupB_credito";
            this.groupB_credito.Size = new System.Drawing.Size(263, 109);
            this.groupB_credito.TabIndex = 74;
            this.groupB_credito.TabStop = false;
            this.groupB_credito.Text = "Crédito";
            // 
            // txt_descuento
            // 
            this.txt_descuento.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_descuento.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_descuento.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_descuento.Location = new System.Drawing.Point(34, 49);
            this.txt_descuento.Multiline = true;
            this.txt_descuento.Name = "txt_descuento";
            this.txt_descuento.Size = new System.Drawing.Size(211, 24);
            this.txt_descuento.TabIndex = 75;
            this.txt_descuento.Tag = "Cantidad_a_retirar";
            this.txt_descuento.Text = "10000";
            this.txt_descuento.Click += new System.EventHandler(this.txt_descuento_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(31, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Monto a descontar:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel3.ForeColor = System.Drawing.Color.Transparent;
            this.panel3.Location = new System.Drawing.Point(66, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 4);
            this.panel3.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(47, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Selección Cliente";
            // 
            // lbl_monto
            // 
            this.lbl_monto.AutoSize = true;
            this.lbl_monto.BackColor = System.Drawing.Color.Transparent;
            this.lbl_monto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_monto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(41)))), ((int)(((byte)(57)))));
            this.lbl_monto.Location = new System.Drawing.Point(152, 411);
            this.lbl_monto.Name = "lbl_monto";
            this.lbl_monto.Size = new System.Drawing.Size(0, 13);
            this.lbl_monto.TabIndex = 95;
            // 
            // frmNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_monto);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.txt_Cuenta);
            this.Controls.Add(this.cmb_facturas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_cheque);
            this.Controls.Add(this.pnl_titulo);
            this.Controls.Add(this.panel2);
            this.Name = "frmNotas";
            this.Text = "frmNotas";
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupB_debito.ResumeLayout(false);
            this.groupB_debito.PerformLayout();
            this.groupB_credito.ResumeLayout(false);
            this.groupB_credito.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox txt_Cuenta;
        private System.Windows.Forms.ComboBox cmb_facturas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_cheque;
        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ch_debito;
        private System.Windows.Forms.CheckBox ch_credito;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupB_debito;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_aumento;
        private System.Windows.Forms.GroupBox groupB_credito;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_descuento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_monto;
    }
}