using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seguridad_Controlador;

namespace Vista_PrototipoMenu
{
    public partial class MenuPrototipo : Form
    {

        Controlador cn = new Controlador();
        public int privileges = 0;
        public Form currentForm;

        //Método que guarda en un arreglo de tipo botón los botones que se tienen en el formulario. Se les da permiso a los diferentes botones de acuerdo a la función que realice este
        public MenuPrototipo()
        {
            InitializeComponent();
            //Control para habilitar opciones del menu
            Button[] apps = { button2 };
            //Llamada metodo de libreria Controlador del modulo de Seguridad
            cn.deshabilitarApps(apps);
            //Llamada metodo de libreria Controlador del modulo de Seguridad
            cn.getAccesoApp(1002, apps[0]);
            CapaControlador_SisB.Controlador ctrl = new CapaControlador_SisB.Controlador();
            int accId = Convert.ToInt32(Seguridad_Controlador.Controlador.GetHash(Seguridad_Controlador.Controlador.idUser));
            this.privileges = ctrl.getUserProfile(accId);
            if (this.privileges == 1) this.enableByAdmin();
            if (this.privileges == 3) this.enableByUser();
        }


        public void openNewForm(Form form)
        {
            if (this.currentForm != null) this.currentForm.Close();
            this.currentForm = form;
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
            hideSubMenu();
        }

        //DANNY PEREZ
        public void enableByUser()
        {
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button8.Enabled = true;

            button5.Enabled = false;

            man_boleta.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;

            btnSeguridad.Enabled = false;
        }
        //DANNY PEREZ
        public void enableByAdmin()
        {
            button5.Enabled = true;

            man_boleta.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;

            btnSeguridad.Enabled = true;

            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button8.Enabled = false;

        }

        //Validaciones que si son visibles los panales los oculta
        private void hideSubMenu()
        {

            if (panelTranportes.Visible == true)
                panelTranportes.Visible = false;
            if (PanelAuditoria.Visible == true)
                PanelAuditoria.Visible = false;
            if (panelseguridad.Visible == true)
                panelseguridad.Visible = false;
            if (panelayuda.Visible == true)
                panelayuda.Visible = false;
        }
        //Método que valida si el submenu no es visible oculta el submenu
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        //Método que muestra el panel indicado
        private void btnmanteniminetos_Click(object sender, EventArgs e)
        {
            showSubMenu(panelTranportes);
        }
        //Método que muestra el panel indicado
        private void btnProcesos_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelAuditoria);
        }
        //Método que muestra el panel indicado
        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            showSubMenu(panelayuda);
        }
        //Método que muestra el panel indicado
        private void btnReportes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelseguridad);
        }
        //Método que muestra el formulario indicado
        //Método que muestra el formulario indicado
        private void btnaplicaciones_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.frmCliente form = new CapaVista_SisB.frmCliente();
            this.openNewForm(form);
        }
        //Método que muestra el formulario indicado

        private void btninicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Método que oculta el formulario
        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Método que muestra el formulario indicado
        private void btnayuda_Click(object sender, EventArgs e)
        {
            //Help.ShowHelp(this, "Ayudas_Base/AyudaSistemaBancario.chm", "MDI_SistemaBancario.html");
            CapaVista_SisB.Helper.Open(this.currentForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.frmHistorial form = new CapaVista_SisB.frmHistorial();
            this.openNewForm(form);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.PagoServicios form = new CapaVista_SisB.PagoServicios();
            this.openNewForm(form);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.frmDeposito form = new CapaVista_SisB.frmDeposito();
            this.openNewForm(form);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //CapaVista_SisB.frmEstado form = new CapaVista_SisB.frmEstado();
            //form.MdiParent = this;
            //form.Show();
            //();
        }

        private void man_boleta_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.frmCheques form = new CapaVista_SisB.frmCheques();
            this.openNewForm(form);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.MovimientosBancarios form = new CapaVista_SisB.MovimientosBancarios();
            this.openNewForm(form);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            CapaVista_SisB.frmTransferencia form = new CapaVista_SisB.frmTransferencia();
            this.openNewForm(form);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.frmRetiro form = new CapaVista_SisB.frmRetiro();
            this.openNewForm(form);
        }

        private void btn_man_cuenta_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.Mantenimiento_Cuenta form = new CapaVista_SisB.Mantenimiento_Cuenta();
            this.openNewForm(form);
        }

        private void btn_mant_tipo_cuenta_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.frmTipoCuenta form = new CapaVista_SisB.frmTipoCuenta();
            this.openNewForm(form);
        }

        private void mant_moneda_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.frmMoneda form = new CapaVista_SisB.frmMoneda();
            this.openNewForm(form);
        }

        private void btn_mant_cliente_Click_2(object sender, EventArgs e)
        {
            CapaVista_SisB.frmCliente form = new CapaVista_SisB.frmCliente();
            this.openNewForm(form);
        }

        private void btn_mant_estados_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.Mantenimiento_Estado form = new CapaVista_SisB.Mantenimiento_Estado();
            this.openNewForm(form);
        }

        private void btn_mant_tarjeta_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.Mantenimiento_Tarjeta form = new CapaVista_SisB.Mantenimiento_Tarjeta();
            this.openNewForm(form);
        }

        private void btn_mant_tipo_tarjeta_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.Mantenimiento_Tipo_Tarjeta form = new CapaVista_SisB.Mantenimiento_Tipo_Tarjeta();
            this.openNewForm(form);
        }

        private void btn_mant_transaccion_Click_2(object sender, EventArgs e)
        {
            CapaVista_SisB.MantenimientoTransaccion form = new CapaVista_SisB.MantenimientoTransaccion();
            this.openNewForm(form);
        }

        private void btn_mant_tipo_trans_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.Mantenimiento_Tipo_Transaccion form = new CapaVista_SisB.Mantenimiento_Tipo_Transaccion();
            this.openNewForm(form);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            CapaVista_SisB.Mantenimientos.FrmCuentaAmiga form = new CapaVista_SisB.Mantenimientos.FrmCuentaAmiga();
            this.openNewForm(form);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            CapaVista_SisB.Mantenimientos.FrmCuentaAmiga form = new CapaVista_SisB.Mantenimientos.FrmCuentaAmiga();
            this.openNewForm(form);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.frmEstadoCuenta form = new CapaVista_SisB.frmEstadoCuenta();
            this.openNewForm(form);
        }

        private void btn_menu_tarjetas_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.Mantenimientos.frmTarjetas form = new CapaVista_SisB.Mantenimientos.frmTarjetas();
            this.openNewForm(form);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CapaVista_SisB.Mantenimientos.frmTarjetas form = new CapaVista_SisB.Mantenimientos.frmTarjetas();
            this.openNewForm(form);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            CapaVista_SisB.frmNotas form = new CapaVista_SisB.frmNotas();
            this.openNewForm(form);
        }
    }
}
