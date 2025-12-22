using FinanceApp.Data;
using Microsoft.AspNetCore.Mvc;


namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly FinanceAppContext _context;
        public ExpensesController(FinanceAppContext conext)
        {
            _context = conext;
        }

        public IActionResult index()
        {
            var expenses = _context.Expenses.ToList();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}