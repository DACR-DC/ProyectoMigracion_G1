using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelo_SisB;
using CapaModelo_SisB.Templates;
using CapaModelo_SisB.Sentences;
using CapaModelo_SisB.Libraries;


namespace CapaControlador_SisB
{
    public class AccountControler
    {

        public Sentencias sn;
        public AccountControler()
        {
            this.sn = new Sentencias();
        }

        public List<Cuenta> getAccountsFromUser(int IdUser)
        {
            return this.sn.getUserAccounts(IdUser);
        }

        public void addFriendAccount(string accountNo, AccountTransactions account)
        {
            account.addFriendAccount(accountNo);
        }

        public static double getAccountInitialBalance(int accountId)
        {
            return HistorySentence.getAccountInitialBalance(accountId);
        }


    }
}





