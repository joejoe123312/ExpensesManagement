using ExpensesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Data
{
    public interface IAccounts
    {
         public List<Account> GetAllAccounts();

        public Account GetAccountById(int id);

        public void CreateAccount(Account acc);

        public bool SaveChanges();

        public void UpdateAccount(Account acc);
        
        public void DeleteAccount(Account acc);

    }
}
