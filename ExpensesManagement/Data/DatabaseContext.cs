using ExpensesManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesManagement.Data
{
    public class DatabaseContext : DbContext
    //public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {

        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Credential> Credentials { get; set; }
    }
}
