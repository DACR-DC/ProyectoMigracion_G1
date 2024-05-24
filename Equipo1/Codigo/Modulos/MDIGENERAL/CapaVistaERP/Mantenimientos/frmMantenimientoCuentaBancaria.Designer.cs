
namespace CapaVistaERP.Mantenimientos
{
    partial class frmMantenimientoCuentaBancaria
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
            this.txt_moneda = new System.Windows.Forms.TextBox();
            this.cb_moneda = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_estado = new System.Windows.Forms.TextBox();
            this.cb_estado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_saldo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_numeroCuenta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_tipo = new System.Windows.Forms.ComboBox();
            this.txt_banco = new System.Windows.Forms.TextBox();
            this.txt_tipoCuenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cb_banco = new System.Windows.Forms.ComboBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.navegador1 = new CapaVista.Navegador();
            this.txt_reserva = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_moneda
            // 
            this.txt_moneda.Enabled = false;
            this.txt_moneda.Location = new System.Drawing.Point(942, 410);
            this.txt_moneda.Name = "txt_moneda";
            this.txt_moneda.Size = new System.Drawing.Size(69, 22);
            this.txt_moneda.TabIndex = 43;
            this.txt_moneda.Tag = "tipo_moneda";
            this.txt_moneda.Visible = false;
            // 
            // cb_moneda
            // 
            this.cb_moneda.FormattingEnabled = true;
            this.cb_moneda.Items.AddRange(new object[] {
            "[seleccionar]",
            "Dollar",
            "Quetzal",
            "Euro",
            "Pesos mexicanos"});
            this.cb_moneda.Location = new System.Drawing.Point(720, 305);
            this.cb_moneda.Name = "cb_moneda";
            this.cb_moneda.Size = new System.Drawing.Size(196, 24);
            this.cb_moneda.TabIndex = 42;
            this.cb_moneda.SelectedIndexChanged += new System.EventHandler(this.cb_moneda_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(564, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 17);
            this.label8.TabIndex = 41;
            this.label8.Text = "tipo de moneda";
            // 
            // txt_estado
            // 
            this.txt_estado.Enabled = false;
            this.txt_estado.Location = new System.Drawing.Point(942, 449);
            this.txt_estado.Name = "txt_estado";
            this.txt_estado.Size = new System.Drawing.Size(69, 22);
            this.txt_estado.TabIndex = 40;
            this.txt_estado.Tag = "estado_cuenta";
            this.txt_estado.Visible = false;
            // 
            // cb_estado
            // 
            this.cb_estado.FormattingEnabled = true;
            this.cb_estado.Items.AddRange(new object[] {
            "[seleccionar]",
            "Activo",
            "Suspendido",
            "Normal"});
            this.cb_estado.Location = new System.Drawing.Point(720, 266);
            this.cb_estado.Name = "cb_estado";
            this.cb_estado.Size = new System.Drawing.Size(196, 24);
            this.cb_estado.TabIndex = 39;
            this.cb_estado.SelectedIndexChanged += new System.EventHandler(this.cb_estado_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(564, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 17);
            this.label7.TabIndex = 38;
            this.label7.Text = "estado de la cuenta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(564, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 17);
            this.label6.TabIndex = 37;
            this.label6.Text = "Fecha de apertura";
            // 
            // txt_saldo
            // 
            this.txt_saldo.Location = new System.Drawing.Point(720, 180);
            this.txt_saldo.Name = "txt_saldo";
            this.txt_saldo.Size = new System.Drawing.Size(196, 22);
            this.txt_saldo.TabIndex = 36;
            this.txt_saldo.Tag = "saldoDisponible";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(564, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 35;
            this.label5.Text = "Saldo de cuenta";
            // 
            // txt_numeroCuenta
            // 
            this.txt_numeroCuenta.Location = new System.Drawing.Point(308, 305);
            this.txt_numeroCuenta.Name = "txt_numeroCuenta";
            this.txt_numeroCuenta.Size = new System.Drawing.Size(196, 22);
            this.txt_numeroCuenta.TabIndex = 34;
            this.txt_numeroCuenta.Tag = "numero_cuenta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "No. cuenta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Tipo de cuenta";
            // 
            // cb_tipo
            // 
            this.cb_tipo.AutoCompleteCustomSource.AddRange(new string[] {
            "[seleccionar]",
            "Monetaria",
            "Ahorro",
            "Normal"});
            this.cb_tipo.FormattingEnabled = true;
            this.cb_tipo.Items.AddRange(new object[] {
            "[seleccionar]",
            "Monetaria",
            "Ahorro",
            "Normal"});
            this.cb_tipo.Location = new System.Drawing.Point(308, 263);
            this.cb_tipo.Name = "cb_tipo";
            this.cb_tipo.Size = new System.Drawing.Size(196, 24);
            this.cb_tipo.TabIndex = 31;
            this.cb_tipo.SelectedIndexChanged += new System.EventHandler(this.cb_tipo_SelectedIndexChanged);
            // 
            // txt_banco
            // 
            this.txt_banco.Enabled = false;
            this.txt_banco.Location = new System.Drawing.Point(942, 540);
            this.txt_banco.Name = "txt_banco";
            this.txt_banco.Size = new System.Drawing.Size(69, 22);
            this.txt_banco.TabIndex = 30;
            this.txt_banco.Tag = "id_bancoAsociado";
            this.txt_banco.Visible = false;
            // 
            // txt_tipoCuenta
            // 
            this.txt_tipoCuenta.Enabled = false;
            this.txt_tipoCuenta.Location = new System.Drawing.Point(942, 492);
            this.txt_tipoCuenta.Name = "txt_tipoCuenta";
            this.txt_tipoCuenta.Size = new System.Drawing.Size(69, 22);
            this.txt_tipoCuenta.TabIndex = 29;
            this.txt_tipoCuenta.Tag = "tipo_cuenta";
            this.txt_tipoCuenta.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Seleccione el banco";
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Location = new System.Drawing.Point(720, 224);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(196, 22);
            this.dtp_fecha.TabIndex = 27;
            this.dtp_fecha.Tag = "fecha_apertura";
            this.dtp_fecha.Value = new System.DateTime(2024, 4, 11, 0, 0, 0, 0);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(155, 433);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(761, 199);
            this.dataGridView1.TabIndex = 26;
            this.dataGridView1.Tag = "tbl_cuentabancaria";
            // 
            // cb_banco
            // 
            this.cb_banco.FormattingEnabled = true;
            this.cb_banco.Location = new System.Drawing.Point(308, 222);
            this.cb_banco.Name = "cb_banco";
            this.cb_banco.Size = new System.Drawing.Size(196, 24);
            this.cb_banco.TabIndex = 25;
            this.cb_banco.SelectedIndexChanged += new System.EventHandler(this.cb_banco_SelectedIndexChanged);
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(308, 180);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(196, 22);
            this.txt_nombre.TabIndex = 24;
            this.txt_nombre.Tag = "nombre_empresa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nombre de la cuenta";
            // 
            // navegador1
            // 
            this.navegador1.Location = new System.Drawing.Point(61, 34);
            this.navegador1.Margin = new System.Windows.Forms.Padding(4);
            this.navegador1.Name = "navegador1";
            this.navegador1.Size = new System.Drawing.Size(1001, 96);
            this.navegador1.TabIndex = 44;
            // 
            // txt_reserva
            // 
            this.txt_reserva.Location = new System.Drawing.Point(308, 353);
            this.txt_reserva.Name = "txt_reserva";
            this.txt_reserva.Size = new System.Drawing.Size(196, 22);
            this.txt_reserva.TabIndex = 46;
            this.txt_reserva.Tag = "reserva";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(152, 353);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 45;
            this.label9.Text = "Reserva";
            // 
            // frmMantenimientoCuentaBancaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 664);
            this.Controls.Add(this.txt_reserva);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.navegador1);
            this.Controls.Add(this.txt_moneda);
            this.Controls.Add(this.cb_moneda);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_estado);
            this.Controls.Add(this.cb_estado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_saldo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_numeroCuenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_tipo);
            this.Controls.Add(this.txt_banco);
            this.Controls.Add(this.txt_tipoCuenta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_fecha);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cb_banco);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label1);
            this.Name = "frmMantenimientoCuentaBancaria";
            this.Text = "8031: frmMantenimientoCuentaBancaria";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_moneda;
        private System.Windows.Forms.ComboBox cb_moneda;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_estado;
        private System.Windows.Forms.ComboBox cb_estado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_saldo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_numeroCuenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_tipo;
        private System.Windows.Forms.TextBox txt_banco;
        private System.Windows.Forms.TextBox txt_tipoCuenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cb_banco;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label1;
        private CapaVista.Navegador navegador1;
        private System.Windows.Forms.TextBox txt_reserva;
        private System.Windows.Forms.Label label9;
    }
}