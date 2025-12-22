using FinanceApp.Models;

namespace FinanceApp.Data.Service
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll();
        Task<IEnumerable<Expense>> GetAllByUser(string userId);
        Task Add(Expense expense);
        IQueryable GetChartData();
        IQueryable GetChartDataByUser(string userId);
    }
}