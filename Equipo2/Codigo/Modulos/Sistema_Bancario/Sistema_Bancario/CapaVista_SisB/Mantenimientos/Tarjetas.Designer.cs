
namespace CapaVista_SisB.Mantenimientos
{
    partial class frmTarjetas
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_cobro2 = new System.Windows.Forms.Button();
            this.groupB_debito = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupB_credito = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cuenta2 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ch_debito = new System.Windows.Forms.CheckBox();
            this.ch_credito = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_cheque = new System.Windows.Forms.Label();
            this.txt_numero = new System.Windows.Forms.TextBox();
            this.btn_generar_codigo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_cvv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.date_v = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_saldo_crediticio = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.groupB_debito.SuspendLayout();
            this.groupB_credito.SuspendLayout();
            this.pnl_titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(57)))));
            this.panel2.Controls.Add(this.btn_cobro2);
            this.panel2.Controls.Add(this.groupB_debito);
            this.panel2.Controls.Add(this.groupB_credito);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(399, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 402);
            this.panel2.TabIndex = 57;
            // 
            // btn_cobro2
            // 
            this.btn_cobro2.BackColor = System.Drawing.Color.SlateGray;
            this.btn_cobro2.FlatAppearance.BorderSize = 0;
            this.btn_cobro2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cobro2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cobro2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cobro2.Location = new System.Drawing.Point(117, 362);
            this.btn_cobro2.Name = "btn_cobro2";
            this.btn_cobro2.Size = new System.Drawing.Size(126, 28);
            this.btn_cobro2.TabIndex = 76;
            this.btn_cobro2.Text = "Asignar tarjeta";
            this.btn_cobro2.UseVisualStyleBackColor = false;
            this.btn_cobro2.Click += new System.EventHandler(this.btn_cobro2_Click);
            // 
            // groupB_debito
            // 
            this.groupB_debito.Controls.Add(this.label7);
            this.groupB_debito.Controls.Add(this.textBox1);
            this.groupB_debito.ForeColor = System.Drawing.Color.White;
            this.groupB_debito.Location = new System.Drawing.Point(52, 225);
            this.groupB_debito.Name = "groupB_debito";
            this.groupB_debito.Size = new System.Drawing.Size(263, 118);
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
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 73;
            this.label7.Text = "No. Cuenta";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBox1.Location = new System.Drawing.Point(34, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 24);
            this.textBox1.TabIndex = 60;
            this.textBox1.Tag = "Cantidad_a_retirar";
            this.textBox1.Text = "Número de cuenta";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // groupB_credito
            // 
            this.groupB_credito.Controls.Add(this.txt_saldo_crediticio);
            this.groupB_credito.Controls.Add(this.label8);
            this.groupB_credito.Controls.Add(this.label4);
            this.groupB_credito.Controls.Add(this.txt_cuenta2);
            this.groupB_credito.ForeColor = System.Drawing.Color.White;
            this.groupB_credito.Location = new System.Drawing.Point(52, 54);
            this.groupB_credito.Name = "groupB_credito";
            this.groupB_credito.Size = new System.Drawing.Size(263, 155);
            this.groupB_credito.TabIndex = 74;
            this.groupB_credito.TabStop = false;
            this.groupB_credito.Text = "Crédito";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(31, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "No. DPI";
            // 
            // txt_cuenta2
            // 
            this.txt_cuenta2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_cuenta2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cuenta2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_cuenta2.Location = new System.Drawing.Point(34, 42);
            this.txt_cuenta2.Multiline = true;
            this.txt_cuenta2.Name = "txt_cuenta2";
            this.txt_cuenta2.Size = new System.Drawing.Size(211, 24);
            this.txt_cuenta2.TabIndex = 60;
            this.txt_cuenta2.Tag = "Cantidad_a_retirar";
            this.txt_cuenta2.Text = "Número de DPI";
            this.txt_cuenta2.Click += new System.EventHandler(this.txt_cuenta2_Click);
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
            // pnl_titulo
            // 
            this.pnl_titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(57)))));
            this.pnl_titulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_titulo.Controls.Add(this.label1);
            this.pnl_titulo.Controls.Add(this.ch_debito);
            this.pnl_titulo.Controls.Add(this.ch_credito);
            this.pnl_titulo.Controls.Add(this.panel4);
            this.pnl_titulo.Controls.Add(this.label6);
            this.pnl_titulo.Location = new System.Drawing.Point(24, 22);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(358, 176);
            this.pnl_titulo.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(124, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Seleccione tipo de tarjeta";
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
            this.label6.Size = new System.Drawing.Size(219, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Gestión de Tarjetas";
            // 
            // lbl_cheque
            // 
            this.lbl_cheque.AutoSize = true;
            this.lbl_cheque.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(41)))), ((int)(((byte)(57)))));
            this.lbl_cheque.Location = new System.Drawing.Point(48, 218);
            this.lbl_cheque.Name = "lbl_cheque";
            this.lbl_cheque.Size = new System.Drawing.Size(71, 13);
            this.lbl_cheque.TabIndex = 72;
            this.lbl_cheque.Text = "No. Tarjeta";
            // 
            // txt_numero
            // 
            this.txt_numero.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_numero.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numero.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_numero.Location = new System.Drawing.Point(51, 235);
            this.txt_numero.Multiline = true;
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.ReadOnly = true;
            this.txt_numero.Size = new System.Drawing.Size(134, 25);
            this.txt_numero.TabIndex = 71;
            this.txt_numero.Tag = "Cantidad_a_retirar";
            // 
            // btn_generar_codigo
            // 
            this.btn_generar_codigo.BackColor = System.Drawing.Color.Olive;
            this.btn_generar_codigo.FlatAppearance.BorderSize = 0;
            this.btn_generar_codigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_generar_codigo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generar_codigo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_generar_codigo.Location = new System.Drawing.Point(51, 384);
            this.btn_generar_codigo.Name = "btn_generar_codigo";
            this.btn_generar_codigo.Size = new System.Drawing.Size(308, 28);
            this.btn_generar_codigo.TabIndex = 73;
            this.btn_generar_codigo.Text = "Generar Códigos";
            this.btn_generar_codigo.UseVisualStyleBackColor = false;
            this.btn_generar_codigo.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(41)))), ((int)(((byte)(57)))));
            this.label2.Location = new System.Drawing.Point(222, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "No. CVV";
            // 
            // txt_cvv
            // 
            this.txt_cvv.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_cvv.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cvv.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_cvv.Location = new System.Drawing.Point(225, 235);
            this.txt_cvv.Multiline = true;
            this.txt_cvv.Name = "txt_cvv";
            this.txt_cvv.ReadOnly = true;
            this.txt_cvv.Size = new System.Drawing.Size(134, 25);
            this.txt_cvv.TabIndex = 74;
            this.txt_cvv.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(41)))), ((int)(((byte)(57)))));
            this.label3.Location = new System.Drawing.Point(48, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "Fecha de Vencimiento";
            // 
            // date_v
            // 
            this.date_v.Location = new System.Drawing.Point(51, 319);
            this.date_v.Name = "date_v";
            this.date_v.Size = new System.Drawing.Size(200, 20);
            this.date_v.TabIndex = 77;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(31, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Saldo Crediticio";
            // 
            // txt_saldo_crediticio
            // 
            this.txt_saldo_crediticio.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_saldo_crediticio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_saldo_crediticio.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_saldo_crediticio.Location = new System.Drawing.Point(34, 98);
            this.txt_saldo_crediticio.Multiline = true;
            this.txt_saldo_crediticio.Name = "txt_saldo_crediticio";
            this.txt_saldo_crediticio.Size = new System.Drawing.Size(211, 24);
            this.txt_saldo_crediticio.TabIndex = 75;
            this.txt_saldo_crediticio.Tag = "Cantidad_a_retirar";
            this.txt_saldo_crediticio.Text = "10000";
            this.txt_saldo_crediticio.Click += new System.EventHandler(this.txt_saldo_crediticio_Click);
            // 
            // frmTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.date_v);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_cvv);
            this.Controls.Add(this.btn_generar_codigo);
            this.Controls.Add(this.lbl_cheque);
            this.Controls.Add(this.txt_numero);
            this.Controls.Add(this.pnl_titulo);
            this.Controls.Add(this.panel2);
            this.Name = "frmTarjetas";
            this.Text = "frmTarjetas";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupB_debito.ResumeLayout(false);
            this.groupB_debito.PerformLayout();
            this.groupB_credito.ResumeLayout(false);
            this.groupB_credito.PerformLayout();
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_cuenta2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ch_debito;
        private System.Windows.Forms.CheckBox ch_credito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_cheque;
        private System.Windows.Forms.TextBox txt_numero;
        private System.Windows.Forms.Button btn_generar_codigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_cvv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker date_v;
        private System.Windows.Forms.GroupBox groupB_credito;
        private System.Windows.Forms.GroupBox groupB_debito;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_cobro2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_saldo_crediticio;
    }
}