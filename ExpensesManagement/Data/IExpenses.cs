using ExpensesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Data
{
    public interface IExpenses
    {
        public List<Expense> GetAllExpenses();

        public Expense GetExpenseById(int id);

        public void CreateExpense(Expense expense);

        public bool SaveChanges();

        public void UpdateExpense(Expense expense);

        public void DeleteExpense(Expense expense);

        public List<Expense> getListOfExpensesByAccountId(int accountId);
    }
}
