using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CapaControlador;
using CrystalDecisions.CrystalReports.Engine;


namespace Reporteador
/* AUTORES DE CODIGO:
LUIS ALBERTO FRANCO MORAN 0901-20-23979
OTTO ADRIAN LOPEZ VENTURA 0901-20-1069
JULIA RASHELL LOPEZ CIFUENTES 0901-20-5910

Las siguientes personas se encargaron de hacer el diseño (Desde las bases, estandarizarlo hasta terminarlo):
MARIA JIMENA TOBIAS VASQUEZ 0901-20-13641
JULIA RASHELL LOPEZ CIFUENTES 0901-20-5910*/


{

    public partial class Reportes : Form
    {
        private List<string> ruta = new List<string>(); // Lista para almacenar las rutas JULIA RASHELL LOPEZ CIFUENTES 0901-20-5910
        Controlador cn = new Controlador();
        public string tabla;
        public string rep = "tbl_reportes";
        public Reportes()
        {
            tabla = "";
            InitializeComponent();
            actualizardatagriew();
            dgv_reportes.Columns[0].HeaderText = "ID";
            dgv_reportes.Columns[1].HeaderText = "Correlativo";
            dgv_reportes.Columns[2].HeaderText = "Nombre";
            dgv_reportes.Columns[3].HeaderText = "Estado";
            dgv_reportes.Columns[4].HeaderText = "Ruta de archivo";
            dgv_reportes.Columns[5].HeaderText = "Fecha de ingreso";
            dgv_reportes.Columns[6].HeaderText = "Fecha de Modificacion";
        }



        public void actualizardatagriew()
        {

            DataTable dt = cn.llenarTbl(rep);
            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Sin datos");
            }
            dgv_reportes.DataSource = dt;

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_ruta_TextChanged(object sender, EventArgs e)
        {

        }



        private void btn_ruta_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                txt_ruta.Enabled = false;
                openFileDialog.InitialDirectory = "C:\\"; // Directorio inicial JULIA RASHELL LOPEZ CIFUENTES 0901-20-5910
                openFileDialog.Filter = "Crystal Reports (*.rpt)|*.rpt|Todos los archivos (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK) //OTTO ADRIAN LOPEZ VENTURA 0901-20-1069 
                {
                    // Preguntar al usuario si desea agregar este archivo
                    result = MessageBox.Show("¿Desea agregar este archivo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Obtener la ruta del archivo seleccionado y mostrarla en el TextBox
                        txt_ruta.Text = openFileDialog.FileName; //LUIS ALBERTO FRANCO MORAN 0901-20-23979
                        correlativoTextBox.Enabled = true;
                    }
                    else
                    {
                        // Limpiar los espacios si el usuario no desea agregar el archivo
                        txt_ruta.Enabled = true;
                        txt_ruta.Clear();
                    }
                }
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            string rutaArchivo = txt_ruta.Text.Trim();

            if (!string.IsNullOrEmpty(rutaArchivo) && File.Exists(rutaArchivo))
            {
                // Preguntar al usuario si desea guardar el archivo
                DialogResult result = MessageBox.Show("¿Desea guardar el archivo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //OTTO ADRIAN LOPEZ VENTURA 0901-20-1069 

                if (result == DialogResult.Yes) //OTTO ADRIAN LOPEZ VENTURA 0901-20-1069 
                {
                    //LUIS ALBERTO FRANCO MORAN 0901-20-23979
                    // Llamar al Controlador para insertar el reporte en la base de datos
                    cn.InsertarReporte(correlativoTextBox.Text, Path.GetFileName(rutaArchivo), estadoTextBox.Text, rutaArchivo);

                    // Actualizar el DataGridView con los datos actualizados
                    actualizardatagriew();
                    txt_ruta.Enabled = true;

                    // Limpiar los TextBox
                    txt_ruta.Clear();
                    correlativoTextBox.Clear();
                    estadoTextBox.Clear();
                    correlativoTextBox.Enabled = false;


                    // Mostrar un mensaje de éxito
                    MessageBox.Show("Reporte agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);//OTTO ADRIAN LOPEZ VENTURA 0901-20-1069 
                }
                else
                {
                    //LUIS ALBERTO FRANCO MORAN 0901-20-23979
                    // Limpiar los TextBox si el usuario elige "No"
                    txt_ruta.Clear();
                    correlativoTextBox.Clear();
                    estadoTextBox.Clear();

                    // Mostrar un mensaje informativo
                    MessageBox.Show("No se guardó el archivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);//OTTO ADRIAN LOPEZ VENTURA 0901-20-1069 
                }
            }
            else
            {
                MessageBox.Show("La ruta no es válida o no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //OTTO ADRIAN LOPEZ VENTURA 0901 - 20 - 1069

                // Limpiar los TextBox
                correlativoTextBox.Clear();
                txt_ruta.Clear();
                estadoTextBox.Clear();
            }
        }

        //LUIS ALBERTO FRANCO MORAN 0901-20-23979
        private void btn_ver_Click(object sender, EventArgs e)
        {
            if (dgv_reportes.SelectedRows.Count > 0)
            {
                // Obtener la ruta del archivo desde la fila seleccionada (la columna "nbr_archivo" debe contener la ruta)
                string rutaArchivo = dgv_reportes.SelectedRows[0].Cells["rep_archivo"].Value.ToString();

                // Verificar si el archivo existe en la ruta almacenada en la base de datos
                if (File.Exists(rutaArchivo))
                {
                    // Crear una instancia del formulario "Vista de Reportes"
                    Vista_de_Reportes vistaDeReportesForm = new Vista_de_Reportes();

                    // Pasar la ruta del informe al formulario "Vista de Reportes"
                    vistaDeReportesForm.RutaInformeSeleccionado = rutaArchivo;

                    // Mostrar el formulario "Vista de Reportes"
                    vistaDeReportesForm.Show();
                }
                else
                {
                    MessageBox.Show("El archivo no existe en la ubicación especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una ruta de archivo para ver.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            correlativoTextBox.Enabled = false;
        }


        private void dgv_reportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //OTTO ADRIAN LOPEZ VENTURA 0901-20-1069
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_reportes.SelectedRows.Count > 0)
            {
                // Obtener el ID del reporte seleccionado ( la columna de ID se llama "pk_id_reporte")
                int idReporte = Convert.ToInt32(dgv_reportes.SelectedRows[0].Cells["pk_id_reporte"].Value);

                // Preguntar al usuario si desea eliminar este reporte
                DialogResult result = MessageBox.Show("¿Desea eliminar este reporte?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Llamar al Controlador para eliminar el reporte de la base de datos
                    cn.EliminarReporte(idReporte);

                    // Actualizar el DataGridView con los datos actualizados
                    actualizardatagriew();

                    // Mostrar un mensaje de confirmación
                    MessageBox.Show("Reporte eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    estadoTextBox.Clear();
                    txt_ruta.Clear();
                }
                // No hacer nada si el usuario elige "No"
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un reporte para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                estadoTextBox.Clear();
                txt_ruta.Clear();
            }
        }

        //LUIS ALBERTO FRANCO MORAN 0901-20-23979
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (dgv_reportes.SelectedRows.Count > 0)
            {
                // Obtener el índice de la fila seleccionada
                int rowIndex = dgv_reportes.SelectedRows[0].Index;

                // Obtener el ID del reporte seleccionado (la columna de ID se llama "pk_id_reporte")
                int idReporte = Convert.ToInt32(dgv_reportes.Rows[rowIndex].Cells["pk_id_reporte"].Value);

                // Obtener los nuevos valores de nombre y estado desde los TextBox
                string nuevoNombre = txt_ruta.Text.Trim();
                string nuevoEstado = estadoTextBox.Text.Trim();

                // Preguntar al usuario si desea modificar este reporte
                DialogResult result = MessageBox.Show("¿Desea modificar este reporte?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Actualizar los valores en el DataGridView directamente
                    dgv_reportes.Rows[rowIndex].Cells["rep_nombre"].Value = nuevoNombre;
                    dgv_reportes.Rows[rowIndex].Cells["fk_estado"].Value = nuevoEstado;

                    // Actualizar la base de datos con los nuevos valores
                    cn.ActualizarReporte(idReporte, nuevoNombre, nuevoEstado);

                    // Mostrar un mensaje de confirmación
                    MessageBox.Show("Reporte modificado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar los TextBox después de la modificación
                    txt_ruta.Clear();
                    estadoTextBox.Clear();
                }
                // No hacer nada si el usuario elige "No"
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un reporte para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Limpiar los TextBox
                txt_ruta.Clear();
                estadoTextBox.Clear();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
        }
    }


}

