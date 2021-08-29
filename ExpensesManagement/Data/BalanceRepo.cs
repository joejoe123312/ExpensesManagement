using ExpensesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Data
{
    public class BalanceRepo : IBalance
    {
        private readonly DatabaseContext _context;

        public BalanceRepo(DatabaseContext context)
        {
            _context = context;
        }

        public void DeductBalanceByAccountId(int Id)
        {
            throw new NotImplementedException();
        }

        public void DepositBalance(int Id, int amount)
        {
            Balance balanceObj = GetBalanceById(Id);

            balanceObj.Money += amount;

            UpdateBalance(balanceObj);
        }

        public List<Balance> GetAllBalance()
        {
            return _context.Balances.ToList();
        }

        public Balance GetBalanceByAccountId(int accountId)
        {
            return _context.Balances.FirstOrDefault(x => x.AccountId == accountId);
        }

        public Balance GetBalanceById(int Id)
        {
            return _context.Balances.FirstOrDefault(x => x.Id == Id);
        }

        public Balance GetBalanceWithAccount(int Id)
        {
            return _context.Balances.FirstOrDefault(x => x.AccountId == Id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateBalance(Balance bal)
        {
            _context.Balances.Update(bal);
        }

        public void WithdrawBalance(int Id, int amount)
        {
            Balance balanceObj = GetBalanceById(Id);

            balanceObj.Money -= amount;

            UpdateBalance(balanceObj);
        }
    }
}
