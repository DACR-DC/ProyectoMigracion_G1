using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace CapaControlador_SisB
{
    public class DocumentController
    {
        public static void makeTransactionDocument(string account, string amount)
        {
            //string folderPath = @"D:\9NO_SEMESTRE\INGENIERIA DE SOFTWARE I\ISP12k24\Equipo2\Codigo\Modulos\Sistema_Bancario\Sistema_Bancario\CapaVista_SisB\Comprobantes";
            string folderPath = "./Comprobantes";
            string fileName = "Comprobante.pdf";
            string filePath = Path.Combine(folderPath, fileName);

            // Asegúrate de que el directorio existe
            Directory.CreateDirectory(folderPath);

            // Crear el documento PDF
            Document doc = new Document();

            // Crear el FileStream con la ruta específica
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            // Abrir el documento para agregar contenido
            doc.Open();

            // Agregar contenido al documento
            Paragraph paragraph = new Paragraph("Comprobante de Pago")
            {
                Alignment = Element.ALIGN_CENTER
            };
            // Agregar contenido al documento
            doc.Add(paragraph);
            doc.Add(new Paragraph("Deposito a Cuenta: "));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph(account));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("Monto: "));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("Q " + amount.ToString()));


            // Cerrar el documento
            doc.Close();

            Console.WriteLine("PDF creado en: " + filePath);

            OpenPDF(filePath);

        }

        private static void OpenPDF(string filePath)
        {
            try
            {
                // Verificar si el archivo existe antes de intentar abrirlo
                if (File.Exists(filePath))
                {
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                }
                else
                {
                    Console.WriteLine("Error al abrir el archivvo");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
