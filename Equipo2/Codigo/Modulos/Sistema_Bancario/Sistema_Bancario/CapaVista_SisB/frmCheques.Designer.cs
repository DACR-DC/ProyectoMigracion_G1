
namespace CapaVista_SisB
{
    partial class frmCheques
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
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cheque2 = new System.Windows.Forms.TextBox();
            this.txt_cuenta2 = new System.Windows.Forms.TextBox();
            this.btn_cobro2 = new System.Windows.Forms.Button();
            this.txt_monto2 = new System.Windows.Forms.TextBox();
            this.lbl_debitar = new System.Windows.Forms.Label();
            this.lbl_destino = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_cobro1 = new System.Windows.Forms.Button();
            this.txt_cheque = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_fill = new System.Windows.Forms.Label();
            this.btn_fill = new System.Windows.Forms.Button();
            this.txt_cant1 = new System.Windows.Forms.TextBox();
            this.ch_retiro = new System.Windows.Forms.CheckBox();
            this.ch_deposito = new System.Windows.Forms.CheckBox();
            this.txt_monto1 = new System.Windows.Forms.TextBox();
            this.lbl_cheque = new System.Windows.Forms.Label();
            this.lbl_monto = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_check = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(57)))));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_cheque2);
            this.panel2.Controls.Add(this.txt_cuenta2);
            this.panel2.Controls.Add(this.btn_cobro2);
            this.panel2.Controls.Add(this.txt_monto2);
            this.panel2.Controls.Add(this.lbl_debitar);
            this.panel2.Controls.Add(this.lbl_destino);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(379, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 456);
            this.panel2.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(64, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "No. Cheque";
            // 
            // txt_cheque2
            // 
            this.txt_cheque2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_cheque2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cheque2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_cheque2.Location = new System.Drawing.Point(63, 146);
            this.txt_cheque2.Multiline = true;
            this.txt_cheque2.Name = "txt_cheque2";
            this.txt_cheque2.Size = new System.Drawing.Size(134, 25);
            this.txt_cheque2.TabIndex = 71;
            this.txt_cheque2.Tag = "Cantidad_a_retirar";
            this.txt_cheque2.Text = "31573015";
            // 
            // txt_cuenta2
            // 
            this.txt_cuenta2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_cuenta2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cuenta2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_cuenta2.Location = new System.Drawing.Point(63, 227);
            this.txt_cuenta2.Multiline = true;
            this.txt_cuenta2.Name = "txt_cuenta2";
            this.txt_cuenta2.Size = new System.Drawing.Size(252, 24);
            this.txt_cuenta2.TabIndex = 60;
            this.txt_cuenta2.Tag = "Cantidad_a_retirar";
            this.txt_cuenta2.Text = " Número de cuenta";
            // 
            // btn_cobro2
            // 
            this.btn_cobro2.BackColor = System.Drawing.Color.SlateGray;
            this.btn_cobro2.FlatAppearance.BorderSize = 0;
            this.btn_cobro2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cobro2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cobro2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cobro2.Location = new System.Drawing.Point(62, 368);
            this.btn_cobro2.Name = "btn_cobro2";
            this.btn_cobro2.Size = new System.Drawing.Size(126, 28);
            this.btn_cobro2.TabIndex = 53;
            this.btn_cobro2.Text = "Cobrar cheque";
            this.btn_cobro2.UseVisualStyleBackColor = false;
            this.btn_cobro2.Click += new System.EventHandler(this.btn_cobro2_Click);
            // 
            // txt_monto2
            // 
            this.txt_monto2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_monto2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_monto2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_monto2.Location = new System.Drawing.Point(63, 309);
            this.txt_monto2.Multiline = true;
            this.txt_monto2.Name = "txt_monto2";
            this.txt_monto2.Size = new System.Drawing.Size(252, 26);
            this.txt_monto2.TabIndex = 50;
            this.txt_monto2.Tag = "Cantidad_a_retirar";
            this.txt_monto2.Text = "Q. 100";
            // 
            // lbl_debitar
            // 
            this.lbl_debitar.AutoSize = true;
            this.lbl_debitar.BackColor = System.Drawing.Color.Transparent;
            this.lbl_debitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_debitar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbl_debitar.Location = new System.Drawing.Point(60, 288);
            this.lbl_debitar.Name = "lbl_debitar";
            this.lbl_debitar.Size = new System.Drawing.Size(96, 13);
            this.lbl_debitar.TabIndex = 49;
            this.lbl_debitar.Text = "Monto a debitar";
            // 
            // lbl_destino
            // 
            this.lbl_destino.AutoSize = true;
            this.lbl_destino.BackColor = System.Drawing.Color.Transparent;
            this.lbl_destino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_destino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbl_destino.Location = new System.Drawing.Point(60, 208);
            this.lbl_destino.Name = "lbl_destino";
            this.lbl_destino.Size = new System.Drawing.Size(92, 13);
            this.lbl_destino.TabIndex = 45;
            this.lbl_destino.Text = "Cuenta destino";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel3.ForeColor = System.Drawing.Color.Transparent;
            this.panel3.Location = new System.Drawing.Point(63, 60);
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
            this.label5.Location = new System.Drawing.Point(47, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Transaccion";
            // 
            // btn_cobro1
            // 
            this.btn_cobro1.BackColor = System.Drawing.Color.SlateGray;
            this.btn_cobro1.FlatAppearance.BorderSize = 0;
            this.btn_cobro1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cobro1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cobro1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cobro1.Location = new System.Drawing.Point(59, 450);
            this.btn_cobro1.Name = "btn_cobro1";
            this.btn_cobro1.Size = new System.Drawing.Size(263, 28);
            this.btn_cobro1.TabIndex = 55;
            this.btn_cobro1.Text = "Cobrar Cheque";
            this.btn_cobro1.UseVisualStyleBackColor = false;
            this.btn_cobro1.Click += new System.EventHandler(this.btn_cobro1_Click);
            // 
            // txt_cheque
            // 
            this.txt_cheque.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_cheque.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cheque.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_cheque.Location = new System.Drawing.Point(54, 314);
            this.txt_cheque.Multiline = true;
            this.txt_cheque.Name = "txt_cheque";
            this.txt_cheque.Size = new System.Drawing.Size(134, 25);
            this.txt_cheque.TabIndex = 54;
            this.txt_cheque.Tag = "Cantidad_a_retirar";
            this.txt_cheque.Text = "31573015";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(41)))), ((int)(((byte)(57)))));
            this.label2.Location = new System.Drawing.Point(56, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "No. Cuenta";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBox1.Location = new System.Drawing.Point(59, 40);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 30);
            this.textBox1.TabIndex = 59;
            this.textBox1.Tag = "Cantidad_a_retirar";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(85)))), ((int)(((byte)(114)))));
            this.label3.Location = new System.Drawing.Point(54, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 60;
            this.label3.Text = "Chequera";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(42)))));
            this.panel4.Location = new System.Drawing.Point(81, 121);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(220, 4);
            this.panel4.TabIndex = 61;
            // 
            // lbl_fill
            // 
            this.lbl_fill.AutoSize = true;
            this.lbl_fill.BackColor = System.Drawing.Color.Silver;
            this.lbl_fill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(41)))), ((int)(((byte)(57)))));
            this.lbl_fill.Location = new System.Drawing.Point(78, 139);
            this.lbl_fill.Name = "lbl_fill";
            this.lbl_fill.Size = new System.Drawing.Size(133, 13);
            this.lbl_fill.TabIndex = 62;
            this.lbl_fill.Text = "Chequera sin cheques";
            // 
            // btn_fill
            // 
            this.btn_fill.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_fill.FlatAppearance.BorderSize = 0;
            this.btn_fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fill.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fill.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_fill.Location = new System.Drawing.Point(199, 173);
            this.btn_fill.Name = "btn_fill";
            this.btn_fill.Size = new System.Drawing.Size(111, 30);
            this.btn_fill.TabIndex = 63;
            this.btn_fill.Text = "Llenar Chequera";
            this.btn_fill.UseVisualStyleBackColor = false;
            this.btn_fill.Click += new System.EventHandler(this.btn_fill_Click);
            // 
            // txt_cant1
            // 
            this.txt_cant1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_cant1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cant1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_cant1.Location = new System.Drawing.Point(54, 177);
            this.txt_cant1.Multiline = true;
            this.txt_cant1.Name = "txt_cant1";
            this.txt_cant1.Size = new System.Drawing.Size(134, 25);
            this.txt_cant1.TabIndex = 64;
            this.txt_cant1.Tag = "Cantidad_a_retirar";
            this.txt_cant1.Text = "Cantidad cheques";
            // 
            // ch_retiro
            // 
            this.ch_retiro.AutoSize = true;
            this.ch_retiro.Location = new System.Drawing.Point(81, 241);
            this.ch_retiro.Name = "ch_retiro";
            this.ch_retiro.Size = new System.Drawing.Size(54, 17);
            this.ch_retiro.TabIndex = 66;
            this.ch_retiro.Text = "Retiro";
            this.ch_retiro.UseVisualStyleBackColor = true;
            this.ch_retiro.CheckedChanged += new System.EventHandler(this.ch_retiro_CheckedChanged);
            // 
            // ch_deposito
            // 
            this.ch_deposito.AutoSize = true;
            this.ch_deposito.Location = new System.Drawing.Point(221, 241);
            this.ch_deposito.Name = "ch_deposito";
            this.ch_deposito.Size = new System.Drawing.Size(68, 17);
            this.ch_deposito.TabIndex = 67;
            this.ch_deposito.Text = "Deposito";
            this.ch_deposito.UseVisualStyleBackColor = true;
            this.ch_deposito.CheckedChanged += new System.EventHandler(this.ch_deposito_CheckedChanged);
            // 
            // txt_monto1
            // 
            this.txt_monto1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_monto1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_monto1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_monto1.Location = new System.Drawing.Point(54, 384);
            this.txt_monto1.Multiline = true;
            this.txt_monto1.Name = "txt_monto1";
            this.txt_monto1.Size = new System.Drawing.Size(134, 25);
            this.txt_monto1.TabIndex = 68;
            this.txt_monto1.Tag = "Cantidad_a_retirar";
            this.txt_monto1.Text = "Q. 100";
            // 
            // lbl_cheque
            // 
            this.lbl_cheque.AutoSize = true;
            this.lbl_cheque.BackColor = System.Drawing.Color.Transparent;
            this.lbl_cheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(41)))), ((int)(((byte)(57)))));
            this.lbl_cheque.Location = new System.Drawing.Point(51, 297);
            this.lbl_cheque.Name = "lbl_cheque";
            this.lbl_cheque.Size = new System.Drawing.Size(74, 13);
            this.lbl_cheque.TabIndex = 70;
            this.lbl_cheque.Text = "No. Cheque";
            // 
            // lbl_monto
            // 
            this.lbl_monto.AutoSize = true;
            this.lbl_monto.BackColor = System.Drawing.Color.Transparent;
            this.lbl_monto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_monto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(41)))), ((int)(((byte)(57)))));
            this.lbl_monto.Location = new System.Drawing.Point(51, 368);
            this.lbl_monto.Name = "lbl_monto";
            this.lbl_monto.Size = new System.Drawing.Size(42, 13);
            this.lbl_monto.TabIndex = 71;
            this.lbl_monto.Text = "Monto";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(3, 218);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 2);
            this.panel1.TabIndex = 72;
            // 
            // btn_check
            // 
            this.btn_check.BackColor = System.Drawing.Color.Transparent;
            this.btn_check.FlatAppearance.BorderSize = 0;
            this.btn_check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_check.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_check.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_check.Image = global::CapaVista_SisB.Properties.Resources.checkIcon;
            this.btn_check.Location = new System.Drawing.Point(253, 39);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(36, 30);
            this.btn_check.TabIndex = 73;
            this.btn_check.UseVisualStyleBackColor = false;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // frmCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(801, 504);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_monto);
            this.Controls.Add(this.lbl_cheque);
            this.Controls.Add(this.txt_monto1);
            this.Controls.Add(this.ch_deposito);
            this.Controls.Add(this.ch_retiro);
            this.Controls.Add(this.txt_cant1);
            this.Controls.Add(this.btn_fill);
            this.Controls.Add(this.lbl_fill);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_cobro1);
            this.Controls.Add(this.txt_cheque);
            this.Name = "frmCheques";
            this.Tag = "GestCli_Cheques";
            this.Text = "frmCheques";
            this.Load += new System.EventHandler(this.frmCheques_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_cobro2;
        private System.Windows.Forms.TextBox txt_monto2;
        private System.Windows.Forms.Label lbl_debitar;
        private System.Windows.Forms.Label lbl_destino;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_cobro1;
        private System.Windows.Forms.TextBox txt_cheque;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_fill;
        private System.Windows.Forms.Button btn_fill;
        private System.Windows.Forms.TextBox txt_cant1;
        private System.Windows.Forms.CheckBox ch_retiro;
        private System.Windows.Forms.CheckBox ch_deposito;
        private System.Windows.Forms.TextBox txt_cuenta2;
        private System.Windows.Forms.TextBox txt_monto1;
        private System.Windows.Forms.Label lbl_cheque;
        private System.Windows.Forms.Label lbl_monto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_cheque2;
    }
}