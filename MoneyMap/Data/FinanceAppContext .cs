using FinanceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data
{
    public class FinanceAppContext : IdentityDbContext<IdentityUser>
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
    }
}