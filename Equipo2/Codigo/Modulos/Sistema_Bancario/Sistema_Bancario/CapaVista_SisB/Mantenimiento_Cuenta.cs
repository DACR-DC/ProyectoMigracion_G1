using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_SisB;
namespace CapaVista_SisB
{
    public partial class Mantenimiento_Cuenta : Form
    {
        Controlador cn = new Controlador();
        CapaControlador_SisB.AccountControler ctrl;
        public Mantenimiento_Cuenta()
        {
            InitializeComponent();
            navegador1.config("tbl_cuenta", this, "8003");
            DatosdeCmb();
            DatosdeCmb1();
            cargarDatos();
            cargarDatos1();

        }
        public void DatosdeCmb()
        {
            if (cmb_tipo_cuenta.SelectedIndex == 0) {

                textBox3.Text = "1";
            
            }else if(cmb_tipo_cuenta.SelectedIndex == 1)
            {

                textBox3.Text = "2";

            }

        }

        public void llenarse(string tabla, string campo1, string campo2)
        {

            string tbl = tabla;
            string cmp1 = campo1;
            string cmp2 = campo2;
            


            cmb_auto.ValueMember = "cli_id";
            cmb_auto.DisplayMember = "cli_nombre";
            string[] items = cn.items1(tabla, campo1, campo2);
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i] != "")
                    {
                        cmb_auto.Items.Add(items[i]);
                    }
                }

            }

            var dt2 = cn.enviar1(tabla, campo1, campo2);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {

                coleccion.Add(Convert.ToString(row[campo1]) + " - " + Convert.ToString(row[campo2]));
                coleccion.Add(Convert.ToString(row[campo2]) + " - " + Convert.ToString(row[campo1]));


            }

            cmb_auto.AutoCompleteCustomSource = coleccion;
            cmb_auto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb_auto.AutoCompleteSource = AutoCompleteSource.CustomSource;


        }
        public void llenarse1(string tabla, string campo1, string campo2)
        {

            string tbl = tabla;
            string cmp1 = campo1;
            string cmp2 = campo2;



            cmb_auto1.ValueMember = "pk_id_usuario";
            cmb_auto1.DisplayMember = "nombre_usuario";
            string[] items = cn.items2(tabla, campo1, campo2);
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i] != "")
                    {
                        cmb_auto1.Items.Add(items[i]);
                    }
                }

            }

            var dt2 = cn.enviar2(tabla, campo1, campo2);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {

                coleccion.Add(Convert.ToString(row[campo1]) + " - " + Convert.ToString(row[campo2]));
                coleccion.Add(Convert.ToString(row[campo2]) + " - " + Convert.ToString(row[campo1]));


            }

            cmb_auto1.AutoCompleteCustomSource = coleccion;
            cmb_auto1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmb_auto1.AutoCompleteSource = AutoCompleteSource.CustomSource;


        }



        public void DatosdeCmb1()
        {
            if (cmb_tipo_moneda.SelectedIndex == 0)
            {

                textBox2.Text = "1";

            }
            else if (cmb_tipo_moneda.SelectedIndex == 1)
            {

                textBox2.Text = "2";

            }
            else if (cmb_tipo_moneda.SelectedIndex == 2)
            {

                textBox2.Text = "3";

            }

        }


        private void cmb_tipo_cuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatosdeCmb();
        }

        private void cmb_moneda_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_tipo_moneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatosdeCmb1();
        }

        void cargarDatos()
        {
            llenarse("tbl_cliente", "cli_id", "cli_nombre");
        }

        void cargarDatos1()
        {
            llenarse1("tbl_usuarios", "pk_id_usuario", "nombre_usuario");
        }

        private void cmb_auto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cmb_auto.SelectedItem.ToString();
            string[] parts = selectedItem.Split('-');
            if (parts.Length > 1)
            {
                // Asignar el primer parte (el número) al TextBox
                textBox1.Text = parts[0];
            }
        }

        private void cmb_auto1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = cmb_auto1.SelectedItem.ToString();
            string[] parts = selectedItem.Split('-');
            if (parts.Length > 1)
            {
                // Asignar el primer parte (el número) al TextBox
                textBox6.Text = parts[0];
            }
        }
    }
}
