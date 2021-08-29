using ExpensesManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Data
{
    public class ExpenseRepo : IExpenses
    {
        private readonly DatabaseContext _context;

        public ExpenseRepo(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
        }

        public void DeleteExpense(Expense expense)
        {
            _context.Expenses.Remove(expense);
        }

        public List<Expense> GetAllExpenses()
        {
            return _context.Expenses.ToList();
        }

        public Expense GetExpenseById(int id)
        {
            return _context.Expenses.FirstOrDefault(x => x.Id == id);
        }

        public List<Expense> getListOfExpensesByAccountId(int accountId)
        {
            return _context.Expenses.Where(x => x.AccountId == accountId).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateExpense(Expense expense)
        {
            _context.Expenses.Update(expense);
        }
    }
}
