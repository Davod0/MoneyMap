using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinanceApp.Data
{
    public class FinanceAppContext : DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
    }
}