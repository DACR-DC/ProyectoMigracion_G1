using CapaVistaERP.Mantenimientos;
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
using CapaVistaERP.Procesos;

namespace CapaVistaERP
{
    public partial class MDIGeneral : Form
    {
        Controlador cn = new Controlador();
        //VARIABLES ANDREA CORADO
        private string idmovpro = "";
        private string namemovpro = "";
        private string nitmovpro = "";

        public MDIGeneral()
        {
            InitializeComponent();
            //Control para habilitar opciones del menu
            // Button[] apps = { btn_precios, btn_generarBoleta };
            //Llamada metodo de libreria Controlador del modulo de Seguridad
            //cns.deshabilitarApps(apps);
            //Llamada metodo de libreria Controlador del modulo de Seguridad
            //cns.getAccesoApp(2001, apps[1]);
            //cns.getAccesoApp(2002, apps[2]);
            //cns.getAccesoApp(2003, apps[3]);
            //cns.getAccesoApp(2004, apps[4]);
            //cns.getAccesoApp(2005, apps[5]);
            escondersubmenus();
        }

        private void escondersubmenus()
        {
            submenumantcompras.Visible = false;
            submenumantventas.Visible = false;
            submenumantlogistica.Visible = false;
            submenumantbancos.Visible = false;
            panelMantenimientos.Visible = false;
            submenuprocesoscompra.Visible = false;
            submenuprocesosventas.Visible = false;
            submenuprocesoslogistica.Visible = false;
            submenuprocesosbancos.Visible = false;
            PanelProcesos.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelMantenimientos.Visible == true)
                panelMantenimientos.Visible = false;
            if (PanelProcesos.Visible == true)
                PanelProcesos.Visible = false;
            if (panelReporte.Visible == true)
                panelReporte.Visible = false;
            if (panelSeguridad.Visible == true)
                panelSeguridad.Visible = false;

        }
        //Método que valida si el submenu no es visible oculta el submenu
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                //hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void showSubMenuMantenimientos(Panel subMenuMant)
        {
            if (subMenuMant.Visible == false)
            {
                hideSubMenu();
                subMenuMant.Visible = true;
            }
            else
                subMenuMant.Visible = false;
        }

        private void Abrir(object abrirform)
        {
            if (this.panelMDI.Controls.Count > 0)
                this.panelMDI.Controls.RemoveAt(0);

            Form fh = abrirform as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.None;
            this.panelMDI.Controls.Add(fh);
            this.panelMDI.Tag = fh;
            // fh.StartPosition = FormStartPosition.CenterParent; 
            //carlos enrique guzman cabrera (hace que las formas esten centradas)
            // Calcular la posición para centrar la forma en el panel
           /* int x = (this.panelMDI.Width - fh.Width) / 2;
            int y = (this.panelMDI.Height - fh.Height) / 2;*/
            // Establecer la posición de la forma
           /* fh.Location = new Point(x, y);*/
            fh.Show();
        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmanteniminetos_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMantenimientos);
        }

        private void btnProcesos_Click(object sender, EventArgs e)
        {
            showSubMenu(PanelProcesos);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelReporte);
        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSeguridad);
        }

        private void btnayuda_Click(object sender, EventArgs e)
        {
            //Help.ShowHelp(this, "umg.chm");
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_mantenimiento1_Click(object sender, EventArgs e)
        {
            showSubMenu(submenumantcompras);
        }

        private void btn_proceso1_Click(object sender, EventArgs e)
        {
            showSubMenu(submenuprocesoscompra);
        }

        private void panel1_Click(object sender, PaintEventArgs e)
        {
            showSubMenu(PanelProcesos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frm_Mant_Proveedor());
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frm_Mant_TransProveedores());
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showSubMenu(submenumantventas);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showSubMenu(submenumantlogistica);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showSubMenu(submenumantbancos);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            showSubMenu(submenuprocesosventas);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            showSubMenu(submenuprocesoslogistica);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            showSubMenu(submenuprocesosbancos);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frm_mant_clientes());
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frm_mant_vendedores());
            hideSubMenu();
        }


        private void button26_Click(object sender, EventArgs e)
        {
            OrdendeCompraEli ordendeCompraNav = new OrdendeCompraEli(); // Crear una instancia de OrdendeCompraNav
            OrdendeCompraModi ordendeCompraModi = new OrdendeCompraModi();
            Abrir(new Procesos.OrdenesdeCompraMaestro(ordendeCompraNav, ordendeCompraModi));
            hideSubMenu();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            ComprasEli comprasEli = new ComprasEli();
            ComprasModi comprasModi = new ComprasModi();
            Abrir(new Procesos.ComprasMaestro(comprasEli, comprasModi));
            hideSubMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FacturaporPagarEli facturaporPagarEli = new FacturaporPagarEli();
            FacturaporPagarModi facturaporPagarModi = new FacturaporPagarModi();
            Abrir(new Procesos.FacturaporPagarMaestro(facturaporPagarEli, facturaporPagarModi));
            hideSubMenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Abrir(new Procesos.CajaProveedor(idmovpro, namemovpro, nitmovpro));
            hideSubMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frmMantenimientoMovimientoConcepto());
            hideSubMenu();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Abrir(new Procesos.Dispo_Diaria());
            hideSubMenu();
        }

        private void button18_Click(object sender, EventArgs e)
        {
          Abrir(new Procesos.Cotizacion());
            hideSubMenu();
            cn.setBtitacora("8014", "Pro. Bitacora de autorizacion ordenes de compra");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Abrir(new Procesos.frm_pedidos());
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frmMantenimientoBanco());
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frm_mant_tipo_de_cambio());
            hideSubMenu();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Abrir(new Procesos.frmBitacoraAutorizacionOrdenesCompra());
            hideSubMenu();
            cn.setBtitacora("8020", "Pro. Bitacora de autorizacion ordenes de compra");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Abrir(new Procesos.frm_factura_cobrar());
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frmMovimientoInventario());
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frmProductos());
            hideSubMenu();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Abrir(new Procesos.TrasladoDeProductoMaestro());
            hideSubMenu();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frmMantenimientoCuentaBancaria());
            hideSubMenu();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Abrir(new Procesos.frmBitacoraMovimientoDeBanco());
            hideSubMenu();
            cn.setBtitacora("8031", "Pro. Bitacora de movimiento de bancos");
        }


        private void btn_buscarCoti_Click(object sender, EventArgs e)
        {
            // Abrir(new Procesos.GestionCotizaciones());
            Abrir(new Procesos.BuscarCotizacion());
            hideSubMenu();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frmMarca());
            hideSubMenu();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frmLinea());
            hideSubMenu();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Abrir(new Mantenimientos.frmSucursales());
            hideSubMenu();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Abrir(new Procesos.TipodecambioApi());
            hideSubMenu();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Abrir(new Procesos.PagoFacturaxCobrar());
            hideSubMenu();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Abrir(new Procesos.Registro_pagos());
            hideSubMenu();
        }
    }
}
