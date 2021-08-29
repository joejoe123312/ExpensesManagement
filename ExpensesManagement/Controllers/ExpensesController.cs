using ExpensesManagement.Data;
using ExpensesManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Controllers
{
    [Authorize]
    public class ExpensesController : Controller
    {
        private readonly IAccounts _accountsRepo;
        private readonly IBalance _balanceRepo;
        private readonly IExpenses _expensesRepo;

        public ExpensesController(IAccounts accounts, IBalance balance, IExpenses expenses)
        {
            _accountsRepo = accounts;
            _balanceRepo = balance;
            _expensesRepo = expenses;
        }

        public IActionResult Index()
        {
            int accountId = 1;
            var expensesList = _expensesRepo.getListOfExpensesByAccountId(accountId);
            return View(expensesList);
        }

        public IActionResult Create()
        {
            int accountId = 1;
            ViewBag.accountId = accountId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            if (!ModelState.IsValid) return View(expense);

            // check if the user has sufficient balance
            int accountId = 1;
            Balance userbalanceObj = _balanceRepo.GetBalanceByAccountId(accountId);

            int currentBalance = userbalanceObj.Money;

            if (expense.Amount > currentBalance) return Ok("wala kang ganun na pera");

            // DEDUCT AMOUNT IN CURRENT BALANCE
            int deductionResult = currentBalance - expense.Amount;

            userbalanceObj.Money = deductionResult;
            _balanceRepo.UpdateBalance(userbalanceObj);

            // CRAETE NEW EXPENSE ROW;
            _expensesRepo.CreateExpense(expense);

            _expensesRepo.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int expenseId)
        {
            Expense expenseobj = _expensesRepo.GetExpenseById(expenseId);

            if (expenseobj == null) return RedirectToAction("Index");

            // Restore money balance of the account
            int accountId = 1;
            Balance balanceObj = _balanceRepo.GetBalanceByAccountId(accountId);

            balanceObj.Money += expenseobj.Amount;
            _balanceRepo.UpdateBalance(balanceObj);

            // Delete Expenses
            _expensesRepo.DeleteExpense(expenseobj);

            _expensesRepo.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult UpdateExpenses(int expenseId)
        {
            Expense expenseObj = _expensesRepo.GetExpenseById(expenseId);
            ViewBag.DbExpenseAmount = expenseObj.Amount;
            return View(expenseObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateExpensePost(Expense exp)
        {
            if (!ModelState.IsValid) return Ok(exp);

            // Subtract the old db expense amount to the current balance
            
            Balance balanceObj = _balanceRepo.GetBalanceByAccountId(exp.AccountId);

            int currentbalance = balanceObj.Money;
            if (TempData.ContainsKey("DbExpenseAmount"))
                currentbalance += (int)TempData["DbExpenseAmount"];

            currentbalance -= exp.Amount;
            balanceObj.Money = currentbalance;

            // update balance
            _balanceRepo.UpdateBalance(balanceObj);

            _expensesRepo.UpdateExpense(exp);

            _expensesRepo.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
