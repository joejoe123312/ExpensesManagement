using ExpensesManagement.Data;
using ExpensesManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBalance _balanceRepo;

        public HomeController(ILogger<HomeController> logger, IBalance balance)
        {
            _logger = logger;
            _balanceRepo = balance;
        }

        public IActionResult Index()
        {
            int balanceId = 1; // for the mean time
            Balance balanceObj = _balanceRepo.GetBalanceById(balanceId);
            return View(balanceObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(Balance bal)
        {
            if (!ModelState.IsValid) return View("Index", bal);
            
            int depositAmount = bal.Money;
            int balanceId = bal.Id;
            _balanceRepo.DepositBalance(balanceId, depositAmount);
            _balanceRepo.SaveChanges();

            return RedirectToAction("Index");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(Balance bal)
        {
            if (!ModelState.IsValid) return View("Index", bal);

            int depositAmount = bal.Money;
            int balanceId = bal.Id;
            _balanceRepo.WithdrawBalance(balanceId, depositAmount);
            _balanceRepo.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
