using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_SisB.Sentences;
using CapaModelo_SisB.Templates;
using CapaModelo_SisB;

namespace CapaControlador_SisB
{
    public class CardController
    {

        public static bool createCreditCard(string number, string cvv, string date, string dpi, double balance)
        {
            int clientId = ClienteSentence.getClientIdByDPI(dpi);
            if (clientId == -1) return false;
            CardSentence.createCreditCard(number, cvv, date, clientId, balance);
            return true;
        }
        public static bool createDebitCard(string number, string cvv, string date, string accountNumber)
        {
            Sentencias sn = new Sentencias();
            Cuenta account = sn.getAccountByNumber(accountNumber);
            if (account == null) return false;
            CardSentence.createDebitCard(number, cvv, date, account.id);
            return true;
        }
    }
}
