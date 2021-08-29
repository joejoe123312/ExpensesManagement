using ExpensesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Data
{
    public interface IBalance
    {
        public List<Balance> GetAllBalance();

        public Balance GetBalanceById(int Id);

        public Balance GetBalanceWithAccount(int Id);

        public void UpdateBalance(Balance bal);

        public bool SaveChanges();

        public void DepositBalance(int Id, int amount);

        public void WithdrawBalance(int Id, int amount);

        public void DeductBalanceByAccountId(int Id);

        public Balance GetBalanceByAccountId(int accountId);
    }
}
