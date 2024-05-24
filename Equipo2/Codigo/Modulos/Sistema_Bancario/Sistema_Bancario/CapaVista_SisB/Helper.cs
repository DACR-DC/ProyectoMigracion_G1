using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CapaVista_SisB
{
    public class Helper
    {

        public static void Open(Form parent)
        {
            if (parent.Tag == null)
            {
                Console.WriteLine("Error  abriendo ayudas");
                return;
            }

            string file = parent.Tag.ToString();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string helpFilePath = Path.Combine(baseDirectory,"Ayudas" ,"AyudaSistemaBancario.chm");
            Console.WriteLine(helpFilePath);
            Help.ShowHelp(parent, helpFilePath,Path.Combine(baseDirectory,"Ayudas",helpFilePath+".html"));
        }
    }
}
