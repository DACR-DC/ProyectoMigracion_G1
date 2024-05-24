using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_SisB.Templates;
using CapaModelo_SisB.Sentences;

namespace CapaControlador_SisB
{
    public class InvoiceController
    {



        public static void debitarFactura(Innvoice fact, double monto)
        {
            InnvoiceSentences.modifyInnvoice(fact.Id, Convert.ToDouble(fact.FacMonto) + monto, 0);
        }

        public static void creditarFactura(Innvoice fact, double monto)
        {
            int estado = Convert.ToDouble(fact.FacMonto) - monto >= Convert.ToDouble(fact.FacMonto) ? 1 : 0;
            InnvoiceSentences.modifyInnvoice(fact.Id, Convert.ToDouble(fact.FacMonto) - monto, estado);
        }
    }
}
