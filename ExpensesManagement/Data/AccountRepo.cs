using ExpensesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Data
{
    public class AccountRepo : IAccounts
    {
        private readonly DatabaseContext _context;

        public AccountRepo(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateAccount(Account acc)
        {
            _context.Accounts.Add(acc);
        }

        public void DeleteAccount(Account acc)
        {
            _context.Accounts.Remove(acc);
        }

        public Account GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateAccount(Account acc)
        {
            _context.Accounts.Update(acc);
        }

    }
}
