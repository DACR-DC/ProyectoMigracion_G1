
namespace CapaVistaERP.Procesos
{
    partial class frm_factura_cobrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_factura_cobrar));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_detalle = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_diaspagar = new System.Windows.Forms.ComboBox();
            this.txt_facturaestado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_idcliente = new System.Windows.Forms.TextBox();
            this.txt_numPedido = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_coreocl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_apellidocl = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_numfactura = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_numcoti = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_nombrecl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_vend = new System.Windows.Forms.TextBox();
            this.dgvVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_direccioncl = new System.Windows.Forms.TextBox();
            this.dgvFactura = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_telefonocl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.btn_Pagar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.dgv_detalle);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 325);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1071, 251);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle de la factura";
            // 
            // dgv_detalle
            // 
            this.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_detalle.Location = new System.Drawing.Point(135, 44);
            this.dgv_detalle.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_detalle.Name = "dgv_detalle";
            this.dgv_detalle.RowHeadersWidth = 51;
            this.dgv_detalle.Size = new System.Drawing.Size(865, 185);
            this.dgv_detalle.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmb_diaspagar);
            this.groupBox1.Controls.Add(this.txt_facturaestado);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txt_idcliente);
            this.groupBox1.Controls.Add(this.txt_numPedido);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_coreocl);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_apellidocl);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txt_numfactura);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.btn_Buscar);
            this.groupBox1.Controls.Add(this.txt_numcoti);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_nombrecl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_vend);
            this.groupBox1.Controls.Add(this.dgvVencimiento);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_direccioncl);
            this.groupBox1.Controls.Add(this.dgvFactura);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_telefonocl);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1071, 314);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la factura";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(902, 243);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.TabIndex = 42;
            this.label11.Text = "Dias en Pagar";
            // 
            // cmb_diaspagar
            // 
            this.cmb_diaspagar.FormattingEnabled = true;
            this.cmb_diaspagar.Location = new System.Drawing.Point(897, 266);
            this.cmb_diaspagar.Name = "cmb_diaspagar";
            this.cmb_diaspagar.Size = new System.Drawing.Size(124, 29);
            this.cmb_diaspagar.TabIndex = 41;
            this.cmb_diaspagar.SelectedIndexChanged += new System.EventHandler(this.cmb_diaspagar_SelectedIndexChanged);
            // 
            // txt_facturaestado
            // 
            this.txt_facturaestado.Enabled = false;
            this.txt_facturaestado.Location = new System.Drawing.Point(694, 220);
            this.txt_facturaestado.Margin = new System.Windows.Forms.Padding(4);
            this.txt_facturaestado.Name = "txt_facturaestado";
            this.txt_facturaestado.Size = new System.Drawing.Size(169, 28);
            this.txt_facturaestado.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(553, 222);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 20);
            this.label10.TabIndex = 39;
            this.label10.Text = "Estado Factura";
            // 
            // txt_idcliente
            // 
            this.txt_idcliente.Enabled = false;
            this.txt_idcliente.Location = new System.Drawing.Point(8, 134);
            this.txt_idcliente.Margin = new System.Windows.Forms.Padding(4);
            this.txt_idcliente.Name = "txt_idcliente";
            this.txt_idcliente.Size = new System.Drawing.Size(58, 28);
            this.txt_idcliente.TabIndex = 38;
            this.txt_idcliente.Visible = false;
            // 
            // txt_numPedido
            // 
            this.txt_numPedido.Enabled = false;
            this.txt_numPedido.Location = new System.Drawing.Point(286, 86);
            this.txt_numPedido.Margin = new System.Windows.Forms.Padding(4);
            this.txt_numPedido.Name = "txt_numPedido";
            this.txt_numPedido.Size = new System.Drawing.Size(251, 28);
            this.txt_numPedido.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(105, 86);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 20);
            this.label8.TabIndex = 36;
            this.label8.Text = "Numero de Pedido";
            // 
            // txt_coreocl
            // 
            this.txt_coreocl.Location = new System.Drawing.Point(694, 183);
            this.txt_coreocl.Margin = new System.Windows.Forms.Padding(4);
            this.txt_coreocl.Name = "txt_coreocl";
            this.txt_coreocl.Size = new System.Drawing.Size(169, 28);
            this.txt_coreocl.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(553, 183);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 34;
            this.label7.Text = "Correo";
            // 
            // txt_apellidocl
            // 
            this.txt_apellidocl.Location = new System.Drawing.Point(694, 135);
            this.txt_apellidocl.Margin = new System.Windows.Forms.Padding(4);
            this.txt_apellidocl.Name = "txt_apellidocl";
            this.txt_apellidocl.Size = new System.Drawing.Size(169, 28);
            this.txt_apellidocl.TabIndex = 33;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(553, 134);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 20);
            this.label21.TabIndex = 32;
            this.label21.Text = "Apellido";
            // 
            // txt_numfactura
            // 
            this.txt_numfactura.Enabled = false;
            this.txt_numfactura.Location = new System.Drawing.Point(727, 38);
            this.txt_numfactura.Margin = new System.Windows.Forms.Padding(4);
            this.txt_numfactura.Name = "txt_numfactura";
            this.txt_numfactura.Size = new System.Drawing.Size(132, 28);
            this.txt_numfactura.TabIndex = 31;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(553, 38);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(149, 20);
            this.label20.TabIndex = 30;
            this.label20.Text = "Numero de factura";
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_Buscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Buscar.BackgroundImage")));
            this.btn_Buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Buscar.Location = new System.Drawing.Point(490, 40);
            this.btn_Buscar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(33, 28);
            this.btn_Buscar.TabIndex = 21;
            this.btn_Buscar.UseVisualStyleBackColor = false;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // txt_numcoti
            // 
            this.txt_numcoti.Location = new System.Drawing.Point(286, 40);
            this.txt_numcoti.Margin = new System.Windows.Forms.Padding(4);
            this.txt_numcoti.Name = "txt_numcoti";
            this.txt_numcoti.Size = new System.Drawing.Size(237, 28);
            this.txt_numcoti.TabIndex = 9;
            this.txt_numcoti.TextChanged += new System.EventHandler(this.txt_numcoti_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de Cotizacion";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(499, 270);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Fecha de vencimiento";
            // 
            // txt_nombrecl
            // 
            this.txt_nombrecl.Location = new System.Drawing.Point(286, 132);
            this.txt_nombrecl.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nombrecl.Name = "txt_nombrecl";
            this.txt_nombrecl.Size = new System.Drawing.Size(251, 28);
            this.txt_nombrecl.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(553, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vendedor";
            // 
            // txt_vend
            // 
            this.txt_vend.Enabled = false;
            this.txt_vend.Location = new System.Drawing.Point(727, 86);
            this.txt_vend.Margin = new System.Windows.Forms.Padding(4);
            this.txt_vend.Name = "txt_vend";
            this.txt_vend.Size = new System.Drawing.Size(136, 28);
            this.txt_vend.TabIndex = 11;
            // 
            // dgvVencimiento
            // 
            this.dgvVencimiento.Enabled = false;
            this.dgvVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dgvVencimiento.Location = new System.Drawing.Point(694, 266);
            this.dgvVencimiento.Margin = new System.Windows.Forms.Padding(4);
            this.dgvVencimiento.Name = "dgvVencimiento";
            this.dgvVencimiento.Size = new System.Drawing.Size(177, 28);
            this.dgvVencimiento.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(105, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre";
            // 
            // txt_direccioncl
            // 
            this.txt_direccioncl.Location = new System.Drawing.Point(286, 180);
            this.txt_direccioncl.Margin = new System.Windows.Forms.Padding(4);
            this.txt_direccioncl.Name = "txt_direccioncl";
            this.txt_direccioncl.Size = new System.Drawing.Size(251, 28);
            this.txt_direccioncl.TabIndex = 12;
            // 
            // dgvFactura
            // 
            this.dgvFactura.Enabled = false;
            this.dgvFactura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dgvFactura.Location = new System.Drawing.Point(286, 266);
            this.dgvFactura.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFactura.Name = "dgvFactura";
            this.dgvFactura.Size = new System.Drawing.Size(162, 28);
            this.dgvFactura.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(105, 266);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha Factura";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(105, 182);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Direccion";
            // 
            // txt_telefonocl
            // 
            this.txt_telefonocl.Location = new System.Drawing.Point(286, 222);
            this.txt_telefonocl.Margin = new System.Windows.Forms.Padding(4);
            this.txt_telefonocl.Name = "txt_telefonocl";
            this.txt_telefonocl.Size = new System.Drawing.Size(251, 28);
            this.txt_telefonocl.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(105, 226);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Teléfono";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(660, 51);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 20);
            this.label16.TabIndex = 3;
            this.label16.Text = "Total";
            // 
            // txt_total
            // 
            this.txt_total.Enabled = false;
            this.txt_total.Location = new System.Drawing.Point(739, 47);
            this.txt_total.Margin = new System.Windows.Forms.Padding(4);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(132, 28);
            this.txt_total.TabIndex = 26;
            // 
            // btn_Pagar
            // 
            this.btn_Pagar.Location = new System.Drawing.Point(920, 22);
            this.btn_Pagar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Pagar.Name = "btn_Pagar";
            this.btn_Pagar.Size = new System.Drawing.Size(129, 76);
            this.btn_Pagar.TabIndex = 17;
            this.btn_Pagar.Text = "GUARDAR FACTURA";
            this.btn_Pagar.UseVisualStyleBackColor = true;
            this.btn_Pagar.Click += new System.EventHandler(this.btn_Pagar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Pagar);
            this.groupBox3.Controls.Add(this.txt_total);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 593);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1071, 123);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Totales";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 129);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(69, 84);
            this.dataGridView1.TabIndex = 32;
            this.dataGridView1.Visible = false;
            // 
            // frm_factura_cobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 760);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_factura_cobrar";
            this.Text = "frm_factura_cobrar";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_detalle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_coreocl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_apellidocl;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_numfactura;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_numcoti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_nombrecl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_vend;
        private System.Windows.Forms.DateTimePicker dgvVencimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_direccioncl;
        private System.Windows.Forms.DateTimePicker dgvFactura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_telefonocl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_numPedido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_idcliente;
        private System.Windows.Forms.TextBox txt_facturaestado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_diaspagar;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Button btn_Pagar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}