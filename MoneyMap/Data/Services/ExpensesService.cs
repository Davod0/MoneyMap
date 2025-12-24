using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Service
{
    public class ExpensesService : IExpensesService
    {
        private readonly FinanceAppContext _context;
        
        public ExpensesService(FinanceAppContext context)
        {
            _context = context;
        }

        public async Task Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return expenses;
        }

        public async Task<IEnumerable<Expense>> GetAllByUser(string userId)
        {
            var expenses = await _context.Expenses
                                         .Where(e => e.UserId == userId)
                                         .ToListAsync();
            return expenses;
        }

        public IQueryable GetChartData()
        {
            var data = _context.Expenses
                              .GroupBy(e => e.Category)
                              .Select(g => new
                              {
                                  Category = g.Key,
                                  Total = g.Sum(e => e.Amount)
                              });
            return data;
        }

        public IQueryable GetChartDataByUser(string userId)
        {
            var data = _context.Expenses
                              .Where(e => e.UserId == userId)
                              .GroupBy(e => e.Category)
                              .Select(g => new
                              {
                                  Category = g.Key,
                                  Total = g.Sum(e => e.Amount)
                              });
            return data;
        }
    }
}